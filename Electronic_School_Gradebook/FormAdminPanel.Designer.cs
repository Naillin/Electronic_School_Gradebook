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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.treeViewObjectCommunications = new System.Windows.Forms.TreeView();
			this.treeViewMainCommunications = new System.Windows.Forms.TreeView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.checkBoxStudents = new System.Windows.Forms.CheckBox();
			this.checkBoxTeachers = new System.Windows.Forms.CheckBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(9, 37);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1106, 714);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dataGridView1);
			this.tabPage1.Controls.Add(this.treeViewObjectCommunications);
			this.tabPage1.Controls.Add(this.treeViewMainCommunications);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage1.Size = new System.Drawing.Size(1098, 688);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(185, 161);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(478, 209);
			this.dataGridView1.TabIndex = 2;
			// 
			// treeViewObjectCommunications
			// 
			this.treeViewObjectCommunications.Location = new System.Drawing.Point(185, 7);
			this.treeViewObjectCommunications.Margin = new System.Windows.Forms.Padding(2);
			this.treeViewObjectCommunications.Name = "treeViewObjectCommunications";
			this.treeViewObjectCommunications.Size = new System.Drawing.Size(479, 150);
			this.treeViewObjectCommunications.TabIndex = 1;
			// 
			// treeViewMainCommunications
			// 
			this.treeViewMainCommunications.Location = new System.Drawing.Point(2, 7);
			this.treeViewMainCommunications.Margin = new System.Windows.Forms.Padding(2);
			this.treeViewMainCommunications.Name = "treeViewMainCommunications";
			this.treeViewMainCommunications.Size = new System.Drawing.Size(177, 362);
			this.treeViewMainCommunications.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage2.Size = new System.Drawing.Size(1098, 688);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// checkBoxStudents
			// 
			this.checkBoxStudents.AutoSize = true;
			this.checkBoxStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkBoxStudents.Location = new System.Drawing.Point(161, 16);
			this.checkBoxStudents.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxStudents.Name = "checkBoxStudents";
			this.checkBoxStudents.Size = new System.Drawing.Size(93, 24);
			this.checkBoxStudents.TabIndex = 1;
			this.checkBoxStudents.Text = "Students";
			this.checkBoxStudents.UseVisualStyleBackColor = true;
			this.checkBoxStudents.CheckedChanged += new System.EventHandler(this.checkBoxStudents_CheckedChanged);
			// 
			// checkBoxTeachers
			// 
			this.checkBoxTeachers.AutoSize = true;
			this.checkBoxTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkBoxTeachers.Location = new System.Drawing.Point(323, 16);
			this.checkBoxTeachers.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxTeachers.Name = "checkBoxTeachers";
			this.checkBoxTeachers.Size = new System.Drawing.Size(94, 24);
			this.checkBoxTeachers.TabIndex = 2;
			this.checkBoxTeachers.Text = "Teachers";
			this.checkBoxTeachers.UseVisualStyleBackColor = true;
			this.checkBoxTeachers.CheckedChanged += new System.EventHandler(this.checkBoxTeachers_CheckedChanged);
			// 
			// FormAdminPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1126, 762);
			this.Controls.Add(this.checkBoxTeachers);
			this.Controls.Add(this.checkBoxStudents);
			this.Controls.Add(this.tabControl1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FormAdminPanel";
			this.Text = "Control Panel";
			this.Load += new System.EventHandler(this.FormAdminPanel_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeViewObjectCommunications;
        private System.Windows.Forms.TreeView treeViewMainCommunications;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBoxStudents;
        private System.Windows.Forms.CheckBox checkBoxTeachers;
    }
}