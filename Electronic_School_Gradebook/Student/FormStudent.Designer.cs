namespace Electronic_School_Gradebook
{
	partial class FormStudent
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStudent));
			this.dataGridViewStudentGradebook = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.listBoxSubjects = new System.Windows.Forms.ListBox();
			this.menuStripStudentGradebook = new System.Windows.Forms.MenuStrip();
			this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelStudent = new System.Windows.Forms.Label();
			this.notifyIconInfoUser = new System.Windows.Forms.NotifyIcon(this.components);
			this.statusStripStatus = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelAVG = new System.Windows.Forms.ToolStripStatusLabel();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentGradebook)).BeginInit();
			this.menuStripStudentGradebook.SuspendLayout();
			this.statusStripStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridViewStudentGradebook
			// 
			this.dataGridViewStudentGradebook.AllowUserToAddRows = false;
			this.dataGridViewStudentGradebook.AllowUserToDeleteRows = false;
			this.dataGridViewStudentGradebook.AllowUserToResizeRows = false;
			this.dataGridViewStudentGradebook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewStudentGradebook.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Italic);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewStudentGradebook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewStudentGradebook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewStudentGradebook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Italic);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewStudentGradebook.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewStudentGradebook.Location = new System.Drawing.Point(265, 103);
			this.dataGridViewStudentGradebook.Name = "dataGridViewStudentGradebook";
			this.dataGridViewStudentGradebook.RowHeadersWidth = 51;
			this.dataGridViewStudentGradebook.Size = new System.Drawing.Size(1107, 625);
			this.dataGridViewStudentGradebook.TabIndex = 1;
			// 
			// Column1
			// 
			this.Column1.FillWeight = 49.43299F;
			this.Column1.HeaderText = "Type";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Name Task";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "Date submission";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column3
			// 
			this.Column3.FillWeight = 22.14062F;
			this.Column3.HeaderText = "Mark";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// listBoxSubjects
			// 
			this.listBoxSubjects.BackColor = System.Drawing.Color.Linen;
			this.listBoxSubjects.Font = new System.Drawing.Font("Arcon", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxSubjects.FormattingEnabled = true;
			this.listBoxSubjects.ItemHeight = 23;
			this.listBoxSubjects.Location = new System.Drawing.Point(12, 34);
			this.listBoxSubjects.Name = "listBoxSubjects";
			this.listBoxSubjects.Size = new System.Drawing.Size(247, 694);
			this.listBoxSubjects.TabIndex = 7;
			this.listBoxSubjects.SelectedIndexChanged += new System.EventHandler(this.listBoxSubjects_SelectedIndexChanged);
			// 
			// menuStripStudentGradebook
			// 
			this.menuStripStudentGradebook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStripStudentGradebook.BackgroundImage")));
			this.menuStripStudentGradebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.menuStripStudentGradebook.Font = new System.Drawing.Font("Arcon", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStripStudentGradebook.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStripStudentGradebook.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem});
			this.menuStripStudentGradebook.Location = new System.Drawing.Point(0, 0);
			this.menuStripStudentGradebook.Name = "menuStripStudentGradebook";
			this.menuStripStudentGradebook.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStripStudentGradebook.Size = new System.Drawing.Size(1384, 26);
			this.menuStripStudentGradebook.TabIndex = 8;
			this.menuStripStudentGradebook.Text = "menuStrip1";
			// 
			// systemToolStripMenuItem
			// 
			this.systemToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
			this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.systemToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
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
			// labelStudent
			// 
			this.labelStudent.AutoSize = true;
			this.labelStudent.BackColor = System.Drawing.Color.Transparent;
			this.labelStudent.Font = new System.Drawing.Font("Arcon", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStudent.Location = new System.Drawing.Point(265, 30);
			this.labelStudent.Name = "labelStudent";
			this.labelStudent.Size = new System.Drawing.Size(107, 35);
			this.labelStudent.TabIndex = 9;
			this.labelStudent.Text = "Student";
			// 
			// notifyIconInfoUser
			// 
			this.notifyIconInfoUser.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIconInfoUser.BalloonTipText = "Empty";
			this.notifyIconInfoUser.BalloonTipTitle = "Gradebook";
			this.notifyIconInfoUser.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconInfoUser.Icon")));
			this.notifyIconInfoUser.Text = "Empty";
			this.notifyIconInfoUser.Visible = true;
			this.notifyIconInfoUser.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconInfoUser_MouseClick);
			// 
			// statusStripStatus
			// 
			this.statusStripStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelAVG});
			this.statusStripStatus.Location = new System.Drawing.Point(0, 736);
			this.statusStripStatus.Name = "statusStripStatus";
			this.statusStripStatus.Size = new System.Drawing.Size(1384, 25);
			this.statusStripStatus.TabIndex = 10;
			this.statusStripStatus.Text = "statusStripStatus";
			// 
			// toolStripStatusLabelUser
			// 
			this.toolStripStatusLabelUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.toolStripStatusLabelUser.Font = new System.Drawing.Font("Arcon", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripStatusLabelUser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabelUser.Image")));
			this.toolStripStatusLabelUser.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
			this.toolStripStatusLabelUser.Size = new System.Drawing.Size(181, 20);
			this.toolStripStatusLabelUser.Text = "toolStripStatusLabelUser";
			// 
			// toolStripStatusLabelAVG
			// 
			this.toolStripStatusLabelAVG.Font = new System.Drawing.Font("Arcon", 11.25F);
			this.toolStripStatusLabelAVG.Name = "toolStripStatusLabelAVG";
			this.toolStripStatusLabelAVG.Size = new System.Drawing.Size(21, 20);
			this.toolStripStatusLabelAVG.Text = "@";
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxSearch.Location = new System.Drawing.Point(265, 68);
			this.textBoxSearch.MaxLength = 50;
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(1107, 29);
			this.textBoxSearch.TabIndex = 11;
			this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
			// 
			// FormStudent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1384, 761);
			this.Controls.Add(this.textBoxSearch);
			this.Controls.Add(this.statusStripStatus);
			this.Controls.Add(this.labelStudent);
			this.Controls.Add(this.menuStripStudentGradebook);
			this.Controls.Add(this.listBoxSubjects);
			this.Controls.Add(this.dataGridViewStudentGradebook);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormStudent";
			this.Text = "Gradebook";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStudent_FormClosing);
			this.Load += new System.EventHandler(this.FormStudent_Load);
			this.SizeChanged += new System.EventHandler(this.FormStudent_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentGradebook)).EndInit();
			this.menuStripStudentGradebook.ResumeLayout(false);
			this.menuStripStudentGradebook.PerformLayout();
			this.statusStripStatus.ResumeLayout(false);
			this.statusStripStatus.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewStudentGradebook;
		private System.Windows.Forms.ListBox listBoxSubjects;
		private System.Windows.Forms.MenuStrip menuStripStudentGradebook;
		private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Label labelStudent;
		private System.Windows.Forms.NotifyIcon notifyIconInfoUser;
		private System.Windows.Forms.StatusStrip statusStripStatus;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
		private System.Windows.Forms.TextBox textBoxSearch;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAVG;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
	}
}