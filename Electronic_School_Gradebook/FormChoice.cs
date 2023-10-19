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
		}

		private void FormChoice_Load(object sender, EventArgs e)
		{
			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);
			dBFormsTools.FillListBox(ref listBoxClasses, "Classes", "Name_Class", $"join TeachToClass on TeachToClass.ID_Class = Classes.ID_Class join Teachers on Teachers.ID_Teacher = TeachToClass.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User}");
		}

		//если выбрали класс
		private void listBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
		{
			//костыль блокировщик от ложного срабатывания активности из за заполнения первого listbox
			ListBox lb = (ListBox)sender;
			if (!lb.Focused)
			{
				return;
			}

			//заполнение dgvTasks задачами
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			object[,] data = dBTools.executeSelectTable($"SELECT ID_Work, Text_Work, Date_WorkFixation, Tasks.Name_Task FROM TeacherPlan join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass where TeachToClass.ID_Class = {listBoxClasses.SelectedValue};");
			for(int i = 0; i < data.GetLength(0); i++)
			{
				dataGridViewTasks.Rows.Add(false, data[i, 1].ToString(), data[i, 2].ToString(), data[i, 3].ToString());
				for(int j = 1; j < dataGridViewTasks.ColumnCount; j++)
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
		}

		//заполнение dgvGradebook
		private void buttonAccept_Click(object sender, EventArgs e)
		{

		}
	}
}
