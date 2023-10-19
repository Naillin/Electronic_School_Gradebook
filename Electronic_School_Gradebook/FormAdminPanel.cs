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
                treeClasses[i] = new TreeNode(data[i, 1].ToString());

                treeViewMainCommunications.Nodes.Add(treeClasses[i]);
            }
        }
    }
}
