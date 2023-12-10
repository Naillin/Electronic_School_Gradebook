using DatabaseTools_MSSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_School_Gradebook
{
	public partial class FormAdminPanel
	{
		struct UsersRowConnect
		{
			public int id;
			public int rowIndex;

			UsersRowConnect(int id = -1, int rowIndex = -1)
			{
				this.id = id;
				this.rowIndex = rowIndex;
			}
		}

		struct ClassesRowConnect
		{
			public int id;
			public int rowIndex;

			ClassesRowConnect(int id = -1, int rowIndex = -1)
			{
				this.id = id;
				this.rowIndex = rowIndex;
			}
		}

		struct StudentsRowConnect
		{
			public int id;
			public int rowIndex;
			public int idclass;
			public int iduser;

			StudentsRowConnect(int id = -1, int rowIndex = -1, int idclass = -1, int iduser = -1)
			{
				this.id = id;
				this.rowIndex = rowIndex;
				this.idclass = idclass;
				this.iduser = iduser;
			}
		}

		struct ParentsRowConnect
		{
			public int id;
			public int rowIndex;

			ParentsRowConnect(int id = -1, int rowIndex = -1)
			{
				this.id = id;
				this.rowIndex = rowIndex;
			}
		}

		struct TeachersRowConnect
		{
			public int id;
			public int iduser;
			public int rowIndex;

			TeachersRowConnect(int id = -1, int rowIndex = -1, int iduser = -1)
			{
				this.id = id;
				this.rowIndex = rowIndex;
				this.iduser = iduser;
			}
		}

		struct SubjectsRowConnect
		{
			public int id;
			public int rowIndex;

			SubjectsRowConnect(int id = -1, int rowIndex = -1)
			{
				this.id = id;
				this.rowIndex = rowIndex;
			}
		}

		private void buttonAddRecordClick()
		{
			DBTools dbTools = new DBTools(FormAuthorization.sqlConnection);

			switch (tabControlAtoms.SelectedTab.Name)
			{
				case "tabPageClasses":
					string[] classValues = new string[3];
					classValues[0] = "'Новый класс'";
					classValues[1] = "'0'";
					classValues[2] = "'0'";
					dbTools.executeInsert("Classes", classValues);
					break;
				case "tabPageStudents":
					string[] studentsValuesUser = new string[4];
					studentsValuesUser[0] = "'Роль'";
					studentsValuesUser[1] = "'Логин'";
					studentsValuesUser[2] = "'Пароль'";
					studentsValuesUser[3] = "'1'";
					dbTools.executeInsert("Users", studentsValuesUser);
					
					string[] studentsValues = new string[8];
					studentsValues[0] = "'Имя'";
					studentsValues[1] = "'Фамилия'";
					studentsValues[2] = "'Отчество'";
					studentsValues[3] = "'(000) 000-00-00'";
					studentsValues[4] = "'Адрес'";
					studentsValues[5] = "'email@example.com'";
					studentsValues[6] = "null";
					studentsValues[7] = dbTools.executeAnySqlScalar($"SELECT TOP (1) ID_User FROM Users ORDER BY ID_User DESC;").ToString();
					dbTools.executeInsert("Students", studentsValues);
					break;
				case "tabPageParents":
					string[] parentsValues = new string[6];
					parentsValues[0] = "'Имя'";
					parentsValues[1] = "'Фамилия'";
					parentsValues[2] = "'Отчество'";
					parentsValues[3] = "'(000) 000-00-00'";
					parentsValues[4] = "'Адрес'";
					parentsValues[5] = "'email@example.com'";
					dbTools.executeInsert("Parents", parentsValues);
					break;
				case "tabPageTeachers":
					string[] teachersValuesUser = new string[4];
					teachersValuesUser[0] = "'Роль'";
					teachersValuesUser[1] = "'Логин'";
					teachersValuesUser[2] = "'Пароль'";
					teachersValuesUser[3] = "'1'";
					dbTools.executeInsert("Users", teachersValuesUser);

					string[] teachersValues = new string[8];
					teachersValues[0] = "'Имя'";
					teachersValues[1] = "'Фамилия'";
					teachersValues[2] = "'Отчество'";
					teachersValues[3] = "'(000) 000-00-00'";
					teachersValues[4] = "'Адрес'";
					teachersValues[5] = "'email@example.com'";
					teachersValues[6] = "'1'";
					teachersValues[7] = dbTools.executeAnySqlScalar($"SELECT TOP (1) ID_User FROM Users ORDER BY ID_User DESC;").ToString();
					dbTools.executeInsert("Teachers", teachersValues);
					break;
				case "tabPageSubjects":
					string[] subjectsValues = new string[2];
					subjectsValues[0] = "'Новая дисциплина'";
					subjectsValues[1] = "'0'";
					dbTools.executeInsert("Subjects", subjectsValues);
					break;
			}

			FillDataGridViews();
		}

		private void buttonRemoveRecordClick()
		{
			DBTools dbTools = new DBTools(FormAuthorization.sqlConnection);

			switch (tabControlAtoms.SelectedTab.Name)
			{
				case "tabPageClasses":
					if (dataGridViewClasses.RowCount > 0)
					{
						DialogResult result = MessageBox.Show("Are you sure you want to delete this class?", "Confirmation", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							dbTools.executeDelete("Classes", $"WHERE ID_Class = {classesRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}");
							FillDataGridViews();
						}
					}
					break;
				case "tabPageStudents":
					if (dataGridViewStudents.RowCount > 0)
					{
						DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirmation", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							dbTools.executeDelete("Students", $"WHERE ID_Student = {studentsRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}");
							FillDataGridViews();
						}
					}
					break;
				case "tabPageParents":
					if (dataGridViewParents.RowCount > 0)
					{
						DialogResult result = MessageBox.Show("Are you sure you want to delete this parent?", "Confirmation", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							dbTools.executeDelete("Parents", $"WHERE ID_Parent = {parentsRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}");
							FillDataGridViews();
						}
					}
					break;
				case "tabPageTeachers":
					if (dataGridViewTeachers.RowCount > 0)
					{
						DialogResult result = MessageBox.Show("Are you sure you want to delete this teacher?", "Confirmation", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							dbTools.executeDelete("Teachers", $"WHERE ID_Teacher = {teachersRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}");
							FillDataGridViews();
						}
					}
					break;
				case "tabPageSubjects":
					if (dataGridViewSubjects.RowCount > 0)
					{
						DialogResult result = MessageBox.Show("Are you sure you want to delete this subject?", "Confirmation", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							dbTools.executeDelete("Subjects", $"WHERE ID_Subject = {subjectsRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}");
							FillDataGridViews();
						}
					}
					break;
			}
		}

		private DBFormsTools.RowConnect[] classesRowConnect;
		private DBFormsTools.RowConnect[] studentsRowConnect;
		private DBFormsTools.RowConnect[] parentsRowConnect;
		private DBFormsTools.RowConnect[] teachersRowConnect;
		private DBFormsTools.RowConnect[] subjectsRowConnect;
		private void FillDataGridViews()
		{
			DBFormsTools dbFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);

			switch (tabControlAtoms.SelectedTab.Name)
			{
				case "tabPageClasses":
					classesRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewClasses, "Classes");
					break;
				case "tabPageStudents":
					string[] fieldsStudents = { "Name_Student", "Surname_Student", "Thirdname_Student", "Number_Student", "Address_Student", "Email_Student", "Login_User", "Password_User", "LifeStatus" };
					studentsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewStudents, "Students", fieldsStudents, $"join Users on Users.ID_User = Students.ID_User");
					break;
				case "tabPageParents":
					parentsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewParents, "Parents");
					break;
				case "tabPageTeachers":
					string[] fieldsTeachers = { "Name_Teacher", "Surname_Teacher", "Thirdname_Teacher", "Number_Teacher", "Address_Teacher", "Email_Teacher", "Type_Of_Teacher", "Login_User", "Password_User", "LifeStatus" };
					teachersRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewTeachers, "Teachers", fieldsTeachers, $"join Users on Users.ID_User = Teachers.ID_User");
					break;
				case "tabPageSubjects":
					subjectsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewSubjects, "Subjects");
					break;
			}
		}

		private void FillDataGridViews(TabPage tabPage)
		{
			DBFormsTools dbFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);


			switch (tabPage.Name)
			{
				case "tabPageAtoms":
					classesRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewClasses, "Classes");
					break;
				case "tabPageClasses":
					classesRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewClasses, "Classes");
					break;
				case "tabPageStudents":
					string[] fieldsStudents = { "Name_Student", "Surname_Student", "Thirdname_Student", "Number_Student", "Address_Student", "Email_Student", "Login_User", "Password_User", "LifeStatus" };
					studentsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewStudents, "Students", fieldsStudents, $"join Users on Users.ID_User = Students.ID_User");
					break;
				case "tabPageParents":
					parentsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewParents, "Parents");
					break;
				case "tabPageTeachers":
					string[] fieldsTeachers = { "Name_Teacher", "Surname_Teacher", "Thirdname_Teacher", "Number_Teacher", "Address_Teacher", "Email_Teacher", "Type_Of_Teacher", "Login_User", "Password_User", "LifeStatus" };
					teachersRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewTeachers, "Teachers", fieldsTeachers, $"join Users on Users.ID_User = Teachers.ID_User");
					break;
				case "tabPageSubjects":
					subjectsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewSubjects, "Subjects");
					break;
			}
		}

		private void dataGridViewClassesCellEndEdit()
		{
			DBTools dbTools = new DBTools(FormAuthorization.sqlConnection);

			object newWriting = dataGridViewClasses.Rows[selectRow].Cells[selectColumn].Value;
			string columnName = dataGridViewClasses.Columns[selectColumn].Name;

			if (columnName == "Name_Class" && !System.Text.RegularExpressions.Regex.IsMatch(newWriting.ToString(), @"^[а-яА-Я0-9]+$"))
			{
				dataGridViewClasses.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
				MessageBox.Show("Only Russian characters and numbers are allowed for the Name of class field.");
			}
			else
			{
				string valueString = $"{columnName}='{newWriting}'";
				string conditionString = string.Empty;
				conditionString = $"WHERE ID_Class = {classesRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}";
				try
				{
					int result = dbTools.executeUpdate("Classes", valueString, conditionString);
				}
				catch (Exception ex)
				{
					dataGridViewClasses.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
					MessageBox.Show("An error occurred while updating the data: " + ex.Message);
				}
			}
		}

		private void dataGridViewStudentsCellEndEdit()
		{
			DBTools dbTools = new DBTools(FormAuthorization.sqlConnection);

			object newWriting = dataGridViewStudents.Rows[selectRow].Cells[selectColumn].Value;
			string columnName = dataGridViewStudents.Columns[selectColumn].Name;

			if (columnName == "Name_Student" && !System.Text.RegularExpressions.Regex.IsMatch(newWriting.ToString(), @"^[а-яА-Я]+$"))
			{
				dataGridViewStudents.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
				MessageBox.Show("Only Russian characters are allowed for the Name of student field.");
			}
			else
			{
				string userId = dbTools.executeAnySqlScalar($"select ID_User from Students where ID_Student = {studentsRowConnect[selectRow].idDataBase.ToString()}").ToString();
				switch (selectColumn)
				{
					case 6:
						dbTools.executeUpdate("Users", $"Login_User='{newWriting}';", $"WHERE ID_User = {userId}");
						break;
					case 7:
						dbTools.executeUpdate("Users", $"Password_User='{newWriting}'", $"WHERE ID_User = {userId}");
						break;
					case 8:
						dbTools.executeUpdate("Users", $"LifeStatus='{newWriting}'", $"WHERE ID_User = {userId}");
						break;
					default:
						string valueString = $"{columnName}='{newWriting}'";
						string conditionString = string.Empty;
						conditionString = $"WHERE ID_Student = {studentsRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}";

						int result = dbTools.executeUpdate("Students", valueString, conditionString);
						break;
				}
			}
		}

		private void dataGridViewTeachersCellEndEdit()
		{
			DBTools dbTools = new DBTools(FormAuthorization.sqlConnection);

			object newWriting = dataGridViewTeachers.Rows[selectRow].Cells[selectColumn].Value;
			string columnName = dataGridViewTeachers.Columns[selectColumn].Name;

			if (columnName == "Name_Teacher" && !System.Text.RegularExpressions.Regex.IsMatch(newWriting.ToString(), @"^[а-яА-Я]+$"))
			{
				dataGridViewTeachers.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
				MessageBox.Show("Only Russian characters are allowed for the Name of teacher field.");
			}
			else
			{
				string userId = dbTools.executeAnySqlScalar($"select ID_User from Teachers where ID_Teacher = {teachersRowConnect[selectRow].idDataBase.ToString()}").ToString();
				switch (selectColumn)
				{
					case 7:
						dbTools.executeUpdate("Users", $"Login_User='{newWriting}';", $"WHERE ID_User = {userId}");
						break;
					case 8:
						dbTools.executeUpdate("Users", $"Password_User='{newWriting}'", $"WHERE ID_User = {userId}");
						break;
					case 9:
						dbTools.executeUpdate("Users", $"LifeStatus='{newWriting}'", $"WHERE ID_User = {userId}");
						break;
					default:
						string valueString = $"{columnName}='{newWriting}'";
						string conditionString = string.Empty;
						conditionString = $"WHERE ID_Teacher = {teachersRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}";

						int result = dbTools.executeUpdate("Teachers", valueString, conditionString);
						break;
				}
			}
		}

		private void dataGridViewParentsCellEndEdit()
		{
			DBTools dbTools = new DBTools(FormAuthorization.sqlConnection);

			object newWriting = dataGridViewParents.Rows[selectRow].Cells[selectColumn].Value;
			string columnName = dataGridViewParents.Columns[selectColumn].Name;

			if (columnName == "Name_Parent" && !System.Text.RegularExpressions.Regex.IsMatch(newWriting.ToString(), @"^[а-яА-Я]+$"))
			{
				dataGridViewParents.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
				MessageBox.Show("Only Russian characters are allowed for the Name of parent field.");
			}
			else
			{
				string valueString = $"{columnName}='{newWriting}'";
				string conditionString = string.Empty;
				conditionString = $"WHERE ID_Parent = {parentsRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}";
				try
				{
					int result = dbTools.executeUpdate("Parents", valueString, conditionString);
				}
				catch (Exception ex)
				{
					dataGridViewParents.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
					MessageBox.Show("An error occurred while updating the data: " + ex.Message);
				}
			}
		}

		private void dataGridViewSubjectsCellEndEdit()
		{
			DBTools dbTools = new DBTools(FormAuthorization.sqlConnection);

			object newWriting = dataGridViewSubjects.Rows[selectRow].Cells[selectColumn].Value;
			string columnName = dataGridViewSubjects.Columns[selectColumn].Name;

			if (columnName == "Name_Subject" && !System.Text.RegularExpressions.Regex.IsMatch(newWriting.ToString(), @"^[а-яА-Я]+$"))
			{
				dataGridViewSubjects.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
				MessageBox.Show("Only Russian characters are allowed for the Name of subject field.");
			}
			else
			{
				string valueString = $"{columnName}='{newWriting}'";
				string conditionString = string.Empty;
				conditionString = $"WHERE ID_Subject = {subjectsRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}";
				try
				{
					int result = dbTools.executeUpdate("Subjects", valueString, conditionString);
				}
				catch (Exception ex)
				{
					dataGridViewSubjects.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
					MessageBox.Show("An error occurred while updating the data: " + ex.Message);
				}
			}
		}

		private void tabControlAtomsSelecting(TabPage tabPage)
		{
			switch (tabPage.Name)
			{
				case "tabPageClasses":
					buttonRemoveRecord.Enabled = true;
					break;
				case "tabPageStudents":
					buttonRemoveRecord.Enabled = false;
					break;
				case "tabPageParents":
					buttonRemoveRecord.Enabled = true;
					break;
				case "tabPageTeachers":
					buttonRemoveRecord.Enabled = false;
					break;
				case "tabPageSubjects":
					buttonRemoveRecord.Enabled = true;
					break;
			}
		}

		private void SearchDataClass(string searchText)
		{
			string columnNameToSearch = "Name_Class";
			foreach (DataGridViewRow row in dataGridViewClasses.Rows)
			{
				string cellValue = row.Cells[columnNameToSearch].Value?.ToString();
				bool match = cellValue != null && cellValue.Contains(searchText);
				row.Visible = match;
			}
		}

		private void SearchDataStudent(string searchText)
		{
			string columnNameToSearch = "Surname_Student";
			foreach (DataGridViewRow row in dataGridViewStudents.Rows)
			{
				string cellValue = row.Cells[columnNameToSearch].Value?.ToString();
				bool match = cellValue != null && cellValue.Contains(searchText);
				row.Visible = match;
			}
		}

		private void SearchDataParent(string searchText)
		{
			string columnNameToSearch = "Surname_Parent";
			foreach (DataGridViewRow row in dataGridViewParents.Rows)
			{
				string cellValue = row.Cells[columnNameToSearch].Value?.ToString();
				bool match = cellValue != null && cellValue.Contains(searchText);
				row.Visible = match;
			}
		}

		private void SearchDataTeacher(string searchText)
		{
			string columnNameToSearch = "Surname_Teacher";
			foreach (DataGridViewRow row in dataGridViewTeachers.Rows)
			{
				string cellValue = row.Cells[columnNameToSearch].Value?.ToString();
				bool match = cellValue != null && cellValue.Contains(searchText);
				row.Visible = match;
			}
		}

		private void SearchDataSubject(string searchText)
		{
			string columnNameToSearch = "Name_Subject";
			foreach (DataGridViewRow row in dataGridViewSubjects.Rows)
			{
				string cellValue = row.Cells[columnNameToSearch].Value?.ToString();
				bool match = cellValue != null && cellValue.Contains(searchText);
				row.Visible = match;
			}
		}
	}
}
