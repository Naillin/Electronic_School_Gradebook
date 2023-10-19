namespace Electronic_School_Gradebook
{
	partial class FormOptions
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonApply = new System.Windows.Forms.Button();
			this.labelPassword = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.labelUserId = new System.Windows.Forms.Label();
			this.textBoxUserId = new System.Windows.Forms.TextBox();
			this.labelInitialCatalog = new System.Windows.Forms.Label();
			this.textBoxInitialCatalog = new System.Windows.Forms.TextBox();
			this.labelDataSource = new System.Windows.Forms.Label();
			this.textBoxDataSource = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
			this.buttonCancel.FlatAppearance.BorderSize = 0;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
			this.buttonCancel.Location = new System.Drawing.Point(12, 339);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(139, 31);
			this.buttonCancel.TabIndex = 20;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = false;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
			this.buttonApply.FlatAppearance.BorderSize = 0;
			this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic);
			this.buttonApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
			this.buttonApply.Location = new System.Drawing.Point(12, 302);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(139, 31);
			this.buttonApply.TabIndex = 19;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = false;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic);
			this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
			this.labelPassword.Location = new System.Drawing.Point(12, 202);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(112, 25);
			this.labelPassword.TabIndex = 18;
			this.labelPassword.Text = "Password:";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxPassword.Location = new System.Drawing.Point(12, 231);
			this.textBoxPassword.Multiline = true;
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(358, 31);
			this.textBoxPassword.TabIndex = 17;
			this.textBoxPassword.Text = "543211234555";
			// 
			// labelUserId
			// 
			this.labelUserId.AutoSize = true;
			this.labelUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic);
			this.labelUserId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
			this.labelUserId.Location = new System.Drawing.Point(12, 139);
			this.labelUserId.Name = "labelUserId";
			this.labelUserId.Size = new System.Drawing.Size(86, 25);
			this.labelUserId.TabIndex = 16;
			this.labelUserId.Text = "User Id:";
			// 
			// textBoxUserId
			// 
			this.textBoxUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxUserId.Location = new System.Drawing.Point(12, 168);
			this.textBoxUserId.Multiline = true;
			this.textBoxUserId.Name = "textBoxUserId";
			this.textBoxUserId.Size = new System.Drawing.Size(358, 31);
			this.textBoxUserId.TabIndex = 15;
			this.textBoxUserId.Text = "connection_user";
			// 
			// labelInitialCatalog
			// 
			this.labelInitialCatalog.AutoSize = true;
			this.labelInitialCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic);
			this.labelInitialCatalog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
			this.labelInitialCatalog.Location = new System.Drawing.Point(12, 76);
			this.labelInitialCatalog.Name = "labelInitialCatalog";
			this.labelInitialCatalog.Size = new System.Drawing.Size(148, 25);
			this.labelInitialCatalog.TabIndex = 14;
			this.labelInitialCatalog.Text = "Initial Catalog:";
			// 
			// textBoxInitialCatalog
			// 
			this.textBoxInitialCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxInitialCatalog.Location = new System.Drawing.Point(12, 105);
			this.textBoxInitialCatalog.Multiline = true;
			this.textBoxInitialCatalog.Name = "textBoxInitialCatalog";
			this.textBoxInitialCatalog.Size = new System.Drawing.Size(358, 31);
			this.textBoxInitialCatalog.TabIndex = 13;
			this.textBoxInitialCatalog.Text = "DB_Electronic_School_Gradebook";
			// 
			// labelDataSource
			// 
			this.labelDataSource.AutoSize = true;
			this.labelDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic);
			this.labelDataSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
			this.labelDataSource.Location = new System.Drawing.Point(12, 13);
			this.labelDataSource.Name = "labelDataSource";
			this.labelDataSource.Size = new System.Drawing.Size(137, 25);
			this.labelDataSource.TabIndex = 12;
			this.labelDataSource.Text = "Data Source:";
			// 
			// textBoxDataSource
			// 
			this.textBoxDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDataSource.Location = new System.Drawing.Point(12, 42);
			this.textBoxDataSource.Multiline = true;
			this.textBoxDataSource.Name = "textBoxDataSource";
			this.textBoxDataSource.Size = new System.Drawing.Size(358, 31);
			this.textBoxDataSource.TabIndex = 11;
			this.textBoxDataSource.Text = "REDDRAGON";
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
			this.ClientSize = new System.Drawing.Size(386, 391);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.labelUserId);
			this.Controls.Add(this.textBoxUserId);
			this.Controls.Add(this.labelInitialCatalog);
			this.Controls.Add(this.textBoxInitialCatalog);
			this.Controls.Add(this.labelDataSource);
			this.Controls.Add(this.textBoxDataSource);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormOptions";
			this.Text = "Options";
			this.Load += new System.EventHandler(this.FormOptions_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Label labelUserId;
		private System.Windows.Forms.TextBox textBoxUserId;
		private System.Windows.Forms.Label labelInitialCatalog;
		private System.Windows.Forms.TextBox textBoxInitialCatalog;
		private System.Windows.Forms.Label labelDataSource;
		private System.Windows.Forms.TextBox textBoxDataSource;
	}
}