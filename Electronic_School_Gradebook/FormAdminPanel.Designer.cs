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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminPanel));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageConnections = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridViewInformation = new System.Windows.Forms.DataGridView();
			this.treeViewObjectCommunications = new System.Windows.Forms.TreeView();
			this.treeViewMainCommunications = new System.Windows.Forms.TreeView();
			this.tabPageAtoms = new System.Windows.Forms.TabPage();
			this.checkBoxStudents = new System.Windows.Forms.CheckBox();
			this.checkBoxTeachers = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tabControl1.SuspendLayout();
			this.tabPageConnections.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformation)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageConnections);
			this.tabControl1.Controls.Add(this.tabPageAtoms);
			this.tabControl1.Font = new System.Drawing.Font("Arcon", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(9, 11);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1106, 740);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageConnections
			// 
			this.tabPageConnections.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPageConnections.BackgroundImage")));
			this.tabPageConnections.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.tabPageConnections.Controls.Add(this.groupBox1);
			this.tabPageConnections.Controls.Add(this.label1);
			this.tabPageConnections.Controls.Add(this.dataGridViewInformation);
			this.tabPageConnections.Controls.Add(this.treeViewObjectCommunications);
			this.tabPageConnections.Controls.Add(this.treeViewMainCommunications);
			this.tabPageConnections.Font = new System.Drawing.Font("Arcon", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabPageConnections.Location = new System.Drawing.Point(4, 34);
			this.tabPageConnections.Margin = new System.Windows.Forms.Padding(2);
			this.tabPageConnections.Name = "tabPageConnections";
			this.tabPageConnections.Padding = new System.Windows.Forms.Padding(2);
			this.tabPageConnections.Size = new System.Drawing.Size(1098, 702);
			this.tabPageConnections.TabIndex = 0;
			this.tabPageConnections.Text = "Connections";
			this.tabPageConnections.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(293, 381);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 19);
			this.label1.TabIndex = 3;
			this.label1.Text = "label1";
			// 
			// dataGridViewInformation
			// 
			this.dataGridViewInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewInformation.Location = new System.Drawing.Point(297, 170);
			this.dataGridViewInformation.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewInformation.Name = "dataGridViewInformation";
			this.dataGridViewInformation.RowHeadersWidth = 51;
			this.dataGridViewInformation.RowTemplate.Height = 24;
			this.dataGridViewInformation.Size = new System.Drawing.Size(479, 209);
			this.dataGridViewInformation.TabIndex = 2;
			this.dataGridViewInformation.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewInformation_CellBeginEdit);
			// 
			// treeViewObjectCommunications
			// 
			this.treeViewObjectCommunications.BackColor = System.Drawing.Color.AliceBlue;
			this.treeViewObjectCommunications.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Italic);
			this.treeViewObjectCommunications.Location = new System.Drawing.Point(297, 16);
			this.treeViewObjectCommunications.Margin = new System.Windows.Forms.Padding(2);
			this.treeViewObjectCommunications.Name = "treeViewObjectCommunications";
			this.treeViewObjectCommunications.Size = new System.Drawing.Size(479, 150);
			this.treeViewObjectCommunications.TabIndex = 1;
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
			this.tabPageAtoms.Location = new System.Drawing.Point(4, 34);
			this.tabPageAtoms.Margin = new System.Windows.Forms.Padding(2);
			this.tabPageAtoms.Name = "tabPageAtoms";
			this.tabPageAtoms.Padding = new System.Windows.Forms.Padding(2);
			this.tabPageAtoms.Size = new System.Drawing.Size(1098, 702);
			this.tabPageAtoms.TabIndex = 1;
			this.tabPageAtoms.Text = "Atoms";
			this.tabPageAtoms.UseVisualStyleBackColor = true;
			// 
			// checkBoxStudents
			// 
			this.checkBoxStudents.AutoSize = true;
			this.checkBoxStudents.Font = new System.Drawing.Font("Arcon", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
			this.checkBoxTeachers.Font = new System.Drawing.Font("Arcon", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxTeachers.Location = new System.Drawing.Point(160, 25);
			this.checkBoxTeachers.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxTeachers.Name = "checkBoxTeachers";
			this.checkBoxTeachers.Size = new System.Drawing.Size(103, 27);
			this.checkBoxTeachers.TabIndex = 2;
			this.checkBoxTeachers.Text = "Teachers";
			this.checkBoxTeachers.UseVisualStyleBackColor = true;
			this.checkBoxTeachers.CheckedChanged += new System.EventHandler(this.checkBoxTeachers_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBoxStudents);
			this.groupBox1.Controls.Add(this.checkBoxTeachers);
			this.groupBox1.Location = new System.Drawing.Point(5, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(287, 67);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select";
			// 
			// FormAdminPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1126, 762);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FormAdminPanel";
			this.Text = "Control Panel";
			this.Load += new System.EventHandler(this.FormAdminPanel_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPageConnections.ResumeLayout(false);
			this.tabPageConnections.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformation)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageConnections;
        private System.Windows.Forms.TabPage tabPageAtoms;
        private System.Windows.Forms.TreeView treeViewObjectCommunications;
        private System.Windows.Forms.TreeView treeViewMainCommunications;
        private System.Windows.Forms.DataGridView dataGridViewInformation;
        private System.Windows.Forms.CheckBox checkBoxStudents;
        private System.Windows.Forms.CheckBox checkBoxTeachers;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}