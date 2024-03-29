﻿using System;
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
	public partial class FormAuthorization : Form
	{
		public FormAuthorization()
		{
			InitializeComponent();

			//настройка формы
			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			this.MaximumSize = new Size(this.Width, this.Height);
			this.MinimumSize = new Size(this.Width, this.Height);

			textBoxLogin.MaxLength = 20;
			textBoxPassword.MaxLength = 20;
			textBoxPassword.PasswordChar = '\0';
			buttonLogin.Select();
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

		/// <summary>
		/// Строка соединения.
		/// </summary>
		static protected string sqlConnection { get; set; }
		
		/// <summary>
		/// Получение строки соединения.
		/// </summary>
		/// <returns></returns>
		static internal string getConnection()
        {
			return sqlConnection;
        }

		/// <summary>
		/// Изменение строки соединения.
		/// </summary>
		/// <param name="newConnection">Новая строка соединения.</param>
		/// <returns></returns>
		static internal int setConnection(string newConnection)
		{
            try 
			{
				sqlConnection = newConnection; 
			}
            catch
			{ 
				return -1;
			}
			return 1;
		}

		private void FormAuthorization_Load(object sender, EventArgs e)
		{
			string path = Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 32, 32) + @"\config.txt";
			// This text is added only once to the file.
			if (!File.Exists(path)) //если не существует файла
			{
				// Create a file to write to.
				string[] createText = { "Data Source=192.168.1.46;", "Initial Catalog=DB_Electronic_School_Gradebook;", "User Id=connection_user;", "Password=543211234555;" };
				File.WriteAllLines(path, createText);
			}

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

			if (DB_Info[2] == "" || DB_Info[3] == "") sqlConnection = $"Data Source={DB_Info[0]};Initial Catalog={DB_Info[1]};Trusted_Connection=True;";
			else sqlConnection = $"Data Source={DB_Info[0]};Initial Catalog={DB_Info[1]};User Id={DB_Info[2]};Password={DB_Info[3]};";
		}

		/// <summary>
		/// Идендификатор вошедшего пользователя.
		/// </summary>
		static protected int ID_User { get; set; }

		/// <summary>
		/// Получение идендификатора вошедшего пользователя.
		/// </summary>
		/// <returns></returns>
		static internal int getID_User()
		{
			return ID_User;
		}

		/// <summary>
		/// Системная роль вошедшего пользователя.
		/// </summary>
		static protected string Role_User { get; set; }

		/// <summary>
		/// Получение роли вошедшего пользователя.
		/// </summary>
		/// <returns></returns>
		static internal string getRole_User()
		{
			return Role_User;
		}


		//выполнение входа
		private void buttonLogin_Click(object sender, EventArgs e)
		{
			string Login = textBoxLogin.Text;
			string Password = textBoxPassword.Text;
			
			DBTools dBTools = new DBTools(sqlConnection);

			if ((Login != "Login") && (Password != "Password"))
			{
				string sql = $"select * from Users where Login_User = '{Login}' and Password_User = '{Password}' and LifeStatus = 1;";
				object [,] data = dBTools.executeSelectTable(sql);

				bool loginOrNo = false;
				try
				{
					if (Login == data[0, 2].ToString())
					{
						if (Password == data[0, 3].ToString())
						{
							loginOrNo = true;
							ID_User = (int)data[0, 0];
							Role_User = data[0, 1].ToString();

							//очистка текстбоксов
							textBoxLogin.Text = string.Empty;
							textBoxPassword.Text = string.Empty;
						}
					}
				}
				catch
				{

				}

				if(loginOrNo)
				{
					SoundPlayer sndVoscl = new SoundPlayer((Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 41, 41) + @"\Res\sound\Voscl.wav"));

					switch (Role_User)
					{
						case "Admin":
							sndVoscl.Play();

							FormAdminPanel formAdminPanel = new FormAdminPanel();
							formAdminPanel.Show();
							this.Hide();
							break;

						case "Teacher":
							sndVoscl.Play();

							FormGradebook formGradebook = new FormGradebook();
							formGradebook.Show();
							this.Hide();
							break;

						case "Student":
							sndVoscl.Play();

							FormStudent formStudent = new FormStudent();
							formStudent.Show();
							this.Hide();
							break;

						default:
							MessageBox.Show("Непредвиденная ошибка!", "Внимание!");
							break;
					}
				}
				else
				{
					SoundPlayer sndError = new SoundPlayer((Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 41, 41) + @"\Res\sound\Error.wav"));
					sndError.Play();
					MessageBox.Show("Неверный логин или пароль!", "Внимание!");
					sndError.Stop();

					buttonLogin.Select();
					textBoxLogin.ForeColor = Color.Silver;
					textBoxLogin.Text = "Login";
					textBoxPassword.ForeColor = Color.Silver;
					textBoxPassword.Text = "Password";
					textBoxPassword.PasswordChar = '\0';
				}
			}
		}

		private void buttonOptions_Click(object sender, EventArgs e)
		{
			FormOptions formOptions = new FormOptions();
			formOptions.ShowDialog();
		}
	}
}
