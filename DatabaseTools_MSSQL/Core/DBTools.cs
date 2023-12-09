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
using System.Windows.Forms;

namespace DatabaseTools_MSSQL
{
	/// <summary>
	/// Набор инструментов для изменения данных в базе данных MS SQL.
	/// </summary>
	public class DBTools : DBBase
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса DBTools.
		/// </summary>
		/// <param name="connectionString">Строка подключения к целевой базе данных.</param>
		public DBTools(string connectionString) : base(connectionString) //передача в старший класс
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
			//try
			//{
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteNonQuery();

					sqlConnection.Close();
				}
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}

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
			//try
			//{
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteScalar();

					sqlConnection.Close();
				}
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}

			return result;
		}

		/// <summary>
		/// Выполнение запроса SELECT с возвращением двумерного массива данных.
		/// </summary>
		/// <param name="sql">Запрос SELECT соотвествующий всем правилам синтаксиса SQL.</param>
		/// <returns></returns>
		public object[,] executeSelectTable(string sql)
		{
			object[,] result = { { -1 } };

			if (sql.TrimStart().ToUpper().StartsWith("SELECT") || sql.TrimStart().ToUpper().StartsWith("EXECUTE"))
			{
				//try
				//{
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
				//}
				//catch (Exception ex)
				//{
				//	//искуственное исключение
				//	ConsoleHandler consoleHandler = new ConsoleHandler();
				//	MessageBox.Show(ex.Message, "Warning!");
				//}
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
				//try
				//{
					result.Clear();
					using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
					{
						sqlConnection.Open();

						SqlCommand command = new SqlCommand(@sql, sqlConnection);
						SqlDataReader reader = command.ExecuteReader();
						result.Load(reader);

						sqlConnection.Close();
					}
				//}
				//catch (Exception ex)
				//{
				//	//искуственное исключение
				//	ConsoleHandler consoleHandler = new ConsoleHandler();
				//	MessageBox.Show(ex.Message, "Warning!");
				//}
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
			//try
			//{
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
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}

			return result;
		}

		/// <summary>
		/// Выполнение запроса INSERT для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает массив значений.</param>
		public void executeInsert(string table, string[] value)
		{
			//try
			//{
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
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}
		}

		/// <summary>
		/// Выполнение запроса INSERT для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает стороку значений разделенных знаком ';'. Пример: "column1=value1;column2=value2;column3=value3;".</param>
		public void executeInsert(string table, string value)
		{
			//try
			//{
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
					values = values + valueMass[i].Split('=')[1] + ", ";
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
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}
		}

		/// <summary>
		/// Выполнение запроса UPDATE для заданной таблицы с укзанными данными.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="value">Принимает массив значений для установки.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public int executeUpdate(string table, string[] value, string conditions)
		{
			int result = -1;
			//try
			//{
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
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}

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
			//try
			//{
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
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}

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
			//try
			//{
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
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}

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
			//try
			//{
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
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}

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
			//try
			//{
				string sql = $"delete {table} {conditions};";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlCommand command = new SqlCommand(@sql, sqlConnection);
					result = command.ExecuteNonQuery();

					sqlConnection.Close();
				}
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}

			return result;
		}

		/// <summary>
		/// Выполнение поиска в таблице по значению столбца с возвратом первой строки результата запроса.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="column">Целевой столбец.</param>
		/// <param name="value">Значение поиска.</param>
		/// <returns></returns>
		public object[] searchRecord(string table, string column, string value)
		{
			object[] result = { -1 };
			//try
			//{
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
			//}
			//catch (Exception ex)
			//{
			//	//искуственное исключение
			//	ConsoleHandler consoleHandler = new ConsoleHandler();
			//	MessageBox.Show(ex.Message, "Warning!");
			//}

			return result;
		}
	}
}
