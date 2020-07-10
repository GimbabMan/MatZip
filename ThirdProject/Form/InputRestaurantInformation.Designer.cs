namespace ThirdProject
{
    partial class InputRestaurantInformation
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
            this.pcbRestaurantImage = new System.Windows.Forms.PictureBox();
            this.cbbFoodType = new System.Windows.Forms.ComboBox();
            this.txeName = new DevExpress.XtraEditors.TextEdit();
            this.btnComplete = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRestaurantImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txeName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pcbRestaurantImage);
            this.panel1.Controls.Add(this.cbbFoodType);
            this.panel1.Controls.Add(this.txeName);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 304);
            this.panel1.TabIndex = 0;
            // 
            // pcbRestaurantImage
            // 
            this.pcbRestaurantImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbRestaurantImage.BackColor = System.Drawing.Color.White;
            this.pcbRestaurantImage.Image = global::ThirdProject.Properties.Resources.이미지_등록;
            this.pcbRestaurantImage.Location = new System.Drawing.Point(0, 0);
            this.pcbRestaurantImage.Name = "pcbRestaurantImage";
            this.pcbRestaurantImage.Size = new System.Drawing.Size(262, 181);
            this.pcbRestaurantImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbRestaurantImage.TabIndex = 16;
            this.pcbRestaurantImage.TabStop = false;
            this.pcbRestaurantImage.Click += new System.EventHandler(this.pcbRestaurantImage_Click);
            // 
            // cbbFoodType
            // 
            this.cbbFoodType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbFoodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFoodType.FormattingEnabled = true;
            this.cbbFoodType.Items.AddRange(new object[] {
            "한식",
            "중식",
            "일식",
            "양식"});
            this.cbbFoodType.Location = new System.Drawing.Point(0, 210);
            this.cbbFoodType.Name = "cbbFoodType";
            this.cbbFoodType.Size = new System.Drawing.Size(261, 26);
            this.cbbFoodType.TabIndex = 15;
            // 
            // txeName
            // 
            this.txeName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txeName.EditValue = "가게명을 입력해주세요";
            this.txeName.Location = new System.Drawing.Point(0, 187);
            this.txeName.Name = "txeName";
            this.txeName.Size = new System.Drawing.Size(261, 24);
            this.txeName.TabIndex = 14;
            this.txeName.Click += new System.EventHandler(this.txeName_Click);
            this.txeName.MouseEnter += new System.EventHandler(this.txeName_MouseEnter);
            this.txeName.MouseLeave += new System.EventHandler(this.txeName_MouseLeave);
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
            this.btnComplete.Location = new System.Drawing.Point(0, 237);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(262, 68);
            this.btnComplete.TabIndex = 13;
            this.btnComplete.Text = "완료";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // InputRestaurantInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 304);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InputRestaurantInformation";
            this.Text = "RestaurantInsertForm";
            this.Load += new System.EventHandler(this.RestaurantInsertForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbRestaurantImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txeName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnComplete;
        private DevExpress.XtraEditors.TextEdit txeName;
        private System.Windows.Forms.ComboBox cbbFoodType;
        private System.Windows.Forms.PictureBox pcbRestaurantImage;
    }
}