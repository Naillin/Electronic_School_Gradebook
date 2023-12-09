using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_School_Gradebook.Res.ExcelTools
{
	internal interface IExcelBase
	{
		//ВИДИМОСТЬ EXCEL - СВОЙСТВО КЛАССА
		bool Visible { set; }

		//ОТКРЫТЬ ДОКУМЕНТ
		void OpenDocument(string name);

		//НОВЫЙ ДОКУМЕНТ
		void NewDocument();

		//ЗАКРЫТЬ ДОКУМЕНТ
		void CloseDocument();

		//СОХРАНИТЬ ДОКУМЕНТ
		void SaveDocument(string name);
	}
}
