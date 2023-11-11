namespace Electronic_School_Gradebook
{
    partial class FormAdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminPanel));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageConnections = new System.Windows.Forms.TabPage();
			this.groupBoxSearch = new System.Windows.Forms.GroupBox();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.checkBoxOnlyRelated = new System.Windows.Forms.CheckBox();
			this.groupBoxSelect = new System.Windows.Forms.GroupBox();
			this.radioButtonTeachers = new System.Windows.Forms.RadioButton();
			this.radioButtonStudents = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridViewInformation = new System.Windows.Forms.DataGridView();
			this.treeViewMainCommunications = new System.Windows.Forms.TreeView();
			this.tabPageAtoms = new System.Windows.Forms.TabPage();
			this.buttonRemoveRecord = new System.Windows.Forms.Button();
			this.buttonAddRecord = new System.Windows.Forms.Button();
			this.tabControlAtoms = new System.Windows.Forms.TabControl();
			this.tabPageUsers = new System.Windows.Forms.TabPage();
			this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
			this.Role_User = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Login_User = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Password_User = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LifeStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.tabPageClasses = new System.Windows.Forms.TabPage();
			this.dataGridViewClasses = new System.Windows.Forms.DataGridView();
			this.Name_Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Type_Of_Class = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Count_Students = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPageStudents = new System.Windows.Forms.TabPage();
			this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
			this.Name_Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Surname_Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Thirdname_Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Number_Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Address_Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Email_Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPageParents = new System.Windows.Forms.TabPage();
			this.dataGridViewParents = new System.Windows.Forms.DataGridView();
			this.Name_Parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Surname_Parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Thirdname_Parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Number_Parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Address_Parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Email_Parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPageTeachers = new System.Windows.Forms.TabPage();
			this.dataGridViewTeachers = new System.Windows.Forms.DataGridView();
			this.Name_Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Surname_Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Thirdname_Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Number_Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Address_Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Email_Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Type_Of_Teacher = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.tabPageSubjects = new System.Windows.Forms.TabPage();
			this.dataGridViewSubjects = new System.Windows.Forms.DataGridView();
			this.Name_Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Type_Of_Subject = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.menuStripAdminPanel = new System.Windows.Forms.MenuStrip();
			this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIconInfoUser = new System.Windows.Forms.NotifyIcon(this.components);
			this.tabControl1.SuspendLayout();
			this.tabPageConnections.SuspendLayout();
			this.groupBoxSearch.SuspendLayout();
			this.groupBoxSelect.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformation)).BeginInit();
			this.tabPageAtoms.SuspendLayout();
			this.tabControlAtoms.SuspendLayout();
			this.tabPageUsers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
			this.tabPageClasses.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).BeginInit();
			this.tabPageStudents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
			this.tabPageParents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewParents)).BeginInit();
			this.tabPageTeachers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).BeginInit();
			this.tabPageSubjects.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).BeginInit();
			this.menuStripAdminPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageConnections);
			this.tabControl1.Controls.Add(this.tabPageAtoms);
			this.tabControl1.Font = new System.Drawing.Font("Arcon", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(9, 28);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1106, 656);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageConnections
			// 
			this.tabPageConnections.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPageConnections.BackgroundImage")));
			this.tabPageConnections.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.tabPageConnections.Controls.Add(this.groupBoxSearch);
			this.tabPageConnections.Controls.Add(this.groupBoxSelect);
			this.tabPageConnections.Controls.Add(this.label1);
			this.tabPageConnections.Controls.Add(this.dataGridViewInformation);
			this.tabPageConnections.Controls.Add(this.treeViewMainCommunications);
			this.tabPageConnections.Font = new System.Drawing.Font("Arcon", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabPageConnections.Location = new System.Drawing.Point(4, 35);
			this.tabPageConnections.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPageConnections.Name = "tabPageConnections";
			this.tabPageConnections.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPageConnections.Size = new System.Drawing.Size(1098, 617);
			this.tabPageConnections.TabIndex = 0;
			this.tabPageConnections.Text = "Connections";
			this.tabPageConnections.UseVisualStyleBackColor = true;
			// 
			// groupBoxSearch
			// 
			this.groupBoxSearch.Controls.Add(this.textBoxSearch);
			this.groupBoxSearch.Controls.Add(this.checkBoxOnlyRelated);
			this.groupBoxSearch.Font = new System.Drawing.Font("Arcon", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxSearch.Location = new System.Drawing.Point(298, 5);
			this.groupBoxSearch.Name = "groupBoxSearch";
			this.groupBoxSearch.Size = new System.Drawing.Size(789, 67);
			this.groupBoxSearch.TabIndex = 5;
			this.groupBoxSearch.TabStop = false;
			this.groupBoxSearch.Text = "Search options";
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSearch.Location = new System.Drawing.Point(198, 21);
			this.textBoxSearch.MaxLength = 50;
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(576, 31);
			this.textBoxSearch.TabIndex = 2;
			this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
			// 
			// checkBoxOnlyRelated
			// 
			this.checkBoxOnlyRelated.AutoSize = true;
			this.checkBoxOnlyRelated.Font = new System.Drawing.Font("Arcon", 13.8F, System.Drawing.FontStyle.Italic);
			this.checkBoxOnlyRelated.Location = new System.Drawing.Point(14, 25);
			this.checkBoxOnlyRelated.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkBoxOnlyRelated.Name = "checkBoxOnlyRelated";
			this.checkBoxOnlyRelated.Size = new System.Drawing.Size(179, 27);
			this.checkBoxOnlyRelated.TabIndex = 1;
			this.checkBoxOnlyRelated.Text = "Only those related";
			this.checkBoxOnlyRelated.UseVisualStyleBackColor = true;
			this.checkBoxOnlyRelated.CheckedChanged += new System.EventHandler(this.checkBoxOnlyRelated_CheckedChanged);
			// 
			// groupBoxSelect
			// 
			this.groupBoxSelect.Controls.Add(this.radioButtonTeachers);
			this.groupBoxSelect.Controls.Add(this.radioButtonStudents);
			this.groupBoxSelect.Font = new System.Drawing.Font("Arcon", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxSelect.Location = new System.Drawing.Point(5, 5);
			this.groupBoxSelect.Name = "groupBoxSelect";
			this.groupBoxSelect.Size = new System.Drawing.Size(287, 67);
			this.groupBoxSelect.TabIndex = 4;
			this.groupBoxSelect.TabStop = false;
			this.groupBoxSelect.Text = "Select";
			// 
			// radioButtonTeachers
			// 
			this.radioButtonTeachers.AutoSize = true;
			this.radioButtonTeachers.Font = new System.Drawing.Font("Arcon", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonTeachers.Location = new System.Drawing.Point(149, 25);
			this.radioButtonTeachers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.radioButtonTeachers.Name = "radioButtonTeachers";
			this.radioButtonTeachers.Size = new System.Drawing.Size(102, 27);
			this.radioButtonTeachers.TabIndex = 4;
			this.radioButtonTeachers.Text = "Teachers";
			this.radioButtonTeachers.UseVisualStyleBackColor = true;
			this.radioButtonTeachers.CheckedChanged += new System.EventHandler(this.radioButtonTeachers_CheckedChanged);
			// 
			// radioButtonStudents
			// 
			this.radioButtonStudents.AutoSize = true;
			this.radioButtonStudents.Checked = true;
			this.radioButtonStudents.Font = new System.Drawing.Font("Arcon", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonStudents.Location = new System.Drawing.Point(22, 25);
			this.radioButtonStudents.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.radioButtonStudents.Name = "radioButtonStudents";
			this.radioButtonStudents.Size = new System.Drawing.Size(97, 27);
			this.radioButtonStudents.TabIndex = 3;
			this.radioButtonStudents.TabStop = true;
			this.radioButtonStudents.Text = "Students";
			this.radioButtonStudents.UseVisualStyleBackColor = true;
			this.radioButtonStudents.CheckedChanged += new System.EventHandler(this.radioButtonStudents_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(293, 683);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 19);
			this.label1.TabIndex = 3;
			this.label1.Text = "label1";
			// 
			// dataGridViewInformation
			// 
			this.dataGridViewInformation.AllowUserToAddRows = false;
			this.dataGridViewInformation.AllowUserToDeleteRows = false;
			this.dataGridViewInformation.AllowUserToResizeRows = false;
			this.dataGridViewInformation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewInformation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridViewInformation.BackgroundColor = System.Drawing.Color.LavenderBlush;
			this.dataGridViewInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewInformation.Location = new System.Drawing.Point(297, 77);
			this.dataGridViewInformation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dataGridViewInformation.MultiSelect = false;
			this.dataGridViewInformation.Name = "dataGridViewInformation";
			this.dataGridViewInformation.RowHeadersWidth = 51;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewInformation.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewInformation.RowTemplate.Height = 24;
			this.dataGridViewInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewInformation.Size = new System.Drawing.Size(790, 533);
			this.dataGridViewInformation.TabIndex = 2;
			this.dataGridViewInformation.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInformation_CellEndEdit);
			// 
			// treeViewMainCommunications
			// 
			this.treeViewMainCommunications.BackColor = System.Drawing.Color.Linen;
			this.treeViewMainCommunications.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeViewMainCommunications.Location = new System.Drawing.Point(2, 77);
			this.treeViewMainCommunications.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.treeViewMainCommunications.Name = "treeViewMainCommunications";
			this.treeViewMainCommunications.Size = new System.Drawing.Size(291, 533);
			this.treeViewMainCommunications.TabIndex = 0;
			this.treeViewMainCommunications.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMainCommunications_AfterSelect);
			// 
			// tabPageAtoms
			// 
			this.tabPageAtoms.Controls.Add(this.buttonRemoveRecord);
			this.tabPageAtoms.Controls.Add(this.buttonAddRecord);
			this.tabPageAtoms.Controls.Add(this.tabControlAtoms);
			this.tabPageAtoms.Location = new System.Drawing.Point(4, 35);
			this.tabPageAtoms.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPageAtoms.Name = "tabPageAtoms";
			this.tabPageAtoms.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPageAtoms.Size = new System.Drawing.Size(1098, 617);
			this.tabPageAtoms.TabIndex = 1;
			this.tabPageAtoms.Text = "Atoms";
			this.tabPageAtoms.UseVisualStyleBackColor = true;
			// 
			// buttonRemoveRecord
			// 
			this.buttonRemoveRecord.Location = new System.Drawing.Point(639, 512);
			this.buttonRemoveRecord.Name = "buttonRemoveRecord";
			this.buttonRemoveRecord.Size = new System.Drawing.Size(200, 100);
			this.buttonRemoveRecord.TabIndex = 2;
			this.buttonRemoveRecord.Text = "Удалить запись";
			this.buttonRemoveRecord.UseVisualStyleBackColor = true;
			this.buttonRemoveRecord.Click += new System.EventHandler(this.buttonRemoveRecord_Click);
			// 
			// buttonAddRecord
			// 
			this.buttonAddRecord.Location = new System.Drawing.Point(260, 512);
			this.buttonAddRecord.Name = "buttonAddRecord";
			this.buttonAddRecord.Size = new System.Drawing.Size(200, 100);
			this.buttonAddRecord.TabIndex = 1;
			this.buttonAddRecord.Text = "Добавить запись";
			this.buttonAddRecord.UseVisualStyleBackColor = true;
			this.buttonAddRecord.Click += new System.EventHandler(this.buttonAddRecord_Click);
			// 
			// tabControlAtoms
			// 
			this.tabControlAtoms.Controls.Add(this.tabPageUsers);
			this.tabControlAtoms.Controls.Add(this.tabPageClasses);
			this.tabControlAtoms.Controls.Add(this.tabPageStudents);
			this.tabControlAtoms.Controls.Add(this.tabPageParents);
			this.tabControlAtoms.Controls.Add(this.tabPageTeachers);
			this.tabControlAtoms.Controls.Add(this.tabPageSubjects);
			this.tabControlAtoms.Location = new System.Drawing.Point(6, 6);
			this.tabControlAtoms.Name = "tabControlAtoms";
			this.tabControlAtoms.SelectedIndex = 0;
			this.tabControlAtoms.Size = new System.Drawing.Size(1087, 500);
			this.tabControlAtoms.TabIndex = 0;
			// 
			// tabPageUsers
			// 
			this.tabPageUsers.Controls.Add(this.dataGridViewUsers);
			this.tabPageUsers.Location = new System.Drawing.Point(4, 35);
			this.tabPageUsers.Name = "tabPageUsers";
			this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPageUsers.Size = new System.Drawing.Size(1079, 461);
			this.tabPageUsers.TabIndex = 0;
			this.tabPageUsers.Text = "Users";
			this.tabPageUsers.UseVisualStyleBackColor = true;
			// 
			// dataGridViewUsers
			// 
			this.dataGridViewUsers.AllowUserToAddRows = false;
			this.dataGridViewUsers.AllowUserToDeleteRows = false;
			this.dataGridViewUsers.AllowUserToResizeRows = false;
			this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Role_User,
            this.Login_User,
            this.Password_User,
            this.LifeStatus});
			this.dataGridViewUsers.Location = new System.Drawing.Point(4, 4);
			this.dataGridViewUsers.MultiSelect = false;
			this.dataGridViewUsers.Name = "dataGridViewUsers";
			this.dataGridViewUsers.RowHeadersWidth = 51;
			this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewUsers.Size = new System.Drawing.Size(1072, 454);
			this.dataGridViewUsers.TabIndex = 0;
			this.dataGridViewUsers.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewUsers_CellBeginEdit);
			this.dataGridViewUsers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellEndEdit);
			// 
			// Role_User
			// 
			this.Role_User.HeaderText = "Role of user";
			this.Role_User.MinimumWidth = 6;
			this.Role_User.Name = "Role_User";
			this.Role_User.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Login_User
			// 
			this.Login_User.HeaderText = "Login of user";
			this.Login_User.MinimumWidth = 6;
			this.Login_User.Name = "Login_User";
			this.Login_User.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Password_User
			// 
			this.Password_User.HeaderText = "Password of user";
			this.Password_User.MinimumWidth = 6;
			this.Password_User.Name = "Password_User";
			this.Password_User.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// LifeStatus
			// 
			this.LifeStatus.HeaderText = "Lifestatus";
			this.LifeStatus.MinimumWidth = 6;
			this.LifeStatus.Name = "LifeStatus";
			// 
			// tabPageClasses
			// 
			this.tabPageClasses.Controls.Add(this.dataGridViewClasses);
			this.tabPageClasses.Location = new System.Drawing.Point(4, 35);
			this.tabPageClasses.Name = "tabPageClasses";
			this.tabPageClasses.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPageClasses.Size = new System.Drawing.Size(1079, 461);
			this.tabPageClasses.TabIndex = 1;
			this.tabPageClasses.Text = "Classes";
			this.tabPageClasses.UseVisualStyleBackColor = true;
			// 
			// dataGridViewClasses
			// 
			this.dataGridViewClasses.AllowUserToAddRows = false;
			this.dataGridViewClasses.AllowUserToDeleteRows = false;
			this.dataGridViewClasses.AllowUserToResizeRows = false;
			this.dataGridViewClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name_Class,
            this.Type_Of_Class,
            this.Count_Students});
			this.dataGridViewClasses.Location = new System.Drawing.Point(4, 4);
			this.dataGridViewClasses.MultiSelect = false;
			this.dataGridViewClasses.Name = "dataGridViewClasses";
			this.dataGridViewClasses.RowHeadersWidth = 51;
			this.dataGridViewClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewClasses.Size = new System.Drawing.Size(1072, 454);
			this.dataGridViewClasses.TabIndex = 0;
			this.dataGridViewClasses.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewClasses_CellBeginEdit);
			this.dataGridViewClasses.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClasses_CellEndEdit);
			this.dataGridViewClasses.Click += new System.EventHandler(this.dataGridViewClasses_Click);
			// 
			// Name_Class
			// 
			this.Name_Class.HeaderText = "Name of class";
			this.Name_Class.MinimumWidth = 6;
			this.Name_Class.Name = "Name_Class";
			this.Name_Class.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Type_Of_Class
			// 
			this.Type_Of_Class.HeaderText = "Type of class";
			this.Type_Of_Class.MinimumWidth = 6;
			this.Type_Of_Class.Name = "Type_Of_Class";
			// 
			// Count_Students
			// 
			this.Count_Students.HeaderText = "Count of students";
			this.Count_Students.MinimumWidth = 6;
			this.Count_Students.Name = "Count_Students";
			this.Count_Students.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// tabPageStudents
			// 
			this.tabPageStudents.Controls.Add(this.dataGridViewStudents);
			this.tabPageStudents.Location = new System.Drawing.Point(4, 35);
			this.tabPageStudents.Name = "tabPageStudents";
			this.tabPageStudents.Size = new System.Drawing.Size(1079, 461);
			this.tabPageStudents.TabIndex = 2;
			this.tabPageStudents.Text = "Students";
			this.tabPageStudents.UseVisualStyleBackColor = true;
			// 
			// dataGridViewStudents
			// 
			this.dataGridViewStudents.AllowUserToAddRows = false;
			this.dataGridViewStudents.AllowUserToDeleteRows = false;
			this.dataGridViewStudents.AllowUserToResizeRows = false;
			this.dataGridViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name_Student,
            this.Surname_Student,
            this.Thirdname_Student,
            this.Number_Student,
            this.Address_Student,
            this.Email_Student});
			this.dataGridViewStudents.Location = new System.Drawing.Point(4, 4);
			this.dataGridViewStudents.MultiSelect = false;
			this.dataGridViewStudents.Name = "dataGridViewStudents";
			this.dataGridViewStudents.RowHeadersWidth = 51;
			this.dataGridViewStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewStudents.Size = new System.Drawing.Size(1072, 454);
			this.dataGridViewStudents.TabIndex = 0;
			this.dataGridViewStudents.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewStudents_CellBeginEdit);
			this.dataGridViewStudents.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudents_CellEndEdit);
			// 
			// Name_Student
			// 
			this.Name_Student.HeaderText = "Name of student";
			this.Name_Student.MinimumWidth = 6;
			this.Name_Student.Name = "Name_Student";
			this.Name_Student.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Surname_Student
			// 
			this.Surname_Student.HeaderText = "Surname of student";
			this.Surname_Student.MinimumWidth = 6;
			this.Surname_Student.Name = "Surname_Student";
			this.Surname_Student.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Thirdname_Student
			// 
			this.Thirdname_Student.HeaderText = "Thirdname of student";
			this.Thirdname_Student.MinimumWidth = 6;
			this.Thirdname_Student.Name = "Thirdname_Student";
			this.Thirdname_Student.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Number_Student
			// 
			this.Number_Student.HeaderText = "Number of student";
			this.Number_Student.MinimumWidth = 6;
			this.Number_Student.Name = "Number_Student";
			this.Number_Student.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Address_Student
			// 
			this.Address_Student.HeaderText = "Address of student";
			this.Address_Student.MinimumWidth = 6;
			this.Address_Student.Name = "Address_Student";
			this.Address_Student.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Email_Student
			// 
			this.Email_Student.HeaderText = "Email of student";
			this.Email_Student.MinimumWidth = 6;
			this.Email_Student.Name = "Email_Student";
			this.Email_Student.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// tabPageParents
			// 
			this.tabPageParents.Controls.Add(this.dataGridViewParents);
			this.tabPageParents.Location = new System.Drawing.Point(4, 35);
			this.tabPageParents.Name = "tabPageParents";
			this.tabPageParents.Size = new System.Drawing.Size(1079, 461);
			this.tabPageParents.TabIndex = 3;
			this.tabPageParents.Text = "Parents";
			this.tabPageParents.UseVisualStyleBackColor = true;
			// 
			// dataGridViewParents
			// 
			this.dataGridViewParents.AllowUserToAddRows = false;
			this.dataGridViewParents.AllowUserToDeleteRows = false;
			this.dataGridViewParents.AllowUserToResizeRows = false;
			this.dataGridViewParents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewParents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewParents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name_Parent,
            this.Surname_Parent,
            this.Thirdname_Parent,
            this.Number_Parent,
            this.Address_Parent,
            this.Email_Parent});
			this.dataGridViewParents.Location = new System.Drawing.Point(4, 4);
			this.dataGridViewParents.MultiSelect = false;
			this.dataGridViewParents.Name = "dataGridViewParents";
			this.dataGridViewParents.RowHeadersWidth = 51;
			this.dataGridViewParents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewParents.Size = new System.Drawing.Size(1072, 454);
			this.dataGridViewParents.TabIndex = 0;
			this.dataGridViewParents.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewParents_CellBeginEdit);
			this.dataGridViewParents.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewParents_CellEndEdit);
			// 
			// Name_Parent
			// 
			this.Name_Parent.HeaderText = "Name of parent";
			this.Name_Parent.MinimumWidth = 6;
			this.Name_Parent.Name = "Name_Parent";
			this.Name_Parent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Surname_Parent
			// 
			this.Surname_Parent.HeaderText = "Surname of parent";
			this.Surname_Parent.MinimumWidth = 6;
			this.Surname_Parent.Name = "Surname_Parent";
			this.Surname_Parent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Thirdname_Parent
			// 
			this.Thirdname_Parent.HeaderText = "Thirdname of parent";
			this.Thirdname_Parent.MinimumWidth = 6;
			this.Thirdname_Parent.Name = "Thirdname_Parent";
			this.Thirdname_Parent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Number_Parent
			// 
			this.Number_Parent.HeaderText = "Number of parent";
			this.Number_Parent.MinimumWidth = 6;
			this.Number_Parent.Name = "Number_Parent";
			this.Number_Parent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Address_Parent
			// 
			this.Address_Parent.HeaderText = "Address of parent";
			this.Address_Parent.MinimumWidth = 6;
			this.Address_Parent.Name = "Address_Parent";
			this.Address_Parent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Email_Parent
			// 
			this.Email_Parent.HeaderText = "Email of parent";
			this.Email_Parent.MinimumWidth = 6;
			this.Email_Parent.Name = "Email_Parent";
			this.Email_Parent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// tabPageTeachers
			// 
			this.tabPageTeachers.Controls.Add(this.dataGridViewTeachers);
			this.tabPageTeachers.Location = new System.Drawing.Point(4, 35);
			this.tabPageTeachers.Name = "tabPageTeachers";
			this.tabPageTeachers.Size = new System.Drawing.Size(1079, 461);
			this.tabPageTeachers.TabIndex = 4;
			this.tabPageTeachers.Text = "Teachers";
			this.tabPageTeachers.UseVisualStyleBackColor = true;
			// 
			// dataGridViewTeachers
			// 
			this.dataGridViewTeachers.AllowUserToAddRows = false;
			this.dataGridViewTeachers.AllowUserToDeleteRows = false;
			this.dataGridViewTeachers.AllowUserToResizeRows = false;
			this.dataGridViewTeachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTeachers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name_Teacher,
            this.Surname_Teacher,
            this.Thirdname_Teacher,
            this.Number_Teacher,
            this.Address_Teacher,
            this.Email_Teacher,
            this.Type_Of_Teacher});
			this.dataGridViewTeachers.Location = new System.Drawing.Point(4, 4);
			this.dataGridViewTeachers.MultiSelect = false;
			this.dataGridViewTeachers.Name = "dataGridViewTeachers";
			this.dataGridViewTeachers.RowHeadersWidth = 51;
			this.dataGridViewTeachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewTeachers.Size = new System.Drawing.Size(1072, 454);
			this.dataGridViewTeachers.TabIndex = 0;
			this.dataGridViewTeachers.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewTeachers_CellBeginEdit);
			this.dataGridViewTeachers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTeachers_CellEndEdit);
			// 
			// Name_Teacher
			// 
			this.Name_Teacher.HeaderText = "Name of teacher";
			this.Name_Teacher.MinimumWidth = 6;
			this.Name_Teacher.Name = "Name_Teacher";
			this.Name_Teacher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Surname_Teacher
			// 
			this.Surname_Teacher.HeaderText = "Surname of teacher";
			this.Surname_Teacher.MinimumWidth = 6;
			this.Surname_Teacher.Name = "Surname_Teacher";
			this.Surname_Teacher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Thirdname_Teacher
			// 
			this.Thirdname_Teacher.HeaderText = "Thirdname of teacher";
			this.Thirdname_Teacher.MinimumWidth = 6;
			this.Thirdname_Teacher.Name = "Thirdname_Teacher";
			this.Thirdname_Teacher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Number_Teacher
			// 
			this.Number_Teacher.HeaderText = "Number of teacher";
			this.Number_Teacher.MinimumWidth = 6;
			this.Number_Teacher.Name = "Number_Teacher";
			this.Number_Teacher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Address_Teacher
			// 
			this.Address_Teacher.HeaderText = "Address of teacher";
			this.Address_Teacher.MinimumWidth = 6;
			this.Address_Teacher.Name = "Address_Teacher";
			this.Address_Teacher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Email_Teacher
			// 
			this.Email_Teacher.HeaderText = "Email of teacher";
			this.Email_Teacher.MinimumWidth = 6;
			this.Email_Teacher.Name = "Email_Teacher";
			this.Email_Teacher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Type_Of_Teacher
			// 
			this.Type_Of_Teacher.HeaderText = "Type of teacher";
			this.Type_Of_Teacher.MinimumWidth = 6;
			this.Type_Of_Teacher.Name = "Type_Of_Teacher";
			// 
			// tabPageSubjects
			// 
			this.tabPageSubjects.Controls.Add(this.dataGridViewSubjects);
			this.tabPageSubjects.Location = new System.Drawing.Point(4, 35);
			this.tabPageSubjects.Name = "tabPageSubjects";
			this.tabPageSubjects.Size = new System.Drawing.Size(1079, 461);
			this.tabPageSubjects.TabIndex = 5;
			this.tabPageSubjects.Text = "Subjects";
			this.tabPageSubjects.UseVisualStyleBackColor = true;
			// 
			// dataGridViewSubjects
			// 
			this.dataGridViewSubjects.AllowUserToAddRows = false;
			this.dataGridViewSubjects.AllowUserToDeleteRows = false;
			this.dataGridViewSubjects.AllowUserToResizeRows = false;
			this.dataGridViewSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name_Subject,
            this.Type_Of_Subject});
			this.dataGridViewSubjects.Location = new System.Drawing.Point(4, 4);
			this.dataGridViewSubjects.MultiSelect = false;
			this.dataGridViewSubjects.Name = "dataGridViewSubjects";
			this.dataGridViewSubjects.RowHeadersWidth = 51;
			this.dataGridViewSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewSubjects.Size = new System.Drawing.Size(1072, 454);
			this.dataGridViewSubjects.TabIndex = 0;
			this.dataGridViewSubjects.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewSubjects_CellBeginEdit);
			this.dataGridViewSubjects.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSubjects_CellEndEdit);
			// 
			// Name_Subject
			// 
			this.Name_Subject.HeaderText = "Name of subject";
			this.Name_Subject.MinimumWidth = 6;
			this.Name_Subject.Name = "Name_Subject";
			this.Name_Subject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Type_Of_Subject
			// 
			this.Type_Of_Subject.HeaderText = "Type of subject";
			this.Type_Of_Subject.MinimumWidth = 6;
			this.Type_Of_Subject.Name = "Type_Of_Subject";
			// 
			// menuStripAdminPanel
			// 
			this.menuStripAdminPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStripAdminPanel.BackgroundImage")));
			this.menuStripAdminPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.menuStripAdminPanel.Font = new System.Drawing.Font("Arcon", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStripAdminPanel.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStripAdminPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem});
			this.menuStripAdminPanel.Location = new System.Drawing.Point(0, 0);
			this.menuStripAdminPanel.Name = "menuStripAdminPanel";
			this.menuStripAdminPanel.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStripAdminPanel.Size = new System.Drawing.Size(1126, 26);
			this.menuStripAdminPanel.TabIndex = 7;
			this.menuStripAdminPanel.Text = "menuStrip1";
			// 
			// systemToolStripMenuItem
			// 
			this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
			this.systemToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
			this.systemToolStripMenuItem.Text = "System";
			// 
			// logoutToolStripMenuItem
			// 
			this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
			this.logoutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.logoutToolStripMenuItem.Text = "Logout";
			this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// notifyIconInfoUser
			// 
			this.notifyIconInfoUser.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIconInfoUser.BalloonTipText = "Empty";
			this.notifyIconInfoUser.BalloonTipTitle = "Control Panel";
			this.notifyIconInfoUser.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconInfoUser.Icon")));
			this.notifyIconInfoUser.Text = "Empty";
			this.notifyIconInfoUser.Visible = true;
			this.notifyIconInfoUser.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconInfoUser_MouseClick);
			// 
			// FormAdminPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1126, 687);
			this.Controls.Add(this.menuStripAdminPanel);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FormAdminPanel";
			this.Text = "Control Panel";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminPanel_FormClosing);
			this.Load += new System.EventHandler(this.FormAdminPanel_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPageConnections.ResumeLayout(false);
			this.tabPageConnections.PerformLayout();
			this.groupBoxSearch.ResumeLayout(false);
			this.groupBoxSearch.PerformLayout();
			this.groupBoxSelect.ResumeLayout(false);
			this.groupBoxSelect.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformation)).EndInit();
			this.tabPageAtoms.ResumeLayout(false);
			this.tabControlAtoms.ResumeLayout(false);
			this.tabPageUsers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
			this.tabPageClasses.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).EndInit();
			this.tabPageStudents.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
			this.tabPageParents.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewParents)).EndInit();
			this.tabPageTeachers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).EndInit();
			this.tabPageSubjects.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).EndInit();
			this.menuStripAdminPanel.ResumeLayout(false);
			this.menuStripAdminPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageConnections;
        private System.Windows.Forms.TabPage tabPageAtoms;
        private System.Windows.Forms.TreeView treeViewMainCommunications;
        private System.Windows.Forms.DataGridView dataGridViewInformation;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBoxSelect;
		private System.Windows.Forms.MenuStrip menuStripAdminPanel;
		private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon notifyIconInfoUser;
		private System.Windows.Forms.GroupBox groupBoxSearch;
		private System.Windows.Forms.TextBox textBoxSearch;
		private System.Windows.Forms.CheckBox checkBoxOnlyRelated;
        private System.Windows.Forms.RadioButton radioButtonTeachers;
        private System.Windows.Forms.RadioButton radioButtonStudents;
        private System.Windows.Forms.Button buttonRemoveRecord;
        private System.Windows.Forms.Button buttonAddRecord;
        private System.Windows.Forms.TabControl tabControlAtoms;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TabPage tabPageClasses;
        private System.Windows.Forms.TabPage tabPageStudents;
        private System.Windows.Forms.TabPage tabPageParents;
        private System.Windows.Forms.TabPage tabPageTeachers;
        private System.Windows.Forms.TabPage tabPageSubjects;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.DataGridView dataGridViewParents;
        private System.Windows.Forms.DataGridView dataGridViewTeachers;
        private System.Windows.Forms.DataGridView dataGridViewSubjects;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.DataGridView dataGridViewClasses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password_User;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LifeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Class;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Type_Of_Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count_Students;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname_Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thirdname_Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number_Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address_Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email_Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Parent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname_Parent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thirdname_Parent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number_Parent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address_Parent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email_Parent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname_Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thirdname_Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number_Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address_Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email_Teacher;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Type_Of_Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Subject;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Type_Of_Subject;
    }
}