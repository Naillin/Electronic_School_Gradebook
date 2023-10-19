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
	public class DBFormsTools
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
		/// Заполняет DataGridView всеми данными указанной таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		public DataSet FillDGV(ref DataGridView dataGridView, string table)
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

		/// <summary>
		/// Заполняет DataGridView всеми данными указанной таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		public DataSet FillDGV(ref DataGridView dataGridView, string table, string conditions)
		{
			string sql = $"select * from {table} {conditions};";
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

		/// <summary>
		/// Заполняет ListBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="listBox">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <returns></returns>
		public DataSet FillListBox(ref ListBox listBox, string table, string column)
		{
			DBTools dBTools = new DBTools(connectionStringReceiver);
			string[] columnsNamesMassive = dBTools.columnsNames(table, false); // имена столбцов
			string[] columnsNamesMassiveClean = dBTools.columnsNames(table, false); // создании второго массива с чистыми именами столбцов из за того что запрос имеет неоднозначные поля приходится указывать ссылки на таблицы в запросе
																					// из за этого возникет исключение при указании listBox.ValueMember так как он получает не чистый указатель на поле таблицы, а с родтелем
			string sql = $"select {columnsNamesMassive[0]}, {column} from {table};";
			DataSet ds = new DataSet();

			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
				adapter.Fill(ds, "TableFromBD");
				listBox.DataSource = ds.Tables["TableFromBD"];
				listBox.ValueMember = columnsNamesMassiveClean[0];
				listBox.DisplayMember = column;

				sqlConnection.Close();
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ListBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="listBox">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		/// <returns></returns>
		public DataSet FillListBox(ref ListBox listBox, string table, string column, string conditions)
		{
			DBTools dBTools = new DBTools(connectionStringReceiver);
			string[] columnsNamesMassive = dBTools.columnsNames(table, true); // имена столбцов
			string[] columnsNamesMassiveClean = dBTools.columnsNames(table, false); // создании второго массива с чистыми именами столбцов из за того что запрос имеет неоднозначные поля приходится указывать ссылки на таблицы в запросе
																				    // из за этого возникет исключение при указании listBox.ValueMember так как он получает не чистый указатель на поле таблицы, а с родтелем
			string sql = $"select {columnsNamesMassive[0]}, {column} from {table} {conditions};";
			DataSet ds = new DataSet();

			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
				adapter.Fill(ds, "TableFromBD");
				listBox.DataSource = ds.Tables["TableFromBD"];
				listBox.ValueMember = columnsNamesMassiveClean[0];
				listBox.DisplayMember = column;

				sqlConnection.Close();
			}

			return ds;
		}

		//метод для формирования диаграммы относительно данных из бд
	}
}
