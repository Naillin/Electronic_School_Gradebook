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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageConnections = new System.Windows.Forms.TabPage();
			this.groupBoxSelect = new System.Windows.Forms.GroupBox();
			this.checkBoxStudents = new System.Windows.Forms.CheckBox();
			this.checkBoxTeachers = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridViewInformation = new System.Windows.Forms.DataGridView();
			this.treeViewMainCommunications = new System.Windows.Forms.TreeView();
			this.tabPageAtoms = new System.Windows.Forms.TabPage();
			this.menuStripAdminPanel = new System.Windows.Forms.MenuStrip();
			this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIconInfoUser = new System.Windows.Forms.NotifyIcon(this.components);
			this.groupBoxSearch = new System.Windows.Forms.GroupBox();
			this.checkBoxOnlyRelated = new System.Windows.Forms.CheckBox();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPageConnections.SuspendLayout();
			this.groupBoxSelect.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformation)).BeginInit();
			this.menuStripAdminPanel.SuspendLayout();
			this.groupBoxSearch.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageConnections);
			this.tabControl1.Controls.Add(this.tabPageAtoms);
			this.tabControl1.Font = new System.Drawing.Font("Arcon", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(9, 28);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1106, 749);
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
			this.tabPageConnections.Margin = new System.Windows.Forms.Padding(2);
			this.tabPageConnections.Name = "tabPageConnections";
			this.tabPageConnections.Padding = new System.Windows.Forms.Padding(2);
			this.tabPageConnections.Size = new System.Drawing.Size(1098, 710);
			this.tabPageConnections.TabIndex = 0;
			this.tabPageConnections.Text = "Connections";
			this.tabPageConnections.UseVisualStyleBackColor = true;
			// 
			// groupBoxSelect
			// 
			this.groupBoxSelect.Controls.Add(this.checkBoxStudents);
			this.groupBoxSelect.Controls.Add(this.checkBoxTeachers);
			this.groupBoxSelect.Font = new System.Drawing.Font("Arcon", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxSelect.Location = new System.Drawing.Point(5, 5);
			this.groupBoxSelect.Name = "groupBoxSelect";
			this.groupBoxSelect.Size = new System.Drawing.Size(287, 67);
			this.groupBoxSelect.TabIndex = 4;
			this.groupBoxSelect.TabStop = false;
			this.groupBoxSelect.Text = "Select";
			// 
			// checkBoxStudents
			// 
			this.checkBoxStudents.AutoSize = true;
			this.checkBoxStudents.Font = new System.Drawing.Font("Arcon", 13.8F, System.Drawing.FontStyle.Italic);
			this.checkBoxStudents.Location = new System.Drawing.Point(14, 25);
			this.checkBoxStudents.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxStudents.Name = "checkBoxStudents";
			this.checkBoxStudents.Size = new System.Drawing.Size(98, 27);
			this.checkBoxStudents.TabIndex = 1;
			this.checkBoxStudents.Text = "Students";
			this.checkBoxStudents.UseVisualStyleBackColor = true;
			this.checkBoxStudents.CheckedChanged += new System.EventHandler(this.checkBoxStudents_CheckedChanged);
			// 
			// checkBoxTeachers
			// 
			this.checkBoxTeachers.AutoSize = true;
			this.checkBoxTeachers.Font = new System.Drawing.Font("Arcon", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxTeachers.Location = new System.Drawing.Point(160, 25);
			this.checkBoxTeachers.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxTeachers.Name = "checkBoxTeachers";
			this.checkBoxTeachers.Size = new System.Drawing.Size(103, 27);
			this.checkBoxTeachers.TabIndex = 2;
			this.checkBoxTeachers.Text = "Teachers";
			this.checkBoxTeachers.UseVisualStyleBackColor = true;
			this.checkBoxTeachers.CheckedChanged += new System.EventHandler(this.checkBoxTeachers_CheckedChanged);
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
			this.dataGridViewInformation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewInformation.Location = new System.Drawing.Point(297, 77);
			this.dataGridViewInformation.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewInformation.Name = "dataGridViewInformation";
			this.dataGridViewInformation.RowHeadersWidth = 51;
			this.dataGridViewInformation.RowTemplate.Height = 24;
			this.dataGridViewInformation.Size = new System.Drawing.Size(790, 606);
			this.dataGridViewInformation.TabIndex = 2;
			// 
			// treeViewMainCommunications
			// 
			this.treeViewMainCommunications.BackColor = System.Drawing.Color.Linen;
			this.treeViewMainCommunications.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeViewMainCommunications.Location = new System.Drawing.Point(2, 77);
			this.treeViewMainCommunications.Margin = new System.Windows.Forms.Padding(2);
			this.treeViewMainCommunications.Name = "treeViewMainCommunications";
			this.treeViewMainCommunications.Size = new System.Drawing.Size(291, 607);
			this.treeViewMainCommunications.TabIndex = 0;
			this.treeViewMainCommunications.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMainCommunications_AfterSelect);
			// 
			// tabPageAtoms
			// 
			this.tabPageAtoms.Location = new System.Drawing.Point(4, 35);
			this.tabPageAtoms.Margin = new System.Windows.Forms.Padding(2);
			this.tabPageAtoms.Name = "tabPageAtoms";
			this.tabPageAtoms.Padding = new System.Windows.Forms.Padding(2);
			this.tabPageAtoms.Size = new System.Drawing.Size(1098, 701);
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
			this.logoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.logoutToolStripMenuItem.Text = "Logout";
			this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
			// checkBoxOnlyRelated
			// 
			this.checkBoxOnlyRelated.AutoSize = true;
			this.checkBoxOnlyRelated.Font = new System.Drawing.Font("Arcon", 13.8F, System.Drawing.FontStyle.Italic);
			this.checkBoxOnlyRelated.Location = new System.Drawing.Point(14, 25);
			this.checkBoxOnlyRelated.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxOnlyRelated.Name = "checkBoxOnlyRelated";
			this.checkBoxOnlyRelated.Size = new System.Drawing.Size(179, 27);
			this.checkBoxOnlyRelated.TabIndex = 1;
			this.checkBoxOnlyRelated.Text = "Only those related";
			this.checkBoxOnlyRelated.UseVisualStyleBackColor = true;
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSearch.Location = new System.Drawing.Point(198, 21);
			this.textBoxSearch.MaxLength = 50;
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(576, 31);
			this.textBoxSearch.TabIndex = 2;
			// 
			// FormAdminPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1126, 788);
			this.Controls.Add(this.menuStripAdminPanel);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FormAdminPanel";
			this.Text = "Control Panel";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminPanel_FormClosing);
			this.Load += new System.EventHandler(this.FormAdminPanel_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPageConnections.ResumeLayout(false);
			this.tabPageConnections.PerformLayout();
			this.groupBoxSelect.ResumeLayout(false);
			this.groupBoxSelect.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformation)).EndInit();
			this.menuStripAdminPanel.ResumeLayout(false);
			this.menuStripAdminPanel.PerformLayout();
			this.groupBoxSearch.ResumeLayout(false);
			this.groupBoxSearch.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageConnections;
        private System.Windows.Forms.TabPage tabPageAtoms;
        private System.Windows.Forms.TreeView treeViewMainCommunications;
        private System.Windows.Forms.DataGridView dataGridViewInformation;
        private System.Windows.Forms.CheckBox checkBoxStudents;
        private System.Windows.Forms.CheckBox checkBoxTeachers;
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
	}
}