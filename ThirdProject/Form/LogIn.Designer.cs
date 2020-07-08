namespace ThirdProject
{
    partial class LogIn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogIn = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txeId = new DevExpress.XtraEditors.TextEdit();
            this.lblSignUp = new System.Windows.Forms.Label();
            this.txePassword = new DevExpress.XtraEditors.TextEdit();
            this.lblLogIn = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txeId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txePassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnLogIn);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txeId);
            this.panel1.Controls.Add(this.lblSignUp);
            this.panel1.Controls.Add(this.txePassword);
            this.panel1.Controls.Add(this.lblLogIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 409);
            this.panel1.TabIndex = 11;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnLogIn.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Appearance.Options.UseBackColor = true;
            this.btnLogIn.Appearance.Options.UseFont = true;
            this.btnLogIn.Appearance.Options.UseForeColor = true;
            this.btnLogIn.Location = new System.Drawing.Point(57, 288);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(250, 50);
            this.btnLogIn.TabIndex = 13;
            this.btnLogIn.Text = "완료";
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(57, 231);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 1);
            this.panel3.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(57, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 1);
            this.panel2.TabIndex = 11;
            // 
            // txeId
            // 
            this.txeId.EditValue = "아이디";
            this.txeId.Location = new System.Drawing.Point(57, 157);
            this.txeId.Name = "txeId";
            this.txeId.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txeId.Properties.Appearance.Options.UseBackColor = true;
            this.txeId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txeId.Size = new System.Drawing.Size(250, 22);
            this.txeId.TabIndex = 9;
            this.txeId.Click += new System.EventHandler(this.txeId_Click);
            this.txeId.MouseLeave += new System.EventHandler(this.txeId_MouseLeave);
            // 
            // lblSignUp
            // 
            this.lblSignUp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSignUp.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignUp.Location = new System.Drawing.Point(0, 347);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(369, 62);
            this.lblSignUp.TabIndex = 8;
            this.lblSignUp.Text = "회원가입";
            this.lblSignUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSignUp.UseMnemonic = false;
            this.lblSignUp.Click += new System.EventHandler(this.lblSignUp_Click);
            // 
            // txePassword
            // 
            this.txePassword.EditValue = "비밀번호를 입력하세요";
            this.txePassword.Location = new System.Drawing.Point(57, 203);
            this.txePassword.Name = "txePassword";
            this.txePassword.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txePassword.Properties.Appearance.Options.UseBackColor = true;
            this.txePassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txePassword.Properties.PasswordChar = '*';
            this.txePassword.Size = new System.Drawing.Size(250, 22);
            this.txePassword.TabIndex = 10;
            this.txePassword.Click += new System.EventHandler(this.txePassword_Click);
            this.txePassword.MouseLeave += new System.EventHandler(this.txePassword_MouseLeave);
            // 
            // lblLogIn
            // 
            this.lblLogIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogIn.Font = new System.Drawing.Font("Malgun Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLogIn.Location = new System.Drawing.Point(3, 0);
            this.lblLogIn.Name = "lblLogIn";
            this.lblLogIn.Size = new System.Drawing.Size(363, 83);
            this.lblLogIn.TabIndex = 4;
            this.lblLogIn.Text = "LOGIN";
            this.lblLogIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogIn
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 409);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LogIn";
            this.Text = "로그인";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txeId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txePassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblLogIn;
        private System.Windows.Forms.Label lblSignUp;
        private DevExpress.XtraEditors.TextEdit txeId;
        private DevExpress.XtraEditors.TextEdit txePassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnLogIn;
    }
}