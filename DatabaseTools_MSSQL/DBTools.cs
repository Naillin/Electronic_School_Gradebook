using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Security.Policy;

namespace DatabaseTools_MSSQL
{
	/// <summary>
	/// Набор инструментов для работы с базой данных MS SQL.
	/// </summary>
	public class DBTools
	{
		static private string connectionStringReceiver;
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
		/// Выполняет запрос и возвращает значение первого столбеца первой строки результирующего набора, возвращаемого запросом. Дополнительные столбцы или строки не обрабатываются.
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

		//сделать методы для выполнения процедур функций(прием значений)

		/// <summary>
		/// Выполнение запроса SELECT с возвращением двумерного массива данных.
		/// </summary>
		/// <param name="sql">Запрос SELECT соотвествующий всем правилам синтаксиса SQL.</param>
		/// <returns></returns>
		public object [,] executeSelectTable(string sql)
		{
			object[,] result = {{ -1 }};

			if (sql.TrimStart().ToUpper().StartsWith("SELECT") || sql.TrimStart().ToUpper().StartsWith("EXECUTE"))
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
				consoleHandler.ConsoleWriteText("Внимание! Ошибка составления запроса! Учитывайте что запрос должен начинаться с оператора SELECT или EXECUTE!");
			}

			return result;
		}

		/// <summary>
		/// Выполнение запроса SELECT с возвращением таблицы хранимой в DataTable.
		/// </summary>
		/// <param name="sql">Запрос SELECT соотвествующий всем правилам синтаксиса SQL.</param>
		/// <returns></returns>
		public DataTable executeSelectTableDT(string sql)
		{
			DataTable result = new DataTable();

			if (sql.TrimStart().ToUpper().StartsWith("SELECT") || sql.TrimStart().ToUpper().StartsWith("EXECUTE"))
			{
				result.Clear();
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					SqlDataReader reader = command.ExecuteReader();
					result.Load(reader);

					sqlConnection.Close();
				}
			}
			else
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText("Внимание! Ошибка составления запроса! Учитывайте что запрос должен начинаться с оператора SELECT или EXECUTE!");
			}

			return result;
		}

		/// <summary>
		/// Возвращение базы данных хранимой в DataSet. Таблицы данных DataSet имеют связь с таблицой из базы данных с пмощью адаптера. //требуется тестирование
		/// </summary>
		/// <param name="database">Целевая база данных.</param>
		/// <returns></returns>
		public DataSet takeDatabase(string database)
		{
			string[] tableNamesMassive = tableNames(database, true);
			SqlDataAdapter[] adapterMass = new SqlDataAdapter[tableNamesMassive.Length];
			DataSet result = new DataSet();

			result.Clear();
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				for(int i = 0; i < tableNamesMassive.Length; i++)
				{
					string sql = $"SELECT * FROM {tableNamesMassive[i]}";
					adapterMass[i] = new SqlDataAdapter(@sql, sqlConnection);
					adapterMass[i].Fill(result, tableNamesMassive[i]);
				}

				sqlConnection.Close();
			}

			return result;
		}

		/// <summary>
		/// Выполнение запроса INSERT для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает массив значений.</param>
		public void executeInsert(string table, string[] value)
		{
			string[] columnsNamesMassive = columnsNames(table, false); // имена столбцов
			string columns = string.Empty;
			for (int i = 1; i < columnsNamesMassive.Length; i++)
			{
				columns = columns + columnsNamesMassive[i] + ", ";
			}
			columns = columns.Remove(columns.Length - 2);

			string strValues = string.Join(", ", value);
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
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает стороку значений разделенных знаком ';'. Пример: "value1;value2;value3;".</param>
		public void executeInsert(string table, string value)
		{
			string[] columnsNamesMassive = columnsNames(table, false); // имена столбцов
			string columns = string.Empty;
			for (int i = 1; i < columnsNamesMassive.Length; i++)
			{
				columns = columns + columnsNamesMassive[i] + ", ";
			}
			columns = columns.Remove(columns.Length - 2);

			if (value.Substring(value.Length - 1) == ";")
			{
				value = value.Remove(value.Length - 1);
			}
			string strValues = value.Replace(';', ',');

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
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает массив значений для установки.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		/// <returns></returns>
		public int executeUpdate(string table, string [] value, string conditions)
		{
			string strValues = string.Empty;

			string[] columnsNamesMassive = columnsNames(table, false); // имена столбцов
			for (int i = 1; i <= value.Length; i++)
			{
				strValues = strValues + columnsNamesMassive[i] + " = " + value[i - 1] + ", ";
			}
			strValues = strValues.Remove(strValues.Length - 2);
			string sql = $"update {table} set {strValues} {conditions};";

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
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает массив значений для установки.</param>
		/// <returns></returns>
		public int executeUpdate(string table, string[] value)
		{
			string strValues = string.Empty;

			string[] columnsNamesMassive = columnsNames(table, false); // имена столбцов
			for (int i = 1; i <= value.Length; i++)
			{
				strValues = strValues + columnsNamesMassive[i] + " = " + value[i - 1] + ", ";
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
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает стороку значений разделенных знаком ';'. Пример: "column1=value1;column2=value2;column3=value3;".</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		/// <returns></returns>
		public int executeUpdate(string table, string value, string conditions)
		{
			if (value.Substring(value.Length - 1) == ";")
			{
				value = value.Remove(value.Length - 1);
			}
			string strValues = value.Replace(';', ',');

			string sql = $"update {table} set {strValues} {conditions};";

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
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает стороку значений разделенных знаком ';'. Пример: "column1=value1;column2=value2;column3=value3;".</param>
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
		/// <param name="table">Целевая таблица.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		/// <returns></returns>
		public int executeDelete(string table, string conditions)
		{
			string sql = $"delete {table} {conditions};";

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
		/// Выполнение поиска в таблице по значению столбца с возвратом первой строки результата запроса.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="column">Целевой столбец.</param>
		/// <param name="value">Значение поиска.</param>
		/// <returns></returns>
		public object [] searchRecord(string table, string column, string value)
		{
			string sql = $"select top (1) * from {table} where {column} = {value};";

			object [] result = { -1 };

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

			result = new object[data.Columns.Count];

			for (int i = 0; i < data.Columns.Count; i++)
			{
				result[i] = data.Rows[0][i];
			}
			data.Clear();

			return result;
		}

		// вынести в отдельный класс работы с целевой таблицей
		/// <summary>
		/// Выполнение SQL-функции COUNT(*) без условий и возвратом количества строк.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <returns></returns>
		public int countRows(string table)
		{
			string sql = $"select count(*) from {table};";

			int count = 0;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				count = (int)command.ExecuteScalar();

				sqlConnection.Close();
			}

			return count;
		}

		// вынести в отдельный класс работы с целевой таблицей
		/// <summary>
		/// Выполнение SQL-функции COUNT(*) с условием и возвратом количества строк.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		/// <returns></returns>
		public int countRows(string table, string conditions)
		{
			string sql = $"select count(*) from {table} {conditions};";

			int count = 0;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				count = (int)command.ExecuteScalar();

				sqlConnection.Close();
			}

			return count;
		}

		// вынести в отдельный класс работы с целевой таблицей
		public struct ColumnsNames
		{
			public enum BDKeys
			{
				NONE = 0, PK = 1, FK = 2
			}

			public string Name;
			public string LongName;
			public BDKeys Key;
			public string FKFiled;

			public ColumnsNames(string name = null, string longName = null, BDKeys key = BDKeys.NONE, string fkFiled = null)
			{
				this.Name = name;
				this.LongName = longName;
				this.Key = key;
				this.FKFiled = fkFiled;
			}
		}
		/// <summary>
		/// Возвращает массив имен всех стлбцов таблицы.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="flag">Включение или отвключение отображения в строке родителя.</param>
		/// <returns></returns>
		public string [] columnsNames(string table, bool flag)
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
					if (flag)
					{
						result[i] = table + "." + data.Columns[i].ColumnName;
					}
					else
					{
						result[i] = data.Columns[i].ColumnName;
					}
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
		/// <param name="database">Целевая база данных.</param>
		/// <param name="flag">Включение или отвключение отображения в строке родителя.</param>
		/// <returns></returns>
		public string[] tableNames(string database, bool flag)
		{
			string sql = $"SELECT TABLE_NAME FROM {database}.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME != 'sysdiagrams';";
			string strUser = currentUser();

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
					if(flag)
					{
						result[i] = database + "." + strUser + "." + data.Rows[i].ToString();
					}
					else
					{
						result[i] = data.Rows[i].ToString();
					}
				}
				data.Clear();

				sqlConnection.Close();
			}

			return result;
		}

		// вынести в отдельный класс работы с целевой таблицей
		/// <summary>
		/// Возвращает имя текущего пользователя базы данных.
		/// </summary>
		/// <returns></returns>
		public string currentUser()
		{
			string sql = $"SELECT (CURRENT_USER);";

			string result = string.Empty;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				result = command.ExecuteScalar().ToString();

				sqlConnection.Close();
			}

			return result;
		}

		// вынести в отдельный класс работы с целевой таблицей
		/// <summary>
		/// Возвращает название базы данных используемой в данный момент.
		/// </summary>
		/// <returns></returns>
		public string datebaseName()
		{
			string sql = $"select db_name(dbid) from master.dbo.sysprocesses where spid = @@spid;";

			string result = string.Empty;
			using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(@sql, sqlConnection);
				result = command.ExecuteScalar().ToString();

				sqlConnection.Close();
			}

			return result;
		}
	}
}
