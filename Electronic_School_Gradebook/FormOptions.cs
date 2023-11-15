using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Data.SqlClient;

namespace Electronic_School_Gradebook
{
	public partial class FormOptions : Form
	{
		public FormOptions()
		{
			InitializeComponent();

			//настройка формы
			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			this.MaximumSize = new Size(this.Width, this.Height);
			this.MinimumSize = new Size(this.Width, this.Height);
		}

		//заполнение textBoxs
		private void FormOptions_Load(object sender, EventArgs e)
		{
			string path = Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 32, 32) + @"\config.txt";

			//Open the file to read from.
			string[] DB_Info = File.ReadAllLines(path);
			DB_Info[0] = DB_Info[0].Remove(0, 12);
			DB_Info[0] = DB_Info[0].Remove(DB_Info[0].Length - 1, 1);
			DB_Info[1] = DB_Info[1].Remove(0, 16);
			DB_Info[1] = DB_Info[1].Remove(DB_Info[1].Length - 1, 1);
			DB_Info[2] = DB_Info[2].Remove(0, 8);
			DB_Info[2] = DB_Info[2].Remove(DB_Info[2].Length - 1, 1);
			DB_Info[3] = DB_Info[3].Remove(0, 9);
			DB_Info[3] = DB_Info[3].Remove(DB_Info[3].Length - 1, 1);

			textBoxDataSource.Text = DB_Info[0];
			textBoxInitialCatalog.Text = DB_Info[1];
			textBoxUserId.Text = DB_Info[2];
			textBoxPassword.Text = DB_Info[3];
		}

		private void buttonApply_Click(object sender, EventArgs e)
		{
			// Create a file to write to.
			string path = Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 32, 32) + @"\config.txt";
			string[] DB_InfoInput = { $"Data Source={textBoxDataSource.Text};", $"Initial Catalog={textBoxInitialCatalog.Text};", $"User Id={textBoxUserId.Text};", $"Password={textBoxPassword.Text};" };
			File.WriteAllLines(path, DB_InfoInput);

			//Применение настроек в программе
			//Open the file to read from.
			string[] DB_Info = File.ReadAllLines(path);
			DB_Info[0] = DB_Info[0].Remove(0, 12);
			DB_Info[0] = DB_Info[0].Remove(DB_Info[0].Length - 1, 1);
			DB_Info[1] = DB_Info[1].Remove(0, 16);
			DB_Info[1] = DB_Info[1].Remove(DB_Info[1].Length - 1, 1);
			DB_Info[2] = DB_Info[2].Remove(0, 8);
			DB_Info[2] = DB_Info[2].Remove(DB_Info[2].Length - 1, 1);
			DB_Info[3] = DB_Info[3].Remove(0, 9);
			DB_Info[3] = DB_Info[3].Remove(DB_Info[3].Length - 1, 1);

			if (DB_Info[2] == "" || DB_Info[3] == "") FormAuthorization.sqlConnection = $"Data Source={DB_Info[0]};Initial Catalog={DB_Info[1]};Trusted_Connection=True;";
			else FormAuthorization.sqlConnection = $"Data Source={DB_Info[0]};Initial Catalog={DB_Info[1]};User Id={DB_Info[2]};Password={DB_Info[3]};";

			MessageBox.Show("Настройки сохранены", "Готово!");
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
