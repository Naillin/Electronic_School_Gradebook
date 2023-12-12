using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_School_Gradebook.Admin
{
	internal struct ColumnUnit
    {
		internal string headerText;
		internal ColumnTypes columnType;

		public enum ColumnTypes
        {
			TEXTBOX = 0,
			CHECKBOX = 1,
			COMBOBOX = 2,
			LINK = 3,
			IMAGE = 4,
			BUTTON = 5
        }
		internal ColumnUnit(string headerText, ColumnTypes columnType)
        {
			this.headerText = headerText;
			this.columnType = columnType;
        }
    }

	internal class DataGridViewBuilder
	{
		//закрытые свойства класса для изменения
		protected ColumnUnit[] Scheme { get; set; }
		protected DataGridView dataGridViewGradebookReciver;

		//доступные свойства класса для изменения
		public DataGridViewColumnSortMode sortMode { get; set; } = DataGridViewColumnSortMode.NotSortable;
		public bool readOnly { get; set; } = true;
		public int width { get; set; } = 70;

		internal DataGridViewBuilder(ref DataGridView dataGridView, params ColumnUnit[] TableScheme)
		{
			dataGridViewGradebookReciver = dataGridView;
			Scheme = TableScheme;
		}

		public void FillingOfColumns()
		{
			for (int i = 0; i < Scheme.Length; i++)
            {
                switch (Scheme[i].columnType)
                {
					case ColumnUnit.ColumnTypes.TEXTBOX:
						dataGridViewGradebookReciver.Columns.Add(ColumnCreator.CreateColumnTextBox(Scheme[i].headerText, sortMode: sortMode, readOnly: readOnly));
					    break;
					case ColumnUnit.ColumnTypes.CHECKBOX:
						dataGridViewGradebookReciver.Columns.Add(ColumnCreator.CreateColumnCheckBox(Scheme[i].headerText, width: width));
						break;
					case ColumnUnit.ColumnTypes.BUTTON:
						dataGridViewGradebookReciver.Columns.Add(ColumnCreator.CreateColumnButton(Scheme[i].headerText));
						break;
					case ColumnUnit.ColumnTypes.IMAGE:
						dataGridViewGradebookReciver.Columns.Add(ColumnCreator.CreateColumnImage(Scheme[i].headerText));
						break;
					case ColumnUnit.ColumnTypes.COMBOBOX:
						dataGridViewGradebookReciver.Columns.Add(ColumnCreator.CreateColumnComboBox(Scheme[i].headerText));
						break;
					case ColumnUnit.ColumnTypes.LINK:
						dataGridViewGradebookReciver.Columns.Add(ColumnCreator.CreateColumnLink(Scheme[i].headerText));
						break;
					default:
						dataGridViewGradebookReciver.Columns.Add(ColumnCreator.CreateColumnTextBox(Scheme[i].headerText, sortMode: sortMode, readOnly: readOnly));
						break;
				}
				
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
		static public DataGridViewTextBoxColumn CreateColumnTextBox(string headerText = "Name", DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.NotSortable, bool readOnly = false)
		{
			DataGridViewTextBoxColumn result = new DataGridViewTextBoxColumn();
			result.HeaderText = headerText;
			result.SortMode = sortMode;
			result.ReadOnly = readOnly;

			return result;
		}

		static public DataGridViewButtonColumn CreateColumnButton(string headerText = "Name")
		{
			DataGridViewButtonColumn result = new DataGridViewButtonColumn();
			result.HeaderText = headerText;

			return result;
		}

		static public DataGridViewComboBoxColumn CreateColumnComboBox(string headerText = "Name")
		{
			DataGridViewComboBoxColumn result = new DataGridViewComboBoxColumn();
			result.HeaderText = headerText;

			return result;
		}

		static public DataGridViewLinkColumn CreateColumnLink(string headerText = "Name")
		{
			DataGridViewLinkColumn result = new DataGridViewLinkColumn();
			result.HeaderText = headerText;

			return result;
		}

		static public DataGridViewImageColumn CreateColumnImage(string headerText = "Name")
		{
			DataGridViewImageColumn result = new DataGridViewImageColumn();
			result.HeaderText = headerText;

			return result;
		}

		static public DataGridViewCheckBoxColumn CreateColumnCheckBox(string headerText = "On", DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.NotSortable, int width = 70)
		{
			DataGridViewCheckBoxColumn result = new DataGridViewCheckBoxColumn();
			result.HeaderText = headerText;
			result.SortMode = sortMode;
			result.Width = width;

			return result;
		}
	}
}
