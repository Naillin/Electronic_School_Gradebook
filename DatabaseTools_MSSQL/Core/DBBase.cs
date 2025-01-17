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
	/// Базовый набор инструментов для работы с базой данных MS SQL.
	/// </summary>
	abstract public class DBBase : IDBBase
	{
		protected string connectionStringReceiver { get; set; }
		/// <summary>
		/// Инициализирует новый экземпляр класса DBBase.
		/// </summary>
		/// <param name="connectionString">Строка подключения к целевой базе данных.</param>
		public DBBase(string connectionString)
		{
			connectionStringReceiver = connectionString;
		}

		/// <summary>
		/// Выполнение SQL-функции COUNT(*) без условий и возвратом количества строк.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <returns></returns>
		public int countRows(string table)
		{
			int count = -1;
			//try
			//{
				string sql = $"select count(*) from {table};";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();
					using (SqlCommand command = new SqlCommand(@sql, sqlConnection))
					{
						count = (int)command.ExecuteScalar();
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

			return count;
		}

		/// <summary>
		/// Выполнение SQL-функции COUNT(*) с условием и возвратом количества строк.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public int countRows(string table, string conditions)
		{
			int count = 0;
			//try
			//{
				string sql = $"select count(*) from {table} {conditions};";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();
					using (SqlCommand command = new SqlCommand(@sql, sqlConnection))
					{
						count = (int)command.ExecuteScalar();
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

			return count;
		}

		/// <summary>
		/// Возвращает массив информации о всех стлбцах таблицы.
		/// </summary>
		/// <param name="table">Целевая таблица.</param>
		/// <returns></returns>
		public ColumnsNames[] columnsNames(string table)
		{
			ColumnsNames[] result = null;
			//try
			//{
				// запрос для имена столбцов таблицы
				string sql = $"select top (1) * from {table};";
				string sql1 = $"SELECT COL_NAME(fc.parent_object_id, fc.parent_column_id) AS 'Поле', OBJECT_NAME (f.referenced_object_id) AS 'Связанная таблица' FROM sys.foreign_keys AS f INNER JOIN sys.foreign_key_columns AS fc ON f.object_id = fc.constraint_object_id WHERE OBJECT_NAME(f.parent_object_id) = '{table}';";

				DataTable dataForeignKeys = new DataTable();
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();
					using (SqlCommand commandForeignKeys = new SqlCommand(@sql1, sqlConnection))
					{
						using (SqlDataReader readerForeignKeys = commandForeignKeys.ExecuteReader())
						{
							dataForeignKeys.Load(readerForeignKeys);
						}
					}
					sqlConnection.Close();
				}

				object[,] foreignKeys = new object[dataForeignKeys.Rows.Count, dataForeignKeys.Columns.Count]; //убрать тип object, оставить DataTable и передавить с таким типом дальше.
				for (int i = 0; i < dataForeignKeys.Rows.Count; i++)
				{
					for (int j = 0; j < dataForeignKeys.Columns.Count; j++)
					{
						foreignKeys[i, j] = dataForeignKeys.Rows[i][j];
					}
				}
				dataForeignKeys.Clear();

				DataTable data = new DataTable();
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();
					using (SqlCommand command = new SqlCommand(@sql, sqlConnection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							data.Load(reader);
						}
					}
					sqlConnection.Close();
				}
				
				result = new ColumnsNames[data.Columns.Count];
				for (int i = 0; i < data.Columns.Count; i++)
				{
					result[i].Name = data.Columns[i].ColumnName;
					result[i].LongName = table + "." + data.Columns[i].ColumnName;
					if (i == 0)
					{
						result[i].Key = ColumnsNames.BDKeys.PK;
						continue;
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
		/// Возвращает массив имен всех таблиц базы данных.
		/// </summary>
		/// <param name="database">Целевая база данных.</param>
		/// <param name="flag">Включение или отвключение отображения в строке родителя.</param>
		/// <returns></returns>
		public string[] tableNames(string database, bool flag)
		{
			string[] result = null;
			//try
			//{
				string sql = $"SELECT TABLE_NAME FROM {database}.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME != 'sysdiagrams';";
				string strUser = currentUser();

				DataTable data = new DataTable();
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();
					using (SqlCommand command = new SqlCommand(@sql, sqlConnection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							data.Load(reader);
						}
					}
					sqlConnection.Close();
				}

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
		/// Возвращает имя текущего пользователя базы данных.
		/// </summary>
		/// <returns></returns>
		public string currentUser()
		{
			string result = string.Empty;
			//try
			//{
				string sql = $"SELECT (CURRENT_USER);";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();
					using (SqlCommand command = new SqlCommand(@sql, sqlConnection))
					{
						result = command.ExecuteScalar().ToString();
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
		/// Возвращает название базы данных используемой в данный момент.
		/// </summary>
		/// <returns></returns>
		public string datebaseName()
		{
			string result = string.Empty;
			//try
			//{
				string sql = $"select db_name(dbid) from master.dbo.sysprocesses where spid = @@spid;";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();
					using (SqlCommand command = new SqlCommand(@sql, sqlConnection))
					{
						result = command.ExecuteScalar().ToString();
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
	}
}
