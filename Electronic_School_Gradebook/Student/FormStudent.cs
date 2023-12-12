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

		private void FormStudent_SizeChanged(object sender, EventArgs e)
		{
			int Wdgv = this.Width - 295;
			int Hdgv = this.Height - 170;
			int Hlb = this.Height - 93;

			dataGridViewStudentGradebook.Size = new Size(Wdgv, Hdgv);
			textBoxSearch.Size = new Size(Wdgv, textBoxSearch.Height);
			listBoxSubjects.Size = new Size(listBoxSubjects.Width, Hlb);
		}

		private void FormStudent_Load(object sender, EventArgs e)
		{
			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.getConnection());
			dBFormsTools.FillListBox(ref listBoxSubjects, "Subjects", "Name_Subject", $"join TeachToSubj on TeachToSubj.ID_Subject = Subjects.ID_Subject join TeachToClass on TeachToClass.ID_Teacher = TeachToSubj.ID_Teacher join Students on Students.ID_Class = TeachToClass.ID_Class join Users on Users.ID_User = Students.ID_User where Users.ID_User = {FormAuthorization.getID_User().ToString()} and Users.LifeStatus = 1");

			//заполение labelStudent
			DBTools dBTools = new DBTools(FormAuthorization.getConnection());
			string UserInfo = dBTools.executeAnySqlScalar($"select Surname_Student from Students join Users on Users.ID_User = Students.ID_User where Users.ID_User = {FormAuthorization.getID_User()};").ToString() + " " + dBTools.executeAnySqlScalar($"select Name_Student from Students join Users on Users.ID_User = Students.ID_User where Users.ID_User = {FormAuthorization.getID_User()};").ToString();
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

			DBTools dBTools = new DBTools(FormAuthorization.getConnection());
			object[,] dataGrades = dBTools.executeSelectTable($"SELECT TeacherPlan.ID_Work, Tasks.Name_Task, TeacherPlan.Text_Work, TeacherPlan.Date_WorkSubmission, Gradebook.Mark, Students.Surname_Student FROM TeacherPlan JOIN Tasks ON Tasks.ID_Task = TeacherPlan.ID_Task JOIN TeachToSubj ON TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj JOIN TeachToClass ON TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass JOIN Students ON Students.ID_Class = TeachToClass.ID_Class JOIN Users ON Users.ID_User = Students.ID_User LEFT JOIN Gradebook ON Gradebook.ID_Work = TeacherPlan.ID_Work and Gradebook.ID_Student = Students.ID_Student WHERE TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue.ToString()} AND Users.ID_User = {FormAuthorization.getID_User().ToString()};");

			for (int i = 0; i < dataGrades.GetLength(0); i++)
			{
				dataGridViewStudentGradebook.Rows.Add(dataGrades[i, 1], dataGrades[i, 2], dataGrades[i, 3], dataGrades[i, 4]);

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

			//получение среднего балла
			string iD_Student = dBTools.executeAnySqlScalar($"select ID_Student from Students where ID_User = {FormAuthorization.getID_User()}").ToString();
			object average = dBTools.executeAnySqlScalar($"select dbo.CalculatingAverageScore({listBoxSubjects.SelectedValue.ToString()}, {iD_Student})");
			if (average != null && !System.DBNull.Value.Equals(average)) toolStripStatusLabelAVG.Text = "Subject average is " + Math.Round(Convert.ToDouble(average), 2).ToString();
			else toolStripStatusLabelAVG.Text = "";
		}

		//поиск
		private void textBoxSearch_TextChanged(object sender, EventArgs e)
		{
			dataGridViewStudentGradebook.Rows.Clear();

			if (textBoxSearch.Text != "")
			{
				DBTools dBTools = new DBTools(FormAuthorization.getConnection());
				object[,] dataGrades = dBTools.executeSelectTable($"SELECT TeacherPlan.ID_Work, Tasks.Name_Task, TeacherPlan.Text_Work, TeacherPlan.Date_WorkSubmission, Gradebook.Mark, Students.Surname_Student FROM TeacherPlan JOIN Tasks ON Tasks.ID_Task = TeacherPlan.ID_Task JOIN TeachToSubj ON TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj JOIN TeachToClass ON TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass JOIN Students ON Students.ID_Class = TeachToClass.ID_Class JOIN Users ON Users.ID_User = Students.ID_User LEFT JOIN Gradebook ON Gradebook.ID_Work = TeacherPlan.ID_Work and Gradebook.ID_Student = Students.ID_Student WHERE TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue.ToString()} AND Users.ID_User = {FormAuthorization.getID_User()} and TeacherPlan.Text_Work like '{textBoxSearch.Text}%'");

				for (int i = 0; i < dataGrades.GetLength(0); i++)
				{
					dataGridViewStudentGradebook.Rows.Add(dataGrades[i, 1], dataGrades[i, 2], dataGrades[i, 3], dataGrades[i, 4]);

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

				DBTools dBTools = new DBTools(FormAuthorization.getConnection());
				object[,] dataGrades = dBTools.executeSelectTable($"SELECT TeacherPlan.ID_Work, Tasks.Name_Task, TeacherPlan.Text_Work, TeacherPlan.Date_WorkSubmission, Gradebook.Mark, Students.Surname_Student FROM TeacherPlan JOIN Tasks ON Tasks.ID_Task = TeacherPlan.ID_Task JOIN TeachToSubj ON TeachToSubj.ID_TeachToSubj = TeacherPlan.ID_TeachToSubj JOIN TeachToClass ON TeachToClass.ID_TeachToClass = TeacherPlan.ID_TeachToClass JOIN Students ON Students.ID_Class = TeachToClass.ID_Class JOIN Users ON Users.ID_User = Students.ID_User LEFT JOIN Gradebook ON Gradebook.ID_Work = TeacherPlan.ID_Work and Gradebook.ID_Student = Students.ID_Student WHERE TeachToSubj.ID_Subject = {listBoxSubjects.SelectedValue.ToString()} AND Users.ID_User = {FormAuthorization.getID_User().ToString()};");

				for (int i = 0; i < dataGrades.GetLength(0); i++)
				{
					dataGridViewStudentGradebook.Rows.Add(dataGrades[i, 1], dataGrades[i, 2], dataGrades[i, 3], dataGrades[i, 4]);

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
