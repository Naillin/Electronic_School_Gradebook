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

        //Перегрузка метода SetValue(string range, string value) для автоматического преобразования в строчное значение 
        public void SetValue(string range, double value)
        {
            SetValue(range, value.ToString());
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

		//---------------------------------------------ПЕРЕГРУЗКИ МЕТОДОВ И ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ---------------------------------------\\

        //ПЕРЕГРУЗКА МЕТОДА SetColumnWidth
        //Установка ширины столбца по номеру
        public void SetColumnWidth(int columnIndex, double width)
        {
            string range = GetCellAddress(1, columnIndex); // Пример: столбец columnIndex, строка 1
            SetCellProperty(range, "ColumnWidth", width);
        }

        //ПЕРЕГРУЗКА МЕТОДА SetRowHeight
        //Установка высоты строки по номеру
        public void SetRowHeight(int rowIndex, double height)
        {
            string range = GetCellAddress(rowIndex, 1); // Пример: столбец 1, строка rowIndex
            SetCellProperty(range, "RowHeight", height);
        }

        //ПЕРЕГРУЗКА МЕТОДА SetVerticalAlignment
        //Установка вертикального выравнивания по номеру строки
        public void SetVerticalAlignment(int rowIndex, int alignment)
        {
            string range = GetCellAddress(rowIndex, 1); // Пример: столбец 1, строка rowIndex
            SetCellProperty(range, "VerticalAlignment", alignment);
        }

        //ПЕРЕГРУЗКА МЕТОДА SetHorisontalAlignment
        //Установка горизонтального выравнивания по номеру столбца
        public void SetHorisontalAlignment(int columnIndex, int alignment)
        {
            string range = GetCellAddress(1, columnIndex); // Пример: столбец columnIndex, строка 1
            SetCellProperty(range, "HorizontalAlignment", alignment);
        }

        //Вспомогательный метод для получения адреса ячейки
        private string GetCellAddress(int row, int column)
        {
            char columnChar = (char)('A' + column - 1);
            return $"{columnChar}{row}";
        }

        //Вспомогательный метод для установки свойства ячейки
        private void SetCellProperty(string range, string propertyName, object value)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });

            object[] args = new object[] { value };
            Range.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, Range, args);
        }
    }
}
