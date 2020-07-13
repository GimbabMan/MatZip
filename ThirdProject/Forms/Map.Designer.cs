namespace ThirdProject
{
    partial class Map
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
            this.bingMapDataProvider1 = new DevExpress.XtraMap.BingMapDataProvider();
            this.bingSearchDataProvider1 = new DevExpress.XtraMap.BingSearchDataProvider();
            this.imageLayer1 = new DevExpress.XtraMap.ImageLayer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mapControl = new DevExpress.XtraMap.MapControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).BeginInit();
            this.SuspendLayout();
            this.bingMapDataProvider1.BingKey = "AsERejax3_Jv6qKhL6X1rDfDc9qeo0OxcikVz1hTTQ9K90G34SJkPwu80PzgGPrP";
            this.bingMapDataProvider1.Kind = DevExpress.XtraMap.BingMapKind.Road;
            this.bingSearchDataProvider1.BingKey = "AsERejax3_Jv6qKhL6X1rDfDc9qeo0OxcikVz1hTTQ9K90G34SJkPwu80PzgGPrP";
            this.bingSearchDataProvider1.MaxVisibleResultCount = 3;
            this.imageLayer1.DataProvider = this.bingMapDataProvider1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mapControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1151, 532);
            this.panel2.TabIndex = 6;
            // 
            // mapControl
            // 
            this.mapControl.CenterPoint = new DevExpress.XtraMap.GeoPoint(37.5421324046854D, 126.840405206299D);
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.Layers.Add(this.imageLayer1);
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.MinZoomLevel = 17D;
            this.mapControl.Name = "mapControl";
            this.mapControl.NavigationPanelOptions.Visible = false;
            this.mapControl.Size = new System.Drawing.Size(1151, 532);
            this.mapControl.TabIndex = 4;
            this.mapControl.ZoomLevel = 17D;
            this.mapControl.MapItemClick += new DevExpress.XtraMap.MapItemClickEventHandler(this.mapControl_MapItemClick);
            this.mapControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapControl_KeyDown);
            this.mapControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseClick);
            this.mapControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseDoubleClick);
            this.mapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseMove);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 532);
            this.Controls.Add(this.panel2);
            this.Name = "Map";
            this.Text = "Map";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Map_FormClosed);
            this.Load += new System.EventHandler(this.Map_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider1;
        private DevExpress.XtraMap.BingSearchDataProvider bingSearchDataProvider1;
        private DevExpress.XtraMap.ImageLayer imageLayer1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraMap.MapControl mapControl;
    }
}