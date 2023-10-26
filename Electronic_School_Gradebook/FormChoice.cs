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
	public partial class FormChoice : Form
	{
		DataGridView dataGridViewGradebookReciver;
		FormGradebook formGradebookReciver;
		public FormChoice(ref DataGridView dataGridViewGradebook, ref FormGradebook formGradebook)
		{
			InitializeComponent();

			//настройка формы
			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			this.MaximumSize = new Size(this.Width, this.Height);
			this.MinimumSize = new Size(this.Width, this.Height);

			dataGridViewGradebookReciver = dataGridViewGradebook;
			formGradebookReciver = formGradebook;

			//настройка dgvTasks
			dataGridViewTasks.AllowUserToAddRows = false;
			dataGridViewTasks.AllowUserToDeleteRows = false;
			//настройка button
			buttonAccept.Enabled = false;
			flagClosing = true;
		}

		private void FormChoice_Load(object sender, EventArgs e)
		{
			//listBoxClasses.Items.Clear();

			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);
			dBFormsTools.FillListBox(ref listBoxClasses, "Classes", "Name_Class", $"join TeachToClass on TeachToClass.ID_Class = Classes.ID_Class join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User}");

			//если открыли повторно
			if (formGradebookReciver.rowConnects != null && formGradebookReciver.rowConnects.Length != 0)
			{
				DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
				int value = (int)dBTools.executeAnySqlScalar($"select Classes.ID_class from Classes join TeachToClass on TeachToClass.ID_Class = Classes.ID_Class join TeacherPlan on TeacherPlan.ID_TeachToClass = TeachToClass.ID_TeachToClass where TeacherPlan.ID_Work = {formGradebookReciver.rowConnects[0].id.ToString()} group by Classes.ID_class;");
				dBFormsTools.FillListBox(ref listBoxSubjects, "Subjects", "Name_Subject", $"join TeachToSubj on TeachToSubj.ID_Subject = Subjects.ID_Subject join Teachers on Teachers.ID_Teacher = TeachToSubj.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User}");
				listBoxClasses.SelectedValue = FormGradebook.ID_Class;
				listBoxSubjects.SelectedValue = FormGradebook.ID_Subject;

				buttonAccept.Enabled = true;
				flagClosing = false;
				dataGridViewTasks.Rows.Clear();

				//заполнение dgvTasks задачами
				dataTasks = dBTools.executeSelectTable($"SELECT ID_Work, Text_Work, Date_WorkFixation, Tasks.Name_Task FROM TeacherPlan join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass join TeachToSubj on TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj join Subjects on Subjects.ID_Subject = TeachToSubj.ID_Subject where TeachToClass.ID_Class = {listBoxClasses.SelectedValue} and Subjects.ID_Subject = {listBoxSubjects.SelectedValue};");
				for (int i = 0; i < dataTasks.GetLength(0); i++)
				{
					dataGridViewTasks.Rows.Add(false, dataTasks[i, 1].ToString(), dataTasks[i, 2].ToString(), dataTasks[i, 3].ToString());
					for (int j = 1; j < dataGridViewTasks.ColumnCount; j++)
					{
						dataGridViewTasks.Rows[i].Cells[j].ReadOnly = true;
					}

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

				//простановка галочек
				for(int i = 0; i < formGradebookReciver.rowConnects.Length; i++)
				{
					if ((formGradebookReciver.rowConnects[i].rowIndex_dgvTasks == i) && (formGradebookReciver.rowConnects[i].columnIndex_dgvGradebook != -1))
					{
						dataGridViewTasks.Rows[i].Cells[0].Value = true;
					}
				}
			}
		}

		object[,] dataTasks;
		//если выбрали класс
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

			FormGradebook.ID_Class = (int)listBoxClasses.SelectedValue;
			dataGridViewTasks.Rows.Clear();
			buttonAccept.Enabled = false;
		}
		//если выбрали предмет
		private void listBoxSubjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			//костыль блокировщик от ложного срабатывания активности из за заполнения первого listbox
			ListBox lb = (ListBox)sender;
			if (!lb.Focused)
			{
				return;
			}

			FormGradebook.ID_Subject = (int)listBoxSubjects.SelectedValue;

			dataGridViewTasks.Rows.Clear();
			buttonAccept.Enabled = true;
			flagClosing = false;

			//заполнение dgvTasks задачами
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			dataTasks = dBTools.executeSelectTable($"SELECT ID_Work, Text_Work, Date_WorkFixation, Tasks.Name_Task FROM TeacherPlan join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass join TeachToSubj on TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj join Subjects on Subjects.ID_Subject = TeachToSubj.ID_Subject where TeachToClass.ID_Class = {listBoxClasses.SelectedValue} and Subjects.ID_Subject = {listBoxSubjects.SelectedValue};");
			formGradebookReciver.rowConnects = new TaskRowConnect[dataTasks.GetLength(0)];
			for (int i = 0; i < dataTasks.GetLength(0); i++)
			{
				dataGridViewTasks.Rows.Add(false, dataTasks[i, 1].ToString(), dataTasks[i, 2].ToString(), dataTasks[i, 3].ToString());
				for (int j = 1; j < dataGridViewTasks.ColumnCount; j++)
				{
					dataGridViewTasks.Rows[i].Cells[j].ReadOnly = true;
				}

				formGradebookReciver.rowConnects[i].id = (int)dataTasks[i, 0]; formGradebookReciver.rowConnects[i].rowIndex_dgvTasks = i; formGradebookReciver.rowConnects[i].columnIndex_dgvGradebook = -1;

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

		//заполнение formGradebook
		bool flagClosing = true;
		private void buttonAccept_Click(object sender, EventArgs e)
		{
			//настройка dgvGradebook
			dataGridViewGradebookReciver.Rows.Clear();
			dataGridViewGradebookReciver.Columns.Clear();
			//dataGridViewGradebookReciver.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
			dataGridViewGradebookReciver.AllowUserToAddRows = false; dataGridViewGradebookReciver.AllowUserToDeleteRows = false;
			//DataGridViewTextBoxColumn columnNameStudents = new DataGridViewTextBoxColumn();
			//columnNameStudents.SortMode = DataGridViewColumnSortMode.NotSortable;
			//columnNameStudents.Name = "ColumnFIO";
			//columnNameStudents.HeaderText = "Name";
			//columnNameStudents.Width = 170;
			//columnNameStudents.ReadOnly = true;
			dataGridViewGradebookReciver.Columns.Add("ColumnFIO", "Name");
			dataGridViewGradebookReciver.Columns[0].Width = 50; //хз почему не робит здесь 

			//заполение dgvGradebook задачами
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			for (int i = 0; i < dataGridViewTasks.RowCount; i++)
			{
				bool ddd = (bool)dataGridViewTasks.Rows[i].Cells[0].Value;
				if ((bool)dataGridViewTasks.Rows[i].Cells[0].Value) //если галочка стоит 
				{
					string ColumnText = dataGridViewTasks.Rows[i].Cells[1].Value.ToString();

					//DataGridViewColumn columnTask = new DataGridViewColumn();
					//columnTask.Name = "Column" + ColumnText;
					//columnTask.HeaderText = ColumnText;

					dataGridViewGradebookReciver.Columns.Add("Column" + ColumnText, ColumnText);
					formGradebookReciver.rowConnects[i].columnIndex_dgvGradebook = i + 1;
				}
				else
				{
					formGradebookReciver.rowConnects[i].columnIndex_dgvGradebook = -1; //есть очень тяжело уловимый баг (выход за пределы массива). происходит когда что то поменяешь в плане и начнешь редачить отображение.
				}
			}
			
			//заполение dgvGradebook студентами
			object[,] dataStudents = dBTools.executeSelectTable($"SELECT ID_Student, Name_Student, Surname_Student FROM Students WHERE ID_Class = {listBoxClasses.SelectedValue};");
			formGradebookReciver.studentRowConnects = new StudentRowConnect[dataStudents.GetLength(0)]; //массив структуры связи строк и id
			for (int i = 0; i < dataStudents.GetLength(0); i++)
			{
				dataGridViewGradebookReciver.Rows.Add(dataStudents[i, 2] + " " + dataStudents[i, 1]);
				formGradebookReciver.studentRowConnects[i].id = (int)dataStudents[i, 0]; //запоминаем id из бд
				formGradebookReciver.studentRowConnects[i].rowIndex_dgvStudents = i; //запоминаем идендификатор строки

				//цвета
				if (i % 2 == 0)
				{
					dataGridViewGradebookReciver.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
				}
				else
				{
					dataGridViewGradebookReciver.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
				}
			}
			dataGridViewGradebookReciver.Columns[0].Width = 150;

			//заполение dgvGradebook оценками
			object[,] dataGradebook = dBTools.executeSelectTable($"select Gradebook.ID_Writing, Gradebook.Mark, Gradebook.ID_Student, TeacherPlan.ID_Work from Gradebook join TeacherPlan on TeacherPlan.ID_Work = Gradebook.ID_Work join TeachToSubj on TeachToSubj.ID_TeachToSubj = Gradebook.ID_TeachToSubj join Subjects on Subjects.ID_Subject = TeachToSubj.ID_Subject where Subjects.ID_Subject = {listBoxSubjects.SelectedValue};");
			for (int z = 0; z < dataGradebook.GetLength(0); z++)
			{
				int rowIndex = 0;
				for(int i = 0; i < formGradebookReciver.studentRowConnects.Length; i++)
				{
					if (formGradebookReciver.studentRowConnects[i].id == (int)dataGradebook[i, 2])
					{
						rowIndex = formGradebookReciver.studentRowConnects[i].rowIndex_dgvStudents;
						break;
					}
				}

				int columnIndex = 0;
				for (int i = 0; i < formGradebookReciver.rowConnects.Length; i++)
				{
					if ((formGradebookReciver.rowConnects[i].id == (int)dataGradebook[z, 3]) && (formGradebookReciver.rowConnects[i].columnIndex_dgvGradebook != -1))
					{
						columnIndex = formGradebookReciver.rowConnects[i].columnIndex_dgvGradebook;
						break;
					}
				}

				if(columnIndex > 0)
				{
					dataGridViewGradebookReciver.Rows[rowIndex].Cells[columnIndex].Value = dataGradebook[z, 1];
				}
			}

			this.Close();
		}

		//запрет на закртие формы
		private void FormChoice_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(flagClosing)
			{
				//Отменяем закрытие формы
				e.Cancel = true;
			}
		}

		//отключение кнопки закрытия
		private const int CP_NOCLOSE_BUTTON = 0x200;
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams myCp = base.CreateParams;
				myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
				return myCp;
			}
		}
	}
}
