namespace ThirdProject
{
    partial class inputReview
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
            this.label2 = new System.Windows.Forms.Label();
            this.txbGrade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComplete = new DevExpress.XtraEditors.SimpleButton();
            this.txbComment = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.pcbReviewPicture = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReviewPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbGrade);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Controls.Add(this.txbComment);
            this.panel1.Controls.Add(this.lblUserId);
            this.panel1.Controls.Add(this.pcbReviewPicture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 516);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "(1점~5점 입력해주세요)";
            // 
            // txbGrade
            // 
            this.txbGrade.Location = new System.Drawing.Point(124, 364);
            this.txbGrade.Name = "txbGrade";
            this.txbGrade.Size = new System.Drawing.Size(150, 26);
            this.txbGrade.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "평점입력:";
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplete.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnComplete.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Appearance.Options.UseBackColor = true;
            this.btnComplete.Appearance.Options.UseFont = true;
            this.btnComplete.Appearance.Options.UseForeColor = true;
            this.btnComplete.Location = new System.Drawing.Point(3, 415);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(495, 97);
            this.btnComplete.TabIndex = 14;
            this.btnComplete.Text = "완료";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // txbComment
            // 
            this.txbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbComment.Location = new System.Drawing.Point(3, 219);
            this.txbComment.Multiline = true;
            this.txbComment.Name = "txbComment";
            this.txbComment.Size = new System.Drawing.Size(497, 103);
            this.txbComment.TabIndex = 2;
            this.txbComment.Text = "코멘트를 남겨주세요";
            this.txbComment.Click += new System.EventHandler(this.txbComment_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserId.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserId.ForeColor = System.Drawing.Color.Black;
            this.lblUserId.Location = new System.Drawing.Point(3, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(492, 50);
            this.lblUserId.TabIndex = 1;
            this.lblUserId.Text = "유저 아이디";
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcbReviewPicture
            // 
            this.pcbReviewPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbReviewPicture.Image = global::ThirdProject.Properties.Resources.이미지_등록;
            this.pcbReviewPicture.Location = new System.Drawing.Point(0, 53);
            this.pcbReviewPicture.Name = "pcbReviewPicture";
            this.pcbReviewPicture.Size = new System.Drawing.Size(500, 160);
            this.pcbReviewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbReviewPicture.TabIndex = 0;
            this.pcbReviewPicture.TabStop = false;
            this.pcbReviewPicture.Click += new System.EventHandler(this.pcbReviewPicture_Click);
            // 
            // InputReview
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(500, 516);
            this.Controls.Add(this.panel1);
            this.Name = "InputReview";
            this.Text = "inputReview";
            this.Load += new System.EventHandler(this.InputReview_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReviewPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcbReviewPicture;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txbComment;
        private DevExpress.XtraEditors.SimpleButton btnComplete;
        private System.Windows.Forms.TextBox txbGrade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}