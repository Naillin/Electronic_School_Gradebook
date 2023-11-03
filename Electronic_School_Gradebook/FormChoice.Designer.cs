namespace Electronic_School_Gradebook
{
	partial class FormChoice
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChoice));
			this.labelClasses = new System.Windows.Forms.Label();
			this.labelTasks = new System.Windows.Forms.Label();
			this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
			this.buttonAccept = new System.Windows.Forms.Button();
			this.listBoxClasses = new System.Windows.Forms.ListBox();
			this.listBoxSubjects = new System.Windows.Forms.ListBox();
			this.labelSubjects = new System.Windows.Forms.Label();
			this.buttonSelectAll = new System.Windows.Forms.Button();
			this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
			this.SuspendLayout();
			// 
			// labelClasses
			// 
			this.labelClasses.AutoSize = true;
			this.labelClasses.BackColor = System.Drawing.Color.Transparent;
			this.labelClasses.Font = new System.Drawing.Font("Arcon", 36F, System.Drawing.FontStyle.Italic);
			this.labelClasses.Location = new System.Drawing.Point(12, 16);
			this.labelClasses.Name = "labelClasses";
			this.labelClasses.Size = new System.Drawing.Size(183, 58);
			this.labelClasses.TabIndex = 2;
			this.labelClasses.Text = "Classes";
			// 
			// labelTasks
			// 
			this.labelTasks.AutoSize = true;
			this.labelTasks.BackColor = System.Drawing.Color.Transparent;
			this.labelTasks.Font = new System.Drawing.Font("Arcon", 36F, System.Drawing.FontStyle.Italic);
			this.labelTasks.Location = new System.Drawing.Point(525, 16);
			this.labelTasks.Name = "labelTasks";
			this.labelTasks.Size = new System.Drawing.Size(138, 58);
			this.labelTasks.TabIndex = 3;
			this.labelTasks.Text = "Tasks";
			// 
			// dataGridViewTasks
			// 
			this.dataGridViewTasks.AllowUserToAddRows = false;
			this.dataGridViewTasks.AllowUserToDeleteRows = false;
			this.dataGridViewTasks.AllowUserToResizeRows = false;
			this.dataGridViewTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewTasks.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Italic);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTasks.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewTasks.Location = new System.Drawing.Point(525, 77);
			this.dataGridViewTasks.Name = "dataGridViewTasks";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arcon", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTasks.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewTasks.Size = new System.Drawing.Size(640, 349);
			this.dataGridViewTasks.TabIndex = 4;
			// 
			// buttonAccept
			// 
			this.buttonAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(241)))), ((int)(((byte)(187)))));
			this.buttonAccept.FlatAppearance.BorderSize = 0;
			this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAccept.Font = new System.Drawing.Font("Arcon", 15.75F, System.Drawing.FontStyle.Italic);
			this.buttonAccept.ForeColor = System.Drawing.Color.Transparent;
			this.buttonAccept.Location = new System.Drawing.Point(12, 432);
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.Size = new System.Drawing.Size(1153, 43);
			this.buttonAccept.TabIndex = 5;
			this.buttonAccept.Text = "Accept";
			this.buttonAccept.UseVisualStyleBackColor = false;
			this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
			// 
			// listBoxClasses
			// 
			this.listBoxClasses.BackColor = System.Drawing.Color.AliceBlue;
			this.listBoxClasses.Font = new System.Drawing.Font("Arcon", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxClasses.FormattingEnabled = true;
			this.listBoxClasses.ItemHeight = 23;
			this.listBoxClasses.Location = new System.Drawing.Point(12, 77);
			this.listBoxClasses.Name = "listBoxClasses";
			this.listBoxClasses.Size = new System.Drawing.Size(247, 349);
			this.listBoxClasses.TabIndex = 0;
			this.listBoxClasses.SelectedIndexChanged += new System.EventHandler(this.listBoxClasses_SelectedIndexChanged);
			// 
			// listBoxSubjects
			// 
			this.listBoxSubjects.BackColor = System.Drawing.Color.Linen;
			this.listBoxSubjects.Font = new System.Drawing.Font("Arcon", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxSubjects.FormattingEnabled = true;
			this.listBoxSubjects.ItemHeight = 23;
			this.listBoxSubjects.Location = new System.Drawing.Point(265, 77);
			this.listBoxSubjects.Name = "listBoxSubjects";
			this.listBoxSubjects.Size = new System.Drawing.Size(247, 349);
			this.listBoxSubjects.TabIndex = 6;
			this.listBoxSubjects.SelectedIndexChanged += new System.EventHandler(this.listBoxSubjects_SelectedIndexChanged);
			// 
			// labelSubjects
			// 
			this.labelSubjects.AutoSize = true;
			this.labelSubjects.BackColor = System.Drawing.Color.Transparent;
			this.labelSubjects.Font = new System.Drawing.Font("Arcon", 36F, System.Drawing.FontStyle.Italic);
			this.labelSubjects.Location = new System.Drawing.Point(265, 16);
			this.labelSubjects.Name = "labelSubjects";
			this.labelSubjects.Size = new System.Drawing.Size(197, 58);
			this.labelSubjects.TabIndex = 7;
			this.labelSubjects.Text = "Subjects";
			// 
			// buttonSelectAll
			// 
			this.buttonSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(241)))), ((int)(((byte)(187)))));
			this.buttonSelectAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSelectAll.BackgroundImage")));
			this.buttonSelectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonSelectAll.FlatAppearance.BorderSize = 0;
			this.buttonSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSelectAll.Font = new System.Drawing.Font("Arcon", 15.75F, System.Drawing.FontStyle.Italic);
			this.buttonSelectAll.ForeColor = System.Drawing.Color.Transparent;
			this.buttonSelectAll.Location = new System.Drawing.Point(536, 81);
			this.buttonSelectAll.Name = "buttonSelectAll";
			this.buttonSelectAll.Size = new System.Drawing.Size(20, 20);
			this.buttonSelectAll.TabIndex = 8;
			this.buttonSelectAll.UseVisualStyleBackColor = false;
			this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
			// 
			// Column1
			// 
			this.Column1.FillWeight = 49.97757F;
			this.Column1.HeaderText = "On";
			this.Column1.Name = "Column1";
			// 
			// Column2
			// 
			this.Column2.FillWeight = 139.1043F;
			this.Column2.HeaderText = "Task";
			this.Column2.Name = "Column2";
			this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column3
			// 
			this.Column3.FillWeight = 101.5229F;
			this.Column3.HeaderText = "Date create";
			this.Column3.Name = "Column3";
			this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column4
			// 
			this.Column4.FillWeight = 109.3954F;
			this.Column4.HeaderText = "Type";
			this.Column4.Name = "Column4";
			this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// FormChoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1177, 494);
			this.Controls.Add(this.buttonSelectAll);
			this.Controls.Add(this.labelSubjects);
			this.Controls.Add(this.listBoxSubjects);
			this.Controls.Add(this.buttonAccept);
			this.Controls.Add(this.dataGridViewTasks);
			this.Controls.Add(this.labelTasks);
			this.Controls.Add(this.labelClasses);
			this.Controls.Add(this.listBoxClasses);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormChoice";
			this.Text = "FormChoice";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChoice_FormClosing);
			this.Load += new System.EventHandler(this.FormChoice_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelClasses;
		private System.Windows.Forms.Label labelTasks;
		private System.Windows.Forms.DataGridView dataGridViewTasks;
		private System.Windows.Forms.Button buttonAccept;
		private System.Windows.Forms.ListBox listBoxClasses;
		private System.Windows.Forms.ListBox listBoxSubjects;
		private System.Windows.Forms.Label labelSubjects;
		private System.Windows.Forms.Button buttonSelectAll;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
	}
}