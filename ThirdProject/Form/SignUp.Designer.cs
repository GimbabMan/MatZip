namespace ThirdProject
{
    partial class SignUp
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txeEmail = new DevExpress.XtraEditors.TextEdit();
            this.txeName = new DevExpress.XtraEditors.TextEdit();
            this.txeId = new DevExpress.XtraEditors.TextEdit();
            this.lblSignUp = new System.Windows.Forms.Label();
            this.txePassword = new DevExpress.XtraEditors.TextEdit();
            this.btnComplete = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txeEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txeId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txePassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txeEmail);
            this.panel1.Controls.Add(this.txeName);
            this.panel1.Controls.Add(this.txeId);
            this.panel1.Controls.Add(this.lblSignUp);
            this.panel1.Controls.Add(this.txePassword);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 449);
            this.panel1.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(54, 244);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(250, 1);
            this.panel5.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(54, 209);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 1);
            this.panel4.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(54, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 1);
            this.panel2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(53, 279);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 1);
            this.panel3.TabIndex = 13;
            // 
            // txeEmail
            // 
            this.txeEmail.EditValue = "이메일";
            this.txeEmail.Location = new System.Drawing.Point(53, 251);
            this.txeEmail.Name = "txeEmail";
            this.txeEmail.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txeEmail.Properties.Appearance.Options.UseBackColor = true;
            this.txeEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txeEmail.Size = new System.Drawing.Size(250, 22);
            this.txeEmail.TabIndex = 11;
            this.txeEmail.Click += new System.EventHandler(this.txeEmail_Click);
            this.txeEmail.MouseLeave += new System.EventHandler(this.txeEmail_MouseLeave);
            // 
            // txeName
            // 
            this.txeName.EditValue = "이름";
            this.txeName.Location = new System.Drawing.Point(53, 216);
            this.txeName.Name = "txeName";
            this.txeName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txeName.Properties.Appearance.Options.UseBackColor = true;
            this.txeName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txeName.Size = new System.Drawing.Size(250, 22);
            this.txeName.TabIndex = 2;
            this.txeName.Click += new System.EventHandler(this.txeName_Click);
            this.txeName.MouseLeave += new System.EventHandler(this.txeName_MouseLeave);
            // 
            // txeId
            // 
            this.txeId.EditValue = "아이디";
            this.txeId.Location = new System.Drawing.Point(53, 146);
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
            this.lblSignUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSignUp.Font = new System.Drawing.Font("Malgun Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSignUp.Location = new System.Drawing.Point(0, 0);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(366, 84);
            this.lblSignUp.TabIndex = 4;
            this.lblSignUp.Text = "회원가입";
            this.lblSignUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txePassword
            // 
            this.txePassword.EditValue = "비밀번호";
            this.txePassword.Location = new System.Drawing.Point(53, 181);
            this.txePassword.Name = "txePassword";
            this.txePassword.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txePassword.Properties.Appearance.Options.UseBackColor = true;
            this.txePassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txePassword.Size = new System.Drawing.Size(250, 22);
            this.txePassword.TabIndex = 10;
            this.txePassword.Click += new System.EventHandler(this.txePassword_Click);
            this.txePassword.MouseLeave += new System.EventHandler(this.txePassword_MouseLeave);
            // 
            // btnComplete
            // 
            this.btnComplete.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnComplete.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Appearance.Options.UseBackColor = true;
            this.btnComplete.Appearance.Options.UseFont = true;
            this.btnComplete.Appearance.Options.UseForeColor = true;
            this.btnComplete.Location = new System.Drawing.Point(54, 334);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(250, 50);
            this.btnComplete.TabIndex = 12;
            this.btnComplete.Text = "완료";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // SignUp
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 449);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txeEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txeId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txePassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txeId;
        private System.Windows.Forms.Label lblSignUp;
        private DevExpress.XtraEditors.TextEdit txePassword;
        private DevExpress.XtraEditors.TextEdit txeEmail;
        private DevExpress.XtraEditors.TextEdit txeName;
        private DevExpress.XtraEditors.SimpleButton btnComplete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
    }
}