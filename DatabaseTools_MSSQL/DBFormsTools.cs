using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseTools_MSSQL
{
	/// <summary>
	/// Набор инструментов для функционирования элементов Windows Forms и MS SQL.
	/// </summary>
	internal class DBFormsTools
	{
		static string connectionStringReceiver;
		/// <summary>
		/// Набор инструментов для функционирования элементов Windows Forms и MS SQL.
		/// </summary>
		/// <param name="connectionString">Строка подкулючения к целевой базе данных.</param>
		public DBFormsTools(string connectionString)
		{
			connectionStringReceiver = connectionString;
		}

		/// <summary>
		/// Заполняет dataGridView всеми данными указанной таблицы.
		/// </summary>
		/// <param name="table"></param>
		/// <param name="dataGridView"></param>
		public DataSet executeSelectDGV(string table, DataGridView dataGridView)
		{
			string sql = $"select * from {table};";
			DataSet ds = new DataSet();

			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
				adapter.Fill(ds, "TableFromBD");
				dataGridView.DataSource = ds.Tables["TableFromBD"];

				sqlConnection.Close();
			}

			return ds;
		}

		//метод для формирования диаграммы относительно данных из бд
	}
}
