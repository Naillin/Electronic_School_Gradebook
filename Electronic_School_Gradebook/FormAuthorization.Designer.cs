namespace Electronic_School_Gradebook
{
    partial class FormAuthorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuthorization));
			this.buttonLogin = new System.Windows.Forms.Button();
			this.buttonOptions = new System.Windows.Forms.Button();
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonLogin
			// 
			this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(241)))), ((int)(((byte)(187)))));
			this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonLogin.Font = new System.Drawing.Font("Arcon", 15.75F, System.Drawing.FontStyle.Italic);
			this.buttonLogin.ForeColor = System.Drawing.Color.White;
			this.buttonLogin.Location = new System.Drawing.Point(102, 264);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(208, 43);
			this.buttonLogin.TabIndex = 1;
			this.buttonLogin.Text = "Sign in";
			this.buttonLogin.UseVisualStyleBackColor = false;
			this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
			// 
			// buttonOptions
			// 
			this.buttonOptions.BackColor = System.Drawing.Color.Gold;
			this.buttonOptions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOptions.BackgroundImage")));
			this.buttonOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOptions.ForeColor = System.Drawing.Color.White;
			this.buttonOptions.Location = new System.Drawing.Point(367, 574);
			this.buttonOptions.Name = "buttonOptions";
			this.buttonOptions.Size = new System.Drawing.Size(35, 35);
			this.buttonOptions.TabIndex = 3;
			this.buttonOptions.UseVisualStyleBackColor = false;
			this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelTitle.Font = new System.Drawing.Font("Arcon", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(77, 102);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(256, 58);
			this.labelTitle.TabIndex = 4;
			this.labelTitle.Text = "Gradebook";
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.BackColor = System.Drawing.Color.White;
			this.textBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxLogin.Font = new System.Drawing.Font("Arcon", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxLogin.ForeColor = System.Drawing.Color.Silver;
			this.textBoxLogin.Location = new System.Drawing.Point(102, 192);
			this.textBoxLogin.Multiline = true;
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(208, 30);
			this.textBoxLogin.TabIndex = 7;
			this.textBoxLogin.Text = "Login";
			this.textBoxLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBoxLogin.Enter += new System.EventHandler(this.textBoxLogin_Enter);
			this.textBoxLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLogin_KeyPress);
			this.textBoxLogin.Leave += new System.EventHandler(this.textBoxLogin_Leave);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.BackColor = System.Drawing.Color.White;
			this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxPassword.Font = new System.Drawing.Font("Arcon", 15.75F, System.Drawing.FontStyle.Italic);
			this.textBoxPassword.ForeColor = System.Drawing.Color.Silver;
			this.textBoxPassword.Location = new System.Drawing.Point(102, 228);
			this.textBoxPassword.Multiline = true;
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(208, 30);
			this.textBoxPassword.TabIndex = 8;
			this.textBoxPassword.Text = "Password";
			this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
			this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_KeyPress);
			this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
			// 
			// FormAuthorization
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(414, 621);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.buttonOptions);
			this.Controls.Add(this.buttonLogin);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormAuthorization";
			this.Text = "Authorization";
			this.Load += new System.EventHandler(this.FormAuthorization_Load);
			this.Click += new System.EventHandler(this.FormAuthorization_Click);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxLogin;
		private System.Windows.Forms.TextBox textBoxPassword;
	}
}

