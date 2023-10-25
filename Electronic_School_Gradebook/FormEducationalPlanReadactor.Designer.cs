namespace Electronic_School_Gradebook
{
	partial class FormEducationalPlanReadactor
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
			this.listBoxClasses = new System.Windows.Forms.ListBox();
			this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
			this.listBoxSubjects = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
			this.SuspendLayout();
			// 
			// listBoxClasses
			// 
			this.listBoxClasses.BackColor = System.Drawing.Color.White;
			this.listBoxClasses.Font = new System.Drawing.Font("Arcon", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxClasses.FormattingEnabled = true;
			this.listBoxClasses.ItemHeight = 23;
			this.listBoxClasses.Location = new System.Drawing.Point(12, 12);
			this.listBoxClasses.Name = "listBoxClasses";
			this.listBoxClasses.Size = new System.Drawing.Size(149, 418);
			this.listBoxClasses.TabIndex = 1;
			this.listBoxClasses.SelectedIndexChanged += new System.EventHandler(this.listBoxClasses_SelectedIndexChanged);
			// 
			// dataGridViewTasks
			// 
			this.dataGridViewTasks.AllowUserToResizeRows = false;
			this.dataGridViewTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewTasks.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTasks.Location = new System.Drawing.Point(322, 12);
			this.dataGridViewTasks.Name = "dataGridViewTasks";
			this.dataGridViewTasks.Size = new System.Drawing.Size(466, 418);
			this.dataGridViewTasks.TabIndex = 5;
			this.dataGridViewTasks.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewTasks_CellBeginEdit);
			this.dataGridViewTasks.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTasks_CellEndEdit);
			// 
			// listBoxSubjects
			// 
			this.listBoxSubjects.BackColor = System.Drawing.Color.White;
			this.listBoxSubjects.Font = new System.Drawing.Font("Arcon", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxSubjects.FormattingEnabled = true;
			this.listBoxSubjects.ItemHeight = 23;
			this.listBoxSubjects.Location = new System.Drawing.Point(167, 12);
			this.listBoxSubjects.Name = "listBoxSubjects";
			this.listBoxSubjects.Size = new System.Drawing.Size(149, 418);
			this.listBoxSubjects.TabIndex = 7;
			this.listBoxSubjects.SelectedIndexChanged += new System.EventHandler(this.listBoxSubjects_SelectedIndexChanged);
			// 
			// FormEducationalPlanReadactor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.listBoxSubjects);
			this.Controls.Add(this.dataGridViewTasks);
			this.Controls.Add(this.listBoxClasses);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormEducationalPlanReadactor";
			this.Text = "FormEducationalPlanReadactor";
			this.Load += new System.EventHandler(this.FormEducationalPlanReadactor_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxClasses;
		private System.Windows.Forms.DataGridView dataGridViewTasks;
		private System.Windows.Forms.ListBox listBoxSubjects;
	}
}