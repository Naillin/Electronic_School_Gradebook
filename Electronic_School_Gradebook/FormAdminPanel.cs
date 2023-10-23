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

        private void FormAdminPanel_Load(object sender, EventArgs e)
        {
            DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
            object[,] data = dBTools.executeSelectTable($"select * from Classes;");

            TreeNode[] treeClasses = new TreeNode[data.GetLength(0)];

            //CheckBox checkBoxStudents = new CheckBox();
            //CheckBox checkBoxTeachers = new CheckBox();

            for (int i = 0; i < treeClasses.Length; i++)
            {
                object[,] dataStudents = dBTools.executeSelectTable($"select * from Students where ID_Class = {data[i, 0]}");
                object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher, A.Name_Teacher, A.Surname_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = {data[i, 0]}");

                //switch case для checkbox
                TreeNode[] treeStudentsTeach = new TreeNode[dataStudents.GetLength(0) + dataTeachers.GetLength(0)];

                for (int j = 0; j < dataStudents.GetLength(0); j++)
                {
                    treeStudentsTeach[j] = new TreeNode(dataStudents[j, 1].ToString());
                }

                for (int k = dataStudents.GetLength(0), z = 0; k < treeStudentsTeach.Length; z++, k++)
                {
                     treeStudentsTeach[k] = new TreeNode(dataTeachers[z, 1].ToString());
                }

                treeClasses[i] = new TreeNode(data[i, 1].ToString(), treeStudentsTeach);
                treeViewMainCommunications.Nodes.Add(treeClasses[i]);
            }

            treeViewMainCommunications.SelectedImageIndex = 0;
        }

        //переключили студентов
		private void checkBoxStudents_CheckedChanged(object sender, EventArgs e)
		{

		}

		//переключили учителей
		private void checkBoxTeachers_CheckedChanged(object sender, EventArgs e)
		{

		}

        //-----------------------------------------------------------------------------------
	}
}
