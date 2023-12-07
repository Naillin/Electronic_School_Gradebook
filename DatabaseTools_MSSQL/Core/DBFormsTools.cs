using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlTypes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.Common;
using System.Globalization;

namespace DatabaseTools_MSSQL
{
	/// <summary>
	/// Набор инструментов для взаимодействия платформы Windows Forms и MS SQL.
	/// </summary>
	public class DBFormsTools
	{
		static private string connectionStringReceiver { get; set; }
		/// <summary>
		/// Инициализирует новый экземпляр класса DBFormsTools.
		/// </summary>
		/// <param name="connectionString">Строка подкулючения к целевой базе данных.</param>
		public DBFormsTools(string connectionString)
		{
			connectionStringReceiver = connectionString;
		}

		/// <summary>
		/// Хранит связь между сурогатным идентификатором записи таблицы из базы данных и индексом строки DataGridView.
		/// </summary>
		public struct RowConnect
		{
			public object idDataBase;
			public int rowIndex;

			/// <summary>
			/// Хранит связь между сурогатным идентификатором записи таблицы из базы данных и индексом строки DataGridView.
			/// </summary>
			/// <param name="idDataBase">Сурогатный идентификатор записи таблицы из базы данных.</param>
			/// <param name="rowIndex">Индекс строки DataGridView.</param>
			RowConnect(object idDataBase = null, int rowIndex = -1)
			{
				this.idDataBase = idDataBase;
				this.rowIndex = rowIndex;
			}
		}

		/// <summary>
		/// Заполняет DataGridView всеми данными указанных полей таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <returns></returns>
		public RowConnect [] FillDGVWithRowConnect(ref DataGridView dataGridView, string table)
		{
			RowConnect[] rowConnects = null;
			try
			{
				dataGridView.Focus();
				dataGridView.Rows.Clear();

				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNames = dBTools.columnsNames(table);
				string columns = string.Empty;
				for (int i = 0; i < columnsNames.Length; i++)
				{
					columns = columns + columnsNames[i].LongName + ", ";
				}
				columns = columns.Remove(columns.Length - 2);

				string sql = $"select {columns} from {table};";
				object[,] data = dBTools.executeSelectTable(@sql);
				rowConnects = new RowConnect[data.GetLength(0)];

				for (int i = 0; i < data.GetLength(0); i++)
				{
					object[] values = new object[data.GetLength(1) - 1];
					for (int j = 0; j < values.Length; j++)
					{
						values[j] = data[i, j + 1];
					}

					dataGridView.Rows.Add(values);
					rowConnects[i].idDataBase = data[i, 0];
					rowConnects[i].rowIndex = i;
				}
		}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}
			
			return rowConnects;
		}

		/// <summary>
		/// Заполняет DataGridView всеми данными указанных полей таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public RowConnect[] FillDGVWithRowConnect(ref DataGridView dataGridView, string table, string conditions)
		{
			RowConnect[] rowConnects = null;
			try
			{
				dataGridView.Rows.Clear();

				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNames = dBTools.columnsNames(table);
				string columns = string.Empty;
				for (int i = 0; i < columnsNames.Length; i++)
				{
					columns = columns + columnsNames[i].LongName + ", ";
				}
				columns = columns.Remove(columns.Length - 2);

				string sql = $"select {columns} from {table} {conditions};";
				object[,] data = dBTools.executeSelectTable(@sql);
				rowConnects = new RowConnect[data.GetLength(0)];

				for (int i = 0; i < data.GetLength(0); i++)
				{
					object[] values = new object[data.GetLength(1) - 1];
					for (int j = 0; j < values.Length; j++)
					{
						values[j] = data[i, j + 1];
					}

					dataGridView.Rows.Add(values);
					rowConnects[i].idDataBase = data[i, 0];
					rowConnects[i].rowIndex = i;
				}
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return rowConnects;
		}

		/// <summary>
		/// Заполняет DataGridView всеми данными указанных полей таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="fields">Массив хранящий поля таблицы.</param>
		/// <returns></returns>
		public RowConnect[] FillDGVWithRowConnect(ref DataGridView dataGridView, string table, string[] fields)
		{
			RowConnect[] rowConnects = null;
			try
			{
				dataGridView.Rows.Clear();

				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNames = dBTools.columnsNames(table);
				string columns = columnsNames[0].LongName + ", " + string.Join(", ", fields);

				string sql = $"select {columns} from {table};";
				object[,] data = dBTools.executeSelectTable(@sql);
				rowConnects = new RowConnect[data.GetLength(0)];

				for (int i = 0; i < data.GetLength(0); i++)
				{
					object[] values = new object[data.GetLength(1) - 1];
					for (int j = 0; j < values.Length; j++)
					{
						values[j] = data[i, j + 1];
					}

					dataGridView.Rows.Add(values);
					rowConnects[i].idDataBase = data[i, 0];
					rowConnects[i].rowIndex = i;
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}
			
			return rowConnects;
		}

		/// <summary>
		/// Заполняет DataGridView всеми данными указанных полей таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="fields">Массив хранящий поля таблицы.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public RowConnect[] FillDGVWithRowConnect(ref DataGridView dataGridView, string table, string[] fields, string conditions)
		{
			RowConnect[] rowConnects = null;
			try
			{
				dataGridView.Rows.Clear();

				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNames = dBTools.columnsNames(table);
				string columns = columnsNames[0].LongName + ", " + string.Join(", ", fields);

				string sql = $"select {columns} from {table} {conditions};";
				object[,] data = dBTools.executeSelectTable(@sql);
				rowConnects = new RowConnect[data.GetLength(0)];

				for (int i = 0; i < data.GetLength(0); i++)
				{
					object[] values = new object[data.GetLength(1) - 1];
					for (int j = 0; j < values.Length; j++)
					{
						values[j] = data[i, j + 1];
					}

					dataGridView.Rows.Add(values);
					rowConnects[i].idDataBase = data[i, 0];
					rowConnects[i].rowIndex = i;
				}
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return rowConnects;
		}

		/// <summary>
		/// Заполняет DataGridView всеми данными указанных полей таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="fields">Массив хранящий поля таблицы.</param>
		/// <returns></returns>
		public DataTable FillDGV(ref DataGridView dataGridView, string table, string[] fields)
		{
			DataTable dt = null;
			try
			{
				string columns = string.Join(", ", fields);

				DBTools dBTools = new DBTools(connectionStringReceiver);
				string sql = $"select {columns} from {table};";
				dt = dBTools.executeSelectTableDT(@sql);

				dataGridView.DataSource = dt;
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return dt;
		}

		/// <summary>
		/// Заполняет DataGridView всеми данными указанных полей таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="fields">Массив хранящий поля таблицы.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public DataTable FillDGV(ref DataGridView dataGridView, string table, string[] fields, string conditions)
		{
			DataTable dt = null;
			try
			{
				string columns = string.Join(", ", fields);

				DBTools dBTools = new DBTools(connectionStringReceiver);
				string sql = $"select {columns} from {table} {conditions};";
				dt = dBTools.executeSelectTableDT(@sql);

				dataGridView.DataSource = dt;
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return dt;
		}

		/// <summary>
		/// Заполняет DataGridView всеми данными указанной таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		public DataSet FillDGV(ref DataGridView dataGridView, string table)
		{
			DataSet ds = new DataSet();
			try
			{
				string sql = $"select * from {table};";
				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					dataGridView.DataSource = null;
					dataGridView.DataSource = ds.Tables["TableFromBD"];

					sqlConnection.Close();
				}
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет DataGridView всеми данными указанной таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		public DataSet FillDGV(ref DataGridView dataGridView, string table, string conditions)
		{
			DataSet ds = new DataSet();
			try
			{
				string sql = $"select * from {table} {conditions};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					dataGridView.DataSource = null;
					dataGridView.DataSource = ds.Tables["TableFromBD"];

					sqlConnection.Close();
				}
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ListBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="listBox">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <returns></returns>
		public DataSet FillListBox(ref ListBox listBox, string table, string column)
		{
			DataSet ds = new DataSet();
			try
			{
				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
				string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					listBox.DataSource = ds.Tables["TableFromBD"];
					listBox.ValueMember = columnsNamesMassive[0].Name;
					listBox.DisplayMember = column;

					sqlConnection.Close();
				}
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ListBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="listBox">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="selectValue">Задает выбор элемента.</param>
		/// <returns></returns>
		public DataSet FillListBox(ref ListBox listBox, string table, string column, int selectValue)
		{
			DataSet ds = new DataSet();
			try
			{
				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
				string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					listBox.DataSource = ds.Tables["TableFromBD"];
					listBox.ValueMember = columnsNamesMassive[0].Name;
					listBox.DisplayMember = column;

					sqlConnection.Close();
				}

				listBox.SelectedValue = selectValue;
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ListBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="listBox">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public DataSet FillListBox(ref ListBox listBox, string table, string column, string conditions)
		{
			DataSet ds = new DataSet();
			try
			{
				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
				string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table} {conditions};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					listBox.DataSource = ds.Tables["TableFromBD"];
					listBox.ValueMember = columnsNamesMassive[0].Name;
					listBox.DisplayMember = column;

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ListBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="listBox">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <param name="selectValue">Задает выбор элемента.</param>
		/// <returns></returns>
		public DataSet FillListBox(ref ListBox listBox, string table, string column, string conditions, int selectValue)
		{
			DataSet ds = new DataSet();
			try
			{
				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
				string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table} {conditions};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					listBox.DataSource = ds.Tables["TableFromBD"];
					listBox.ValueMember = columnsNamesMassive[0].Name;
					listBox.DisplayMember = column;

					sqlConnection.Close();
				}

				listBox.SelectedValue = selectValue;
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ComboBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref System.Windows.Forms.ComboBox comboBox, string table, string column)
		{
			DataSet ds = new DataSet();
			try
			{
				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
				string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					comboBox.DataSource = ds.Tables["TableFromBD"];
					comboBox.ValueMember = columnsNamesMassive[0].Name;
					comboBox.DisplayMember = column;

					sqlConnection.Close();
				}
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ComboBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="selectValue">Задает выбор элемента.</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref System.Windows.Forms.ComboBox comboBox, string table, string column, int selectValue)
		{
			DataSet ds = new DataSet();
			try
			{
				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
				string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					comboBox.DataSource = ds.Tables["TableFromBD"];
					comboBox.ValueMember = columnsNamesMassive[0].Name;
					comboBox.DisplayMember = column;

					sqlConnection.Close();
				}

				comboBox.SelectedValue = selectValue;
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ComboBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref System.Windows.Forms.ComboBox comboBox, string table, string column, string conditions)
		{
			DataSet ds = new DataSet();
			try
			{
				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
				string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table} {conditions};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					comboBox.DataSource = ds.Tables["TableFromBD"];
					comboBox.ValueMember = columnsNamesMassive[0].Name;
					comboBox.DisplayMember = column;

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ComboBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <param name="selectValue">Задает выбор элемента.</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref System.Windows.Forms.ComboBox comboBox, string table, string column, string conditions, int selectValue)
		{
			DataSet ds = new DataSet();
			try
			{
				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
				string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table} {conditions};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					comboBox.DataSource = ds.Tables["TableFromBD"];
					comboBox.ValueMember = columnsNamesMassive[0].Name;
					comboBox.DisplayMember = column;

					sqlConnection.Close();
				}

				comboBox.SelectedValue = selectValue;
			}
			catch (Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ComboBoxCell всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref DataGridViewComboBoxColumn comboBox, string table, string column)
		{
			DataSet ds = new DataSet();
			try
			{
				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
				string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					comboBox.DataSource = ds.Tables["TableFromBD"];
					comboBox.ValueMember = columnsNamesMassive[0].Name;
					comboBox.DisplayMember = column;
					comboBox.Name = "ComboBoxColumn";

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет ComboBoxCell всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект элемента формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref DataGridViewComboBoxColumn comboBox, string table, string column, string conditions)
		{
			DataSet ds = new DataSet();
			try
			{
				DBTools dBTools = new DBTools(connectionStringReceiver);
				ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
				string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table} {conditions};";

				using (SqlConnection sqlConnection = new SqlConnection(connectionStringReceiver))
				{
					sqlConnection.Open();

					SqlDataAdapter adapter = new SqlDataAdapter(@sql, sqlConnection);
					adapter.Fill(ds, "TableFromBD");
					comboBox.DataSource = ds.Tables["TableFromBD"];
					comboBox.ValueMember = columnsNamesMassive[0].Name;
					comboBox.DisplayMember = column;
					comboBox.Name = "ComboBoxColumn";

					sqlConnection.Close();
				}
			}
			catch(Exception ex)
			{
				//искуственное исключение
				ConsoleHandler consoleHandler = new ConsoleHandler();
				MessageBox.Show(ex.Message, "Warning!");
			}

			return ds;
		}

		/// <summary>
		/// Заполняет Series всеми данными указанной таблицы.
		/// </summary>
		/// <param name="name">Имя ряда.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column_X">Столбец таблицы, данные которого будут размещенны по оси X.</param>
		/// <param name="column_Y">Столбец таблицы, данные которого будут размещенны по оси Y.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where или join).</param>
		/// <returns></returns>
		public Series FillSeries(string name, string table, string column_X, string column_Y, string conditions)
		{
			Series series = new Series(name);

			DBTools dBTools = new DBTools(connectionStringReceiver);
			string sql = $"select {column_X}, {column_Y} from {table} {conditions};";
			object[,] data = dBTools.executeSelectTable(sql);

			for (int i = 0; i < data.Length; i++)
			{
				//DateTime DateItem = DateTime.ParseExact(data[i, 0].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
				series.Points.AddXY(data[i, 0], (double)data[i, 1]);
			}

			return series;
		}
	}
}
