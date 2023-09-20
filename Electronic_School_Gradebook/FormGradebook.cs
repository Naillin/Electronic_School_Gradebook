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
using Excel1 = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
//Media
using System.Media;

namespace Electronic_School_Gradebook
{
	public partial class FormGradebook : Form
	{
		public FormGradebook()
		{
			InitializeComponent();

			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			//границы размеров
			this.MaximumSize = new Size(10000, 10000);
			this.MinimumSize = new Size(1200, 500);
		}

		//авто размер
		private void FormGradebook_SizeChanged(object sender, EventArgs e)
		{
			int W = this.Width - 40;
			int H = this.Height - 125;
			dataGridViewGradebook.Size = new Size(W, H);
		}

		//перезапуск для открытия окна входа
		private void FormGradebook_FormClosing(object sender, FormClosingEventArgs e)
		{
			Process.Start("Electronic_School_Gradebook.exe");
			Environment.Exit(0);
		}

		private void FormGradebook_Load(object sender, EventArgs e)
		{
			//заполнение dgv отностильно вошедшего учителя
		}
	}
}
