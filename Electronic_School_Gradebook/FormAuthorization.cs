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

		//static public string sqlConnection = @"Server=LAPTOP-Q7QIC61G;Database=DB_Electronic_School_Gradebook;Trusted_Connection=True;";
		static public string sqlConnection = @"Data Source=192.168.1.46;Initial Catalog=DB_Electronic_School_Gradebook;User Id=connection_user;Password=543211234555"; //строка соединения
		private void FormAuthorization_Load(object sender, EventArgs e)
		{
		//	string path = Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 32, 32) + @"\config.txt";
		//	// This text is added only once to the file.
		//	if (!File.Exists(path)) //если не существует файла
		//	{
		//		// Create a file to write to.
		//		string[] createText = { "Data Source=192.168.1.46;", "Initial Catalog=DB_Electronic_School_Gradebook;", "User Id=connection_user;", "Password=543211234555;" };
		//		File.WriteAllLines(path, createText);
		//	}

		//	//Open the file to read from.
		//	string[] DB_Info = File.ReadAllLines(path);
		//	DB_Info[0] = DB_Info[0].Remove(0, 12);
		//	DB_Info[0] = DB_Info[0].Remove(DB_Info[0].Length - 1, 1);
		//	DB_Info[1] = DB_Info[1].Remove(0, 16);
		//	DB_Info[1] = DB_Info[1].Remove(DB_Info[1].Length - 1, 1);
		//	DB_Info[2] = DB_Info[2].Remove(0, 8);
		//	DB_Info[2] = DB_Info[2].Remove(DB_Info[2].Length - 1, 1);
		//	DB_Info[3] = DB_Info[3].Remove(0, 9);
		//	DB_Info[3] = DB_Info[3].Remove(DB_Info[3].Length - 1, 1);

		//	sqlConnection = $"Data Source={DB_Info[0]};Initial Catalog={DB_Info[1]};User Id={DB_Info[2]};Password={DB_Info[3]};";
		}

		static public int ID_User; //глобальная переменная id пользователя
		static public string Role_User; //глобальная переменная роль пользователя
		//выполнение входа
		private void buttonLogin_Click(object sender, EventArgs e)
		{
			string Login = textBoxLogin.Text;
			string Password = textBoxPassword.Text;
			
			DBTools dBTools = new DBTools(sqlConnection);

			if ((Login != "Login") && (Password != "Password"))
			{
				string sql = $"select * from Users where Login_User = '{Login}' and Password_User = '{Password}';";
				object [,] data = dBTools.executeSelectTable(sql); // сделать метод для поиска в бд - долбоеб у тебя уже есть этот метод(ахуенный причем)

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
					switch (Role_User)
					{
						case "Admin":
							FormAdminPanel formAdminPanel = new FormAdminPanel();
							formAdminPanel.Show();
							this.Hide();
							break;

						case "Teacher":
							FormGradebook formGradebook = new FormGradebook();
							formGradebook.Show();

							//перенести папку Res к exe и добавить звуки в нее
							//написать коменты к всему

							//SoundPlayer sndVoscl = new SoundPlayer((Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 14, 14) + @"\Res\sound\Voscl.wav"));
							//sndVoscl.Play();

							this.Hide();
							break;

						case "Student":
							//student
							break;

						default:
							MessageBox.Show("Непредвиденная ошибка!", "Внимание!");
							break;
					}
				}
				else
				{
					//SoundPlayer sndError = new SoundPlayer((Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 14, 14) + @"\Res\sound\Error.wav"));
					//sndError.Play();
					MessageBox.Show("Неверный логин или пароль!", "Внимание!");
					//sndError.Stop();

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
