using DatabaseTools_MSSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_School_Gradebook
{
	//структура для хранения связи строк dgv с элементами бд
	public struct TaskRowConnect
	{
		public int id;
		public int rowIndex_dgvTasks;
		public int columnIndex_dgvGradebook;
	}

	public partial class FormChoice : Form
	{
		DataGridView dataGridViewGradebookReciver;
		public FormChoice(ref DataGridView dataGridViewGradebook)
		{
			InitializeComponent();

			//настройка формы
			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			this.MaximumSize = new Size(this.Width, this.Height);
			this.MinimumSize = new Size(this.Width, this.Height);

			dataGridViewGradebookReciver = dataGridViewGradebook;

			//настройка dgvTasks
			dataGridViewTasks.AllowUserToAddRows = false;
			dataGridViewTasks.AllowUserToDeleteRows = false;
		}

		private void FormChoice_Load(object sender, EventArgs e)
		{
			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);
			dBFormsTools.FillListBox(ref listBoxClasses, "Classes", "Name_Class", $"join TeachToClass on TeachToClass.ID_Class = Classes.ID_Class join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User}");
		}

		public TaskRowConnect[] rowConnects;
		object[,] dataTasks;
		//если выбрали класс
		private void listBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
		{
			dataGridViewTasks.Rows.Clear();

			//костыль блокировщик от ложного срабатывания активности из за заполнения первого listbox
			ListBox lb = (ListBox)sender;
			if (!lb.Focused)
			{
				return;
			}

			//заполнение dgvTasks задачами
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			dataTasks = dBTools.executeSelectTable($"SELECT ID_Work, Text_Work, Date_WorkFixation, Tasks.Name_Task FROM TeacherPlan join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass where TeachToClass.ID_Class = {listBoxClasses.SelectedValue};");
			rowConnects = new TaskRowConnect[dataTasks.GetLength(0)];
			for (int i = 0; i < dataTasks.GetLength(0); i++)
			{
				dataGridViewTasks.Rows.Add(false, dataTasks[i, 1].ToString(), dataTasks[i, 2].ToString(), dataTasks[i, 3].ToString());
				for(int j = 1; j < dataGridViewTasks.ColumnCount; j++)
				{
					dataGridViewTasks.Rows[i].Cells[j].ReadOnly = true;
				}

				rowConnects[i].id = (int)dataTasks[i, 0]; rowConnects[i].rowIndex_dgvTasks = i;

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

		//заполнение dgvGradebook
		private void buttonAccept_Click(object sender, EventArgs e)
		{
			//настройка dgvGradebook
			//dataGridViewGradebookReciver.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
			dataGridViewGradebookReciver.AllowUserToAddRows = false; dataGridViewGradebookReciver.AllowUserToDeleteRows = false;
			//DataGridViewTextBoxColumn columnNameStudents = new DataGridViewTextBoxColumn();
			//columnNameStudents.SortMode = DataGridViewColumnSortMode.NotSortable;
			//columnNameStudents.Name = "ColumnFIO";
			//columnNameStudents.HeaderText = "Name";
			//columnNameStudents.Width = 170;
			//columnNameStudents.ReadOnly = true;
			dataGridViewGradebookReciver.Columns.Add("ColumnFIO", "Name");

			//заполение dgvGradebook задачами
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			for (int i = 0; i < dataGridViewTasks.RowCount; i++)
			{
				if ((bool)dataGridViewTasks.Rows[i].Cells[0].Value) //если галочка стоит 
				{
					string ColumnText = dataGridViewTasks.Rows[i].Cells[1].Value.ToString();

					//DataGridViewColumn columnTask = new DataGridViewColumn();
					//columnTask.Name = "Column" + ColumnText;
					//columnTask.HeaderText = ColumnText;

					dataGridViewGradebookReciver.Columns.Add("Column" + ColumnText, ColumnText);
					rowConnects[i].columnIndex_dgvGradebook = i;
				}
			}
			
			//заполение dgvGradebook студентами
			object[,] dataStudents = dBTools.executeSelectTable($"SELECT ID_Student, Name_Student, Surname_Student FROM Students WHERE ID_Class = {listBoxClasses.SelectedValue};");
			FormGradebook formGradebook = new FormGradebook();
			formGradebook.studentRowConnects = new StudentRowConnect[dataStudents.GetLength(0)]; //массив структуры связи строк и id
			for (int i = 0; i < dataStudents.GetLength(0); i++)
			{
				dataGridViewGradebookReciver.Rows.Add(dataStudents[i, 2] + " " + dataStudents[i, 1]);
				formGradebook.studentRowConnects[i].id = (int)dataStudents[i, 0]; //запоминаем id из бд
				formGradebook.studentRowConnects[i].rowIndex_dgvStudents = i; //запоминаем идендификатор строки
			}

			this.Close();
		}
	}
}
