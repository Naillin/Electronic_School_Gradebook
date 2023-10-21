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
        }

        private void FormAdminPanel_Load(object sender, EventArgs e)
        {
            DBTools dBTools = new DBTools(FormAuthorization.sqlConnection);
            object[,] data = dBTools.executeSelectTable($"select * from Classes;");

            TreeNode[] treeClasses = new TreeNode[data.GetLength(0)];
            for(int i = 0; i < treeClasses.Length; i++)
            {
                object[,] dataStudents = dBTools.executeSelectTable($"select * from Students where ID_Class = {data[i, 0]}");
                TreeNode[] treeStudents = new TreeNode[dataStudents.GetLength(0)];
                for(int j = 0; j < treeStudents.Length; j++)
                {
                    treeStudents[j] = new TreeNode(dataStudents[j, 1].ToString());
                }

                object[,] dataTeachers = dBTools.executeSelectTable($"SELECT A.ID_Teacher, A.Name_Teacher, A.Surname_Teacher from Teachers A JOIN TeachToClass B on A.ID_Teacher = B.ID_Teacher join Classes C on B.ID_Class = C.ID_Class where C.ID_Class = { data[i, 0]}");
                TreeNode[] treeTeachers = new TreeNode[dataTeachers.GetLength(0)];
                for (int k = 0; k < treeTeachers.Length; k++)
                {
                    treeTeachers[k] = new TreeNode(dataTeachers[k, 1].ToString());
                }

                treeClasses[i] = new TreeNode(data[i, 1].ToString(),treeTeachers);


                treeViewMainCommunications.Nodes.Add(treeClasses[i]);

            }
            treeViewMainCommunications.SelectedImageIndex = 0;



        }
    }
}
