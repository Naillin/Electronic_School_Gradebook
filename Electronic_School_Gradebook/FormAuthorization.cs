using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
//MySql
using DatabaseTools_MSSQL;
//Excel
using Excel1 = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
//Media
using System.Media;

namespace Electronic_School_Gradebook
{
	public partial class FormAuthorization : Form
	{
		public FormAuthorization()
		{
			InitializeComponent();

			//настройка формы
			textBoxLogin.MaxLength = 30;
			textBoxPassword.MaxLength = 30;
			textBoxPassword.PasswordChar = '\0';
			buttonLogin.Select();
			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;
		}

		private void FormAuthorization_Click(object sender, EventArgs e)
		{
			if (textBoxLogin.Text == "")
			{
				textBoxLogin.ForeColor = Color.Silver;
				textBoxLogin.Text = "Login";
			}
			if (textBoxPassword.Text == "")
			{
				textBoxPassword.PasswordChar = '\0';
				textBoxPassword.ForeColor = Color.Silver;
				textBoxPassword.Text = "Password";
			}
			buttonLogin.Select();
		}

		private void textBoxLogin_Enter(object sender, EventArgs e)
		{
			if (textBoxLogin.Text == "Login")
			{
				textBoxLogin.Text = "";
				textBoxLogin.ForeColor = Color.Black;
			}
		}

		private void textBoxLogin_Leave(object sender, EventArgs e)
		{
			if (textBoxLogin.Text == "")
			{
				textBoxLogin.ForeColor = Color.Silver;
				textBoxLogin.Text = "Login";
			}
		}

		private void textBoxPassword_Enter(object sender, EventArgs e)
		{
			if (textBoxPassword.Text == "Password")
			{
				textBoxPassword.PasswordChar = '*';
				textBoxPassword.Text = "";
				textBoxPassword.ForeColor = Color.Black;
			}
		}

		private void textBoxPassword_Leave(object sender, EventArgs e)
		{
			if (textBoxPassword.Text == "")
			{
				textBoxPassword.PasswordChar = '\0';
				textBoxPassword.ForeColor = Color.Silver;
				textBoxPassword.Text = "Password";
			}
		}

		//переход в другой textbox
		private void textBoxLogin_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Convert.ToChar(Keys.Enter) == e.KeyChar)
			{
				e.Handled = true;
				textBoxPassword.Focus();
			}
		}

		//выполнение входа 
		private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Convert.ToChar(Keys.Enter) == e.KeyChar)
			{
				e.Handled = true;
				buttonLogin_Click(sender, e);
			}
		}

		static public string sqlConnection = @"Data Source=REDDRAGON;Initial Catalog=DB_Electronic_School_Gradebook;User Id=connection_user;Password=543211234555"; //строка соединения
		private void FormAuthorization_Load(object sender, EventArgs e)
		{
			string path = Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 32, 32) + @"\config.txt";
			// This text is added only once to the file.
			if (!File.Exists(path))
			{
				// Create a file to write to.
				string[] createText = { "Data Source=REDDRAGON;", "Initial Catalog=DB_Electronic_School_Gradebook;", "User Id=connection_user;", "Password=543211234555" };
				File.WriteAllLines(path, createText);
			}

			//Open the file to read from.
			string[] DB_Info = File.ReadAllLines(path);
			DB_Info[0] = DB_Info[0].Remove(0, 7);
			DB_Info[0] = DB_Info[0].Remove(DB_Info[0].Length - 1, 1);
			DB_Info[1] = DB_Info[1].Remove(0, 7);
			DB_Info[1] = DB_Info[1].Remove(DB_Info[1].Length - 1, 1);
			DB_Info[2] = DB_Info[2].Remove(0, 9);
			DB_Info[2] = DB_Info[2].Remove(DB_Info[2].Length - 1, 1);
			DB_Info[3] = DB_Info[3].Remove(0, 9);
			DB_Info[3] = DB_Info[3].Remove(DB_Info[3].Length - 1, 1);

			sqlConnection = $"Data Source={DB_Info[0]};Initial Catalog={DB_Info[1]};User Id={DB_Info[2]};Password={DB_Info[3]}";
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			FormGradebook formGradebook = new FormGradebook();
			formGradebook.Show();
			this.Hide();
		}

		private void buttonOptions_Click(object sender, EventArgs e)
		{
			FormOptions formOptions = new FormOptions();
			formOptions.ShowDialog();
		}
	}
}
