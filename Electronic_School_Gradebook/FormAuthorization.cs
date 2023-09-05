using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseTools_MSSQL;

namespace Electronic_School_Gradebook
{
	public partial class FormAuthorization : Form
	{
		public FormAuthorization()
		{
			InitializeComponent();
		}

		private void FormAuthorization_Load(object sender, EventArgs e)
		{
			string sqlConnection = @"Data Source=REDDRAGON;Initial Catalog=DB_Electronic_School_Gradebook;User Id=connection_user;Password=543211234555";

			DBTools dBTools = new DBTools(sqlConnection);
			dBTools.executeInsert("Classes", "'сабина лох';0");
			label1.Text = dBTools.executeAnySqlScalar("select * from Classes").ToString(); // test
		}
	}
}
