using DevExpress.DataAccess.Wizard.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;

namespace ThirdProject
{ 
    public partial class InputRestaurantInformation : RootForm
    {
        private IInputRestaurantInformationToMap dataTransfer = null;

        public InputRestaurantInformation()
        {
            InitializeComponent();
        }

        public InputRestaurantInformation(IInputRestaurantInformationToMap _dataTransfer) : this()
        {
            dataTransfer = _dataTransfer;
        }

        private void RestaurantInsertForm_Load(object sender, EventArgs e)
        {

        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txeName.Text) || txeName.Text == "가게명을 입력해주세요")
                return;

            if (string.IsNullOrEmpty(cbbFoodType.Text) || cbbFoodType.Text == "음식 종류를 선택해주세요")
                return;

            if (MessageBox.Show("입력을 완료하셨나요?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataTransfer.SetName(txeName.Text, cbbFoodType.Text, pcbRestaurantImage.ImageLocation.ToString());
            }
            
            Close();
        }

        private void txeName_MouseEnter(object sender, EventArgs e)
        {
            if (txeName.Text != "가게명을 입력해주세요")
                return;

            txeName.Text = "";

        }

        private void txeName_MouseLeave(object sender, EventArgs e)
        {
          
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txeName_Click(object sender, EventArgs e)
        {
            txeName.Text = "";
        }

        private void pcbRestaurantImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\Users\\plant12\\Desktop\\Image";
            open.Filter = "All Files(*.*)|*.*|Image file(*.jpg)|*.jpg|(*.png)|*png";
            open.FilterIndex = 1;
            string picpath = null;
            if (open.ShowDialog() == DialogResult.OK)
            {
                picpath = open.FileName.ToString();
                pcbRestaurantImage.ImageLocation = picpath;
                pcbRestaurantImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
