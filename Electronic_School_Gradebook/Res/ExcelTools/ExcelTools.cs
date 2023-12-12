using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Electronic_School_Gradebook.Res.ExcelTools;

namespace Electronic_School_Gradebook
{
	internal class ExcelTools : ExcelBase
	{
		//КОНСТРУКТОР КЛАССА
		public ExcelTools() : base()
		{
			oExcel = Activator.CreateInstance(Type.GetTypeFromProgID(UID));
		}

		//ЗАПИСАТЬ ЗНАЧЕНИЕ В ЯЧЕЙКУ
		public void SetValue(string range, string value)
		{
			Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
				null, WorkSheet, new object[] { range });
			Range.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range, new object[] { value });
		}

		//ОБЪЕДЕНИТЬ ЯЧЕЙКИ 
		//Alignment - ВЫРАВНИВАНИЕ В ОБЪЕДИНЕННЫХ ЯЧЕЙКАХ
		public void SetMerge(string range, int Alignment)
		{
			Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
				null, WorkSheet, new object[] { range });
			object[] args = new object[] { Alignment };
			Range.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, Range, new object[] { true });
			Range.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, null, Range, args);
		}

		//УСТАНОВИТЬ ОРИЕНТАЦИЮ СТРАНИЦЫ 
		//1 - КНИЖНЫЙ
		//2 - АЛЬБОМНЫЙ
		public void SetOrientation(int Orientation)
		{
			//Range.Interior.ColorIndex
			object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty, null, WorkSheet, null);

			PageSetup.GetType().InvokeMember("Orientation", BindingFlags.SetProperty, null, PageSetup, new object[] { Orientation });
		}

		//УСТАНОВИТЬ ШИРИНУ СТОЛБЦОВ
		public void SetColumnWidth(string range, double Width)
		{
			Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
				null, WorkSheet, new object[] { range });
			object[] args = new object[] { Width };
			Range.GetType().InvokeMember("ColumnWidth", BindingFlags.SetProperty, null, Range, args);
		}

		//УСТАНОВИТЬ ВЫСОТУ СТРОК
		public void SetRowHeight(string range, double Height)
		{
			Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
				null, WorkSheet, new object[] { range });
			object[] args = new object[] { Height };
			Range.GetType().InvokeMember("RowHeight", BindingFlags.SetProperty, null, Range, args);
		}

		//УСТАНОВИТЬ ВИД РАМКИ ВОКРУГ ЯЧЕЙКИ
		public void SetBorderStyle(string range, int Style)
		{
			Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
				null, WorkSheet, new object[] { range });
			object[] args = new object[] { 1 };
			object[] args1 = new object[] { 1 };
			object Borders = Range.GetType().InvokeMember("Borders", BindingFlags.GetProperty, null, Range, null);
			Borders = Range.GetType().InvokeMember("LineStyle", BindingFlags.SetProperty, null, Borders, args);
		}

		//ЧТЕНИЕ ДАННЫХ ИЗ ВЫБРАННОЙ ЯЧЕЙКИ
		public string GetValue(string range)
		{
			Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
				null, WorkSheet, new object[] { range });
			return Range.GetType().InvokeMember("Value", BindingFlags.GetProperty,
				null, Range, null).ToString();
		}

		//УСТАНОВИТЬ ВЫРАВНИВАНИЕ В ЯЧЕЙКЕ ПО ВЕРТИКАЛИ
		public void SetVerticalAlignment(string range, int Alignment)
		{
			Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
				null, WorkSheet, new object[] { range });
			object[] args = new object[] { Alignment };
			Range.GetType().InvokeMember("VerticalAlignment", BindingFlags.SetProperty, null, Range, args);
		}

		//УСТАНОВИТЬ ВЫРАВНИВАНИЕ В ЯЧЕЙКЕ ПО ГОРИЗОНТАЛИ
		public void SetHorisontalAlignment(string range, int Alignment)
		{
			Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
				null, WorkSheet, new object[] { range });
			object[] args = new object[] { Alignment };
			Range.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, null, Range, args);
		}
	}
}
