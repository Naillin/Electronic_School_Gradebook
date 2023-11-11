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
					studentsValues[0] = "'Новый студент'";
					studentsValues[1] = "'Новый студент'";
					studentsValues[2] = "'Новый студент'";
					studentsValues[3] = "'(000) 000-00-00'";
					studentsValues[4] = "'Адрес'";
					studentsValues[5] = "'email@example.com'";
					dbTools.executeInsert("Students", studentsValues);
					break;
				case "Parents":
					string[] parentsValues = new string[6];
					parentsValues[0] = "'Новый родитель'";
					parentsValues[1] = "'Новый родитель'";
					parentsValues[2] = "'Новый родитель'";
					parentsValues[3] = "'(000) 000-00-00'";
					parentsValues[4] = "'Адрес'";
					parentsValues[5] = "'email@example.com'";
					dbTools.executeInsert("Parents", parentsValues);
					break;
				case "Teachers":
					string[] teachersValues = new string[7];
					teachersValues[0] = "'Новый учитель'";
					teachersValues[1] = "'Новый учитель'";
					teachersValues[2] = "'Новый учитель'";
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

			if (tabControlAtoms.SelectedTab.Text == "Students") //переделать if\else\elseif под switch\case
			{
				if (dataGridViewStudents.SelectedRows.Count > 0) 
				{
					DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirmation", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						int studentID = Convert.ToInt32(dataGridViewStudents.SelectedRows[0].Cells[0].Value);

						dbTools.executeDelete("Students", $"WHERE ID_Student = {studentID}");

						FillDataGridViews();
					}
				}
			}
			else if (tabControlAtoms.SelectedTab.Text == "Teachers") //переделать if\else\elseif под switch\case
			{
				if (dataGridViewTeachers.SelectedRows.Count > 0)
				{
					DialogResult result = MessageBox.Show("Are you sure you want to delete this teacher?", "Confirmation", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						int teacherID = Convert.ToInt32(dataGridViewTeachers.SelectedRows[0].Cells[0].Value);

						dbTools.executeDelete("Teachers", $"WHERE ID_Teacher = {teacherID}");

						FillDataGridViews();
					}
				}
			}




			///ПЕРЕДЕЛАТЬ ВСЕ ТЕЛА УСЛОВИЙ КАК ТОТ ЧТО НИЖЕ
			else if (tabControlAtoms.SelectedTab.Text == "Classes") //переделать if\else\elseif под switch\case
			{
				if (dataGridViewClasses.RowCount > 0)
				{
					DialogResult result = MessageBox.Show("Are you sure you want to delete this class?", "Confirmation", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						dbTools.executeDelete("Classes", $"WHERE ID_Class = {classesRowConnect[(selectRow == -1) ? 0 : selectRow].idDataBase}");
						FillDataGridViews();
					}
				}
			}
			///ПЕРЕДЕЛАТЬ ВСЕ ТЕЛА УСЛОВИЙ КАК ТОТ ЧТО ВЫШЕ
			///





		}

		private UsersRowConnect[] usersRowConnect;
		//private ClassesRowConnect[] classesRowConnect;
		private DBFormsTools.RowConnect[] classesRowConnect;
		private StudentsRowConnect[] studentsRowConnect;
		private ParentsRowConnect[] parentsRowConnect;
		private TeachersRowConnect[] teachersRowConnect;
		private SubjectsRowConnect[] subjectsRowConnect;
		private void FillDataGridViews(bool flag = false)
		{
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			DBFormsTools dbFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);

			switch (flag ? string.Empty : tabControlAtoms.SelectedTab.Text)
			{
				case "Users":
					dataGridViewUsers.Rows.Clear();
					object[,] dataUsers = dBTools.executeSelectTable($"SELECT ID_User, Role_User, Login_User, Password_User, LifeStatus FROM Users");
					usersRowConnect = new UsersRowConnect[dataUsers.GetLength(0)];
					for (int i = 0; i < dataUsers.GetLength(0); i++)
					{
						dataGridViewUsers.Rows.Add(dataUsers[i, 1].ToString(), dataUsers[i, 2].ToString(), dataUsers[i, 3].ToString(), (bool)dataUsers[i, 4]);
						usersRowConnect[i].id = (int)dataUsers[i, 0];
						usersRowConnect[i].rowIndex = i;
					}
					break;



				///ПЕРЕДЕЛАТЬ ВСЕ ТЕЛА УСЛОВИЙ КАК ТОТ ЧТО НИЖЕ
				case "Classes":
					classesRowConnect = dbFormsTools.FillDGVWithRowConnect(ref dataGridViewClasses, "Classes");

					break;
				///ПЕРЕДЕЛАТЬ ВСЕ ТЕЛА УСЛОВИЙ КАК ТОТ ЧТО ВЫШЕ



				case "Students":
					dataGridViewStudents.Rows.Clear();
					object[,] dataStudents = dBTools.executeSelectTable($"SELECT ID_Student, Name_Student, Surname_Student, Thirdname_Student, Number_Student, Address_Student, Email_Student, ID_Class, ID_User FROM Students");
					studentsRowConnect = new StudentsRowConnect[dataStudents.GetLength(0)];
					for (int i = 0; i < dataStudents.GetLength(0); i++)
					{
						dataGridViewStudents.Rows.Add(dataStudents[i, 1].ToString(), dataStudents[i, 2].ToString(), dataStudents[i, 3].ToString(), dataStudents[i, 4].ToString(), dataStudents[i, 5].ToString(), dataStudents[i, 6].ToString());
						studentsRowConnect[i].id = (int)dataStudents[i, 0];
						studentsRowConnect[i].idclass = (int)dataStudents[i, 7];
						studentsRowConnect[i].iduser = (int)dataStudents[i, 8];
						studentsRowConnect[i].rowIndex = i;
					}
					break;
				case "Parents":
					dataGridViewParents.Rows.Clear();
					object[,] dataParents = dBTools.executeSelectTable($"SELECT ID_Parent, Name_Parent, Surname_Parent, Thirdname_Parent, Number_Parent, Address_Parent, Email_Parent FROM Parents");
					parentsRowConnect = new ParentsRowConnect[dataParents.GetLength(0)];
					for (int i = 0; i < dataParents.GetLength(0); i++)
					{
						dataGridViewParents.Rows.Add(dataParents[i, 1].ToString(), dataParents[i, 2].ToString(), dataParents[i, 3].ToString(), dataParents[i, 4].ToString(), dataParents[i, 5].ToString(), dataParents[i, 6].ToString());
						parentsRowConnect[i].id = (int)dataParents[i, 0];
						parentsRowConnect[i].rowIndex = i;
					}
					break;
				case "Teachers":
					dataGridViewTeachers.Rows.Clear();
					object[,] dataTeachers = dBTools.executeSelectTable($"SELECT ID_Teacher, Name_Teacher, Surname_Teacher, Thirdname_Teacher, Number_Teacher, Address_Teacher, Email_Teacher, Type_Of_Teacher, ID_User FROM Teachers");
					teachersRowConnect = new TeachersRowConnect[dataTeachers.GetLength(0)];
					for (int i = 0; i < dataTeachers.GetLength(0); i++)
					{
						dataGridViewTeachers.Rows.Add(dataTeachers[i, 1].ToString(), dataTeachers[i, 2].ToString(), dataTeachers[i, 3].ToString(), dataTeachers[i, 4].ToString(), dataTeachers[i, 5].ToString(), dataTeachers[i, 6].ToString(), (bool)dataTeachers[i, 7]);
						teachersRowConnect[i].id = (int)dataTeachers[i, 0];
						teachersRowConnect[i].iduser = (int)dataTeachers[i, 8];
						teachersRowConnect[i].rowIndex = i;
					}
					break;
				case "Subjects":
					dataGridViewSubjects.Rows.Clear();
					object[,] dataSubjects = dBTools.executeSelectTable($"SELECT ID_Subject, Name_Subject, Type_Of_Subject FROM Subjects");
					subjectsRowConnect = new SubjectsRowConnect[dataSubjects.GetLength(0)];
					for (int i = 0; i < dataSubjects.GetLength(0); i++)
					{
						dataGridViewSubjects.Rows.Add(dataSubjects[i, 1].ToString(), (bool)dataSubjects[i, 2]);
						subjectsRowConnect[i].id = (int)dataSubjects[i, 0];
						subjectsRowConnect[i].rowIndex = i;
					}
					break;
				default:

					break;
			}
		}

		private void RefreshAllThisDataGridView() //мы не используем dataSource
		{
			DBFormsTools dbFormsTools = new DBFormsTools(FormAuthorization.sqlConnection);

			dbFormsTools.FillDGV(ref dataGridViewUsers, "Users");//мы не используем dataSource

			dbFormsTools.FillDGV(ref dataGridViewStudents, "Students");//мы не используем dataSource

			dbFormsTools.FillDGV(ref dataGridViewTeachers, "Teachers");//мы не используем dataSource

			//string[] classfieldsValues = new string[3];
			//classfieldsValues[0] = "Name_Class";
			//classfieldsValues[1] = "Type_Of_Class";
			//classfieldsValues[2] = "Count_Students";
			//dbFormsTools.FillDGV(ref dataGridViewClasses, "Classes", classfieldsValues);
			//dbFormsTools.FillDGV(ref dataGridViewClasses, "Classes");

			//string[] parentsfieldsValues = new string[6];
			//parentsfieldsValues[0] = "Name_Parent";
			//parentsfieldsValues[1] = "Surname_Parent";
			//parentsfieldsValues[2] = "Thirdname_Parent";
			//parentsfieldsValues[3] = "Number_Parent";
			//parentsfieldsValues[4] = "Address_Parent";
			//parentsfieldsValues[5] = "Email_Parent";
			//dbFormsTools.FillDGV(ref dataGridViewParents, "Parents", parentsfieldsValues);
			dbFormsTools.FillDGV(ref dataGridViewParents, "Parents");//мы не используем dataSource

			dbFormsTools.FillDGV(ref dataGridViewSubjects, "Subjects");//мы не используем dataSource
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
				for (int i = 0; i < usersRowConnect.Length; i++)
				{
					if (usersRowConnect[i].rowIndex == selectRow)
					{
						conditionString = $"WHERE ID_User = {usersRowConnect[i].id}";
						break;
					}
				}
				try
				{
					int result = dbTools.executeUpdate("Users", valueString, conditionString);
					if (result > 0)
					{
						FillDataGridViews();
					}
				}
				catch (Exception ex)
				{
					dataGridViewUsers.Rows[selectRow].Cells[selectColumn].Value = oldWriting;
					MessageBox.Show("An error occurred while updating the data: " + ex.Message);
				}
			}
		}

		private void dataGridViewClassesCellEndEdit() // зачем второй метод проверки - сделай один универсальный
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
				buttonAddRecord.Text = selectRow.ToString();
				//int result = dbTools.executeUpdate("Classes", valueString, conditionString);
				//FillDataGridViews();
				try
				{
					int result = dbTools.executeUpdate("Classes", valueString, conditionString);
					if (result > 0) // неплохо, молодец
					{
						//FillDataGridViews(); // не надо обновлять дгв после обновления записи. данные дгв и так соответсвуют последней версии. а так ты будешь ловить ошибку установки значения потому что редактирование ячейки не изменилось а мой метод попытался очистить для тебя дгв(удали эту строку вообще)
					}
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
				for (int i = 0; i < studentsRowConnect.Length; i++)
				{
					if (studentsRowConnect[i].rowIndex == selectRow)
					{
						conditionString = $"WHERE ID_Student = {studentsRowConnect[i].id}";
						break;
					}
				}
				try
				{
					int result = dbTools.executeUpdate("Students", valueString, conditionString);
					if (result > 0)
					{
						FillDataGridViews();
					}
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
				for (int i = 0; i < teachersRowConnect.Length; i++)
				{
					if (teachersRowConnect[i].rowIndex == selectRow)
					{
						conditionString = $"WHERE ID_Teacher = {teachersRowConnect[i].id}";
						break;
					}
				}
				try
				{
					int result = dbTools.executeUpdate("Teachers", valueString, conditionString);
					if (result > 0)
					{
						FillDataGridViews();
					}
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
				for (int i = 0; i < parentsRowConnect.Length; i++)
				{
					if (parentsRowConnect[i].rowIndex == selectRow)
					{
						conditionString = $"WHERE ID_Parent = {parentsRowConnect[i].id}";
						break;
					}
				}
				try
				{
					int result = dbTools.executeUpdate("Parents", valueString, conditionString);
					if (result > 0)
					{
						FillDataGridViews();
					}
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
				for (int i = 0; i < subjectsRowConnect.Length; i++)
				{
					if (subjectsRowConnect[i].rowIndex == selectRow)
					{
						conditionString = $"WHERE ID_Subject = {subjectsRowConnect[i].id}";
						break;
					}
				}
				try
				{
					int result = dbTools.executeUpdate("Subjects", valueString, conditionString);
					if (result > 0)
					{
						FillDataGridViews();
					}
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
