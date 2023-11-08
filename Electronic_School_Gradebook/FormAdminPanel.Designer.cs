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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.menuStripAdminPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageConnections);
            this.tabControl1.Controls.Add(this.tabPageAtoms);
            this.tabControl1.Font = new System.Drawing.Font("Arcon", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 34);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1475, 922);
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
            this.tabPageConnections.Location = new System.Drawing.Point(4, 41);
            this.tabPageConnections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageConnections.Name = "tabPageConnections";
            this.tabPageConnections.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageConnections.Size = new System.Drawing.Size(1467, 877);
            this.tabPageConnections.TabIndex = 0;
            this.tabPageConnections.Text = "Connections";
            this.tabPageConnections.UseVisualStyleBackColor = true;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.textBoxSearch);
            this.groupBoxSearch.Controls.Add(this.checkBoxOnlyRelated);
            this.groupBoxSearch.Font = new System.Drawing.Font("Arcon", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSearch.Location = new System.Drawing.Point(397, 6);
            this.groupBoxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxSearch.Size = new System.Drawing.Size(1052, 82);
            this.groupBoxSearch.TabIndex = 5;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search options";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(264, 26);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSearch.MaxLength = 50;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(767, 37);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // checkBoxOnlyRelated
            // 
            this.checkBoxOnlyRelated.AutoSize = true;
            this.checkBoxOnlyRelated.Font = new System.Drawing.Font("Arcon", 13.8F, System.Drawing.FontStyle.Italic);
            this.checkBoxOnlyRelated.Location = new System.Drawing.Point(19, 31);
            this.checkBoxOnlyRelated.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxOnlyRelated.Name = "checkBoxOnlyRelated";
            this.checkBoxOnlyRelated.Size = new System.Drawing.Size(215, 32);
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
            this.groupBoxSelect.Location = new System.Drawing.Point(7, 6);
            this.groupBoxSelect.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxSelect.Name = "groupBoxSelect";
            this.groupBoxSelect.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxSelect.Size = new System.Drawing.Size(383, 82);
            this.groupBoxSelect.TabIndex = 4;
            this.groupBoxSelect.TabStop = false;
            this.groupBoxSelect.Text = "Select";
            // 
            // radioButtonTeachers
            // 
            this.radioButtonTeachers.AutoSize = true;
            this.radioButtonTeachers.Font = new System.Drawing.Font("Arcon", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTeachers.Location = new System.Drawing.Point(199, 31);
            this.radioButtonTeachers.Name = "radioButtonTeachers";
            this.radioButtonTeachers.Size = new System.Drawing.Size(122, 32);
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
            this.radioButtonStudents.Location = new System.Drawing.Point(29, 31);
            this.radioButtonStudents.Name = "radioButtonStudents";
            this.radioButtonStudents.Size = new System.Drawing.Size(116, 32);
            this.radioButtonStudents.TabIndex = 3;
            this.radioButtonStudents.TabStop = true;
            this.radioButtonStudents.Text = "Students";
            this.radioButtonStudents.UseVisualStyleBackColor = true;
            this.radioButtonStudents.CheckedChanged += new System.EventHandler(this.radioButtonStudents_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 841);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
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
            this.dataGridViewInformation.Location = new System.Drawing.Point(396, 95);
            this.dataGridViewInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewInformation.MultiSelect = false;
            this.dataGridViewInformation.Name = "dataGridViewInformation";
            this.dataGridViewInformation.RowHeadersWidth = 51;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInformation.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewInformation.RowTemplate.Height = 24;
            this.dataGridViewInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewInformation.Size = new System.Drawing.Size(1053, 655);
            this.dataGridViewInformation.TabIndex = 2;
            this.dataGridViewInformation.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInformation_CellEndEdit);
            // 
            // treeViewMainCommunications
            // 
            this.treeViewMainCommunications.BackColor = System.Drawing.Color.Linen;
            this.treeViewMainCommunications.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewMainCommunications.Location = new System.Drawing.Point(3, 95);
            this.treeViewMainCommunications.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeViewMainCommunications.Name = "treeViewMainCommunications";
            this.treeViewMainCommunications.Size = new System.Drawing.Size(387, 655);
            this.treeViewMainCommunications.TabIndex = 0;
            this.treeViewMainCommunications.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMainCommunications_AfterSelect);
            // 
            // tabPageAtoms
            // 
            this.tabPageAtoms.Location = new System.Drawing.Point(4, 41);
            this.tabPageAtoms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAtoms.Name = "tabPageAtoms";
            this.tabPageAtoms.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAtoms.Size = new System.Drawing.Size(1467, 877);
            this.tabPageAtoms.TabIndex = 1;
            this.tabPageAtoms.Text = "Atoms";
            this.tabPageAtoms.UseVisualStyleBackColor = true;
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
            this.menuStripAdminPanel.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStripAdminPanel.Size = new System.Drawing.Size(1501, 31);
            this.menuStripAdminPanel.TabIndex = 7;
            this.menuStripAdminPanel.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(85, 27);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(153, 28);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 28);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1501, 970);
            this.Controls.Add(this.menuStripAdminPanel);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
    }
}