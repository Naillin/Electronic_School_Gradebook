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
		}

		public TaskRowConnect[] rowConnects;
		public StudentRowConnect[] studentRowConnects;

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
			FormChoice formChoice = new FormChoice(ref dataGridViewGradebook, ref labelClass, ref formGradebook); //передача ссылки на объект dgv
			formChoice.ShowDialog();

			//хз лол

		}

		//форма настройка плана
		private void plansToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		//открытие формы задачек
		private void changeTasksToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//запуск формы выбора класс и работы
			FormChoice formChoice = new FormChoice(ref dataGridViewGradebook, ref labelClass, ref formGradebook); //передача ссылки на объект dgv
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
