using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
		/// Заполняет DataGridView всеми данными указанных полей таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="fields">Массив хранящий поля таблицы.</param>
		/// <returns></returns>
		public DataTable FillDGV(ref DataGridView dataGridView, string table, string[] fields)
		{
			string columns = string.Join(", ", fields);

			DBTools dBTools = new DBTools(connectionStringReceiver);
			string sql = $"select {columns} from {table};";
			DataTable dt = dBTools.executeSelectTableDT(@sql);

			dataGridView.DataSource = dt;

			return dt;
		}

		/// <summary>
		/// Заполняет DataGridView всеми данными указанных полей таблицы.
		/// </summary>
		/// <param name="dataGridView">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="fields">Массив хранящий поля таблицы.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		/// <returns></returns>
		public DataTable FillDGV(ref DataGridView dataGridView, string table, string[] fields, string conditions)
		{
			string columns = string.Join(", ", fields);

			DBTools dBTools = new DBTools(connectionStringReceiver);
			string sql = $"select {columns} from {table} {conditions};";
			DataTable dt = dBTools.executeSelectTableDT(@sql);

			dataGridView.DataSource = dt;

			return dt;
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
				dataGridView.DataSource = null;
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
				dataGridView.DataSource = null;
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
			DBTools.ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
			string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table};";
			DataSet ds = new DataSet();

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

			return ds;
		}

		/// <summary>
		/// Заполняет ListBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="listBox">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="selectValue">Задает выбор элемента.</param>
		/// <returns></returns>
		public DataSet FillListBox(ref ListBox listBox, string table, string column, int selectValue)
		{
			DBTools dBTools = new DBTools(connectionStringReceiver);
			DBTools.ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
			string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table};";
			DataSet ds = new DataSet();

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
			DBTools.ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
			string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table} {conditions};";
			DataSet ds = new DataSet();

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

			return ds;
		}

		/// <summary>
		/// Заполняет ListBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="listBox">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		/// <param name="selectValue">Задает выбор элемента.</param>
		/// <returns></returns>
		public DataSet FillListBox(ref ListBox listBox, string table, string column, string conditions, int selectValue)
		{
			DBTools dBTools = new DBTools(connectionStringReceiver);
			DBTools.ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
			string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table} {conditions};";
			DataSet ds = new DataSet();

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
			return ds;
		}

		/// <summary>
		/// Заполняет ComboBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref System.Windows.Forms.ComboBox comboBox, string table, string column)
		{
			DBTools dBTools = new DBTools(connectionStringReceiver);
			DBTools.ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
			string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table};";
			DataSet ds = new DataSet();

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

			return ds;
		}

		/// <summary>
		/// Заполняет ComboBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="selectValue">Задает выбор элемента.</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref System.Windows.Forms.ComboBox comboBox, string table, string column, int selectValue)
		{
			DBTools dBTools = new DBTools(connectionStringReceiver);
			DBTools.ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
			string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table};";
			DataSet ds = new DataSet();

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
			return ds;
		}

		/// <summary>
		/// Заполняет ComboBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref System.Windows.Forms.ComboBox comboBox, string table, string column, string conditions)
		{
			DBTools dBTools = new DBTools(connectionStringReceiver);
			DBTools.ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
			string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table} {conditions};";
			DataSet ds = new DataSet();

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

			return ds;
		}

		/// <summary>
		/// Заполняет ComboBox всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		/// <param name="selectValue">Задает выбор элемента.</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref System.Windows.Forms.ComboBox comboBox, string table, string column, string conditions, int selectValue)
		{
			DBTools dBTools = new DBTools(connectionStringReceiver);
			DBTools.ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
			string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table} {conditions};";
			DataSet ds = new DataSet();

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
			return ds;
		}

		/// <summary>
		/// Заполняет ComboBoxCell всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref DataGridViewComboBoxColumn comboBox, string table, string column)
		{
			DBTools dBTools = new DBTools(connectionStringReceiver);
			DBTools.ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
			string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table};";
			DataSet ds = new DataSet();

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

			return ds;
		}

		/// <summary>
		/// Заполняет ComboBoxCell всеми данными указанной таблицы.
		/// </summary>
		/// <param name="comboBox">Ссылка на объект формы.</param>
		/// <param name="table">Наименование таблицы хранящеся в базе данных.</param>
		/// <param name="column">Поле таблицы которое требуется отобразить.</param>
		/// <param name="conditions">Условия выполнения запроса (обычно начинается с where).</param>
		/// <returns></returns>
		public DataSet FillComboBox(ref DataGridViewComboBoxColumn comboBox, string table, string column, string conditions)
		{
			DBTools dBTools = new DBTools(connectionStringReceiver);
			DBTools.ColumnsNames[] columnsNamesMassive = dBTools.columnsNames(table); // имена столбцов
			string sql = $"select {columnsNamesMassive[0].LongName}, {column} from {table} {conditions};";
			DataSet ds = new DataSet();

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

			return ds;
		}

		//метод для формирования диаграммы относительно данных из бд
	}
}
