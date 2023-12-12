using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Electronic_School_Gradebook.Res.ExcelTools
{
	internal abstract class ExcelBase : IExcelBase
	{
		protected const string UID = "Excel.Application";
		protected object oExcel = null;
		protected object WorkBooks, WorkBook, WorkSheets, WorkSheet, Range, Interior;

		public ExcelBase()
		{
			oExcel = Activator.CreateInstance(Type.GetTypeFromProgID(UID));
		}

		//ВИДИМОСТЬ EXCEL - СВОЙСТВО КЛАССА
		public bool Visible
		{
			set
			{
				if (false == value)
					oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, oExcel, new object[] { false });

				else
					oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, oExcel, new object[] { true });
			}
		}

		//ОТКРЫТЬ ДОКУМЕНТ
		public void OpenDocument(string name)
		{
			WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
			WorkBook = WorkBooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, WorkBooks, new object[] { name, true });
			WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
			WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
			// Range = WorkSheet.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,WorkSheet,new object[1] { "A1" });
		}

        //Перегрузка метода OpenDocument(string name) для открытия в режиме "толлько для чтения"
        public void OpenDocument(string name, bool readOnly)
        {
            WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
            WorkBook = WorkBooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, WorkBooks, new object[] { name, readOnly });
            WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
        }

        //НОВЫЙ ДОКУМЕНТ
        public void NewDocument()
		{
			WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
			WorkBook = WorkBooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, WorkBooks, null);
			WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
			WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
			Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1" });
		}

        //Перегрузка метода NewDocument() для открытия документа в режиме "по умолчанию", открывается только нужная часть
        public void NewDocument(bool addDefaultSheet)
        {
            WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
            WorkBook = WorkBooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, WorkBooks, null);
            WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });

            if (addDefaultSheet)
            {
                Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1" });
            }
        }

        //ЗАКРЫТЬ ДОКУМЕНТ
        public void CloseDocument()
		{
			WorkBook.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, WorkBook, new object[] { true });
		}

        //Перегрузка метода CloseDocument() для автосохранения при закрытии документа
        public void CloseDocument(bool saveChanges)
        {
            WorkBook.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, WorkBook, new object[] { saveChanges });
        }

        //СОХРАНИТЬ ДОКУМЕНТ
        public void SaveDocument(string name)
		{
			if (File.Exists(name))
				WorkBook.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, null,
					WorkBook, null);
			else
				WorkBook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null,
					WorkBook, new object[] { name });
		}

        //Перегрузка метода SaveDocument(string name) для обеспечения перезаписи документа 
        public void SaveDocument(string name, bool overwrite)
        {
            if (File.Exists(name) && !overwrite)
            {
                WorkBook.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, null, WorkBook, null);
            }
            else
            {
                WorkBook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, WorkBook, new object[] { name });
            }
        }
    }
}
