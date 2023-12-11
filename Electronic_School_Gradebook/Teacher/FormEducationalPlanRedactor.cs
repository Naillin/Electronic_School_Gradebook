using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//MS_Sql
using DatabaseTools_MSSQL;
//Excel
//using Excel1 = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
//Media
using System.Media;
using System.Globalization;

namespace Electronic_School_Gradebook
{
	public partial class FormEducationalPlanRedactor : Form
	{
		public FormEducationalPlanRedactor()
		{
			InitializeComponent();

			//настройка формы
			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			this.MaximumSize = new Size(this.Width, this.Height);
			this.MinimumSize = new Size(this.Width, this.Height);

			//настройка dgvTasks
			dataGridViewTasks.MultiSelect = false;
			dataGridViewTasks.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dataGridViewTasks.AllowUserToAddRows = false;
			dataGridViewTasks.AllowUserToDeleteRows = false;
			
			//buttons
			buttonAdd.Enabled = false;
			buttonDelete.Enabled = false;
		}

		private void FormEducationalPlanRedactor_Load(object sender, EventArgs e)
		{
			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.getConnection());
			dBFormsTools.FillListBox(ref listBoxClasses, "Classes", "Name_Class", $"join TeachToClass on TeachToClass.ID_Class = Classes.ID_Class join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User}");
		}

		private void listBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
		{
			//костыль блокировщик от ложного срабатывания активности из за заполнения первого listbox
			ListBox lb = (ListBox)sender;
			if (!lb.Focused)
			{
				return;
			}

			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.getConnection());
			dBFormsTools.FillListBox(ref listBoxSubjects, "Subjects", "Name_Subject", $"join TeachToSubj on TeachToSubj.ID_Subject = Subjects.ID_Subject join Teachers on Teachers.ID_Teacher = TeachToSubj.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User}");

			dataGridViewTasks.Rows.Clear();
			if (flagDeleteComboBoxColumn)
			{
				dataGridViewTasks.Columns.RemoveAt(2);
			}
			else
			{
				flagDeleteComboBoxColumn = true;
			}
			buttonAdd.Enabled = false;
			buttonDelete.Enabled = false;
			flagDeleteComboBoxColumn = false;
		}

		bool flagDeleteComboBoxColumn = false;
		private void FillDataGridViewTasks(object sender, EventArgs e)
		{
			//очистка
			dataGridViewTasks.Rows.Clear();
			if (flagDeleteComboBoxColumn)
			{
				dataGridViewTasks.Columns.RemoveAt(3);
			}
			else
			{
				flagDeleteComboBoxColumn = true;
			}

			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.getConnection());
			//string[] selectFields = { "ID_Work", "Text_Work", "Name_Task", "Date_WorkFixation" };
			//dBFormsTools.FillDGV(ref dataGridViewTasks, "TeacherPlan", selectFields, $"join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task where Users.LifeStatus = 1 and Users.ID_User = {FormAuthorization.ID_User} and TeachToClass.ID_Class = {listBoxClasses.SelectedValue}");

			//сделать заполение из массива object и реализовать комбобоксовое изменение
			DBTools dBTools = new DBTools(FormAuthorization.getConnection());
			object[,] dataTasks = dBTools.executeSelectTable($"select TeacherPlan.ID_Work, TeacherPlan.Text_Work, TeacherPlan.Date_WorkFixation, TeacherPlan.Date_WorkSubmission, TeacherPlan.ID_TeachToClass, TeacherPlan.ID_TeachToSubj, Tasks.ID_Task, Tasks.Name_Task from TeacherPlan join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass join TeachToSubj on TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User} and TeachToClass.ID_Class = {listBoxClasses.SelectedValue} and TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue};");
			for (int i = 0; i < dataTasks.GetLength(0); i++)
			{
				dataGridViewTasks.Rows.Add(dataTasks[i, 1].ToString(), dataTasks[i, 2].ToString(), dataTasks[i, 3].ToString());

				//цвета
				if (i % 2 == 0)
				{
					dataGridViewTasks.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
				}
				else
				{
					dataGridViewTasks.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
				}
			}

			DataGridViewComboBoxColumn comboBox = new DataGridViewComboBoxColumn();
			dBFormsTools.FillComboBox(ref comboBox, "Tasks", "Name_Task");
			dataGridViewTasks.Columns.Add(comboBox);
			dataGridViewTasks.Columns[3].HeaderText = "Type";
			for (int i = 0; i < dataTasks.GetLength(0); i++)
			{
				dataGridViewTasks.Rows[i].Cells[3].Value = (int)dataTasks[i, 6];
			}

			//настройка
			dataGridViewTasks.Columns[1].ReadOnly = true;
			buttonAdd.Enabled = true;
			buttonDelete.Enabled = true;
			if (dataGridViewTasks.RowCount <= 0)
			{
				buttonDelete.Enabled = false;
			}
		}

		private void listBoxSubjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			//костыль блокировщик от ложного срабатывания активности из за заполнения первого listbox
			ListBox lb = (ListBox)sender;
			if (!lb.Focused)
			{
				return;
			}

			FillDataGridViewTasks(sender, e);
		}

		//запоминание координат ячейки
		string oldRecord = string.Empty;
		int selectRow = 0;
		int selectColumn = 0;
		private void dataGridViewTasks_Click(object sender, EventArgs e)
		{
			oldRecord = dataGridViewTasks.SelectedCells[0].Value.ToString();

			selectRow = dataGridViewTasks.SelectedCells[0].RowIndex;
			selectColumn = dataGridViewTasks.SelectedCells[0].ColumnIndex;

			labelSelectedWork.Text = "Selected work: " + dataGridViewTasks.Rows[selectRow].Cells[0].Value.ToString();
		}
		private void dataGridViewTasks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			oldRecord = dataGridViewTasks.SelectedCells[0].Value.ToString();

			selectRow = dataGridViewTasks.SelectedCells[0].RowIndex;
			selectColumn = dataGridViewTasks.SelectedCells[0].ColumnIndex;

			labelSelectedWork.Text = "Selected work: " + dataGridViewTasks.Rows[selectRow].Cells[0].Value.ToString();
		}

		//изменить строчку
		private void dataGridViewTasks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DateTime today = DateTime.Today;
			string dateFormatBDFixation = today.ToString("yyyy-MM-dd HH:mm:ss");
			string dateFormatDGVFixation = today.ToString("dd/MM/yyyy H:mm:ss");
			dataGridViewTasks.Rows[selectRow].Cells[1].Value = dateFormatBDFixation;

			DBTools dBTools = new DBTools(FormAuthorization.getConnection());
			object[,] dataTasks = dBTools.executeSelectTable($"select TeacherPlan.ID_Work, TeacherPlan.Text_Work, TeacherPlan.Date_WorkFixation, TeacherPlan.Date_WorkSubmission, TeacherPlan.ID_TeachToClass, TeacherPlan.ID_TeachToSubj, Tasks.ID_Task, Tasks.Name_Task from TeacherPlan join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass join TeachToSubj on TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User} and TeachToClass.ID_Class = {listBoxClasses.SelectedValue} and TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue};");

			object ID_TeachToClass = dBTools.executeAnySqlScalar($"select TeachToClass.ID_TeachToClass from TeachToClass join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User} and TeachToClass.ID_Class = {listBoxClasses.SelectedValue};");
			object ID_TeachToSubj = dBTools.executeAnySqlScalar($"select TeachToSubj.ID_TeachToSubj from TeachToSubj join Teachers on Teachers.ID_Teacher = TeachToSubj.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User} and TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue};");

			string nameWork = (dataGridViewTasks.Rows[selectRow].Cells[0].Value == null ? "New Work" : dataGridViewTasks.Rows[selectRow].Cells[0].Value.ToString());
			string[] values = { "'" + nameWork + "'", "'" + dateFormatDGVFixation + "'", "'" + dataGridViewTasks.Rows[selectRow].Cells[2].Value.ToString() + "'", ID_TeachToClass.ToString(), ID_TeachToSubj.ToString(), dataGridViewTasks.Rows[selectRow].Cells[3].Value.ToString() };

			try
			{
				dBTools.executeUpdate("TeacherPlan", values, $"where ID_Work = {dataTasks[selectRow, 0].ToString()}");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Warning!");
				dataGridViewTasks.SelectedCells[0].Value = oldRecord;
			}

			labelSelectedWork.Text = "Selected work: " + dataGridViewTasks.Rows[selectRow].Cells[0].Value.ToString();
		}

		//добавить строку
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			DateTime today = DateTime.Today;
			string dateFormatBDFixation = today.ToString("yyyy-MM-dd HH:mm:ss");
			string dateFormatDGVFixation = today.ToString("dd/MM/yyyy H:mm:ss");
			string dateFormatDGVSubmission = today.AddDays(7).ToString("dd/MM/yyyy H:mm:ss");
			dataGridViewTasks.Rows.Add("New Work" + dataGridViewTasks.RowCount.ToString(), dateFormatDGVFixation, dateFormatDGVSubmission, 1);//сделать триггер на автоматическую установку сегодняшенего времени
			int lastRow = dataGridViewTasks.RowCount - 1;
			dataGridViewTasks.Rows[lastRow].DefaultCellStyle.BackColor = Color.Orange;

			DBTools dBTools = new DBTools(FormAuthorization.getConnection());
			object ID_TeachToClass = dBTools.executeAnySqlScalar($"select TeachToClass.ID_TeachToClass from TeachToClass join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User} and TeachToClass.ID_Class = {listBoxClasses.SelectedValue};");
			object ID_TeachToSubj = dBTools.executeAnySqlScalar($"select TeachToSubj.ID_TeachToSubj from TeachToSubj join Teachers on Teachers.ID_Teacher = TeachToSubj.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User} and TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue};");
			
			string[] values = { "'" + dataGridViewTasks.Rows[lastRow].Cells[0].Value.ToString() + "'", "'" + dateFormatBDFixation + "'", "'" + dateFormatDGVSubmission + "'", ID_TeachToClass.ToString(), ID_TeachToSubj.ToString(), dataGridViewTasks.Rows[lastRow].Cells[3].Value.ToString() };
			dBTools.executeInsert("TeacherPlan", values);

			//настройка
			if (dataGridViewTasks.RowCount > 0)
			{
				buttonDelete.Enabled = true;
			}

			labelSelectedWork.Text = "Selected work: " + dataGridViewTasks.Rows[selectRow].Cells[0].Value.ToString();
		}

		//удалить строчку
		private void buttonDelete_Click(object sender, EventArgs e) //невозможно удалить задачу, если с ней связанна оценка. решение - сделать триггер на удаление записи из gradebook
		{
			labelSelectedWork.Text = "Selected work: " + dataGridViewTasks.Rows[selectRow].Cells[0].Value.ToString();

			DialogResult dialogResult = MessageBox.Show("Deleting a record of a learning task will result in the deletion of grades corresponding to this task!", "Attention!", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				//удаолить из бд и перезагрущзить dgv
				DBTools dBTools = new DBTools(FormAuthorization.getConnection());
				object[,] dataTasks = dBTools.executeSelectTable($"select TeacherPlan.ID_Work, TeacherPlan.Text_Work, TeacherPlan.Date_WorkFixation, TeacherPlan.ID_TeachToClass, TeacherPlan.ID_TeachToSubj, Tasks.ID_Task, Tasks.Name_Task from TeacherPlan join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass join TeachToSubj on TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User} and TeachToClass.ID_Class = {listBoxClasses.SelectedValue} and TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue};");

				dBTools.executeDelete("TeacherPlan", $"where ID_Work = {dataTasks[selectRow, 0].ToString()}");

				FillDataGridViewTasks(sender, e);
			}
			else if (dialogResult == DialogResult.No)
			{
				//do something else
			}

			if (dataGridViewTasks.RowCount <= 0)
			{
				//настройка
				buttonDelete.Enabled = false;
			}
			else
			{
				//выбор после удаления
				dataGridViewTasks.Rows[0].Cells[0].Selected = true;
			}
		}
	}
}
