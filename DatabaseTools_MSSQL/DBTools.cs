using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SqlServer.Server;

namespace DatabaseTools_MSSQL
{
	/// <summary>
	/// Инструментарий работы с базой данных MS SQL.
	/// </summary>
	public class DBTools
	{
		static string connectionStringReceiver;
		/// <summary>
		/// Инструментарий работы с базой данных MS SQL.
		/// </summary>
		/// <param name="connectionString">Строка подкулючения к целевой базе данных.</param>
		public DBTools(string connectionString)
		{
			connectionStringReceiver = connectionString;
		}

		//if (query.TrimStart().ToUpper().StartsWith("SELECT")) - реализовать аналогию библиотеки объеденив все функции в один метод. Возвращаемое занчение в случае ожидании данных - данные, в случае простого выполнения запроса без возращения вернуть количество затронутых строк.

		/// <summary>
		/// Выполняет любой запрос и возвращает количество затронутых строк.
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public int executeAnySql(string sql)
		{
			int result = 0;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				result = command.ExecuteNonQuery();

				sqlConnection.Close();
			}

			return result;
		}

		/// <summary>
		/// Выполняет запрос и возвращает первый столбец первой строки результирующего набора, возвращаемого запросом. Дополнительные столбцы или строки не обрабатываются.
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public object executeAnySqlScalar(string sql)
		{
			object result = null;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				result = command.ExecuteScalar();

				sqlConnection.Close();
			}

			return result;
		}

		/// <summary>
		/// Выполнение запроса SELECT с возвращением одномерного массива данных. ОШИБКА!!!! вырезать нахуй этот метод из библиотеки!
		/// </summary>
		/// <param name="columnsORfunction"></param>
		/// <param name="tables"></param>
		/// <param name="conditions"></param>
		/// <returns></returns>
		public object [] executeSelectColumn(string columnsORfunction, string tables, string conditions)
		{
			string sql = $"select {columnsORfunction} from {tables} where {conditions};"; // ошибка - обязательно требуется условие иначе сломанный запрос. реализовать логический конструктор запроса.
			string sqlRows = $"select count(*) from {tables} where {conditions};";
			object [] result = null;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();
			
				SqlCommand commandRows = new SqlCommand(@sqlRows, sqlConnection);
				result = new object[(int)commandRows.ExecuteScalar()];
				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				SqlDataReader reader = command.ExecuteReader();

				int i = 0;
				while (reader.Read())
				{
					result[i] = (object)reader.GetValue(0);
					i++;
				}
				i = 0;
				
				sqlConnection.Close();
			}

			return result;
		}

		/// <summary>
		/// Выполнение запроса SELECT с возвращением двумерного массива данных.
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public object [,] executeSelectTable(string sql)
		{
			DataTable data = new DataTable();
			data.Clear();
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				SqlDataReader reader = command.ExecuteReader();
				data.Load(reader);

				sqlConnection.Close();
			}

			object [,] result = new object[data.Rows.Count, data.Columns.Count];

			for (int i = 0; i < data.Rows.Count; i++)
			{
				for(int j = 0; j < data.Columns.Count; j++)
				{
					result[i, j] = data.Rows[i][j];
				}
			}
			data.Clear();

			return result;
		}

		//select с заполнением dgv

		/// <summary>
		/// Выполнение запроса INSERT для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table"></param>
		/// <param name="value"></param>
		public void executeInsert(string table, string value)
		{
			string[] values = value.Split(';');
			string strValues = string.Empty;

			string[] nameColumns = ColumnsNames(table); // имена столбцов
			string columns = string.Empty;
			for (int i = 1; i <= values.Length; i++) //бесполезная ебанина в случае этого метода, так как 1 столбец; цикл орентируется отностильено массива значений(values) потому что допускается не полный insert в таблицу
			{
				columns = columns + nameColumns[i] + ", ";
				strValues = strValues + values[i - 1] + ", ";
			}
			columns = columns.Remove(columns.Length - 2);
			strValues = strValues.Remove(strValues.Length - 2);
			string sql = $"insert into {table} ({columns}) values ({strValues});";

			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				command.ExecuteNonQuery();

				sqlConnection.Close();
			}
		}

		//public void executeInsert(string table, string value1, string value2)
		//{
		//	string [] NameColumns = ColumnsNames(table); // имена столбцов
		//	string columns = null;
		//	for (int i = 1; i < 2; i++)
		//	{
		//		columns = columns + NameColumns[i] + ", ";
		//	}
		//	columns = columns.Remove(columns.Length - 2);

		//	string sql = $"insert into {table} ({columns}) values ({value1}, {value2});";

		//	using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
		//	{
		//		sqlConnection.Open();

		//		SqlCommand command = new SqlCommand(@sql, sqlConnection);
		//		command.ExecuteNonQuery();

		//		sqlConnection.Close();
		//	}
		//}

		//update - херня, так как копия executeAnySql
		public int executeUpdate(string sql)
		{
			int result = 0;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				result = command.ExecuteNonQuery();

				sqlConnection.Close();
			}

			return result;
		}

		//delete

		// вынести в отдельный класс работы с целевой таблицей
		/// <summary>
		/// Выполнение SQL-функции COUNT(*) без условий и возвратом количества строк.
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public int countRows(string table)
		{
			string sql = $"select count(*) from {table};";

			int count = 0;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				count = command.ExecuteNonQuery();

				sqlConnection.Close();
			}

			return count;
		}

		// вынести в отдельный класс работы с целевой таблицей
		/// <summary>
		/// Выполнение SQL-функции COUNT(*) с условием и возвратом количества строк.
		/// </summary>
		/// <param name="table"></param>
		/// <param name="conditions"></param>
		/// <returns></returns>
		public int countRows(string table, string conditions)
		{
			string sql = $"select count(*) from {table} where {conditions};";

			int count = 0;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				count = command.ExecuteNonQuery();

				sqlConnection.Close();
			}

			return count;
		}

		// вынести в отдельный класс работы с целевой таблицей
		/// <summary>
		/// Возвращает массив имен всех стлбцов таблицы.
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public string [] ColumnsNames(string table)
		{
			// запрос для имена столбцов таблицы
			string sql = $"select top (1) * from {table};";

			string [] result = null;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
				DataSet ds = new DataSet();
				adapter.Fill(ds);
				result = new string[ds.Tables[0].Columns.Count];
				for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
				{
					result[i] = ds.Tables[0].Columns[i].ColumnName;
				}
				ds.Clear();

				sqlConnection.Close();
			}

			return result;
		}
	}
}
