using DatabaseTools_MSSQL;
using System;
using System.Collections.Generic;
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

			switch (tabControlAtoms.SelectedTab.Text)
			{
				case "Users":
					string[] userValues = new string[4];
					userValues[0] = "'Роль'";
					userValues[1] = "'Логин'";
					userValues[2] = "'Пароль'";
					userValues[3] = "'1'";
					dbTools.executeInsert("Users", userValues);
					break;
				case "Classes":
					string[] classValues = new string[3];
					classValues[0] = "'Новый класс'";
					classValues[1] = "'0'";
					classValues[2] = "'0'";
					dbTools.executeInsert("Classes", classValues);
					break;
				case "Students":
					string[] studentsValues = new string[6];
					studentsValues[0] = "'Фамилия'";
					studentsValues[1] = "'Имя'";
					studentsValues[2] = "'Отчество'";
					studentsValues[3] = "'(000) 000-00-00'";
					studentsValues[4] = "'Адрес'";
					studentsValues[5] = "'email@example.com'";
					dbTools.executeInsert("Students", studentsValues);
					break;
				case "Parents":
					string[] parentsValues = new string[6];
					parentsValues[0] = "'Фамилия'";
					parentsValues[1] = "'Имя'";
					parentsValues[2] = "'Отчество'";
					parentsValues[3] = "'(000) 000-00-00'";
					parentsValues[4] = "'Адрес'";
					parentsValues[5] = "'email@example.com'";
					dbTools.executeInsert("Parents", parentsValues);
					break;
				case "Teachers":
					string[] teachersValues = new string[7];
					teachersValues[0] = "'Фамилия'";
					teachersValues[1] = "'Имя'";
					teachersValues[2] = "'Отчество'";
					teachersValues[3] = "'(000) 000-00-00'";
					teachersValues[4] = "'Адрес'";
					teachersValues[5] = "'email@example.com'";
					teachersValues[6] = "'0'";
					dbTools.executeInsert("Students", teachersValues);
					break;
				case "Subjects":
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

			switch (tabControlAtoms.SelectedTab.Text)
			{
				case "Users":
					if (dataGridViewUsers.RowCount > 0)
					{
						DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							dbTools.executeDelete("Users", $"WHERE ID_User = {usersRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}");
							FillDataGridViews();
						}
					}
					break;
				case "Classes":
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
				case "Students":
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
				case "Parents":
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
				case "Teachers":
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
				case "Subjects":
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

        private DBFormsTools.RowConnect[] usersRowConnect;
        private DBFormsTools.RowConnect[] classesRowConnect;
		private DBFormsTools.RowConnect[] studentsRowConnect;
		private DBFormsTools.RowConnect[] parentsRowConnect;
		private DBFormsTools.RowConnect[] teachersRowConnect;
		private DBFormsTools.RowConnect[] subjectsRowConnect;

		private void FillDataGridViews()
		{
			DBFormsTools dbFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);

			switch (tabControlAtoms.SelectedTab.Text)
			{
				case "Users":
                    usersRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewUsers, "Users");
                    break;
				case "Classes":
					classesRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewClasses, "Classes");
					break;
				case "Students":
                    studentsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewStudents, "Students");
                    break;
				case "Parents":
                    parentsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewParents, "Parents");
                    break;
				case "Teachers":
                    teachersRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewTeachers, "Teachers");
                    break;
				case "Subjects":
                    subjectsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewSubjects, "Subjects");
                    break;
			}
		}

        private void StartFillDataGridViews(TabPage tabPage)
        {
            DBFormsTools dbFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);

            switch (tabPage.Name)
            {
                case "tabPageAtoms":
                    usersRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewUsers, "Users");
                    break;
                case "tabPageUsers":
                    usersRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewUsers, "Users");
                    break;
                case "tabPageClasses":
                    classesRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewClasses, "Classes");
                    break;
                case "tabPageStudents":
                    studentsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewStudents, "Students");
                    break;
                case "tabPageParents":
                    parentsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewParents, "Parents");
                    break;
                case "tabPageTeachers":
                    teachersRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewTeachers, "Teachers");
                    break;
                case "tabPageSubjects":
                    subjectsRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewSubjects, "Subjects");
                    break;
            }
        }

        private void dataGridViewUsersCellEndEdit()
		{
			DBTools dbTools = new DBTools(FormAuthorization.sqlConnection);

			object newWriting = dataGridViewUsers.Rows[selectRow].Cells[selectColumn].Value;
			string columnName = dataGridViewUsers.Columns[selectColumn].Name;

			if (columnName == "Role_User" && !System.Text.RegularExpressions.Regex.IsMatch(newWriting.ToString(), @"^[a-zA-Z]+$"))
			{
				dataGridViewUsers.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
				MessageBox.Show("Only Latian characters are allowed for the Role of user field."); // не надо выводить меседжбокс из за каждого символа. это супер не удобно. просто запрети не дай ввести такие символы. (можно сделать через получение объекта текстбокс и уже у него проверять водимые символы в реальном времени)
			}
			else
			{
				string valueString = $"{columnName}='{newWriting}'";
				string conditionString = string.Empty;
                conditionString = $"WHERE ID_User = {usersRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}";
                try
				{
					int result = dbTools.executeUpdate("Users", valueString, conditionString);
				}
				catch (Exception ex)
				{
					dataGridViewUsers.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
					MessageBox.Show("An error occurred while updating the data: " + ex.Message);
				}
			}
		}

		private void dataGridViewClassesCellEndEdit() // зачем второй метод проверки - сделай один универсальный. 
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
				string valueString = $"{columnName}='{newWriting}'";
				string conditionString = string.Empty;
                conditionString = $"WHERE ID_Student = {studentsRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}";
                try
				{
					int result = dbTools.executeUpdate("Students", valueString, conditionString);
				}
				catch (Exception ex)
				{
					dataGridViewStudents.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
					MessageBox.Show("An error occurred while updating the data: " + ex.Message);
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
				string valueString = $"{columnName}='{newWriting}'";
				string conditionString = string.Empty;
                conditionString = $"WHERE ID_Teacher = {teachersRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}";
                try
				{
					int result = dbTools.executeUpdate("Teachers", valueString, conditionString);
				}
				catch (Exception ex)
				{
					dataGridViewTeachers.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
					MessageBox.Show("An error occurred while updating the data: " + ex.Message);
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
	}
}
