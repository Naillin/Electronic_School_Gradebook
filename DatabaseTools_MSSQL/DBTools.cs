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
	/// Набор инструментов для работы с базой данных MS SQL.
	/// </summary>
	public class DBTools
	{
		static string connectionStringReceiver;
		/// <summary>
		/// Набор инструментов для работы с базой данных MS SQL.
		/// </summary>
		/// <param name="connectionString">Строка подключения к целевой базе данных.</param>
		public DBTools(string connectionString)
		{
			connectionStringReceiver = connectionString;
		}

		/// <summary>
		/// Выполняет любой запрос и возвращает количество затронутых строк.
		/// </summary>
		/// <param name="sql">Запрос соотвествующий всем правилам синтаксиса SQL.</param>
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
		/// <param name="sql">Запрос соотвествующий всем правилам синтаксиса SQL.</param>
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
		/// Выполнение запроса SELECT с возвращением двумерного массива данных.
		/// </summary>
		/// <param name="sql">Запрос SELECT соотвествующий всем правилам синтаксиса SQL.</param>
		/// <returns></returns>
		public object [,] executeSelectTable(string sql)
		{
			object[,] result = {{ -1 }};

			if (sql.TrimStart().ToUpper().StartsWith("SELECT"))
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

				result = new object[data.Rows.Count, data.Columns.Count];

				for (int i = 0; i < data.Rows.Count; i++)
				{
					for (int j = 0; j < data.Columns.Count; j++)
					{
						result[i, j] = data.Rows[i][j];
					}
				}
				data.Clear();
			}
			else
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText("Внимание! Ошибка составления запроса! Запрос должен начинаться с оператора SELECT!");
			}

			return result;
		}

		/// <summary>
		/// Выполнение запроса SELECT с возвращением таблицы хранимой в DataTable.
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public DataTable executeSelectTableDT(string sql)
		{
			DataTable result = null;

			if (sql.TrimStart().ToUpper().StartsWith("SELECT"))
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

				result = data;
				data.Clear();
			}
			else
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText("Внимание! Ошибка составления запроса! Запрос должен начинаться с оператора SELECT!");
			}

			return result;
		}

		/// <summary>
		/// Возвращение базы данных хранимой в DataSet. Таблицы данных DataSet имеют связь с таблицой из базы данных с пмощью адаптера. //требуется тестирование
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public DataSet TakeDatabase(string database)
		{
			string[] tableNames = TableNames(database);
			SqlDataAdapter[] adapterMass = new SqlDataAdapter[tableNames.Length];
			DataSet result = new DataSet();

			result.Clear();
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				for(int i = 0; i < tableNames.Length; i++)
				{
					string sql = $"SELECT * FROM {tableNames[i]}";
					adapterMass[i] = new SqlDataAdapter(@sql, sqlConnection);
					adapterMass[i].Fill(result, tableNames[i]);
				}

				sqlConnection.Close();
			}

			return result;
		}

		/// <summary>
		/// Выполнение запроса INSERT для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table"></param>
		/// <param name="value">Принимает массив значений.</param>
		public void executeInsert(string table, string[] value)
		{
			string strValues = string.Empty;

			string[] nameColumns = ColumnsNames(table); // имена столбцов
			string columns = string.Empty;
			for (int i = 1; i <= value.Length; i++) //бесполезная ебанина в случае этого метода, так как 1 столбец; цикл орентируется отностильено массива значений(values) потому что допускается не полный insert в таблицу
			{
				columns = columns + nameColumns[i] + ", ";
				strValues = strValues + value[i - 1] + ", ";
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

		/// <summary>
		/// Выполнение запроса INSERT для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table"></param>
		/// <param name="value">Принимает стороку значений разделенных знаком ';'. Пример: "value1;value2;value3;".</param>
		public void executeInsert(string table, string value)
		{
			if (value.Substring(value.Length - 1) == ";")
			{
				value = value.Remove(value.Length - 1);
			}
			string[] values = value.Split(';');
			string strValues = string.Empty;

			string[] nameColumns = ColumnsNames(table); // имена столбцов
			string columns = string.Empty;
			for (int i = 1; i <= values.Length; i++)
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

		/// <summary>
		/// Выполнение запроса UPDATE для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table"></param>
		/// <param name="value"></param>
		/// <param name="where"></param>
		/// <returns></returns>
		public int executeUpdate(string table, string [] value, string where)
		{
			string strValues = string.Empty;

			string[] nameColumns = ColumnsNames(table); // имена столбцов
			for (int i = 1; i <= value.Length; i++)
			{
				strValues = strValues + nameColumns[i] + " = " + value[i - 1] + ", ";
			}
			strValues = strValues.Remove(strValues.Length - 2);
			string sql = $"update {table} set {strValues} where ({where});";

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
		/// Выполнение запроса UPDATE для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public int executeUpdate(string table, string[] value)
		{
			string strValues = string.Empty;

			string[] nameColumns = ColumnsNames(table); // имена столбцов
			for (int i = 1; i <= value.Length; i++)
			{
				strValues = strValues + nameColumns[i] + " = " + value[i - 1] + ", ";
			}
			strValues = strValues.Remove(strValues.Length - 2);
			string sql = $"update {table} set {strValues};";

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
		/// Выполнение запроса UPDATE для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table"></param>
		/// <param name="value"></param>
		/// <param name="where"></param>
		/// <returns></returns>
		public int executeUpdate(string table, string value, string where)
		{
			if (value.Substring(value.Length - 1) == ";")
			{
				value = value.Remove(value.Length - 1);
			}
			string strValues = value.Replace(';', ',');

			string sql = $"update {table} set {strValues} where ({where});";

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
		/// Выполнение запроса UPDATE для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public int executeUpdate(string table, string value)
		{
			if (value.Substring(value.Length - 1) == ";")
			{
				value = value.Remove(value.Length - 1);
			}
			string strValues = value.Replace(';', ',');

			string sql = $"update {table} set {strValues};";

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
		/// Выполнение запроса DELETE для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table"></param>
		/// <param name="where"></param>
		/// <returns></returns>
		public int executeDelete(string table, string where)
		{
			string sql = $"delete {table} where {where};";

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
			DataTable data = new DataTable();
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				SqlDataReader reader = command.ExecuteReader();
				data.Load(reader);
				result = new string[data.Columns.Count];
				for (int i = 0; i < data.Columns.Count; i++)
				{
					result[i] = data.Columns[i].ColumnName;
				}
				data.Clear();

				sqlConnection.Close();
			}

			return result;
		}

		// вынести в отдельный класс работы с целевой таблицей
		/// <summary>
		/// Возвращает массив имен всех таблиц базы данных.
		/// </summary>
		/// <param name="database"></param>
		/// <returns></returns>
		public string[] TableNames(string database)
		{
			string sql = $"SELECT TABLE_NAME FROM {database}.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME != 'sysdiagrams';";

			string[] result = null;
			DataTable data = new DataTable();
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				SqlDataReader reader = command.ExecuteReader();
				data.Load(reader);
				result = new string[data.Rows.Count];
				for (int i = 0; i < data.Rows.Count; i++)
				{
					result[i] = data.Rows[i].ToString();
				}
				data.Clear();

				sqlConnection.Close();
			}

			return result;
		}
	}
}
