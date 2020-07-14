using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;

namespace ThirdProject
{
    public partial class InputMenu : RootForm
    {
        private Review review;
        public InputMenu()
        {
            InitializeComponent();
        }

        public InputMenu(Review _review):this()
        {
            review = _review;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            string name = txbMenu.Text;
            double? price = double.Parse(txbPrice.Text);

            if (string.IsNullOrEmpty(name) || price == null)
            {
                MessageBox.Show("메뉴, 가격 입력을 완료해주세요");
                return;
            }

            if (MessageBox.Show("입력을 완료하셨나요?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                review.GetMenuInformation(name, (double)price);
                Close();
            }

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
       
    }
}
