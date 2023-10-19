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
			this.dataGridViewGradebook = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGradebook)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewGradebook
			// 
			this.dataGridViewGradebook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewGradebook.Location = new System.Drawing.Point(367, 252);
			this.dataGridViewGradebook.Name = "dataGridViewGradebook";
			this.dataGridViewGradebook.Size = new System.Drawing.Size(745, 300);
			this.dataGridViewGradebook.TabIndex = 0;
			// 
			// FormGradebook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1384, 761);
			this.Controls.Add(this.dataGridViewGradebook);
			this.Name = "FormGradebook";
			this.Text = "FormGradebook";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGradebook_FormClosing);
			this.Load += new System.EventHandler(this.FormGradebook_Load);
			this.SizeChanged += new System.EventHandler(this.FormGradebook_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGradebook)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewGradebook;
	}
}