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
		private void buttonAddRecordClick()
		{
			DBTools dbTools = new DBTools(FormAuthorization.sqlConnection);

			switch (tabControlAtoms.SelectedTab.Name)
			{
				case "tabPageClasses":
					dbTools.executeInsert("Classes", new string[] { "'Новый класс'", "'0'", "'0'" });
					break;
				case "tabPageStudents":
					dbTools.executeInsert("Users", new string[] { "'Роль'", "'Логин'", "'Пароль'", "'1'" });
					dbTools.executeInsert("Students", new string[] { "'Имя'", "'Фамилия'", "'Отчество'", "'(000) 000-00-00'", "'Адрес'", "'email@example.com'", "null", dbTools.executeAnySqlScalar($"SELECT TOP (1) ID_User FROM Users ORDER BY ID_User DESC;").ToString() });
					break;
				case "tabPageParents":
					dbTools.executeInsert("Parents", new string[] { "'Имя'", "'Фамилия'", "'Отчество'", "'(000) 000-00-00'", "'Адрес'", "'email@example.com'"});
					break;
				case "tabPageTeachers":
					dbTools.executeInsert("Users", new string[] { "'Роль'", "'Логин'", "'Пароль'", "'1'" });
					dbTools.executeInsert("Teachers", new string[] { "'Имя'", "'Фамилия'", "'Отчество'", "'(000) 000-00-00'", "'Адрес'", "'email@example.com'", "'1'", dbTools.executeAnySqlScalar($"SELECT TOP (1) ID_User FROM Users ORDER BY ID_User DESC;").ToString() });
					break;
				case "tabPageSubjects":
					dbTools.executeInsert("Subjects", new string[] { "'Новая дисциплина'", "'0'" });
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


		//в отдельный класс все ниже что ниже-----------------------------------------
		//в отдельный класс все ниже что ниже-----------------------------------------
		//в отдельный класс все ниже что ниже-----------------------------------------
		//в отдельный класс все ниже что ниже-----------------------------------------
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
		//в отдельный класс все ниже что выше-----------------------------------------
		//в отдельный класс все ниже что выше-----------------------------------------
		//в отдельный класс все ниже что выше-----------------------------------------
		//в отдельный класс все ниже что выше-----------------------------------------
		//в отдельный класс все ниже что выше-----------------------------------------
	}
}
