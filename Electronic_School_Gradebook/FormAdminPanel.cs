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
			public Types types;
		}

		NodeConnect[] nodeConnects; 
		private void FormAdminPanel_Load(object sender, EventArgs e)
		{   
			treeViewMainCommunications.Nodes.Clear();

			DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
			object[,] data = dBTools.executeSelectTable($"select ID_Class, Name_Class from Classes;");

			TreeNode[] treeClasses = new TreeNode[data.GetLength(0)];

		   
			if(checkBoxStudents.Checked && checkBoxTeachers.Checked)
            {
				object countClasses = dBTools.executeAnySqlScalar("select count(ID_Class) from Classes;");
				object countStudents = dBTools.executeAnySqlScalar("select count(ID_Student) from Students;");
				object countTeachers = dBTools.executeAnySqlScalar("select count(ID_Teacher) from Teachers;");

				nodeConnects = new NodeConnect[(int)countClasses + (int)countStudents + (int)countTeachers];

				for (int i = 0; i < treeClasses.Length; i++)
				{
					object[,] dataStudents = dBTools.executeSelectTable($"select ID_Student, Name_Student, Surname_Student from Students where ID_Class = {data[i, 0]}");
					object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher, A.Name_Teacher, A.Surname_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {data[i, 0]}");


					TreeNode[] treeStudentsTeach = new TreeNode[dataStudents.GetLength(0) + dataTeachers.GetLength(0)];

					for (int j = 0; j < dataStudents.GetLength(0); j++)
					{
						treeStudentsTeach[j] = new TreeNode((dataStudents[j, 2] + " " + dataStudents[j, 1]).ToString());
                        nodeConnects[j].node = treeStudentsTeach[j];
						nodeConnects[j].id = (int)dataStudents[j, 0];
						nodeConnects[j].types = NodeConnect.Types.STUDENT;
						
					}

					for (int k = dataStudents.GetLength(0), z = 0; k < treeStudentsTeach.Length; z++, k++)
					{
						treeStudentsTeach[k] = new TreeNode((dataTeachers[z, 2] + " " + dataTeachers[z, 1]).ToString());
						nodeConnects[k].node = treeStudentsTeach[k];
						nodeConnects[k].id = (int)dataTeachers[z, 0];
						nodeConnects[k].types = NodeConnect.Types.TEACHER;
						
					}

					treeClasses[i] = new TreeNode(data[i, 1].ToString(), treeStudentsTeach);
					nodeConnects[i].node = treeClasses[i];
					nodeConnects[i].id = (int)data[i, 0];
					nodeConnects[i].types = NodeConnect.Types.CLASS;

					treeViewMainCommunications.Nodes.Add(treeClasses[i]);
				}

			}
			//else if (checkBoxStudents.Checked)
   //         {
			//	int countClasses = dBTools.countRows("Classes");
			//	int countStudents = dBTools.countRows("Students");
				
			//	nodeConnects = new NodeConnect[countClasses + countStudents];
			//	for (int i = 0; i < treeClasses.Length; i++)
			//	{
			//		object[,] dataStudents = dBTools.executeSelectTable($"select ID_Student, Name_Student,Surname_Student from Students where ID_Class = {data[i, 0]}");
						
			//		TreeNode[] treeStudents = new TreeNode[dataStudents.GetLength(0)];

			//		for (int j = 0; j < dataStudents.GetLength(0); j++)
			//		{
			//			treeStudents[j] = new TreeNode((dataStudents[j, 2] + " " + dataStudents[j, 1]).ToString());
			//			nodeConnects[j].node = treeStudents[j];
			//			nodeConnects[j].id = (int)dataStudents[j, 0];
			//			nodeConnects[j].types = NodeConnect.Types.STUDENT;
			//		}

			//		treeClasses[i] = new TreeNode(data[i, 1].ToString(), treeStudents);
			//		nodeConnects[i].node = treeClasses[i];
			//		nodeConnects[i].id = (int)data[i, 0];
			//		nodeConnects[i].types = NodeConnect.Types.CLASS;
			//		treeViewMainCommunications.Nodes.Add(treeClasses[i]);
			//	}

			//}
			//else if (checkBoxTeachers.Checked)
   //         {
			//	int countClasses = dBTools.countRows("Classes");
			//	int countTeachers = dBTools.countRows("Teachers", "join Users on Users.ID_User=Teachers.ID_User where LifeStatus=1;");

			//	nodeConnects = new NodeConnect[countClasses + countTeachers];
			//	for (int i = 0; i < treeClasses.Length; i++)
			//	{
					
			//		object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher, A.Name_Teacher, A.Surname_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {data[i, 0]}");


			//		TreeNode[] treeTeach = new TreeNode[dataTeachers.GetLength(0)];

			//		for (int j = 0; j < dataTeachers.GetLength(0); j++)
			//		{
			//			treeTeach[j] = new TreeNode((dataTeachers[j,2] + " " + dataTeachers[j, 1]).ToString());
			//			nodeConnects[j].node = treeTeach[j];
			//			nodeConnects[j].id = (int)dataTeachers[j, 0];
			//			nodeConnects[j].types = NodeConnect.Types.TEACHER;
			//		}

			//		treeClasses[i] = new TreeNode(data[i, 1].ToString(), treeTeach);
			//		nodeConnects[i].node = treeClasses[i];
			//		nodeConnects[i].id = (int)data[i, 0];
			//		nodeConnects[i].types = NodeConnect.Types.CLASS;
			//		treeViewMainCommunications.Nodes.Add(treeClasses[i]);
			//	}
			//}
            else
            {
				object countClasses = dBTools.executeAnySqlScalar("select count(ID_Class) from Classes;");
				

				nodeConnects = new NodeConnect[(int)countClasses];
				for (int i = 0; i < treeClasses.Length; i++)
				{
					treeClasses[i] = new TreeNode(data[i, 1].ToString());
                    nodeConnects[i].node = treeClasses[i];
                    nodeConnects[i].id = (int)data[i, 0];
                    nodeConnects[i].types = NodeConnect.Types.CLASS;

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

        private void treeViewMainCommunications_AfterSelect(object sender, TreeViewEventArgs e)
        {
			int BDid = 0;
			NodeConnect.Types tableType;

			for(int i = 0; i < nodeConnects.Length; i++)
            {
                if (nodeConnects[i].node == treeViewMainCommunications.SelectedNode)
                {
					BDid = nodeConnects[i].id;
					tableType = nodeConnects[i].types;
                }
            }

			//switch case (по типу таблицы)
			

        }

        //-----------------------------------------------------------------------------------
    }
}
