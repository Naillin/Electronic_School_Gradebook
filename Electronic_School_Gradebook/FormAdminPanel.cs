﻿using System;
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
			this.DoubleBuffered = true;
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

		NodeConnect[] nodeConnects; 
		private void FormAdminPanel_Load(object sender, EventArgs e)
		{
			treeViewMainCommunications.Nodes.Clear();
			
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			object[,] data = dBTools.executeSelectTable($"select ID_Class, Name_Class from Classes;");

			TreeNode[] treeClasses = new TreeNode[data.GetLength(0)];


			if (checkBoxStudents.Checked && checkBoxTeachers.Checked)
			{
				int countClasses = dBTools.countRows("Classes");
				int countStudents = dBTools.countRows("Students", "join Users on Users.ID_User = Students.ID_User where Users.LifeStatus = 1");
				int countTeachers = dBTools.countRows("Teachers", "join Users on Users.ID_User = Teachers.ID_User where Users.LifeStatus = 1");
				int countParent = dBTools.countRows("Parents");
				int countSubj = dBTools.countRows("Subjects");

				nodeConnects = new NodeConnect[countClasses + countStudents + countTeachers + countParent+ countSubj];

				for (int i = 0, l = nodeConnects.Length - 1; i < treeClasses.Length;l=l-4, i++)
				{
					object[,] dataStudents = dBTools.executeSelectTable($"select ID_Student, Name_Student, Surname_Student from Students where ID_Class = {data[i, 0]}");
					object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher, A.Name_Teacher, A.Surname_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {data[i, 0]}");


					TreeNode[] treeStudentsTeach = new TreeNode[dataStudents.GetLength(0) + dataTeachers.GetLength(0)];

					for (int j = 0 ; j < dataStudents.GetLength(0); j++)
					{
						object[,] dataParent = dBTools.executeSelectTable($"SELECT A.ID_Parent, A.Name_Parent, A.Surname_Parent from Parents A JOIN ParentToStud B on A.ID_Parent = B.ID_ParentToStud join Students C on B.ID_Student = C.ID_Student where C.ID_Student = {dataStudents[j,0]}");
						TreeNode[] treeParent = new TreeNode[dataParent.GetLength(0)];

						for(int k = 0 ; k < dataParent.GetLength(0); k++)
                        {
                            treeParent[k] = new TreeNode((dataParent[k,2] + " " +  dataParent[k,1]).ToString());
							nodeConnects[l-2].node = treeParent[k];
							nodeConnects[l-2].id = (int)dataParent[k, 0];
							nodeConnects[l-2].type = NodeConnect.Types.PARENT;
						}

						treeStudentsTeach[j] = new TreeNode((dataStudents[j, 2] + " " + dataStudents[j, 1]).ToString(), treeParent);
						nodeConnects[l].node = treeStudentsTeach[j];
						nodeConnects[l].id = (int)dataStudents[j, 0];
						nodeConnects[l].type = NodeConnect.Types.STUDENT;

					}

					for (int k = dataStudents.GetLength(0), z = 0; k < treeStudentsTeach.Length; z++, k++)
					{
						object[,] dataSubj = dBTools.executeSelectTable($"select A.ID_Subject, A.Name_Subject from Subjects A join TeachToSubj B on A.ID_Subject = B.ID_Subject JOIN Teachers C ON B.ID_Teacher = C.ID_Teacher JOIN TeachToClass D ON C.ID_Teacher = D.ID_Teacher join Classes E on D.ID_Class = E.ID_Class WHERE C.ID_Teacher = {dataTeachers[z, 0]} AND D.ID_Class = {data[i, 0]}");
						TreeNode[] treeSubj = new TreeNode[dataSubj.GetLength(0)];

						for (int j = 0; j < dataSubj.GetLength(0); j++)
                        {
							treeSubj[j] = new TreeNode((dataSubj[j, 1]).ToString());
							nodeConnects[l - 3].node = treeSubj[j];
							nodeConnects[l - 3].id = (int)dataSubj[j, 0];
							nodeConnects[l - 3].type = NodeConnect.Types.SUBJECT;
						}
						treeStudentsTeach[k] = new TreeNode((dataTeachers[z, 2] + " " + dataTeachers[z, 1]).ToString(), treeSubj);
						nodeConnects[l-1].node = treeStudentsTeach[k];
						nodeConnects[l-1].id = (int)dataTeachers[z, 0];
						nodeConnects[l-1].type = NodeConnect.Types.TEACHER;

					}

					treeClasses[i] = new TreeNode(data[i, 1].ToString(),treeStudentsTeach);
					nodeConnects[i].node = treeClasses[i];
					nodeConnects[i].id = (int)data[i, 0];
					nodeConnects[i].type = NodeConnect.Types.CLASS;
					

					treeViewMainCommunications.Nodes.Add(treeClasses[i]);
				}

			}
			else if (checkBoxStudents.Checked)
			{
				int countClasses = dBTools.countRows("Classes");
				int countStudents = dBTools.countRows("Students", "join Users on Users.ID_User = Students.ID_User where Users.LifeStatus = 1");
				int countParent = dBTools.countRows("Parents");

				nodeConnects = new NodeConnect[countClasses + countStudents+ countParent];
				for (int i = 0, l = nodeConnects.Length - 1;  i < treeClasses.Length; l=l-2, i++)
				{
					object[,] dataStudents = dBTools.executeSelectTable($"select ID_Student, Name_Student,Surname_Student from Students where ID_Class = {data[i, 0]}");

					TreeNode[] treeStudents = new TreeNode[dataStudents.GetLength(0)];

					for (int j = 0; j < dataStudents.GetLength(0); j++)
					{
						object[,] dataParent = dBTools.executeSelectTable($"SELECT A.ID_Parent, A.Name_Parent, A.Surname_Parent from Parents A JOIN ParentToStud B on A.ID_Parent = B.ID_ParentToStud join Students C on B.ID_Student = C.ID_Student where C.ID_Student = {dataStudents[j,0]}");
						TreeNode[] treeParent = new TreeNode[dataParent.GetLength(0)];

						for (int k = 0; k < dataParent.GetLength(0); k++)
						{
							treeParent[k] = new TreeNode((dataParent[k, 2] + " " + dataParent[k, 1]).ToString());
							nodeConnects[l - 1].node = treeParent[k];
							nodeConnects[l - 1].id = (int)dataParent[k, 0];
							nodeConnects[l - 1].type = NodeConnect.Types.PARENT;
						}


						treeStudents[j] = new TreeNode((dataStudents[j, 2] + " " + dataStudents[j, 1]).ToString(), treeParent);
						nodeConnects[l].node = treeStudents[j];
						nodeConnects[l].id = (int)dataStudents[j, 0];
						nodeConnects[l].type = NodeConnect.Types.STUDENT;
					}

					treeClasses[i] = new TreeNode(data[i, 1].ToString(), treeStudents);
					nodeConnects[i].node = treeClasses[i];
					nodeConnects[i].id = (int)data[i, 0];
					nodeConnects[i].type = NodeConnect.Types.CLASS;
					treeViewMainCommunications.Nodes.Add(treeClasses[i]);
				}


			}
			else if (checkBoxTeachers.Checked)
			{
				int countClasses = dBTools.countRows("Classes");
				int countTeachers = dBTools.countRows("Teachers", "join Users on Users.ID_User = Teachers.ID_User where Users.LifeStatus = 1");
				int countSubj = dBTools.countRows("Subjects");

				nodeConnects = new NodeConnect[countClasses + countTeachers+ countSubj];
				for (int i = 0, l = nodeConnects.Length - 1;  i < treeClasses.Length; l=l-2, i++)
				{
					object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher, A.Name_Teacher, A.Surname_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {data[i, 0]}");

					TreeNode[] treeTeach = new TreeNode[dataTeachers.GetLength(0)];

					for (int j = 0; j < dataTeachers.GetLength(0); j++)
					{
						object[,] dataSubj = dBTools.executeSelectTable($"select A.ID_Subject, A.Name_Subject from Subjects A join TeachToSubj B on A.ID_Subject = B.ID_Subject JOIN Teachers C ON B.ID_Teacher = C.ID_Teacher JOIN TeachToClass D ON C.ID_Teacher = D.ID_Teacher join Classes E on D.ID_Class = E.ID_Class WHERE C.ID_Teacher = {dataTeachers[j,0]} AND D.ID_Class = {data[i, 0]}");
						TreeNode[] treeSubj = new TreeNode[dataSubj.GetLength(0)];
						for(int k = 0; k < dataSubj.GetLength(0); k++)
                        {
							treeSubj[k] = new TreeNode((dataSubj[k, 1]).ToString());
							nodeConnects[l-1].node = treeSubj[k];
							nodeConnects[l-1].id = (int)dataSubj[j, 0];
							nodeConnects[l-1].type = NodeConnect.Types.SUBJECT;
						}

						treeTeach[j] = new TreeNode((dataTeachers[j, 2] + " " + dataTeachers[j, 1]).ToString(),treeSubj);
						nodeConnects[l].node = treeTeach[j];
						nodeConnects[l].id = (int)dataTeachers[j, 0];
						nodeConnects[l].type = NodeConnect.Types.TEACHER;
					}

					treeClasses[i] = new TreeNode(data[i, 1].ToString(), treeTeach);
					nodeConnects[i].node = treeClasses[i];
					nodeConnects[i].id = (int)data[i, 0];
					nodeConnects[i].type = NodeConnect.Types.CLASS;
					treeViewMainCommunications.Nodes.Add(treeClasses[i]);
				}
			}
			else
			{
				
				nodeConnects = new NodeConnect[data.GetLength(0)];
				for (int i = 0; i < treeClasses.Length; i++)
				{
					treeClasses[i] = new TreeNode(data[i, 1].ToString());
					nodeConnects[i].node = treeClasses[i];
					nodeConnects[i].id = (int)data[i, 0];
					nodeConnects[i].type = NodeConnect.Types.CLASS;

					treeViewMainCommunications.Nodes.Add(treeClasses[i]);
				}
			}

		}

		//переключили студентов
		private void checkBoxStudents_CheckedChanged(object sender, EventArgs e) //может поменять эти чекбоксы на радио батоны? они взамиоисключают друг друга
		{
			FormAdminPanel_Load(sender, e);
		}

		//переключили учителей
		private void checkBoxTeachers_CheckedChanged(object sender, EventArgs e)
		{
			FormAdminPanel_Load(sender, e);
		}

		int BDid = 0;
		NodeConnect.Types tableType;
		int g = 0;
		private void treeViewMainCommunications_AfterSelect(object sender, TreeViewEventArgs e)
		{
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);

			for (int i = 0; i < nodeConnects.Length; i++)
			{
				if (treeViewMainCommunications.SelectedNode == nodeConnects[i].node) 
				{
					BDid = nodeConnects[i].id;
					tableType = nodeConnects[i].type;
				}
			}

			label1.Text = treeViewMainCommunications.SelectedNode.Text + "|" + g++.ToString();

			//уберите ненужные коменты. зачем лейблы тебе?
			//switch case (по типу таблицы)
			switch (tableType)
			{
				case NodeConnect.Types.CLASS:
					label1.Text = label1.Text + "Выбрали класс"; //исправьте массив(nodeConnects), что бы идиально точно заполнялся после запускайте и тестите черерз лейбл. пусть пишет какой вы выбрали тип элемента. если работает то начинайте раскоментировать код и тестить уже его.

					//зачем делать массив для первой группы если выбрали вторую, или наобророт?
                    object[,] dataStudents = dBTools.executeSelectTable($"select ID_Student,Surname_Student, Name_Student,  Thirdname_Student, Number_Student, Address_Student, Email_Student from Students where ID_Class = {BDid}");
					object[,] dataStudentsAll = dBTools.executeSelectTable($"select ID_Student,Surname_Student, Name_Student,  Thirdname_Student, Number_Student, Address_Student, Email_Student from Students where not ID_Class = {BDid}");
					object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher,A.Surname_Teacher, A.Name_Teacher,  A.Thirdname_Teacher, A.Number_Teacher, A.Address_Teacher, A.Email_Teacher, A.Type_Of_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {BDid}");
					object[,] dataTeachersAll = dBTools.executeSelectTable($"SELECT A.ID_Teacher,A.Surname_Teacher, A.Name_Teacher,  A.Thirdname_Teacher, A.Number_Teacher, A.Address_Teacher, A.Email_Teacher, A.Type_Of_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where not C.ID_Class = {BDid}");
					if (checkBoxStudents.Checked)
                    {
						dataGridViewInformation.Rows.Clear();
						dataGridViewInformation.Columns.Clear();
						DataGridViewCheckBoxColumn dataGridViewCheckBoxColumnStud = new DataGridViewCheckBoxColumn();
						dataGridViewCheckBoxColumnStud.HeaderText = "On";
						dataGridViewCheckBoxColumnStud.SortMode = DataGridViewColumnSortMode.NotSortable;
						dataGridViewCheckBoxColumnStud.Width = 70;

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

						dataGridViewInformation.Columns.Add(dataGridViewCheckBoxColumnStud);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudSurname);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudName);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudThirdName);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudNumber);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudAddress);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnStudEmail);

						dataGridViewCheckBoxColumnStud.Width = 70;

						for (int i = 0; i<dataStudents.GetLength(0); i++)
                        {
                            dataGridViewInformation.Rows.Add(true,dataStudents[i,1], dataStudents[i, 2], dataStudents[i, 3], dataStudents[i, 4], dataStudents[i, 5], dataStudents[i, 6]);
						}
						for (int i = dataStudents.GetLength(0)-1; i < dataStudentsAll.GetLength(0); i++)
						{
							dataGridViewInformation.Rows.Add(false, dataStudentsAll[i, 1], dataStudentsAll[i, 2], dataStudentsAll[i, 3], dataStudentsAll[i, 4], dataStudentsAll[i, 5], dataStudentsAll[i, 6]);
							
						}

						//dataGridViewInformation.Rows[0].Cells[0].Value = true;
					}
					if (checkBoxTeachers.Checked)
					{
						dataGridViewInformation.Rows.Clear();
						dataGridViewInformation.Columns.Clear();
                        DataGridViewCheckBoxColumn dataGridViewCheckBoxColumnTeach = new DataGridViewCheckBoxColumn();
                        dataGridViewCheckBoxColumnTeach.HeaderText = "On";
                        dataGridViewCheckBoxColumnTeach.SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridViewCheckBoxColumnTeach.Width = 70;

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

						dataGridViewInformation.Columns.Add(dataGridViewCheckBoxColumnTeach);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachSurname);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachName);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachThirdName);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachNumber);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachAddress);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachEmail);
						dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnTeachType);

						dataGridViewCheckBoxColumnTeach.Width = 70;

						for (int i = 0; i < dataTeachers.GetLength(0); i++)
						{
							if ((bool)dataTeachers[i, 7] == false)
							{
								dataGridViewInformation.Rows.Add(true, dataTeachers[i, 1], dataTeachers[i, 2], dataTeachers[i, 3], dataTeachers[i, 4], dataTeachers[i, 5], dataTeachers[i, 6], "преподаватель младшей школы");
							}
                            else
                            {
								dataGridViewInformation.Rows.Add(true, dataTeachers[i, 1], dataTeachers[i, 2], dataTeachers[i, 3], dataTeachers[i, 4], dataTeachers[i, 5], dataTeachers[i, 6], "преподаватель старшей школы");
							}
						}
						for (int i = dataTeachers.GetLength(0) - 1; i < dataTeachersAll.GetLength(0); i++)
						{
							if ((bool)dataTeachersAll[i, 7] == false)
							{
								dataGridViewInformation.Rows.Add(false, dataTeachersAll[i, 1], dataTeachersAll[i, 2], dataTeachersAll[i, 3], dataTeachersAll[i, 4], dataTeachersAll[i, 5], dataTeachersAll[i, 6], "преподаватель малдшей школы");
							}
                            else
                            {
								dataGridViewInformation.Rows.Add(false, dataTeachersAll[i, 1], dataTeachersAll[i, 2], dataTeachersAll[i, 3], dataTeachersAll[i, 4], dataTeachersAll[i, 5], dataTeachersAll[i, 6], "преподаватель старшей школы");
							}
						}

					}
					if(checkBoxStudents.Checked && checkBoxTeachers.Checked)
                    {
						dataGridViewInformation.Rows.Clear();
						dataGridViewInformation.Columns.Clear();
					}
					break;

				case NodeConnect.Types.STUDENT:
					label1.Text = label1.Text + "Выбрали ученика";

					dataGridViewInformation.Rows.Clear();
					dataGridViewInformation.Columns.Clear();

					DataGridViewCheckBoxColumn dataGridViewCheckBoxColumnPar = new DataGridViewCheckBoxColumn();
					dataGridViewCheckBoxColumnPar.HeaderText = "On";
					dataGridViewCheckBoxColumnPar.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewCheckBoxColumnPar.Width = 70;

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

					dataGridViewInformation.Columns.Add(dataGridViewCheckBoxColumnPar);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParSurname);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParName);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParThirdName);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParNumber);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParAddress);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnParEmail);

					dataGridViewCheckBoxColumnPar.Width = 70;

					object[,] dataParent = dBTools.executeSelectTable($"SELECT A.ID_Parent,A.Surname_Parent, A.Name_Parent, A.Thirdname_Parent, A.Number_Parent, A.Address_Parent, A.Email_Parent  from Parents A JOIN ParentToStud B on A.ID_Parent = B.ID_ParentToStud join Students C on B.ID_Student = C.ID_Student where C.ID_Student = {BDid}");
					object[,] dataParentAll = dBTools.executeSelectTable($"SELECT A.ID_Parent, A.Surname_Parent, A.Name_Parent, A.Thirdname_Parent, A.Number_Parent, A.Address_Parent, A.Email_Parent from Parents A JOIN ParentToStud B on A.ID_Parent = B.ID_ParentToStud join Students C on B.ID_Student = C.ID_Student where NOT C.ID_Student = {BDid}");

					for (int i = 0; i < dataParent.GetLength(0); i++)
                    {
						dataGridViewInformation.Rows.Add(true, dataParent[i, 1], dataParent[i, 2], dataParent[i, 3], dataParent[i, 4], dataParent[i, 5], dataParent[i, 6]);
						
                    }
					for (int i = dataParent.GetLength(0)-1; i < dataParentAll.GetLength(0); i++)
					{
						dataGridViewInformation.Rows.Add(false, dataParentAll[i, 1], dataParentAll[i, 2], dataParentAll[i, 3], dataParentAll[i, 4], dataParentAll[i, 5], dataParentAll[i, 6]);

					}
					break;

				case NodeConnect.Types.TEACHER:
					label1.Text = label1.Text + "Выбрали учителя";
					dataGridViewInformation.Rows.Clear();
					dataGridViewInformation.Columns.Clear();

					DataGridViewCheckBoxColumn dataGridViewCheckBoxColumnSubj = new DataGridViewCheckBoxColumn();
					dataGridViewCheckBoxColumnSubj.HeaderText = "On";
					dataGridViewCheckBoxColumnSubj.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewCheckBoxColumnSubj.Width = 70;

					DataGridViewTextBoxColumn dataGridViewTextBoxColumnSubjName = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumnSubjName.HeaderText = "Name";
					dataGridViewTextBoxColumnSubjName.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewTextBoxColumnSubjName.ReadOnly = true;

					DataGridViewTextBoxColumn dataGridViewTextBoxColumnSubjType = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumnSubjType.HeaderText = "Type";
					dataGridViewTextBoxColumnSubjType.SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewTextBoxColumnSubjType.ReadOnly = true;

					dataGridViewInformation.Columns.Add(dataGridViewCheckBoxColumnSubj);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnSubjName);
					dataGridViewInformation.Columns.Add(dataGridViewTextBoxColumnSubjType);

					dataGridViewCheckBoxColumnSubj.Width = 70;

					object[,] data = dBTools.executeSelectTable($"select ID_Class, Name_Class from Classes;");
					
					for (int i = 0; i < data.GetLength(0); i++)
					{
						object[,] dataSubj = dBTools.executeSelectTable($"select A.ID_Subject, A.Name_Subject,A.Type_Of_Subject from Subjects A join TeachToSubj B on A.ID_Subject = B.ID_Subject JOIN Teachers C ON B.ID_Teacher = C.ID_Teacher JOIN TeachToClass D ON C.ID_Teacher = D.ID_Teacher join Classes E on D.ID_Class = E.ID_Class WHERE C.ID_Teacher = {BDid} AND D.ID_Class = {data[i, 0]}");
						object[,] dataSubjAll = dBTools.executeSelectTable($"select A.ID_Subject, A.Name_Subject, A.Type_Of_Subject from Subjects A join TeachToSubj B on A.ID_Subject = B.ID_Subject JOIN Teachers C ON B.ID_Teacher = C.ID_Teacher JOIN TeachToClass D ON C.ID_Teacher = D.ID_Teacher join Classes E on D.ID_Class = E.ID_Class WHERE not C.ID_Teacher = {BDid}");
						if (dataSubj.GetLength(0) != 0)
						{
							for (int j = 0; j < dataSubj.GetLength(0); j++)
							{
								if ((bool)dataSubj[j, 2] == false)
								{
									dataGridViewInformation.Rows.Add(true, dataSubj[j, 1], "младшая школа");
								}
                                else if((bool)dataSubj[j, 2] == true)
                                {
									dataGridViewInformation.Rows.Add(true, dataSubj[j, 1], "старшая школа");
								}
							}
                            for (int j = dataSubj.GetLength(0)-1; j < dataSubjAll.GetLength(0); j++)
                            {
                                if ((bool)dataSubjAll[j, 2] == false)
                                {
                                    dataGridViewInformation.Rows.Add(false, dataSubjAll[j, 1], "младшая школа");
                                }
                                else if ((bool)dataSubjAll[j, 2] == true)
                                {
                                    dataGridViewInformation.Rows.Add(false, dataSubjAll[j, 1], "старшая школа");
                                }

                            }
                        }
						
					}
					break;

				default:
					break;

			}
		}
		///-----------------------------------------ГАЗИЗОВА САБИНА|КОНЕЦ-----------------------------------------

		///-----------------------------------------ШАПОШНИКОВ СЕРГЕЙ|НАЧАЛО-----------------------------------------
		///-----------------------------------------ШАПОШНИКОВ СЕРГЕЙ|КОНЕЦ-----------------------------------------

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
	}
}
