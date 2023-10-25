using DatabaseTools_MSSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_School_Gradebook
{
	public partial class FormEducationalPlanReadactor : Form
	{
		public FormEducationalPlanReadactor()
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
			//dataGridViewTasks.AllowUserToAddRows = false;
			//dataGridViewTasks.AllowUserToDeleteRows = false;
		}

		private void FormEducationalPlanReadactor_Load(object sender, EventArgs e)
		{
			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);
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

			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);
			dBFormsTools.FillListBox(ref listBoxSubjects, "Subjects", "Name_Subject", $"join TeachToSubj on TeachToSubj.ID_Subject = Subjects.ID_Subject join Teachers on Teachers.ID_Teacher = TeachToSubj.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User}");

			dataGridViewTasks.Rows.Clear();
		}

		private void listBoxSubjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			//костыль блокировщик от ложного срабатывания активности из за заполнения первого listbox
			ListBox lb = (ListBox)sender;
			if (!lb.Focused)
			{
				return;
			}

			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);
			string[] selectFields = { "ID_Work", "Text_Work", "Name_Task", "Date_WorkFixation" };
			//сделать заполение из массива object и реализовать комбобоксовое изменение
			dBFormsTools.FillDGV(ref dataGridViewTasks, "TeacherPlan", selectFields, $"join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task where Users.LifeStatus = 1 and Users.ID_User = {FormAuthorization.ID_User} and TeachToClass.ID_Class = {listBoxClasses.SelectedValue}");

			dataGridViewTasks.Columns[0].Width = 70;
			dataGridViewTasks.Columns[3].ReadOnly = true;

			dataGridViewTasks.Columns[0].HeaderText = "Номер задачи";
			dataGridViewTasks.Columns[1].HeaderText = "Описание задачи";
			dataGridViewTasks.Columns[2].HeaderText = "Тип задачи";
			dataGridViewTasks.Columns[3].HeaderText = "Дата установки задачи";

			for (int i = 0; i < dataGridViewTasks.ColumnCount; i++)
			{
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
		}

		//если начали менять значение
		bool flagInsert = false;
		int selectRow = 0;
		int selectColumn = 0;
		private void dataGridViewTasks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			DateTime today = DateTime.Today;
			dataGridViewTasks.Rows[selectRow].Cells[3].Value = today.ToString("dd/MM/yyyy"); //сделать триггер на автоматическую установку сегодняшенего времени

			selectRow = dataGridViewTasks.SelectedCells[0].RowIndex;
			selectColumn = dataGridViewTasks.SelectedCells[0].ColumnIndex;

			string[] values = { dataGridViewTasks.Rows[selectRow].Cells[0].Value.ToString(), dataGridViewTasks.Rows[selectRow].Cells[1].Value.ToString(), dataGridViewTasks.Rows[selectRow].Cells[2].Value.ToString(), dataGridViewTasks.Rows[selectRow].Cells[3].Value.ToString() };
			//если было пусто
			if (values[0] == "" && values[1] == "" && values[2] == "" && values[3] == "")
			{
				flagInsert = true;

			}
			else //если уже было значение
			{
				flagInsert = false;
			}
		}

		//если ввели значение и вся сторока пуста то insert даже одного поля c пустыми остальными (data, idclass, idsubj, idtask вводятся в любом случае)
		//если ввели значение и было какое то значение то update
		private void dataGridViewTasks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);

			string ID_TeachToClass = dBTools.executeAnySqlScalar($"select ID_TeachToClass from TeachToClass join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.LifeStatus = 1 and Users.ID_User = {FormAuthorization.ID_User} and TeachToClass.ID_Class = {listBoxClasses.SelectedValue};").ToString();
			string ID_TeachToSubj = dBTools.executeAnySqlScalar($"select ID_TeachToClass from TeachToClass join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.LifeStatus = 1 and Users.ID_User = {FormAuthorization.ID_User} and TeachToClass.ID_Class = {listBoxClasses.SelectedValue};").ToString();

			string[] values = { dataGridViewTasks.Rows[selectRow].Cells[0].Value.ToString(), dataGridViewTasks.Rows[selectRow].Cells[1].Value.ToString(), dataGridViewTasks.Rows[selectRow].Cells[2].Value.ToString(), dataGridViewTasks.Rows[selectRow].Cells[3].Value.ToString(), dataGridViewTasks.Rows[selectRow].Cells[4].Value.ToString() };
			if (flagInsert)
			{
				dBTools.executeInsert("TeacherPlan", values);
			}
			else
			{
				dBTools.executeUpdate("TeacherPlan", values);
			}
		}
	}
}
