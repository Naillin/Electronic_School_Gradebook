using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//MS_Sql
using DatabaseTools_MSSQL;
//Excel
//using Excel1 = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
//Media
using System.Media;
using System.Diagnostics;

namespace Electronic_School_Gradebook
{
	public partial class FormAdminPanel : Form
	{
		public FormAdminPanel()
		{
			InitializeComponent();

			///-----------------------------------------СРЕДА ОБЩЕГО КОДА|НАЧАЛО-----------------------------------------
			//настройка формы
			//this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			//границы размеров
			this.MaximumSize = new Size(this.Width, this.Height);
			this.MinimumSize = new Size(this.Width, this.Height);

			//заполнение notifyIconInfoUser
			notifyIconInfoUser.Text = "Active user as admin";
			notifyIconInfoUser.BalloonTipText = "Welcome!";
			notifyIconInfoUser.MouseClick += notifyIconInfoUser_MouseClick;
			notifyIconInfoUser.ShowBalloonTip(12);
			///-----------------------------------------СРЕДА ОБЩЕГО КОДА|КОНЕЦ-----------------------------------------
			///-----------------------------------------ГАЗИЗОВА САБИНА|НАЧАЛО-----------------------------------------
			textBoxSearch.Enabled = false;
			checkBoxOnlyRelated.Enabled = false;
			///-----------------------------------------ГАЗИЗОВА САБИНА|КОНЕЦ-----------------------------------------
		}


		///-----------------------------------------ГАЗИЗОВА САБИНА|НАЧАЛО-----------------------------------------
		//структура для хранения связи узлов с элементами бд
		struct NodeConnect
		{
			public enum Types
			{
				NONE = 0,
				TEACHER = 1,
				STUDENT = 2,
				CLASS = 3,
				SUBJECT = 4,
				PARENT = 5
			}

			public TreeNode node;
			public int id;
			public Types type;

			public NodeConnect(TreeNode node = null, int id = -1, Types type = Types.NONE)
			{
				this.node = node;
				this.id = id;
				this.type = type;
			}
		}
		public struct InfRowConnect
		{
			public int id;
			public int rowIndex_dgvInf;
		}

		InfRowConnect[] rowConnectDgvInf;

		NodeConnect[] nodeConnects; 
		private void FormAdminPanel_Load(object sender, EventArgs e)
		{
			treeViewMainCommunications.Nodes.Clear();
			
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			object[,] data = dBTools.executeSelectTable($"select ID_Class, Name_Class from Classes;");

			TreeNode[] treeClasses = new TreeNode[data.GetLength(0)];

			if (radioButtonStudents.Checked)
			{
				int countClasses = dBTools.countRows("Classes");
				int countStudents = dBTools.countRows("Students", "join Users on Users.ID_User = Students.ID_User where Users.LifeStatus = 1");
				int countParent = dBTools.countRows("Parents");
				int koeffStud = 0;
				int koeffPar = 0;

				nodeConnects = new NodeConnect[countClasses + countStudents+ countParent];
				for (int i = 0;  i < treeClasses.Length; i++)
				{
					object[,] dataStudents = dBTools.executeSelectTable($"select ID_Student, Name_Student,Surname_Student from Students where ID_Class = {data[i, 0]}");

					TreeNode[] treeStudents = new TreeNode[dataStudents.GetLength(0)];
				
					for (int j = 0, l = countClasses+koeffStud; j < dataStudents.GetLength(0); l++, j++)
					{
						object[,] dataParent = dBTools.executeSelectTable($"SELECT A.ID_Parent, A.Name_Parent, A.Surname_Parent from Parents A JOIN ParentToStud B on A.ID_Parent = B.ID_ParentToStud join Students C on B.ID_Student = C.ID_Student where C.ID_Student = {dataStudents[j,0]}");
						TreeNode[] treeParent = new TreeNode[dataParent.GetLength(0)];

						for (int k = 0, z=countClasses+countStudents+koeffPar; k < dataParent.GetLength(0);z++, k++)
						{
							treeParent[k] = new TreeNode((dataParent[k, 2] + " " + dataParent[k, 1]).ToString()); treeParent[k].ImageIndex = 3;
							nodeConnects[z].node = treeParent[k];
							nodeConnects[z].id = (int)dataParent[k, 0];
							nodeConnects[z].type = NodeConnect.Types.PARENT;
							koeffPar++;
						}
					
						treeStudents[j] = new TreeNode((dataStudents[j, 2] + " " + dataStudents[j, 1]).ToString(), treeParent); treeStudents[j].ImageIndex = 1;
						nodeConnects[l].node = treeStudents[j];
						nodeConnects[l].id = (int)dataStudents[j, 0];
						nodeConnects[l].type = NodeConnect.Types.STUDENT;
						koeffStud++;
					}

					treeClasses[i] = new TreeNode(data[i, 1].ToString(), treeStudents); treeClasses[i].ImageIndex = 2;
					nodeConnects[i].node = treeClasses[i];
					nodeConnects[i].id = (int)data[i, 0];
					nodeConnects[i].type = NodeConnect.Types.CLASS;
					treeViewMainCommunications.Nodes.Add(treeClasses[i]);
				}


			}
			else
			{
				int countClasses = dBTools.countRows("Classes");
				//int countTeachers = dBTools.countRows("TeachToClass", "join Users on Users.ID_User = Teachers.ID_User where Users.LifeStatus = 1");
				int countTeachers = dBTools.countRows("TeachToClass");
				int countSubj = dBTools.countRows("TeachToSubj");
				int countClassss = dBTools.countRows("Classes");
				int countSubjjjj = dBTools.countRows("Subjects");
				int koeffTeach = 0;
				//int koeffSubj = 0;

				nodeConnects = new NodeConnect[countClasses + countTeachers+ countSubj + countClassss + countSubjjjj];
				for (int i = 0;  i < treeClasses.Length;i++)
				{
					object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher, A.Name_Teacher, A.Surname_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {data[i, 0]}");

					TreeNode[] treeTeach = new TreeNode[dataTeachers.GetLength(0)];

                    for (int j = 0, l = countClasses + koeffTeach; j < dataTeachers.GetLength(0); l++, j++)
                    {
                        //                   object[,] dataSubj = dBTools.executeSelectTable($"select A.ID_Subject, A.Name_Subject from Subjects A join TeachToSubj B on A.ID_Subject = B.ID_Subject WHERE B.ID_Teacher = {dataTeachers[j, 0]}");
                        //                   TreeNode[] treeSubj = new TreeNode[dataSubj.GetLength(0)];
                        //                   for (int k = 0, z = countClasses + countTeachers + koeffSubj; k < dataSubj.GetLength(0); z++, k++)
                        //                   {
                        //                       treeSubj[k] = new TreeNode((dataSubj[k, 1]).ToString());
                        //                       nodeConnects[z].node = treeSubj[k];
                        //                       nodeConnects[z].id = (int)dataSubj[k, 0];
                        //                       nodeConnects[z].type = NodeConnect.Types.SUBJECT;
                        //                       koeffSubj++;
                        //                   }

                        //treeTeach[j] = new TreeNode((dataTeachers[j, 2] + " " + dataTeachers[j, 1]).ToString(), treeSubj);
                        treeTeach[j] = new TreeNode((dataTeachers[j, 2] + " " + dataTeachers[j, 1]).ToString()); treeTeach[j].ImageIndex = 0;
						nodeConnects[l].node = treeTeach[j];
						nodeConnects[l].id = (int)dataTeachers[j, 0];
						nodeConnects[l].type = NodeConnect.Types.TEACHER;
						koeffTeach++;
					}

					treeClasses[i] = new TreeNode(data[i, 1].ToString(), treeTeach); treeClasses[i].ImageIndex = 2;
					nodeConnects[i].node = treeClasses[i];
					nodeConnects[i].id = (int)data[i, 0];
					nodeConnects[i].type = NodeConnect.Types.CLASS;
					treeViewMainCommunications.Nodes.Add(treeClasses[i]);
				}
			}
		}

		//переключили студентов
		private void radioButtonStudents_CheckedChanged(object sender, EventArgs e)
		{
			textBoxSearch.Text = string.Empty;
			textBoxSearch.Enabled = false;
			checkBoxOnlyRelated.Checked = false;
			checkBoxOnlyRelated.Enabled = false;
			
			dataGridViewInformation.Rows.Clear();
			dataGridViewInformation.Columns.Clear();
			FormAdminPanel_Load(sender, e);
		}

		private void radioButtonTeachers_CheckedChanged(object sender, EventArgs e)
		{
			textBoxSearch.Text = string.Empty;
			textBoxSearch.Enabled = false;
			checkBoxOnlyRelated.Checked = false;
			checkBoxOnlyRelated.Enabled = false;

			dataGridViewInformation.Rows.Clear();
			dataGridViewInformation.Columns.Clear();
			FormAdminPanel_Load(sender, e);
		}


		NodeConnect.Types tableType = NodeConnect.Types.NONE;
		private void dataGridViewInformationFill()
		{
			int BDid = 0;
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);

			for (int i = 0; i < nodeConnects.Length; i++)
			{
				if (treeViewMainCommunications.SelectedNode == nodeConnects[i].node)
				{
					BDid = nodeConnects[i].id;
					tableType = nodeConnects[i].type;

				}
			}


			rowConnectDgvInf = null;
			dataGridViewInformation.Rows.Clear();
			dataGridViewInformation.Columns.Clear();
			DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			dataGridViewCheckBoxColumn.HeaderText = "On";
			dataGridViewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewCheckBoxColumn.Width = 70;
			dataGridViewInformation.Columns.Add(dataGridViewCheckBoxColumn);
			
			//switch case (по типу таблицы)
			switch (tableType)
			{
				case NodeConnect.Types.CLASS:

					if (radioButtonStudents.Checked)
					{

						object[,] dataStudents = null;
						object[,] dataStudentsAll = null;


						DataGridViewTextBoxColumn dataGridViewTextBoxColumnStudSurname = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnStudSurname.HeaderText = "Surname";
						dataGridViewTextBoxColumnStudSurname.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnStudSurname.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnStudName = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnStudName.HeaderText = "Name";
						dataGridViewTextBoxColumnStudName.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnStudName.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnStudThirdName = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnStudThirdName.HeaderText = "Third Name";
						dataGridViewTextBoxColumnStudThirdName.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnStudThirdName.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnStudNumber = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnStudNumber.HeaderText = "Number";
						dataGridViewTextBoxColumnStudNumber.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnStudNumber.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnStudAddress = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnStudAddress.HeaderText = "Address";
						dataGridViewTextBoxColumnStudAddress.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnStudAddress.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnStudEmail = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnStudEmail.HeaderText = "Email";
						dataGridViewTextBoxColumnStudEmail.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnStudEmail.ReadOnly = true;


						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudSurname);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudName);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudThirdName);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudNumber);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudAddress);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudEmail);

						dataGridViewCheckBoxColumn.Width = 50;

						if (textBoxSearch.Text == "")
						{
							dataStudents = dBTools.executeSelectTable($"select ID_Student,Surname_Student, Name_Student,  Thirdname_Student, Number_Student, Address_Student, Email_Student from Students where ID_Class = {BDid}");
							dataStudentsAll = dBTools.executeSelectTable($"select ID_Student,Surname_Student, Name_Student,  Thirdname_Student, Number_Student, Address_Student, Email_Student from Students where ID_Class is null");
						}
						else
						{
							dataStudents = dBTools.executeSelectTable($"select ID_Student,Surname_Student, Name_Student,  Thirdname_Student, Number_Student, Address_Student, Email_Student from Students where ID_Class = {BDid} and Surname_Student like '{textBoxSearch.Text}%'");
							dataStudentsAll = dBTools.executeSelectTable($"select ID_Student,Surname_Student, Name_Student,  Thirdname_Student, Number_Student, Address_Student, Email_Student from Students where ID_Class is null and Surname_Student like '{textBoxSearch.Text}%'");
						}
						rowConnectDgvInf = new InfRowConnect[dataStudents.GetLength(0) + dataStudentsAll.GetLength(0)];
						if (checkBoxOnlyRelated.Checked)
						{
							for (int i = 0; i < dataStudents.GetLength(0); i++)
							{
								dataGridViewInformation.Rows.Add(true, dataStudents[i, 1], dataStudents[i, 2], dataStudents[i, 3], dataStudents[i, 4], dataStudents[i, 5], dataStudents[i, 6]);
								rowConnectDgvInf[i].id = (int)dataStudents[i, 0];
								rowConnectDgvInf[i].rowIndex_dgvInf = i;

							}
						}
						else
						{
							for (int i = 0; i < dataStudents.GetLength(0); i++)
							{
								dataGridViewInformation.Rows.Add(true, dataStudents[i, 1], dataStudents[i, 2], dataStudents[i, 3], dataStudents[i, 4], dataStudents[i, 5], dataStudents[i, 6]);
								rowConnectDgvInf[i].id = (int)dataStudents[i, 0];
								rowConnectDgvInf[i].rowIndex_dgvInf = i;
							}
							for (int i =dataStudents.GetLength(0), j = 0; i < dataStudents.GetLength(0) + dataStudentsAll.GetLength(0); i++, j++)
							{
								dataGridViewInformation.Rows.Add(false, dataStudentsAll[j, 1], dataStudentsAll[j, 2], dataStudentsAll[j, 3], dataStudentsAll[j, 4], dataStudentsAll[j, 5], dataStudentsAll[j, 6]);
								rowConnectDgvInf[i].id = (int)dataStudentsAll[j, 0];
								rowConnectDgvInf[i].rowIndex_dgvInf = i;
							}
						}
					}
					if (radioButtonTeachers.Checked)
					{
						object[,] dataTeachers = null;
						object[,] dataTeachersAll = null;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnTeachSurname = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnTeachSurname.HeaderText = "Surname";
						dataGridViewTextBoxColumnTeachSurname.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnTeachSurname.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnTeachName = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnTeachName.HeaderText = "Name";
						dataGridViewTextBoxColumnTeachName.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnTeachName.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnTeachThirdName = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnTeachThirdName.HeaderText = "Third Name";
						dataGridViewTextBoxColumnTeachThirdName.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnTeachThirdName.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnTeachNumber = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnTeachNumber.HeaderText = "Number";
						dataGridViewTextBoxColumnTeachNumber.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnTeachNumber.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnTeachAddress = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnTeachAddress.HeaderText = "Address";
						dataGridViewTextBoxColumnTeachAddress.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnTeachAddress.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnTeachEmail = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnTeachEmail.HeaderText = "Email";
						dataGridViewTextBoxColumnTeachEmail.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnTeachEmail.ReadOnly = true;

						DataGridViewTextBoxColumn dataGridViewTextBoxColumnTeachType = new DataGridViewTextBoxColumn();
						dataGridViewTextBoxColumnTeachType.HeaderText = "Type";
						dataGridViewTextBoxColumnTeachType.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewTextBoxColumnTeachType.ReadOnly = true;

						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachSurname);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachName);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachThirdName);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachNumber);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachAddress);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachEmail);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachType);

						dataGridViewCheckBoxColumn.Width = 50;

						if (textBoxSearch.Text == "")
						{
							dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher,A.Surname_Teacher, A.Name_Teacher,  A.Thirdname_Teacher, A.Number_Teacher, A.Address_Teacher, A.Email_Teacher, A.Type_Of_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {BDid}");
							dataTeachersAll = dBTools.executeSelectTable($" SELECT distinct(A.Surname_Teacher),A.ID_Teacher, A.Name_Teacher,  A.Thirdname_Teacher, A.Number_Teacher, A.Address_Teacher, A.Email_Teacher, A.Type_Of_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher where  B.ID_Class! = {BDid} AND B.ID_Teacher NOT IN(SELECT ID_Teacher from TeachToClass D WHERE D.ID_Class = {BDid})");
						}
						else
						{
							dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher,A.Surname_Teacher, A.Name_Teacher,  A.Thirdname_Teacher, A.Number_Teacher, A.Address_Teacher, A.Email_Teacher, A.Type_Of_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {BDid} and A.Surname_Teacher like '{textBoxSearch.Text}%'");
							dataTeachersAll = dBTools.executeSelectTable($" SELECT distinct(A.Surname_Teacher),A.ID_Teacher, A.Name_Teacher,  A.Thirdname_Teacher, A.Number_Teacher, A.Address_Teacher, A.Email_Teacher, A.Type_Of_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher where  B.ID_Class! = {BDid} and A.Surname_Teacher like '{textBoxSearch.Text}%' AND B.ID_Teacher NOT IN(SELECT ID_Teacher from TeachToClass D WHERE D.ID_Class = {BDid})");
						}
						rowConnectDgvInf = new InfRowConnect[dataTeachers.GetLength(0) + dataTeachersAll.GetLength(0)];
						if (checkBoxOnlyRelated.Checked)
						{
							for (int i = 0; i < dataTeachers.GetLength(0); i++)
							{
								if ((bool)dataTeachers[i, 7] == false)
								{
									dataGridViewInformation.Rows.Add(true, dataTeachers[i, 1], dataTeachers[i, 2], dataTeachers[i, 3], dataTeachers[i, 4], dataTeachers[i, 5], dataTeachers[i, 6], "преподаватель младшей школы");
									rowConnectDgvInf[i].id = (int)dataTeachers[i, 0];
									rowConnectDgvInf[i].rowIndex_dgvInf = i;
								}
								else
								{
									dataGridViewInformation.Rows.Add(true, dataTeachers[i, 1], dataTeachers[i, 2], dataTeachers[i, 3], dataTeachers[i, 4], dataTeachers[i, 5], dataTeachers[i, 6], "преподаватель старшей школы");
									rowConnectDgvInf[i].id = (int)dataTeachers[i, 0];
									rowConnectDgvInf[i].rowIndex_dgvInf = i;
								}
							}
						}
						else
						{
							for (int i = 0; i < dataTeachers.GetLength(0); i++)
							{
								if ((bool)dataTeachers[i, 7] == false)
								{
									dataGridViewInformation.Rows.Add(true, dataTeachers[i, 1], dataTeachers[i, 2], dataTeachers[i, 3], dataTeachers[i, 4], dataTeachers[i, 5], dataTeachers[i, 6], "преподаватель младшей школы");
									rowConnectDgvInf[i].id = (int)dataTeachers[i, 0];
									rowConnectDgvInf[i].rowIndex_dgvInf = i;
								}
								else
								{
									dataGridViewInformation.Rows.Add(true, dataTeachers[i, 1], dataTeachers[i, 2], dataTeachers[i, 3], dataTeachers[i, 4], dataTeachers[i, 5], dataTeachers[i, 6], "преподаватель старшей школы");
									rowConnectDgvInf[i].id = (int)dataTeachers[i, 0];
									rowConnectDgvInf[i].rowIndex_dgvInf = i;
								}
							}
							for (int i = dataTeachers.GetLength(0), j= 0; i < dataTeachers.GetLength(0) + dataTeachersAll.GetLength(0);j++, i++)
							{
								if ((bool)dataTeachersAll[j, 7] == false)
								{
									dataGridViewInformation.Rows.Add(false, dataTeachersAll[j, 0], dataTeachersAll[j, 2], dataTeachersAll[j, 3], dataTeachersAll[j, 4], dataTeachersAll[j, 5], dataTeachersAll[j, 6], "преподаватель малдшей школы");
									rowConnectDgvInf[i].id = (int)dataTeachersAll[j, 1];
									rowConnectDgvInf[i].rowIndex_dgvInf = i;
								}
								else
								{
									dataGridViewInformation.Rows.Add(false, dataTeachersAll[j, 0], dataTeachersAll[j, 2], dataTeachersAll[j, 3], dataTeachersAll[j, 4], dataTeachersAll[j, 5], dataTeachersAll[j, 6], "преподаватель старшей школы");
									rowConnectDgvInf[i].id = (int)dataTeachersAll[j, 1];
									rowConnectDgvInf[i].rowIndex_dgvInf = i;
								}
							}
						}
					}

					break;

				case NodeConnect.Types.STUDENT:

					DataGridViewTextBoxColumn dataGridViewTextBoxColumnParSurname = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumnParSurname.HeaderText = "Surname";
					dataGridViewTextBoxColumnParSurname.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewTextBoxColumnParSurname.ReadOnly = true;

					DataGridViewTextBoxColumn dataGridViewTextBoxColumnParName = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumnParName.HeaderText = "Name";
					dataGridViewTextBoxColumnParName.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewTextBoxColumnParName.ReadOnly = true;

					DataGridViewTextBoxColumn dataGridViewTextBoxColumnParThirdName = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumnParThirdName.HeaderText = "Third Name";
					dataGridViewTextBoxColumnParThirdName.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewTextBoxColumnParThirdName.ReadOnly = true;

					DataGridViewTextBoxColumn dataGridViewTextBoxColumnParNumber = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumnParNumber.HeaderText = "Number";
					dataGridViewTextBoxColumnParNumber.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewTextBoxColumnParNumber.ReadOnly = true;

					DataGridViewTextBoxColumn dataGridViewTextBoxColumnParAddress = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumnParAddress.HeaderText = "Address";
					dataGridViewTextBoxColumnParAddress.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewTextBoxColumnParAddress.ReadOnly = true;

					DataGridViewTextBoxColumn dataGridViewTextBoxColumnParEmail = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumnParEmail.HeaderText = "Email";
					dataGridViewTextBoxColumnParEmail.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewTextBoxColumnParEmail.ReadOnly = true;

					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParSurname);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParName);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParThirdName);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParNumber);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParAddress);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParEmail);

					dataGridViewCheckBoxColumn.Width = 50;

					object[,] dataParent = null;
					object[,] dataParentAll = null;
					if (textBoxSearch.Text == "")
					{
						dataParent = dBTools.executeSelectTable($"SELECT A.ID_Parent,A.Surname_Parent, A.Name_Parent, A.Thirdname_Parent, A.Number_Parent, A.Address_Parent, A.Email_Parent  from Parents A JOIN ParentToStud B on A.ID_Parent = B.ID_ParentToStud join Students C on B.ID_Student = C.ID_Student where C.ID_Student = {BDid}");
						dataParentAll = dBTools.executeSelectTable($"SELECT A.ID_Parent, A.Surname_Parent, A.Name_Parent, A.Thirdname_Parent, A.Number_Parent, A.Address_Parent, A.Email_Parent from Parents A JOIN ParentToStud B on A.ID_Parent = B.ID_ParentToStud join Students C on B.ID_Student = C.ID_Student where NOT C.ID_Student = {BDid}");
					}
					else
					{
						dataParent = dBTools.executeSelectTable($"SELECT A.ID_Parent,A.Surname_Parent, A.Name_Parent, A.Thirdname_Parent, A.Number_Parent, A.Address_Parent, A.Email_Parent  from Parents A JOIN ParentToStud B on A.ID_Parent = B.ID_ParentToStud join Students C on B.ID_Student = C.ID_Student where C.ID_Student = {BDid} and A.Surname_Parent LIKE '{textBoxSearch.Text}%'");
						dataParentAll = dBTools.executeSelectTable($"SELECT A.ID_Parent, A.Surname_Parent, A.Name_Parent, A.Thirdname_Parent, A.Number_Parent, A.Address_Parent, A.Email_Parent from Parents A JOIN ParentToStud B on A.ID_Parent = B.ID_ParentToStud join Students C on B.ID_Student = C.ID_Student where NOT C.ID_Student = {BDid} and A.Surname_Parent LIKE '{textBoxSearch.Text}%'");
					}
					rowConnectDgvInf = new InfRowConnect[dataParent.GetLength(0) + dataParentAll.GetLength(0)];
					if (checkBoxOnlyRelated.Checked)
					{
						for (int i = 0; i < dataParent.GetLength(0); i++)
						{
							dataGridViewInformation.Rows.Add(true, dataParent[i, 1], dataParent[i, 2], dataParent[i, 3], dataParent[i, 4], dataParent[i, 5], dataParent[i, 6]);
							rowConnectDgvInf[i].id = (int)dataParent[i, 0];
							rowConnectDgvInf[i].rowIndex_dgvInf = i;
						}
					}
					else
					{
						for (int i = 0; i < dataParent.GetLength(0); i++)
						{
							dataGridViewInformation.Rows.Add(true, dataParent[i, 1], dataParent[i, 2], dataParent[i, 3], dataParent[i, 4], dataParent[i, 5], dataParent[i, 6]);
							rowConnectDgvInf[i].id = (int)dataParent[i, 0];
							rowConnectDgvInf[i].rowIndex_dgvInf = i;
						}
						for (int i = dataParent.GetLength(0), j=0; i < dataParent.GetLength(0) + dataParentAll.GetLength(0);j++, i++)
						{
							dataGridViewInformation.Rows.Add(false, dataParentAll[j, 1], dataParentAll[j, 2], dataParentAll[j, 3], dataParentAll[j, 4], dataParentAll[j, 5], dataParentAll[j, 6]);
							rowConnectDgvInf[i].id = (int)dataParentAll[j, 0];
							rowConnectDgvInf[i].rowIndex_dgvInf = i;
						}
					}

					break;

				case NodeConnect.Types.TEACHER:
					object[,] data = dBTools.executeSelectTable($"select ID_Class, Name_Class from Classes;");

					DataGridViewTextBoxColumn dataGridViewTextBoxColumnSubjName = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumnSubjName.HeaderText = "Name";
					dataGridViewTextBoxColumnSubjName.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewTextBoxColumnSubjName.ReadOnly = true;

					DataGridViewTextBoxColumn dataGridViewTextBoxColumnSubjType = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumnSubjType.HeaderText = "Type";
					dataGridViewTextBoxColumnSubjType.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewTextBoxColumnSubjType.ReadOnly = true;

					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnSubjName);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnSubjType);

					dataGridViewCheckBoxColumn.Width = 50;

					object[,] dataSubj = null;
					object[,] dataSubjAll = null;

					if (textBoxSearch.Text == "") ///////////////////////////////////////////////////////////////////////////////////
					{
						for (int i = 0; i < data.GetLength(0); i++)
						{
							dataSubj = dBTools.executeSelectTable($"select A.ID_Subject, A.Name_Subject,A.Type_Of_Subject from Subjects A join TeachToSubj B on A.ID_Subject = B.ID_Subject JOIN Teachers C ON B.ID_Teacher = C.ID_Teacher JOIN TeachToClass D ON C.ID_Teacher = D.ID_Teacher join Classes E on D.ID_Class = E.ID_Class WHERE C.ID_Teacher = {BDid} AND D.ID_Class = {data[i, 0]}");
							if (dataSubj.GetLength(0) != 0) break;
						}
						dataSubjAll = dBTools.executeSelectTable($"  select  distinct (A.Name_Subject), A.ID_Subject, A.Type_Of_Subject from Subjects A join TeachToSubj B on A.ID_Subject = B.ID_Subject WHERE B.ID_Teacher != {BDid} AND B.ID_Subject NOT IN(SELECT ID_Subject from TeachToSubj D WHERE D.ID_Teacher = {BDid})");
					}
					else
					{
						for (int i = 0; i < data.GetLength(0); i++)
						{
							dataSubj = dBTools.executeSelectTable($"select A.ID_Subject, A.Name_Subject,A.Type_Of_Subject from Subjects A join TeachToSubj B on A.ID_Subject = B.ID_Subject JOIN Teachers C ON B.ID_Teacher = C.ID_Teacher JOIN TeachToClass D ON C.ID_Teacher = D.ID_Teacher join Classes E on D.ID_Class = E.ID_Class WHERE C.ID_Teacher = {BDid} AND D.ID_Class = {data[i, 0]} and A.Name_Subject like '{textBoxSearch.Text}%'");
							if (dataSubj.GetLength(0) != 0) break;
						}
						dataSubjAll = dBTools.executeSelectTable($"  select  distinct (A.Name_Subject), A.ID_Subject, A.Type_Of_Subject from Subjects A join TeachToSubj B on A.ID_Subject = B.ID_Subject WHERE B.ID_Teacher != {BDid} and A.Name_Subject like '{textBoxSearch.Text}%' AND B.ID_Subject NOT IN(SELECT ID_Subject from TeachToSubj D WHERE D.ID_Teacher = {BDid})");
					}
					rowConnectDgvInf = new InfRowConnect[dataSubj.GetLength(0) + dataSubjAll.GetLength(0)];
					if (checkBoxOnlyRelated.Checked)
					{
						for (int j = 0; j < dataSubj.GetLength(0); j++)
						{
							if ((bool)dataSubj[j, 2] == false)
							{
								dataGridViewInformation.Rows.Add(true, dataSubj[j, 1], "младшая школа");
								rowConnectDgvInf[j].id = (int)dataSubj[j, 0];
								rowConnectDgvInf[j].rowIndex_dgvInf = j;
							}
							else if ((bool)dataSubj[j, 2] == true)
							{
								dataGridViewInformation.Rows.Add(true, dataSubj[j, 1], "старшая школа");
								rowConnectDgvInf[j].id = (int)dataSubj[j, 0];
								rowConnectDgvInf[j].rowIndex_dgvInf = j;
							}
						}

					}
					else
					{
						for (int j = 0; j < dataSubj.GetLength(0); j++) 
						{
							if ((bool)dataSubj[j, 2] == false)
							{
								dataGridViewInformation.Rows.Add(true, dataSubj[j, 1], "младшая школа");
								rowConnectDgvInf[j].id = (int)dataSubj[j, 0];
								rowConnectDgvInf[j].rowIndex_dgvInf = j;
							}
							else if ((bool)dataSubj[j, 2] == true)
							{
								dataGridViewInformation.Rows.Add(true, dataSubj[j, 1], "старшая школа");
								rowConnectDgvInf[j].id = (int)dataSubj[j, 0];
								rowConnectDgvInf[j].rowIndex_dgvInf = j;
							}
						}
						for (int j = 0, z= dataSubj.GetLength(0); z < dataSubj.GetLength(0) + dataSubjAll.GetLength(0); z++, j++)
						{
							if ((bool)dataSubjAll[j, 2] == false)
							{
								dataGridViewInformation.Rows.Add(false, dataSubjAll[j, 0], "младшая школа");
								rowConnectDgvInf[z].id = (int)dataSubjAll[j, 1];
								rowConnectDgvInf[z].rowIndex_dgvInf = z;
							}
							else if ((bool)dataSubjAll[j, 2] == true)
							{
								dataGridViewInformation.Rows.Add(false, dataSubjAll[j, 0], "старшая школа");
								rowConnectDgvInf[z].id = (int)dataSubjAll[j, 1];
								rowConnectDgvInf[z].rowIndex_dgvInf = z;
							}

						}

					}


					break;
				case NodeConnect.Types.SUBJECT:
					dataGridViewInformation.Rows.Clear();
					dataGridViewInformation.Columns.Clear();
					rowConnectDgvInf = null;
					break;

				case NodeConnect.Types.PARENT:
					dataGridViewInformation.Rows.Clear();
					dataGridViewInformation.Columns.Clear();
					rowConnectDgvInf = null;
					break;

				default:
					break;

			}
		}
		private void treeViewMainCommunications_AfterSelect(object sender, TreeViewEventArgs e)
		{
			textBoxSearch.Enabled = true;
			checkBoxOnlyRelated.Enabled = true;
			dataGridViewInformationFill();
		}
		private void checkBoxOnlyRelated_CheckedChanged(object sender, EventArgs e)
		{
			dataGridViewInformationFill();
		}
		private void textBoxSearch_TextChanged(object sender, EventArgs e)
		{
			dataGridViewInformationFill();
		}

		private void dataGridViewInformation_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);

			int BDid = 0;
			
			switch (tableType)
			{
				case NodeConnect.Types.CLASS:
					if (radioButtonStudents.Checked)
					{
                        if ((bool)dataGridViewInformation.SelectedCells[0].Value)
                        {
							for (int i = 0; i < nodeConnects.Length; i++)
							{
								if (treeViewMainCommunications.SelectedNode == nodeConnects[i].node)
								{
									BDid = nodeConnects[i].id;
								}
							}
							int ID_Student = 0;
							for (int i = 0; i < rowConnectDgvInf.Length; i++)
							{
								if (rowConnectDgvInf[i].rowIndex_dgvInf == dataGridViewInformation.SelectedCells[0].RowIndex)
								{
									ID_Student = rowConnectDgvInf[i].id;
									break;
								}
							}

							//update
							dBTools.executeUpdate("Students", $"ID_Class = {BDid.ToString()}", $"where ID_Student = {ID_Student.ToString()}");
						}
						else
                        {
							int ID_Student = 0;
							for (int i = 0; i < rowConnectDgvInf.Length; i++)
							{
								if (rowConnectDgvInf[i].rowIndex_dgvInf == dataGridViewInformation.SelectedCells[0].RowIndex)
								{
									ID_Student = rowConnectDgvInf[i].id;
									break;
								}
							}

							//update
							dBTools.executeUpdate("Students", $"ID_Class = null", $"where ID_Student = {ID_Student.ToString()}");
						}
					}
					if (radioButtonTeachers.Checked)
					{
						if ((bool)dataGridViewInformation.Rows[dataGridViewInformation.SelectedCells[0].RowIndex].Cells[0].Value)
						{

							for (int i = 0; i < nodeConnects.Length; i++)
							{
								if (treeViewMainCommunications.SelectedNode == nodeConnects[i].node)
								{
									BDid = nodeConnects[i].id;
								}
							}
							int ID_Teacher = 0;
							for (int i = 0; i < rowConnectDgvInf.Length; i++)
							{
								if (rowConnectDgvInf[i].rowIndex_dgvInf == dataGridViewInformation.SelectedCells[0].RowIndex)
								{
									ID_Teacher = rowConnectDgvInf[i].id;
									break;
								}
							}
							try
							{
								//insert
								string[] valuesTeach = { ID_Teacher.ToString(), BDid.ToString() };
								dBTools.executeInsert("TeachToClass", valuesTeach);
							}
                            catch
                            {
								dataGridViewInformation.Rows[dataGridViewInformation.SelectedCells[0].RowIndex].Cells[0].Value = false;
							}
						}
                        else
                        {
							for (int i = 0; i < nodeConnects.Length; i++)
							{
								if (treeViewMainCommunications.SelectedNode == nodeConnects[i].node)
								{
									BDid = nodeConnects[i].id;
								}
							}
							int ID_Teacher = 0;
							for (int i = 0; i < rowConnectDgvInf.Length; i++)
							{
								if (rowConnectDgvInf[i].rowIndex_dgvInf == dataGridViewInformation.SelectedCells[0].RowIndex)
								{
									ID_Teacher = rowConnectDgvInf[i].id;
									break;
								}
							}
							//delete
							dBTools.executeDelete("TeachToClass", $"where ID_Teacher={ID_Teacher.ToString()} and ID_Class={BDid}");
						}
					}
					break;

				case NodeConnect.Types.STUDENT:
                    if ((bool)dataGridViewInformation.Rows[dataGridViewInformation.SelectedCells[0].RowIndex].Cells[0].Value)
					{
						
						for (int i = 0; i < nodeConnects.Length; i++)
						{
							if (treeViewMainCommunications.SelectedNode == nodeConnects[i].node)
							{
								BDid = nodeConnects[i].id;
							}
						}
						int ID_Parent = 0;
						for (int i = 0; i < rowConnectDgvInf.Length; i++)
						{
							if (rowConnectDgvInf[i].rowIndex_dgvInf == dataGridViewInformation.SelectedCells[0].RowIndex)
							{
								ID_Parent = rowConnectDgvInf[i].id;
								break;
							}
						}
                        try
                        {   //insert
                            string[] values = { BDid.ToString(), ID_Parent.ToString() };
                            dBTools.executeInsert("ParentToStud", values);
                        }
                        catch
                        {
							dataGridViewInformation.Rows[dataGridViewInformation.SelectedCells[0].RowIndex].Cells[0].Value = false;
                        }
                    }
                    else
                    {
						for(int i = 0; i < nodeConnects.Length; i++)
						{
							if (treeViewMainCommunications.SelectedNode == nodeConnects[i].node)
							{
								BDid = nodeConnects[i].id;
							}
						}
						int ID_Parent = 0;
						for (int i = 0; i < rowConnectDgvInf.Length; i++)
						{
							if (rowConnectDgvInf[i].rowIndex_dgvInf == dataGridViewInformation.SelectedCells[0].RowIndex)
							{
								ID_Parent = rowConnectDgvInf[i].id;
								break;
							}
						}
						dBTools.executeDelete("ParentToStud", $"where ID_Parent={ID_Parent.ToString()} and ID_Student={BDid}");
					}
					break;

				case NodeConnect.Types.TEACHER:
					if ((bool)dataGridViewInformation.SelectedCells[0].Value)
					{
						for (int i = 0; i < nodeConnects.Length; i++)
						{
							if (treeViewMainCommunications.SelectedNode == nodeConnects[i].node)
							{
								BDid = nodeConnects[i].id;
							}
						}
						int ID_Subject = 0;
						for (int i = 0; i < rowConnectDgvInf.Length; i++)
						{
							if (rowConnectDgvInf[i].rowIndex_dgvInf == dataGridViewInformation.SelectedCells[0].RowIndex)
							{
								ID_Subject = rowConnectDgvInf[i].id;
								break;
							}
						}

						//insert
						string[] values1 = { BDid.ToString(), ID_Subject.ToString() };
						dBTools.executeInsert("TeachToSubj", values1);
					}
                    else
                    {
						for(int i = 0; i < nodeConnects.Length; i++)
						{
							if (treeViewMainCommunications.SelectedNode == nodeConnects[i].node)
							{
								BDid = nodeConnects[i].id;
							}
						}
						int ID_Subject = 0;
						for (int i = 0; i < rowConnectDgvInf.Length; i++)
						{
							if (rowConnectDgvInf[i].rowIndex_dgvInf == dataGridViewInformation.SelectedCells[0].RowIndex)
							{
								ID_Subject = rowConnectDgvInf[i].id;
								break;
							}
						}
						dBTools.executeDelete("TeachToSubj", $"where ID_Subject={ID_Subject.ToString()} and ID_Teacher={BDid}");
					}
					break;
			}
		}
		///-----------------------------------------ГАЗИЗОВА САБИНА|КОНЕЦ-----------------------------------------

		///-----------------------------------------ХАСИЯТУЛИН КАМИЛЬ|НАЧАЛО-----------------------------------------
		//клик по тултипу в туллах
		private void notifyIconInfoUser_MouseClick(object sender, MouseEventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
		}

		//перезапуск для открытия окна входа
		private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("Electronic_School_Gradebook.exe");
			Environment.Exit(0);
		}

		//exit
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		//exit
		private void FormAdminPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}

        ///-----------------------------------------ХАСИЯТУЛИН КАМИЛЬ|КОНЕЦ-----------------------------------------

        ///-----------------------------------------ШАПОШНИКОВ СЕРГЕЙ|НАЧАЛО----------------------------------------

        int selectRow = -1;
        int selectColumn = -1;
        object oldWriting = null;
        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            buttonAddRecordClick();
        }

        private void buttonRemoveRecord_Click(object sender, EventArgs e)
        {
            buttonRemoveRecordClick();
        }
																			/// БЛЯТЬ СЕРГЕЙ СДЕЛАЙ ТАКИЕ ДЛЯ ВСЕХ
		private void dataGridViewClasses_Click(object sender, EventArgs e) // Сергей - добавь такие для всех дгв
		{
			selectRow = dataGridViewClasses.SelectedCells[0].RowIndex;
			selectColumn = dataGridViewClasses.SelectedCells[0].ColumnIndex;
			oldWriting = dataGridViewClasses.Rows[selectRow].Cells[selectColumn].Value;

			labelSelectedRecord.Text = "Selected record: " + dataGridViewClasses.Rows[selectRow].Cells[0].Value.ToString(); // сделай такие для всех методов, где получаешь selectRow selectColumn. в таблицах студентов, родителей, учителей, выводи фамилии.
		}

		private void dataGridViewClasses_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectRow = dataGridViewClasses.SelectedCells[0].RowIndex;
            selectColumn = dataGridViewClasses.SelectedCells[0].ColumnIndex;
            oldWriting = dataGridViewClasses.Rows[selectRow].Cells[selectColumn].Value;
        }

        private void dataGridViewClasses_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
			dataGridViewClassesCellEndEdit();
        }

        private void dataGridViewStudents_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectRow = dataGridViewStudents.SelectedCells[0].RowIndex;
            selectColumn = dataGridViewStudents.SelectedCells[0].ColumnIndex;
            oldWriting = dataGridViewStudents.Rows[selectRow].Cells[selectColumn].Value;
        }

        private void dataGridViewStudents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewStudentsCellEndEdit();
        }

        private void dataGridViewParents_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectRow = dataGridViewParents.SelectedCells[0].RowIndex;
            selectColumn = dataGridViewParents.SelectedCells[0].ColumnIndex;
            oldWriting = dataGridViewParents.Rows[selectRow].Cells[selectColumn].Value;
        }

        private void dataGridViewParents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewParentsCellEndEdit();
        }

        private void dataGridViewTeachers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectRow = dataGridViewTeachers.SelectedCells[0].RowIndex;
            selectColumn = dataGridViewTeachers.SelectedCells[0].ColumnIndex;
            oldWriting = dataGridViewTeachers.Rows[selectRow].Cells[selectColumn].Value;
        }

        private void dataGridViewTeachers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewTeachersCellEndEdit();
        }

        private void dataGridViewSubjects_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            selectRow = dataGridViewSubjects.SelectedCells[0].RowIndex;
            selectColumn = dataGridViewSubjects.SelectedCells[0].ColumnIndex;
            oldWriting = dataGridViewSubjects.Rows[selectRow].Cells[selectColumn].Value;
        }

        private void dataGridViewSubjects_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewSubjectsCellEndEdit();
        }

        private void tabControlAtoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTabPage = tabControlAtoms.SelectedTab;

            if (selectedTabPage == tabPageClasses ||
                selectedTabPage == tabPageStudents ||
                selectedTabPage == tabPageParents ||
                selectedTabPage == tabPageTeachers ||
                selectedTabPage == tabPageSubjects)
            {
                StartFillDataGridViews(selectedTabPage);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTabConrolPage = tabControl1.SelectedTab;

            if (selectedTabConrolPage == tabPageAtoms)
            {
                StartFillDataGridViews(selectedTabConrolPage);
            }
        }

        private void tabControlAtoms_Selecting(object sender, TabControlCancelEventArgs e)
        {
			TabPage selectingTabPage = tabControlAtoms.SelectedTab;

            tabControlAtomsSelecting(selectingTabPage);
        }

        ///-----------------------------------------ШАПОШНИКОВ СЕРГЕЙ|КОНЕЦ-----------------------------------------
    }
}
