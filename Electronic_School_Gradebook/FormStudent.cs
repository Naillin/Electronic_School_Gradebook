using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
	public partial class FormStudent : Form
	{
		public FormStudent()
		{
			InitializeComponent();

			//настройка формы
			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			//границы размеров
			this.MaximumSize = new Size(10000, 10000);
			this.MinimumSize = new Size(1200, 500);

			//настройка dgvGradebook
			dataGridViewStudentGradebook.MultiSelect = false;
			dataGridViewStudentGradebook.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dataGridViewStudentGradebook.AllowUserToAddRows = false;
			dataGridViewStudentGradebook.AllowUserToDeleteRows = false;

			textBoxSearch.Enabled = false;
		}

		private void FormStudent_Load(object sender, EventArgs e)
		{
			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);
			dBFormsTools.FillListBox(ref listBoxSubjects, "Subjects", "Name_Subject", $"join TeachToSubj on TeachToSubj.ID_Subject = Subjects.ID_Subject join TeachToClass on TeachToClass.ID_Teacher = TeachToSubj.ID_Teacher join Students on Students.ID_Class = TeachToClass.ID_Class join Users on Users.ID_User = Students.ID_User where Users.ID_User = {FormAuthorization.ID_User.ToString()} and Users.LifeStatus = 1");

			//заполение labelStudent
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			string UserInfo = dBTools.executeAnySqlScalar($"select Surname_Student from Students join Users on Users.ID_User = Students.ID_User where Users.ID_User = {FormAuthorization.ID_User};").ToString() + " " + dBTools.executeAnySqlScalar($"select Name_Student from Students join Users on Users.ID_User = Students.ID_User where Users.ID_User = {FormAuthorization.ID_User};").ToString();
			labelStudent.Text = "Student: " + UserInfo;

			//заполнение notifyIconInfoUser
			notifyIconInfoUser.Text = "Active user: " + UserInfo;
			notifyIconInfoUser.BalloonTipText = "Welcome " + UserInfo + "!";
			notifyIconInfoUser.MouseClick += notifyIconInfoUser_MouseClick;
			notifyIconInfoUser.ShowBalloonTip(12);

			//заполнение toolStripStatus
			toolStripStatusLabelUser.Text = "Active user: " + UserInfo;
		}

		private void listBoxSubjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			//костыль блокировщик от ложного срабатывания активности из за заполнения первого listbox
			ListBox lb = (ListBox)sender;
			if (!lb.Focused)
			{
				return;
			}

			dataGridViewStudentGradebook.Rows.Clear();
			textBoxSearch.Enabled = true;

			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			object[,] dataGrades = dBTools.executeSelectTable($"select Gradebook.ID_Writing, Tasks.Name_Task, TeacherPlan.Text_Work, Gradebook.Mark from Gradebook join TeacherPlan on TeacherPlan.ID_Work = Gradebook.ID_Work join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task join TeachToSubj on TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass join Students on Students.ID_Class = TeachToClass.ID_Class join Users on Users.ID_User = Students.ID_User where TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue.ToString()} and Users.ID_User = {FormAuthorization.ID_User.ToString()};");

			for(int i = 0; i < dataGrades.GetLength(0); i++)
			{
				dataGridViewStudentGradebook.Rows.Add(dataGrades[i, 1], dataGrades[i, 2], dataGrades[i, 3]);

				//цвета
				if (i % 2 == 0)
				{
					dataGridViewStudentGradebook.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
				}
				else
				{
					dataGridViewStudentGradebook.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
				}
			}
		}

		//поиск
		private void textBoxSearch_TextChanged(object sender, EventArgs e)
		{
			dataGridViewStudentGradebook.Rows.Clear();

			if (textBoxSearch.Text != "")
			{
				DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
				object[,] dataGrades = dBTools.executeSelectTable($"select Gradebook.ID_Writing, Tasks.Name_Task, TeacherPlan.Text_Work, Gradebook.Mark from Gradebook join TeacherPlan on TeacherPlan.ID_Work = Gradebook.ID_Work join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task join TeachToSubj on TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass join Students on Students.ID_Class = TeachToClass.ID_Class join Users on Users.ID_User = Students.ID_User where TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue.ToString()} and Users.ID_User = {FormAuthorization.ID_User.ToString()} and TeacherPlan.Text_Work like '{textBoxSearch.Text}%'");

				for (int i = 0; i < dataGrades.GetLength(0); i++)
				{
					dataGridViewStudentGradebook.Rows.Add(dataGrades[i, 1], dataGrades[i, 2], dataGrades[i, 3]);

					//цвета
					if (i % 2 == 0)
					{
						dataGridViewStudentGradebook.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
					}
					else
					{
						dataGridViewStudentGradebook.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
					}
				}
			}
			else
			{
				dataGridViewStudentGradebook.Rows.Clear();

				DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
				object[,] dataGrades = dBTools.executeSelectTable($"select Gradebook.ID_Writing, Tasks.Name_Task, TeacherPlan.Text_Work, Gradebook.Mark from Gradebook join TeacherPlan on TeacherPlan.ID_Work = Gradebook.ID_Work join Tasks on Tasks.ID_Task = TeacherPlan.ID_Task join TeachToSubj on TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj join TeachToClass on TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass join Students on Students.ID_Class = TeachToClass.ID_Class join Users on Users.ID_User = Students.ID_User where TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue.ToString()} and Users.ID_User = {FormAuthorization.ID_User.ToString()};");

				for (int i = 0; i < dataGrades.GetLength(0); i++)
				{
					dataGridViewStudentGradebook.Rows.Add(dataGrades[i, 1], dataGrades[i, 2], dataGrades[i, 3]);

					//цвета
					if (i % 2 == 0)
					{
						dataGridViewStudentGradebook.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
					}
					else
					{
						dataGridViewStudentGradebook.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
					}
				}
			}
		}

		private void notifyIconInfoUser_MouseClick(object sender, MouseEventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
		}

		//перезапуск для открытия окна входа
		private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("Electronic_School_Gradebook.exe");
			Environment.Exit(0);
		}

		//exit
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		//exit
		private void FormStudent_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
