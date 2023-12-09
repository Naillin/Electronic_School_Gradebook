using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_School_Gradebook.Admin
{
	internal class DataGridViewBuilder
	{
		protected string[] Scheme { get; set; }
		protected DataGridView dataGridViewGradebookReciver;

		public DataGridViewBuilder(ref DataGridView dataGridView, string[] TableScheme)
		{
			dataGridViewGradebookReciver = dataGridView;
			Scheme = TableScheme;
		}

		//по идее это обявляется в наследуемом классе как override (сделал в OperatorsForColumns)
		public static int operator +(DataGridViewBuilder builder, DataGridViewColumn column)
		{
			builder.dataGridViewGradebookReciver.Columns.Add(column);
			return builder.dataGridViewGradebookReciver.Columns.Count;
		}

		public static int operator +(DataGridViewColumn column, DataGridViewBuilder builder)
		{
			builder.dataGridViewGradebookReciver.Columns.Add(column);
			return builder.dataGridViewGradebookReciver.Columns.Count;
		}

		public static int operator -(DataGridViewBuilder builder, DataGridViewColumn column)
		{
			builder.dataGridViewGradebookReciver.Columns.Remove(column);
			return builder.dataGridViewGradebookReciver.Columns.Count;
		}

		public static int operator -(DataGridViewColumn column, DataGridViewBuilder builder)
		{
			builder.dataGridViewGradebookReciver.Columns.Remove(column);
			return builder.dataGridViewGradebookReciver.Columns.Count;
		}

		public void FillingOfColumns()
		{
			dataGridViewGradebookReciver.Columns.Clear();

			for (int i = 0; i < Scheme.Length; i++)
            {
				dataGridViewGradebookReciver.Columns.Add(ColumnCreator.CreateColumn(Scheme[i], readOnly: true));
            }
        }
	}

	internal class OperatorsForColumns : DataGridViewColumn
	{

		protected DataGridView dataGridViewGradebookReciver;

		public OperatorsForColumns(ref DataGridView dataGridView)
		{
			dataGridViewGradebookReciver = dataGridView;
		}

		public static int operator +(OperatorsForColumns table, DataGridViewColumn column)
		{
			table.dataGridViewGradebookReciver.Columns.Add(column);
			return table.dataGridViewGradebookReciver.Columns.Count;
		}

		public static int operator -(OperatorsForColumns table, DataGridViewColumn column)
		{
			table.dataGridViewGradebookReciver.Columns.Remove(column);
			return table.dataGridViewGradebookReciver.Columns.Count;
		}

		public static int operator +(DataGridViewColumn column, OperatorsForColumns table)
		{
			table.dataGridViewGradebookReciver.Columns.Add(column);
			return table.dataGridViewGradebookReciver.Columns.Count;
		}

		public static int operator -(DataGridViewColumn column, OperatorsForColumns table)
		{
			table.dataGridViewGradebookReciver.Columns.Remove(column);
			return table.dataGridViewGradebookReciver.Columns.Count;
		}
	}

	internal class ColumnCreator
	{
		static public DataGridViewTextBoxColumn CreateColumn(string headerText = "Name", DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.NotSortable, bool readOnly = false)
		{
			DataGridViewTextBoxColumn result = new DataGridViewTextBoxColumn();
			result.HeaderText = headerText;
			result.SortMode = sortMode;
			result.ReadOnly = readOnly;

			return result;
		}

		static public DataGridViewCheckBoxColumn CreateColumn(string headerText = "On", DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.NotSortable, int width = 70)
		{
			DataGridViewCheckBoxColumn result = new DataGridViewCheckBoxColumn();
			result.HeaderText = headerText;
			result.SortMode = sortMode;
			result.Width = width;

			return result;
		}
	}
}
