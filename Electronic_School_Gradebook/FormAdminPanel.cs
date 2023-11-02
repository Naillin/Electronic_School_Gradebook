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

namespace Electronic_School_Gradebook
{
	public partial class FormAdminPanel : Form
	{
		public FormAdminPanel()
		{
			InitializeComponent();

			//настройка формы
			this.DoubleBuffered = true;
			this.StartPosition = FormStartPosition.CenterScreen;

			//границы размеров
			this.MaximumSize = new Size(this.Width, this.Height);
			this.MinimumSize = new Size(this.Width, this.Height);
		}

		//структура для хранения связи узлов с элементами бд
		struct NodeConnect
		{
			public enum Types
			{
				TEACHER = 0,
				STUDENT = 1,
				CLASS = 2,
				SUBJECT = 3,
				PARENT = 4
			}

			public TreeNode node;
			public int id;
			public Types type;
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

				nodeConnects = new NodeConnect[countClasses + countStudents + countTeachers];

				for (int i = 0, l = nodeConnects.Length - 1; i < treeClasses.Length;l=l-2, i++)
				{
					object[,] dataStudents = dBTools.executeSelectTable($"select ID_Student, Name_Student, Surname_Student from Students where ID_Class = {data[i, 0]}");
					object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher, A.Name_Teacher, A.Surname_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {data[i, 0]}");


					TreeNode[] treeStudentsTeach = new TreeNode[dataStudents.GetLength(0) + dataTeachers.GetLength(0)];

					for (int j = 0 ; j < dataStudents.GetLength(0); j++)
					{
						treeStudentsTeach[j] = new TreeNode((dataStudents[j, 2] + " " + dataStudents[j, 1]).ToString());
						nodeConnects[l].node = treeStudentsTeach[j];
						nodeConnects[l].id = (int)dataStudents[j, 0];
						nodeConnects[l].type = NodeConnect.Types.STUDENT;

					}

					for (int k = dataStudents.GetLength(0), z = 0; k < treeStudentsTeach.Length; z++, k++)
					{
						treeStudentsTeach[k] = new TreeNode((dataTeachers[z, 2] + " " + dataTeachers[z, 1]).ToString());
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

				nodeConnects = new NodeConnect[countClasses + countStudents];
				for (int i = 0, l = nodeConnects.Length - 1;  i < treeClasses.Length; l--, i++)
				{
					object[,] dataStudents = dBTools.executeSelectTable($"select ID_Student, Name_Student,Surname_Student from Students where ID_Class = {data[i, 0]}");

					TreeNode[] treeStudents = new TreeNode[dataStudents.GetLength(0)];

					for (int j = 0; j < dataStudents.GetLength(0); j++)
					{
						treeStudents[j] = new TreeNode((dataStudents[j, 2] + " " + dataStudents[j, 1]).ToString());
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

				nodeConnects = new NodeConnect[countClasses + countTeachers];
				for (int i = 0, l = nodeConnects.Length - 1;  i < treeClasses.Length; l--, i++)
				{
					object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher, A.Name_Teacher, A.Surname_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {data[i, 0]}");

					TreeNode[] treeTeach = new TreeNode[dataTeachers.GetLength(0)];

					for (int j = 0; j < dataTeachers.GetLength(0); j++)
					{
						treeTeach[j] = new TreeNode((dataTeachers[j, 2] + " " + dataTeachers[j, 1]).ToString());
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
		private void checkBoxStudents_CheckedChanged(object sender, EventArgs e)
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
			treeViewObjectCommunications.Nodes.Clear();
			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);

			for (int i = 0; i < nodeConnects.Length; i++)
			{
				if (treeViewMainCommunications.SelectedNode == nodeConnects[i].node) //блять пофиксите ебучий массив. половина массива пустая, зачем? некоторые элемнты отсутсвуют. AfterSelect работает
				{
					BDid = nodeConnects[i].id;
					tableType = nodeConnects[i].type;
				}
			}

			label1.Text = treeViewMainCommunications.SelectedNode.Text + "|" + g++.ToString();

			//switch case (по типу таблицы)
			switch (tableType)
			{
				case NodeConnect.Types.CLASS:
					label1.Text = label1.Text + "Выбрали класс"; //исправьте массив(nodeConnects), что бы идиально точно заполнялся после запускайте и тестите черерз лейбл. пусть пишет какой вы выбрали тип элемента. если работает то начинайте раскоментировать код и тестить уже его.

					object[,] dataStudents = dBTools.executeSelectTable($"select ID_Student, Name_Student, Surname_Student from Students where ID_Class = {BDid}");
					object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher, A.Name_Teacher, A.Surname_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {BDid}");

					TreeNode[] treeStudentsTeach = new TreeNode[dataStudents.GetLength(0) + dataTeachers.GetLength(0)];

					if (treeViewMainCommunications.SelectedNode != null)
					{
						for (int j = 0; j < dataStudents.GetLength(0); j++)
						{
							treeStudentsTeach[j] = new TreeNode((dataStudents[j, 2] + " " + dataStudents[j, 1]).ToString());
							treeViewObjectCommunications.Nodes.Add(treeStudentsTeach[j]);

						}

						for (int k = dataStudents.GetLength(0), z = 0; k < treeStudentsTeach.Length; z++, k++)
						{
							treeStudentsTeach[k] = new TreeNode((dataTeachers[z, 2] + " " + dataTeachers[z, 1]).ToString());
							treeViewObjectCommunications.Nodes.Add(treeStudentsTeach[k]);

						}

					}
					break;

				case NodeConnect.Types.STUDENT:
					label1.Text = label1.Text + "Выбрали ученика";

					object[,] dataParent = dBTools.executeSelectTable($"SELECT A.ID_Parent, A.Name_Parent, A.Surname_Parent from Parents A JOIN ParentToStud B on A.ID_Parent = B.ID_ParentToStud join Students C on B.ID_Student = C.ID_Student where C.ID_Student = {BDid}");
					TreeNode[] treeParent = new TreeNode[dataParent.GetLength(0)];

					if (treeViewMainCommunications.SelectedNode != null)
					{
						for (int j = 0; j < treeParent.Length; j++)
						{
							treeParent[j] = new TreeNode((dataParent[j, 2] + " " + dataParent[j, 1]).ToString());

							treeViewObjectCommunications.Nodes.Add(treeParent[j]);
						}
					}
					break;

				case NodeConnect.Types.TEACHER:
					label1.Text = label1.Text + "Выбрали учителя";
					object[,] dataClasses = dBTools.executeSelectTable($"SELECT A.ID_Class, A.Name_Class from Classes A JOIN TeachToClass B on A.ID_Class = B.ID_Class join Teachers C on B.ID_Teacher = C.ID_Teacher where C.ID_Teacher = {BDid}");
					TreeNode[] treeClasses = new TreeNode[dataClasses.GetLength(0)];
					for (int j = 0; j < treeClasses.Length; j++)
					{
						object[,] dataSubj = dBTools.executeSelectTable($"select A.ID_Subject, A.Name_Subject from Subjects A join TeachToSubj B on A.ID_Subject = B.ID_Subject JOIN Teachers C ON B.ID_Teacher = C.ID_Teacher JOIN TeachToClass D ON C.ID_Teacher = D.ID_Teacher join Classes E on D.ID_Class = E.ID_Class WHERE C.ID_Teacher = {BDid} AND D.ID_Class = {dataClasses[j, 0]}");
						TreeNode[] treeeSubj = new TreeNode[dataSubj.GetLength(0)];
						for (int i = 0; i < treeeSubj.Length; i++)
						{
							treeeSubj[i] = new TreeNode(dataSubj[i, 1].ToString());

						}
						treeClasses[j] = new TreeNode(dataClasses[j, 1].ToString(), treeeSubj);

						treeViewObjectCommunications.Nodes.Add(treeClasses[j]);
					}
					break;
				default:
					break;

			}


		}

		private void dataGridViewInformation_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			//treeViewMainCommunications_AfterSelect(sender, e);
		}

		//-----------------------------------------------------------------------------------
	}
}
