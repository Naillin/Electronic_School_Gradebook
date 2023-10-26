﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
//MS_Sql
using DatabaseTools_MSSQL;
//Excel
//using Excel1 = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
//Media
using System.Media;

namespace Electronic_School_Gradebook
{
	//структура для хранения связи строк dgvTasks с элементами бд
	public struct TaskRowConnect
	{
		public int id;
		public int rowIndex_dgvTasks;
		public int columnIndex_dgvGradebook;
	}

	//структура для хранения связи строк dgv с элементами бд
	public struct StudentRowConnect
	{
		public int id;
		public int rowIndex_dgvStudents;
	}

	public partial class FormGradebook : Form
	{
		public FormGradebook()
		{
			InitializeComponent();

			//настройка формы
			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			//границы размеров
			this.MaximumSize = new Size(10000, 10000);
			this.MinimumSize = new Size(1200, 500);

			//настройка dgvGradebook
			dataGridViewGradebook.MultiSelect = false;
			dataGridViewGradebook.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dataGridViewGradebook.AllowUserToAddRows = false;
			dataGridViewGradebook.AllowUserToDeleteRows = false;
		}

		public TaskRowConnect[] rowConnects;
		public StudentRowConnect[] studentRowConnects;
		static public int ID_Class;
		static public int ID_Subject;

		//авто размер
		private void FormGradebook_SizeChanged(object sender, EventArgs e)
		{
			int W = this.Width - 40;
			int H = this.Height - 125;
			dataGridViewGradebook.Size = new Size(W, H);
		}

		FormGradebook formGradebook;
		private void FormGradebook_Load(object sender, EventArgs e)
		{
			//запуск формы выбора класс и работы
			formGradebook = new FormGradebook();
			FormChoice formChoice = new FormChoice(ref dataGridViewGradebook, ref formGradebook); //передача ссылки на объект dgv
			formChoice.ShowDialog();

			//заполнение labelClass
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			labelClass.Text = "Selected class: " + dBTools.executeAnySqlScalar($"select Name_Class from Classes where ID_Class = {ID_Class}");
			labelSubject.Text = "Selected subject: " + dBTools.executeAnySqlScalar($"select Name_Subject from Subjects where ID_Subject = {ID_Class}");
		}

		//запоминание координат ячейки
		int selectRow = 0;
		int selectColumn = 0;
		bool flagInsert = false;
		string oldRecord = string.Empty;
		private void dataGridViewGradebook_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			selectRow = dataGridViewGradebook.SelectedCells[0].RowIndex;
			selectColumn = dataGridViewGradebook.SelectedCells[0].ColumnIndex;
			oldRecord = dataGridViewGradebook.Rows[selectRow].Cells[selectColumn].Value.ToString();

			if (oldRecord == "")
			{
				flagInsert = true;
			}
			else
			{
				flagInsert = false;
			}
		}

		private void dataGridViewGradebook_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);

			//insert
			if (flagInsert)
			{
				DateTime today = DateTime.Today;
				string dateFormatBD = today.ToString("yyyy-MM-dd HH:mm:ss");

				object ID_TeachToSubj = dBTools.executeAnySqlScalar($"select TeachToSubj.ID_TeachToSubj from TeachToSubj join Teachers on Teachers.ID_Teacher = TeachToSubj.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User} and TeachToSubj.ID_Subject = {FormGradebook.ID_Subject};");

				string[] values = { dateFormatBD, dataGridViewGradebook.Rows[selectRow].Cells[selectColumn].Value.ToString(), studentRowConnects[selectRow].id.ToString(), ID_TeachToSubj.ToString() };

				dBTools.executeInsert("Gradebook", values);
			}
			else
			{
				string newRecord = dataGridViewGradebook.Rows[selectRow].Cells[selectColumn].Value.ToString();
				//delete
				if (newRecord == "")
				{

				}
				else //update
				{

				}
			}
		}

		//форма настройка плана
		private void plansToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("This leads to clearing the fields of the gradebook!", "Attention!", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				dataGridViewGradebook.Columns.Clear();

				FormEducationalPlanReadactor formEducationalPlanReadactor = new FormEducationalPlanReadactor();
				formEducationalPlanReadactor.ShowDialog();
			}
			else if (dialogResult == DialogResult.No)
			{
				//do something else
			}
		}

		//открытие формы задачек
		private void changeTasksToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//запуск формы выбора класс и работы
			FormChoice formChoice = new FormChoice(ref dataGridViewGradebook, ref formGradebook); //передача ссылки на объект dgv
			formChoice.ShowDialog();
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
		private void FormGradebook_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
