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
        private IDataTransferInterface dataTransfer = null;

        public InputRestaurantInformation()
        {
            InitializeComponent();
        }

        public InputRestaurantInformation(IDataTransferInterface _dataTransfer) : this()
        {
            dataTransfer = _dataTransfer;
        }

        private void RestaurantInsertForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txeName.Text) || txeName.Text == "가게명을 입력해주세요")
                return;

            if (string.IsNullOrEmpty(cbbFoodType.Text) || cbbFoodType.Text == "음식 종류를 선택해주세요")
                return;

            

            if (MessageBox.Show("입력을 완료하셨나요?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataTransfer.SetName(txeName.Text, cbbFoodType.Text);
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
            if (!string.IsNullOrEmpty(txeName.Text))
                return;

            txeName.Text = "가게명을 입력해주세요";
        }

        
    }
}
