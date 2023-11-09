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
			int result = -1;
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteNonQuery();

					sqlConnection.Close();
				}
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
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
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteScalar();

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
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
				try
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
				catch(Exception ex)
				{
					//искуственное исключение
					ConsoleHandler consoleHandler = new ConsoleHandler();
					consoleHandler.ConsoleWriteText(ex.Message);
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
		/// Выполнение запроса SELECT с возвращением таблицы хранимой в DataTable.
		/// </summary>
		/// <param name="sql">Запрос SELECT соотвествующий всем правилам синтаксиса SQL.</param>
		/// <returns></returns>
		public DataTable executeSelectTableDT(string sql)
		{
			DataTable result = new DataTable();

			if (sql.TrimStart().ToUpper().StartsWith("SELECT") || sql.TrimStart().ToUpper().StartsWith("EXECUTE"))
			{
				try
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
				catch(Exception ex)
				{
					//искуственное исключение
					ConsoleHandler consoleHandler = new ConsoleHandler();
					consoleHandler.ConsoleWriteText(ex.Message);
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
			DataSet result = null;
			try
			{
				string[] tableNamesMassive = tableNames(database, true);
				SqlDataAdapter[] adapterMass = new SqlDataAdapter[tableNamesMassive.Length];
				result = new DataSet();

				result.Clear();
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					for (int i = 0; i < tableNamesMassive.Length; i++)
					{
						string sql = $"SELECT * FROM {tableNamesMassive[i]}";
						adapterMass[i] = new SqlDataAdapter(@sql, sqlConnection);
						adapterMass[i].Fill(result, tableNamesMassive[i]);
					}

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
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
			try
			{
				ColumnsNames[] columnsNamesMassive = columnsNames(table); // имена столбцов
				string columns = string.Empty;
				for (int i = 1; i < columnsNamesMassive.Length; i++)
				{
					columns = columns + columnsNamesMassive[i].Name + ", ";
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
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
			}
		}

		/// <summary>
		/// Выполнение запроса INSERT для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает стороку значений разделенных знаком ';'. Пример: "column1=value1;column2=value2;column3=value3;".</param>
		public void executeInsert(string table, string value)
		{
			try
			{
				if (value.Substring(value.Length - 1) == ";")
				{
					value = value.Remove(value.Length - 1);
				}
				string[] valueMass = value.Split(';');

				//ColumnsNames[] columnsNamesMassive = columnsNames(table); // имена столбцов
				string columns = string.Empty;
				string values = string.Empty;
				for (int i = 0; i < valueMass.Length; i++)
				{
					columns = columns + valueMass[i].Split('=')[0] + ", ";
					values = values + valueMass[i].Split('=')[0] + ", ";
				}
				columns = columns.Remove(columns.Length - 2);
				values = values.Remove(columns.Length - 2);

				string sql = $"insert into {table} ({columns}) values ({values});";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					command.ExecuteNonQuery();

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
			}
		}

		/// <summary>
		/// Выполнение запроса UPDATE для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает массив значений для установки.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public int executeUpdate(string table, string [] value, string conditions)
		{
			int result = -1;
			try
			{
				string strValues = string.Empty;
				ColumnsNames[] columnsNamesMassive = columnsNames(table); // имена столбцов
				for (int i = 1; i <= value.Length; i++)
				{
					strValues = strValues + columnsNamesMassive[i].Name + " = " + value[i - 1] + ", ";
				}
				strValues = strValues.Remove(strValues.Length - 2);
				string sql = $"update {table} set {strValues} {conditions};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteNonQuery();

					sqlConnection.Close();
				}
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
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
			int result = -1;
			try
			{
				string strValues = string.Empty;

				ColumnsNames[] columnsNamesMassive = columnsNames(table); // имена столбцов
				for (int i = 1; i <= value.Length; i++)
				{
					strValues = strValues + columnsNamesMassive[i].Name + " = " + value[i - 1] + ", ";
				}
				strValues = strValues.Remove(strValues.Length - 2);
				string sql = $"update {table} set {strValues};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteNonQuery();

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
			}

			return result;
		}

		/// <summary>
		/// Выполнение запроса UPDATE для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает стороку значений разделенных знаком ';'. Пример: "column1=value1;column2=value2;column3=value3;".</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public int executeUpdate(string table, string value, string conditions)
		{
			int result = -1;
			try
			{
				if (value.Substring(value.Length - 1) == ";")
				{
					value = value.Remove(value.Length - 1);
				}
				string strValues = value.Replace(';', ',');

				string sql = $"update {table} set {strValues} {conditions};";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteNonQuery();

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
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
			int result = -1;
			try
			{
				if (value.Substring(value.Length - 1) == ";")
				{
					value = value.Remove(value.Length - 1);
				}
				string strValues = value.Replace(';', ',');

				string sql = $"update {table} set {strValues};";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteNonQuery();

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
			}

			return result;
		}

		/// <summary>
		/// Выполнение запроса DELETE для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public int executeDelete(string table, string conditions)
		{
			int result = -1;
			try
			{
				string sql = $"delete {table} {conditions};";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteNonQuery();

					sqlConnection.Close();
				}
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
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
			object[] result = { -1 };
			try
			{
				string sql = $"select top (1) * from {table} where {column} = {value};";

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
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
			}
			
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
			int count = -1;
			try
			{
				string sql = $"select count(*) from {table};";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					count = (int)command.ExecuteScalar();

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
			}

			return count;
		}

		// вынести в отдельный класс работы с целевой таблицей
		/// <summary>
		/// Выполнение SQL-функции COUNT(*) с условием и возвратом количества строк.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public int countRows(string table, string conditions)
		{
			int count = 0;
			try
			{
				string sql = $"select count(*) from {table} {conditions};";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					count = (int)command.ExecuteScalar();

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
			}

			return count;
		}

		// вынести в отдельный класс работы с целевой таблицей
		/// <summary>
		/// Структура хранения информации о полях таблицы.
		/// </summary>
		public struct ColumnsNames
		{
			/// <summary>
			/// Типы ключей базы данных.
			/// </summary>
			public enum BDKeys
			{
				NONE = 0, PK = 1, FK = 2
			}

			public string Name;
			public string LongName;
			public BDKeys Key;
			public string FkParent;

			/// <summary>
			/// Структура хранения информации о полях таблицы.
			/// </summary>
			/// <param name="name">Имя таблицы.</param>
			/// <param name="longName">Полное имя таблицы.</param>
			/// <param name="key">Тип ключа.</param>
			/// <param name="fkParent">Родительская таблица.</param>
			public ColumnsNames(string name = null, string longName = null, BDKeys key = BDKeys.NONE, string fkParent = null)
			{
				this.Name = name;
				this.LongName = longName;
				this.Key = key;
				this.FkParent = fkParent;
			}
		}
		/// <summary>
		/// Возвращает массив информации о всех стлбцах таблицы.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="flag">Включение или отвключение отображения в строке родителя.</param>
		/// <returns></returns>
		public ColumnsNames[] columnsNames(string table)
		{
			ColumnsNames[] result = null;
			try
			{
				// запрос для имена столбцов таблицы
				string sql = $"select top (1) * from {table};";
				string sql1 = $"SELECT COL_NAME(fc.parent_object_id, fc.parent_column_id) AS 'Поле', OBJECT_NAME (f.referenced_object_id) AS 'Связанная таблица' FROM sys.foreign_keys AS f INNER JOIN sys.foreign_key_columns AS fc ON f.object_id = fc.constraint_object_id WHERE OBJECT_NAME(f.parent_object_id) = '{table}';";
				object[,] foreignKeys = executeSelectTable(@sql1);

				DataTable data = new DataTable();
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					SqlDataReader reader = command.ExecuteReader();
					data.Load(reader);
					result = new ColumnsNames[data.Columns.Count];
					for (int i = 0; i < data.Columns.Count; i++)
					{
						result[i].Name = data.Columns[i].ColumnName;
						result[i].LongName = table + "." + data.Columns[i].ColumnName;
						if (i == 0)
						{
							result[i].Key = ColumnsNames.BDKeys.PK;
						}

						for (int j = 0; j < foreignKeys.GetLength(0); j++)
						{
							if (data.Columns[i].ColumnName == foreignKeys[j, 0].ToString())
							{
								result[i].Key = ColumnsNames.BDKeys.FK;
								result[i].FkParent = foreignKeys[j, 1].ToString();
							}
						}
					}
					data.Clear();

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
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
			string[] result = null;
			try
			{
				string sql = $"SELECT TABLE_NAME FROM {database}.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME != 'sysdiagrams';";
				string strUser = currentUser();

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
						if (flag)
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
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
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
			string result = string.Empty;
			try
			{
				string sql = $"SELECT (CURRENT_USER);";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteScalar().ToString();

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
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
			string result = string.Empty;
			try
			{
				string sql = $"select db_name(dbid) from master.dbo.sysprocesses where spid = @@spid;";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteScalar().ToString();

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				consoleHandler.ConsoleWriteText(ex.Message);
			}

			return result;
		}
	}
}
