using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//MySql
using DatabaseTools_MSSQL;
//Excel
using Excel1 = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
//Media
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
		}

		private void FormAuthorization_Load(object sender, EventArgs e)
		{
			string sqlConnection = @"Data Source=REDDRAGON;Initial Catalog=DB_Electronic_School_Gradebook;User Id=connection_user;Password=543211234555"; //строка соединения

			DBTools dBTools = new DBTools(sqlConnection);
			string[] g = { "'сабина лох'", "0" };
			dBTools.executeInsert("Classes", g);
			dBTools.executeInsert("Classes", "val1;val2;");
			label1.Text = dBTools.executeAnySqlScalar("select * from Classes").ToString(); // test
		}
	}
}
