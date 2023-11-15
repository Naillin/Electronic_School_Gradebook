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

		static public TaskRowConnect[] rowConnects;
		static public StudentRowConnect[] studentRowConnects;
		static public int ID_Class;
		static public int ID_Subject;

		//авто размер
		private void FormGradebook_SizeChanged(object sender, EventArgs e)
		{
			int W = this.Width - 40;
			int H = this.Height - 170;
			dataGridViewGradebook.Size = new Size(W, H);
		}

		FormGradebook formGradebook;
		private void FormGradebook_Load(object sender, EventArgs e)
		{
			//запуск формы выбора класс и работы
			formGradebook = new FormGradebook();
			FormChoice formChoice = new FormChoice(ref dataGridViewGradebook, ref formGradebook); //передача ссылки на объект dgv
			formChoice.ShowDialog();

			//заполнение labelClass и labelSubject
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			labelClass.Text = "Selected class: " + dBTools.executeAnySqlScalar($"select Name_Class from Classes where ID_Class = {ID_Class}");
			labelSubject.Text = "Selected subject: " + dBTools.executeAnySqlScalar($"select Name_Subject from Subjects where ID_Subject = {ID_Subject}");

			//заполнение notifyIconInfoUser
			string UserInfo = dBTools.executeAnySqlScalar($"select Surname_Teacher from Teachers join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User};").ToString() + " " + dBTools.executeAnySqlScalar($"select Name_Teacher from Teachers join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User};").ToString();
			notifyIconInfoUser.Text = "Active user: " + UserInfo;
			notifyIconInfoUser.BalloonTipText = "Welcome " + UserInfo + "!";
			notifyIconInfoUser.MouseClick += notifyIconInfoUser_MouseClick;
			notifyIconInfoUser.ShowBalloonTip(12);

			//заполнение toolStripStatus
			toolStripStatusLabelUser.Text = "Active user: " + UserInfo;
			toolStripStatusLabelCountStudens.Text = "Count students: " + studentRowConnects.Length.ToString() + " | Select student: " + dataGridViewGradebook.Rows[0].Cells[0].Value.ToString();
			toolStripStatusLabelCountTasks.Text = "Count tasks: " + rowConnects.Length.ToString();

			//заполнение цветами ячеек
			CellsColors = new Color[dataGridViewGradebook.RowCount, dataGridViewGradebook.ColumnCount];
			for (int i = 0; i < CellsColors.GetLength(0); i++)
			{
				for (int j = 0; j < CellsColors.GetLength(1); j++)
				{
					CellsColors[i, j] = dataGridViewGradebook.Rows[i].Cells[j].Style.BackColor;
				}
			}
		}

		//запоминание координат ячейки
		int selectRow = 0;
		int selectColumn = 0;
		bool flagInsert = false;
		object oldRecord = null;
		private void dataGridViewGradebook_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			selectRow = dataGridViewGradebook.SelectedCells[0].RowIndex;
			selectColumn = dataGridViewGradebook.SelectedCells[0].ColumnIndex;
			oldRecord = dataGridViewGradebook.Rows[selectRow].Cells[selectColumn].Value;

			if (oldRecord == null)
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
			DateTime today = DateTime.Today;
			//string dateFormatBD = today.ToString("yyyy-MM-dd HH:mm:ss");
			string dateFormatBD = today.ToString("yyyy-MM-dd");

			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			object ID_TeachToSubj = dBTools.executeAnySqlScalar($"select TeachToSubj.ID_TeachToSubj from TeachToSubj join Teachers on Teachers.ID_Teacher = TeachToSubj.ID_Teacher join Users on Users.ID_User = Teachers.ID_User where Users.ID_User = {FormAuthorization.ID_User} and TeachToSubj.ID_Subject = {FormGradebook.ID_Subject};");

			int ID_Work = -1;
			for (int i = 0; i < rowConnects.Length; i++)
			{
				if (rowConnects[i].columnIndex_dgvGradebook == selectColumn)
				{
					ID_Work = rowConnects[i].id;
					break;
				}
			}

			//insert
			if (flagInsert)
			{
				if (dataGridViewGradebook.Rows[selectRow].Cells[selectColumn].Value != null)
				{
                    string[] values = { dateFormatBD, dataGridViewGradebook.Rows[selectRow].Cells[selectColumn].Value.ToString(), studentRowConnects[selectRow].id.ToString(), ID_TeachToSubj.ToString(), ID_Work.ToString() };
                    dBTools.executeInsert("Gradebook", values);
                }
			}
			else
			{
				object newRecord = dataGridViewGradebook.Rows[selectRow].Cells[selectColumn].Value;
				//delete
				if (newRecord == null)
				{
					dBTools.executeDelete("Gradebook", $"where ID_Student = {studentRowConnects[selectRow].id.ToString()} and ID_TeachToSubj = {ID_TeachToSubj.ToString()} and ID_Work = {ID_Work.ToString()}");
				}
				else //update
				{
					string[] values = { dateFormatBD, newRecord.ToString(), studentRowConnects[selectRow].id.ToString(), ID_TeachToSubj.ToString(), ID_Work.ToString() };
					dBTools.executeUpdate("Gradebook", values, $"where ID_Student = {studentRowConnects[selectRow].id.ToString()} and ID_TeachToSubj = {ID_TeachToSubj.ToString()} and ID_Work = {ID_Work.ToString()}");
				}
			}

			realTimeWriting = string.Empty;
		}

		private void dataGridViewGradebook_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (e.Control is TextBox textBox)
			{
				textBox.KeyPress -= dataGridViewGradebook_KeyPress;
				textBox.KeyPress += dataGridViewGradebook_KeyPress;
			}
		}

		//запрет на ввод всего кроме цифр оценки
		string realTimeWriting = string.Empty;
		private void dataGridViewGradebook_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Проверка, является ли введенный символ цифрой
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') // Добавлено условие для разрешения символа backspace ('\b')
			{
				e.Handled = true; // Отмена ввода символа
				return;
			}

			realTimeWriting = realTimeWriting + e.KeyChar.ToString();

			// Если символ backspace, разрешить удаление значения
			if (e.KeyChar == '\b')
			{
				realTimeWriting = realTimeWriting.TrimEnd('\b');
				if (realTimeWriting != "") realTimeWriting = realTimeWriting.Remove(realTimeWriting.Length - 1);

				return;
			}

			// Преобразование введенного символа в число
			int number = int.Parse(e.KeyChar.ToString());

			// Проверка диапазона значений и однозначности числа
			if ((number < 2 || number > 5) || (realTimeWriting.Length > 1))
			{
				e.Handled = true; // Отмена ввода символа
				if (realTimeWriting != "") realTimeWriting = realTimeWriting.Remove(realTimeWriting.Length - 1);
			}
		}

		//переключение цветов в dgv
		Color[,] CellsColors = null; 
		private void checkBoxColorMark_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxColorMark.Checked)
			{
				for (int i = 0; i < CellsColors.GetLength(0); i++)
				{
					for (int j = 0; j < CellsColors.GetLength(1); j++)
					{
						switch(dataGridViewGradebook.Rows[i].Cells[j].Value)
						{
							case 2:
								dataGridViewGradebook.Rows[i].Cells[j].Style.BackColor = Color.Red;
								break;
							case 3:
								dataGridViewGradebook.Rows[i].Cells[j].Style.BackColor = Color.Orange;
								break;
							case 4:
								dataGridViewGradebook.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
								break;
							case 5:
								dataGridViewGradebook.Rows[i].Cells[j].Style.BackColor = Color.LimeGreen;
								break;
							default:
								dataGridViewGradebook.Rows[i].Cells[j].Style.BackColor = Color.White;
								break;
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < CellsColors.GetLength(0); i++)
				{
					for (int j = 0; j < CellsColors.GetLength(1); j++)
					{
						dataGridViewGradebook.Rows[i].Cells[j].Style.BackColor = CellsColors[i, j];
					}
				}
			}
		}

		//форма настройка плана
		private void plansToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SoundPlayer sndWhu = new SoundPlayer((Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 41, 41) + @"\Res\sound\Whu.wav"));
			sndWhu.Play();

			DialogResult dialogResult = MessageBox.Show("This leads to clearing the fields of the gradebook!", "Attention!", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				dataGridViewGradebook.Columns.Clear();
				rowConnects = null;
				studentRowConnects = null;

				FormEducationalPlanRedactor formEducationalPlanReadactor = new FormEducationalPlanRedactor();
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

			//заполнение toolStripStatus
			toolStripStatusLabelCountStudens.Text = "Count students: " + studentRowConnects.Length.ToString() + " | Select student: " + dataGridViewGradebook.Rows[0].Cells[0].Value.ToString();
			toolStripStatusLabelCountTasks.Text = "Количество задач:" + rowConnects.Length.ToString();
		}

		//заполнение toolStripStatusLabelCountStudens
		private void dataGridViewGradebook_MouseClick(object sender, MouseEventArgs e)
		{
			//заполнение toolStripStatusLabelCountStudens
			if(dataGridViewGradebook.RowCount > 0)
			{
				toolStripStatusLabelCountStudens.Text = "Count students: " + studentRowConnects.Length.ToString() + " | Select student: " + dataGridViewGradebook.Rows[selectRow].Cells[0].Value.ToString();
			}
			else
			{
				toolStripStatusLabelCountStudens.Text = "Count students: " + studentRowConnects.Length.ToString() + " | Select student: None";
			}
		}

		//клик по тултипу в туллах
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
		private void FormGradebook_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
