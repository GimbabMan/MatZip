namespace ThirdProject
{
    partial class Review
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Review));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pcbRestaurantImage = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbGrade1 = new System.Windows.Forms.TextBox();
            this.txbGrade2 = new System.Windows.Forms.TextBox();
            this.txbGrade3 = new System.Windows.Forms.TextBox();
            this.txbGrade4 = new System.Windows.Forms.TextBox();
            this.txbGrade5 = new System.Windows.Forms.TextBox();
            this.pcbGrade = new System.Windows.Forms.PictureBox();
            this.bdsReview = new System.Windows.Forms.BindingSource(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txbMenus = new System.Windows.Forms.TextBox();
            this.txbDays = new System.Windows.Forms.TextBox();
            this.lblHours = new DevExpress.XtraEditors.LabelControl();
            this.btnLoadMap = new DevExpress.XtraEditors.SimpleButton();
            this.txbRestaurantName = new System.Windows.Forms.TextBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.dgvReviews = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRestaurantImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsReview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(713, 471);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dgvReviews);
            this.panel3.Controls.Add(this.lblGrade);
            this.panel3.Controls.Add(this.pcbRestaurantImage);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.simpleButton1);
            this.panel3.Controls.Add(this.txbMenus);
            this.panel3.Controls.Add(this.txbDays);
            this.panel3.Controls.Add(this.lblHours);
            this.panel3.Controls.Add(this.btnLoadMap);
            this.panel3.Controls.Add(this.txbRestaurantName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(713, 471);
            this.panel3.TabIndex = 1;
            // 
            // pcbRestaurantImage
            // 
            this.pcbRestaurantImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcbRestaurantImage.Location = new System.Drawing.Point(0, 0);
            this.pcbRestaurantImage.Name = "pcbRestaurantImage";
            this.pcbRestaurantImage.Size = new System.Drawing.Size(692, 122);
            this.pcbRestaurantImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbRestaurantImage.TabIndex = 10;
            this.pcbRestaurantImage.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbGrade1);
            this.groupBox1.Controls.Add(this.txbGrade2);
            this.groupBox1.Controls.Add(this.txbGrade3);
            this.groupBox1.Controls.Add(this.txbGrade4);
            this.groupBox1.Controls.Add(this.txbGrade5);
            this.groupBox1.Controls.Add(this.pcbGrade);
            this.groupBox1.Location = new System.Drawing.Point(218, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 182);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "별점";
            // 
            // txbGrade1
            // 
            this.txbGrade1.Location = new System.Drawing.Point(308, 145);
            this.txbGrade1.Name = "txbGrade1";
            this.txbGrade1.Size = new System.Drawing.Size(85, 26);
            this.txbGrade1.TabIndex = 5;
            // 
            // txbGrade2
            // 
            this.txbGrade2.Location = new System.Drawing.Point(308, 113);
            this.txbGrade2.Name = "txbGrade2";
            this.txbGrade2.Size = new System.Drawing.Size(85, 26);
            this.txbGrade2.TabIndex = 4;
            // 
            // txbGrade3
            // 
            this.txbGrade3.Location = new System.Drawing.Point(308, 80);
            this.txbGrade3.Name = "txbGrade3";
            this.txbGrade3.Size = new System.Drawing.Size(85, 26);
            this.txbGrade3.TabIndex = 3;
            // 
            // txbGrade4
            // 
            this.txbGrade4.Location = new System.Drawing.Point(308, 48);
            this.txbGrade4.Name = "txbGrade4";
            this.txbGrade4.Size = new System.Drawing.Size(85, 26);
            this.txbGrade4.TabIndex = 2;
            // 
            // txbGrade5
            // 
            this.txbGrade5.Location = new System.Drawing.Point(308, 16);
            this.txbGrade5.Name = "txbGrade5";
            this.txbGrade5.Size = new System.Drawing.Size(85, 26);
            this.txbGrade5.TabIndex = 1;
            // 
            // pcbGrade
            // 
            this.pcbGrade.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbGrade.InitialImage")));
            this.pcbGrade.Location = new System.Drawing.Point(14, 16);
            this.pcbGrade.Name = "pcbGrade";
            this.pcbGrade.Size = new System.Drawing.Size(288, 155);
            this.pcbGrade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbGrade.TabIndex = 0;
            this.pcbGrade.TabStop = false;
            // 
            // bdsReview
            // 
            this.bdsReview.DataSource = typeof(ThirdProject.Data.Review);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Silver;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(31, 533);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(177, 44);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "리뷰 작성하기";
            // 
            // txbMenus
            // 
            this.txbMenus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txbMenus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbMenus.Location = new System.Drawing.Point(92, 255);
            this.txbMenus.Multiline = true;
            this.txbMenus.Name = "txbMenus";
            this.txbMenus.Size = new System.Drawing.Size(245, 51);
            this.txbMenus.TabIndex = 6;
            this.txbMenus.Text = "메뉴넣을곳";
            // 
            // txbDays
            // 
            this.txbDays.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txbDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbDays.Location = new System.Drawing.Point(237, 219);
            this.txbDays.Name = "txbDays";
            this.txbDays.Size = new System.Drawing.Size(100, 19);
            this.txbDays.TabIndex = 5;
            this.txbDays.Text = "월,목 휴무";
            // 
            // lblHours
            // 
            this.lblHours.Location = new System.Drawing.Point(92, 220);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(116, 18);
            this.lblHours.TabIndex = 4;
            this.lblHours.Text = "매일 11:00~17:00";
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Appearance.BackColor = System.Drawing.Color.Silver;
            this.btnLoadMap.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMap.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLoadMap.Appearance.Options.UseBackColor = true;
            this.btnLoadMap.Appearance.Options.UseFont = true;
            this.btnLoadMap.Appearance.Options.UseForeColor = true;
            this.btnLoadMap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadMap.ImageOptions.Image")));
            this.btnLoadMap.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLoadMap.Location = new System.Drawing.Point(204, 164);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(94, 38);
            this.btnLoadMap.TabIndex = 3;
            this.btnLoadMap.Text = "지도";
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // txbRestaurantName
            // 
            this.txbRestaurantName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txbRestaurantName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbRestaurantName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbRestaurantName.Location = new System.Drawing.Point(200, 129);
            this.txbRestaurantName.Name = "txbRestaurantName";
            this.txbRestaurantName.Size = new System.Drawing.Size(124, 19);
            this.txbRestaurantName.TabIndex = 1;
            this.txbRestaurantName.Text = "상호명입력할곳";
            // 
            // lblGrade
            // 
            this.lblGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrade.Font = new System.Drawing.Font("Malgun Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblGrade.Location = new System.Drawing.Point(12, 283);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(196, 155);
            this.lblGrade.TabIndex = 11;
            this.lblGrade.Text = "4.3";
            this.lblGrade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvReviews
            // 
            this.dgvReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviews.Location = new System.Drawing.Point(31, 594);
            this.dgvReviews.Name = "dgvReviews";
            this.dgvReviews.RowHeadersWidth = 51;
            this.dgvReviews.RowTemplate.Height = 27;
            this.dgvReviews.Size = new System.Drawing.Size(602, 169);
            this.dgvReviews.TabIndex = 12;
            // 
            // Review
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 471);
            this.Controls.Add(this.panel2);
            this.Name = "Review";
            this.Text = "Review";
            this.Load += new System.EventHandler(this.Review_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRestaurantImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsReview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.LabelControl lblHours;
        private DevExpress.XtraEditors.SimpleButton btnLoadMap;
        private System.Windows.Forms.TextBox txbRestaurantName;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TextBox txbMenus;
        private System.Windows.Forms.TextBox txbDays;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pcbGrade;
        private System.Windows.Forms.TextBox txbGrade1;
        private System.Windows.Forms.TextBox txbGrade2;
        private System.Windows.Forms.TextBox txbGrade3;
        private System.Windows.Forms.TextBox txbGrade4;
        private System.Windows.Forms.TextBox txbGrade5;
        private System.Windows.Forms.PictureBox pcbRestaurantImage;
        private System.Windows.Forms.BindingSource bdsReview;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.DataGridView dgvReviews;
    }
}