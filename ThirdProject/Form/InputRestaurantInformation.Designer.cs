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
            this.cbbFoodType = new System.Windows.Forms.ComboBox();
            this.txeName = new DevExpress.XtraEditors.TextEdit();
            this.btnComplete = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txeName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbFoodType);
            this.panel1.Controls.Add(this.txeName);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 85);
            this.panel1.TabIndex = 0;
            // 
            // cbbFoodType
            // 
            this.cbbFoodType.FormattingEnabled = true;
            this.cbbFoodType.Items.AddRange(new object[] {
            "한식",
            "중식",
            "일식",
            "양식"});
            this.cbbFoodType.Location = new System.Drawing.Point(0, 27);
            this.cbbFoodType.Name = "cbbFoodType";
            this.cbbFoodType.Size = new System.Drawing.Size(228, 26);
            this.cbbFoodType.TabIndex = 15;
            this.cbbFoodType.Text = "음식 종류를 선택해주세요";
            // 
            // txeName
            // 
            this.txeName.EditValue = "가게명을 입력해주세요";
            this.txeName.Location = new System.Drawing.Point(0, 3);
            this.txeName.Name = "txeName";
            this.txeName.Size = new System.Drawing.Size(228, 24);
            this.txeName.TabIndex = 14;
            this.txeName.MouseEnter += new System.EventHandler(this.txeName_MouseEnter);
            this.txeName.MouseLeave += new System.EventHandler(this.txeName_MouseLeave);
            // 
            // btnComplete
            // 
            this.btnComplete.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnComplete.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Appearance.Options.UseBackColor = true;
            this.btnComplete.Appearance.Options.UseFont = true;
            this.btnComplete.Appearance.Options.UseForeColor = true;
            this.btnComplete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnComplete.Location = new System.Drawing.Point(0, 53);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(228, 32);
            this.btnComplete.TabIndex = 13;
            this.btnComplete.Text = "완료";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // InputRestaurantName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 85);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InputRestaurantName";
            this.Text = "RestaurantInsertForm";
            this.Load += new System.EventHandler(this.RestaurantInsertForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txeName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnComplete;
        private DevExpress.XtraEditors.TextEdit txeName;
        private System.Windows.Forms.ComboBox cbbFoodType;
    }
}