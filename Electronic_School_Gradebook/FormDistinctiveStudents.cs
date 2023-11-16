using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
//MS_Sql
using DatabaseTools_MSSQL;
//Excel
//using ExcelLib = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
//Media
using System.Media;
using System.Globalization;


namespace Electronic_School_Gradebook
{
	public partial class FormDistinctiveStudents : Form
	{
		int ID_Class = -1;
		int ID_Subject = -1;

		public FormDistinctiveStudents(int ID_Class, int ID_Subject)
		{
			InitializeComponent();

			this.ID_Class = ID_Class;
			this.ID_Subject = ID_Subject;

			//настройка формы
			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			//границы размеров
			//this.MaximumSize = new Size(10000, 10000);
			//this.MinimumSize = new Size(1200, 500);
		}


		private DBFormsTools.RowConnect[] studentsHighRowConnect;
		private DBFormsTools.RowConnect[] studentsLowRowConnect;
		private void FormDistinctiveStudents_Load(object sender, EventArgs e)
		{
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);

			//заполнение медалистами
			object[,] dataStudentsHigh = dBTools.executeSelectTable($"EXECUTE dbo.PerfectGradeStudents @ID_Class = {ID_Class}, @Сoefficient = 4.5;"); //поиск медалистов
			string strStudentsHigh = string.Join(", ", dataStudentsHigh.Cast<int>().ToArray());
			string[] fileds = { "Name_Student", "Surname_Student", "Thirdname_Student", "Number_Student", "Address_Student", "Email_Student" };
			studentsHighRowConnect = dBFormsTools.FillDGVWithRowConnect(ref dataGridViewGoldMedalContenders, "Students", fileds, $"where ID_Student in ({strStudentsHigh})");

			//заполнение двоечниками
			object[,] dataStudentsLow = dBTools.executeSelectTable($"EXECUTE dbo.LowGradeStudents @ID_Class = {ID_Class}, @ID_Subject = {ID_Subject}, @Coefficient = 3.0;"); //поиск неуспевающих
			string strStudentsLow = string.Join(", ", dataStudentsLow.Cast<int>().ToArray());
			//fileds = { "Name_Student", "Surname_Student", "Thirdname_Student", "Number_Student", "Address_Student", "Email_Student" };
			studentsLowRowConnect = dBFormsTools.FillDGVWithRowConnect(ref dataGridViewPoorStudetns, "Students", fileds, $"where ID_Student in ({strStudentsLow})");
		}

		//выбрали двоечника
		private void dataGridViewPoorStudetns_Click(object sender, EventArgs e)
		{
			DBFormsTools dBFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);

			string[] fileds = { "Name_Parent", "Surname_Parent", "Thirdname_Parent", "Number_Parent", "Address_Parent", "Email_Parent" };
			dBFormsTools.FillDGVWithRowConnect(ref dataGridViewParents, "Parents", fileds, $"join ParentToStud on ParentToStud.ID_Parent = Parents.ID_Parent join Students on Students.ID_Student = ParentToStud.ID_Student where Students.ID_Student = {studentsLowRowConnect[dataGridViewPoorStudetns.SelectedCells[0].RowIndex].idDataBase}");
		}
	}
}
