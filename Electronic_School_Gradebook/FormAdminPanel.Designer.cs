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
			this.treeViewObjectCommunications = new System.Windows.Forms.TreeView();
			this.treeViewMainCommunications = new System.Windows.Forms.TreeView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(9, 10);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(591, 346);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.treeViewObjectCommunications);
			this.tabPage1.Controls.Add(this.treeViewMainCommunications);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPage1.Size = new System.Drawing.Size(583, 320);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// treeViewObjectCommunications
			// 
			this.treeViewObjectCommunications.Location = new System.Drawing.Point(374, 5);
			this.treeViewObjectCommunications.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.treeViewObjectCommunications.Name = "treeViewObjectCommunications";
			this.treeViewObjectCommunications.Size = new System.Drawing.Size(92, 314);
			this.treeViewObjectCommunications.TabIndex = 1;
			// 
			// treeViewMainCommunications
			// 
			this.treeViewMainCommunications.Location = new System.Drawing.Point(2, 7);
			this.treeViewMainCommunications.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.treeViewMainCommunications.Name = "treeViewMainCommunications";
			this.treeViewMainCommunications.Size = new System.Drawing.Size(177, 316);
			this.treeViewMainCommunications.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPage2.Size = new System.Drawing.Size(583, 320);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// FormAdminPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 366);
			this.Controls.Add(this.tabControl1);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FormAdminPanel";
			this.Text = "FormAdminPanel";
			this.Load += new System.EventHandler(this.FormAdminPanel_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeViewObjectCommunications;
        private System.Windows.Forms.TreeView treeViewMainCommunications;
    }
}