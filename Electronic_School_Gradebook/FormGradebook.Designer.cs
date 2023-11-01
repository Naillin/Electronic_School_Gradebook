namespace Electronic_School_Gradebook
{
	partial class FormGradebook
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGradebook));
			this.dataGridViewGradebook = new System.Windows.Forms.DataGridView();
			this.labelClass = new System.Windows.Forms.Label();
			this.notifyIconInfoUser = new System.Windows.Forms.NotifyIcon(this.components);
			this.statusStripStatus = new System.Windows.Forms.StatusStrip();
			this.menuStripGradebook = new System.Windows.Forms.MenuStrip();
			this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gradebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.plansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelSubject = new System.Windows.Forms.Label();
			this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelCountStudens = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelCountTasks = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGradebook)).BeginInit();
			this.statusStripStatus.SuspendLayout();
			this.menuStripGradebook.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridViewGradebook
			// 
			this.dataGridViewGradebook.AllowUserToAddRows = false;
			this.dataGridViewGradebook.AllowUserToDeleteRows = false;
			this.dataGridViewGradebook.AllowUserToResizeRows = false;
			this.dataGridViewGradebook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewGradebook.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewGradebook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewGradebook.Location = new System.Drawing.Point(12, 92);
			this.dataGridViewGradebook.Name = "dataGridViewGradebook";
			this.dataGridViewGradebook.Size = new System.Drawing.Size(1360, 630);
			this.dataGridViewGradebook.TabIndex = 0;
			this.dataGridViewGradebook.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewGradebook_CellBeginEdit);
			this.dataGridViewGradebook.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGradebook_CellEndEdit);
			this.dataGridViewGradebook.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewGradebook_EditingControlShowing);
			this.dataGridViewGradebook.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewGradebook_KeyPress);
			this.dataGridViewGradebook.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewGradebook_MouseClick);
			// 
			// labelClass
			// 
			this.labelClass.AutoSize = true;
			this.labelClass.BackColor = System.Drawing.Color.Transparent;
			this.labelClass.Font = new System.Drawing.Font("Arcon", 36F, System.Drawing.FontStyle.Italic);
			this.labelClass.Location = new System.Drawing.Point(12, 25);
			this.labelClass.Name = "labelClass";
			this.labelClass.Size = new System.Drawing.Size(138, 58);
			this.labelClass.TabIndex = 4;
			this.labelClass.Text = "Class";
			// 
			// notifyIconInfoUser
			// 
			this.notifyIconInfoUser.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIconInfoUser.BalloonTipText = "Empty";
			this.notifyIconInfoUser.BalloonTipTitle = "Журнал активен.";
			this.notifyIconInfoUser.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconInfoUser.Icon")));
			this.notifyIconInfoUser.Text = "Empty";
			this.notifyIconInfoUser.Visible = true;
			this.notifyIconInfoUser.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
			// 
			// statusStripStatus
			// 
			this.statusStripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelCountStudens,
            this.toolStripStatusLabelCountTasks});
			this.statusStripStatus.Location = new System.Drawing.Point(0, 739);
			this.statusStripStatus.Name = "statusStripStatus";
			this.statusStripStatus.Size = new System.Drawing.Size(1384, 22);
			this.statusStripStatus.TabIndex = 5;
			this.statusStripStatus.Text = "statusStripStatus";
			// 
			// menuStripGradebook
			// 
			this.menuStripGradebook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStripGradebook.BackgroundImage")));
			this.menuStripGradebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.menuStripGradebook.Font = new System.Drawing.Font("Arcon", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStripGradebook.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.gradebookToolStripMenuItem});
			this.menuStripGradebook.Location = new System.Drawing.Point(0, 0);
			this.menuStripGradebook.Name = "menuStripGradebook";
			this.menuStripGradebook.Size = new System.Drawing.Size(1384, 26);
			this.menuStripGradebook.TabIndex = 6;
			this.menuStripGradebook.Text = "menuStrip1";
			// 
			// systemToolStripMenuItem
			// 
			this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
			this.systemToolStripMenuItem.Size = new System.Drawing.Size(65, 22);
			this.systemToolStripMenuItem.Text = "System";
			// 
			// logoutToolStripMenuItem
			// 
			this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
			this.logoutToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.logoutToolStripMenuItem.Text = "Logout";
			this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// gradebookToolStripMenuItem
			// 
			this.gradebookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeTasksToolStripMenuItem,
            this.plansToolStripMenuItem});
			this.gradebookToolStripMenuItem.Name = "gradebookToolStripMenuItem";
			this.gradebookToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.gradebookToolStripMenuItem.Text = "Gradebook";
			// 
			// changeTasksToolStripMenuItem
			// 
			this.changeTasksToolStripMenuItem.Name = "changeTasksToolStripMenuItem";
			this.changeTasksToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.changeTasksToolStripMenuItem.Text = "Change tasks";
			this.changeTasksToolStripMenuItem.Click += new System.EventHandler(this.changeTasksToolStripMenuItem_Click);
			// 
			// plansToolStripMenuItem
			// 
			this.plansToolStripMenuItem.Name = "plansToolStripMenuItem";
			this.plansToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.plansToolStripMenuItem.Text = "Educational plans";
			this.plansToolStripMenuItem.Click += new System.EventHandler(this.plansToolStripMenuItem_Click);
			// 
			// labelSubject
			// 
			this.labelSubject.AutoSize = true;
			this.labelSubject.BackColor = System.Drawing.Color.Transparent;
			this.labelSubject.Font = new System.Drawing.Font("Arcon", 36F, System.Drawing.FontStyle.Italic);
			this.labelSubject.Location = new System.Drawing.Point(495, 25);
			this.labelSubject.Name = "labelSubject";
			this.labelSubject.Size = new System.Drawing.Size(177, 58);
			this.labelSubject.TabIndex = 7;
			this.labelSubject.Text = "Subject";
			// 
			// toolStripStatusLabelUser
			// 
			this.toolStripStatusLabelUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.toolStripStatusLabelUser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabelUser.Image")));
			this.toolStripStatusLabelUser.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
			this.toolStripStatusLabelUser.Size = new System.Drawing.Size(151, 17);
			this.toolStripStatusLabelUser.Text = "toolStripStatusLabelUser";
			// 
			// toolStripStatusLabelCountStudens
			// 
			this.toolStripStatusLabelCountStudens.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabelCountStudens.Image")));
			this.toolStripStatusLabelCountStudens.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.toolStripStatusLabelCountStudens.Name = "toolStripStatusLabelCountStudens";
			this.toolStripStatusLabelCountStudens.Size = new System.Drawing.Size(203, 17);
			this.toolStripStatusLabelCountStudens.Text = "toolStripStatusLabelCountStudens";
			// 
			// toolStripStatusLabelCountTasks
			// 
			this.toolStripStatusLabelCountTasks.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabelCountTasks.Image")));
			this.toolStripStatusLabelCountTasks.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.toolStripStatusLabelCountTasks.Name = "toolStripStatusLabelCountTasks";
			this.toolStripStatusLabelCountTasks.Size = new System.Drawing.Size(188, 17);
			this.toolStripStatusLabelCountTasks.Text = "toolStripStatusLabelCountTasks";
			// 
			// FormGradebook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1384, 761);
			this.Controls.Add(this.labelSubject);
			this.Controls.Add(this.statusStripStatus);
			this.Controls.Add(this.menuStripGradebook);
			this.Controls.Add(this.labelClass);
			this.Controls.Add(this.dataGridViewGradebook);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStripGradebook;
			this.Name = "FormGradebook";
			this.Text = "Gradebook";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGradebook_FormClosing);
			this.Load += new System.EventHandler(this.FormGradebook_Load);
			this.SizeChanged += new System.EventHandler(this.FormGradebook_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGradebook)).EndInit();
			this.statusStripStatus.ResumeLayout(false);
			this.statusStripStatus.PerformLayout();
			this.menuStripGradebook.ResumeLayout(false);
			this.menuStripGradebook.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewGradebook;
		private System.Windows.Forms.Label labelClass;
		private System.Windows.Forms.StatusStrip statusStripStatus;
		private System.Windows.Forms.MenuStrip menuStripGradebook;
		private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gradebookToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeTasksToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem plansToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Label labelSubject;
		private System.Windows.Forms.NotifyIcon notifyIconInfoUser;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCountStudens;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCountTasks;
	}
}