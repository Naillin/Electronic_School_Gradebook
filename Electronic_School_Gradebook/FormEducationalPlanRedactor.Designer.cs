namespace Electronic_School_Gradebook
{
	partial class FormEducationalPlanRedactor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEducationalPlanRedactor));
			this.listBoxClasses = new System.Windows.Forms.ListBox();
			this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.listBoxSubjects = new System.Windows.Forms.ListBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.labelSelectedWork = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
			this.SuspendLayout();
			// 
			// listBoxClasses
			// 
			this.listBoxClasses.BackColor = System.Drawing.Color.AliceBlue;
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
            this.Column2});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Italic);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTasks.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewTasks.Location = new System.Drawing.Point(322, 12);
			this.dataGridViewTasks.Name = "dataGridViewTasks";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTasks.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewTasks.Size = new System.Drawing.Size(557, 340);
			this.dataGridViewTasks.TabIndex = 5;
			this.dataGridViewTasks.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewTasks_CellBeginEdit);
			this.dataGridViewTasks.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTasks_CellEndEdit);
			this.dataGridViewTasks.Click += new System.EventHandler(this.dataGridViewTasks_Click);
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Задача";
			this.Column1.Name = "Column1";
			this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Дата создания";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// listBoxSubjects
			// 
			this.listBoxSubjects.BackColor = System.Drawing.Color.Linen;
			this.listBoxSubjects.Font = new System.Drawing.Font("Arcon", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxSubjects.FormattingEnabled = true;
			this.listBoxSubjects.ItemHeight = 23;
			this.listBoxSubjects.Location = new System.Drawing.Point(167, 12);
			this.listBoxSubjects.Name = "listBoxSubjects";
			this.listBoxSubjects.Size = new System.Drawing.Size(149, 418);
			this.listBoxSubjects.TabIndex = 7;
			this.listBoxSubjects.SelectedIndexChanged += new System.EventHandler(this.listBoxSubjects_SelectedIndexChanged);
			// 
			// buttonAdd
			// 
			this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(241)))), ((int)(((byte)(187)))));
			this.buttonAdd.FlatAppearance.BorderSize = 0;
			this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAdd.Font = new System.Drawing.Font("Arcon", 15.75F, System.Drawing.FontStyle.Italic);
			this.buttonAdd.ForeColor = System.Drawing.Color.Transparent;
			this.buttonAdd.Location = new System.Drawing.Point(322, 393);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(225, 37);
			this.buttonAdd.TabIndex = 8;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = false;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
			this.buttonDelete.FlatAppearance.BorderSize = 0;
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDelete.Font = new System.Drawing.Font("Arcon", 15.75F, System.Drawing.FontStyle.Italic);
			this.buttonDelete.ForeColor = System.Drawing.Color.Transparent;
			this.buttonDelete.Location = new System.Drawing.Point(654, 393);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(225, 37);
			this.buttonDelete.TabIndex = 9;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.UseVisualStyleBackColor = false;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// labelSelectedWork
			// 
			this.labelSelectedWork.AutoSize = true;
			this.labelSelectedWork.BackColor = System.Drawing.Color.Transparent;
			this.labelSelectedWork.Font = new System.Drawing.Font("Arcon", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSelectedWork.Location = new System.Drawing.Point(316, 355);
			this.labelSelectedWork.Name = "labelSelectedWork";
			this.labelSelectedWork.Size = new System.Drawing.Size(202, 35);
			this.labelSelectedWork.TabIndex = 10;
			this.labelSelectedWork.Text = "Selected work: ";
			// 
			// FormEducationalPlanRedactor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(891, 450);
			this.Controls.Add(this.labelSelectedWork);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.listBoxSubjects);
			this.Controls.Add(this.dataGridViewTasks);
			this.Controls.Add(this.listBoxClasses);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormEducationalPlanRedactor";
			this.Text = "Educational Plan Redactor";
			this.Load += new System.EventHandler(this.FormEducationalPlanRedactor_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxClasses;
		private System.Windows.Forms.DataGridView dataGridViewTasks;
		private System.Windows.Forms.ListBox listBoxSubjects;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Label labelSelectedWork;
	}
}