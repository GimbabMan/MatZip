using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;

namespace ThirdProject
{
    public partial class inputReview : RootForm
    {
        private IInputReviewToReview Review { get; set; }
  
        private Member LoggedInMember { get; set; }
        private string FilePath { get; set; }
        public inputReview()
        {
            InitializeComponent();
        }

        public inputReview(IInputReviewToReview review, Member loggedInMember) : this()
        {
            Review = review;
            LoggedInMember = loggedInMember;
        }

        private void pcbReviewPicture_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\Users\\plant12\\Desktop\\Image";
            open.Filter = "All Files(*.*)|*.*|Image file(*.jpg)|*.jpg|(*.png)|*png";
            open.FilterIndex = 1;
            string picpath = null;
            if (open.ShowDialog() == DialogResult.OK)
            {
                picpath = open.FileName.ToString();
                pcbReviewPicture.ImageLocation = picpath;
                FilePath = picpath;
                pcbReviewPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void InputReview_Load(object sender, System.EventArgs e)
        {
            lblUserId.Text = $"{LoggedInMember.Id}";
        }

        private void btnComplete_Click(object sender, System.EventArgs e)
        {
            string comment = txbComment.Text;
            string filePath = FilePath;
            int? grade = int.Parse(txbGrade.Text);

            if (string.IsNullOrEmpty(comment) || grade == null)
            {
                MessageBox.Show("코멘트, 평점 입력을 완료해주세요");
                return;
            }

            if (MessageBox.Show("입력을 완료하셨나요?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Review.SetData(comment, filePath, (int)grade);
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

        private void txbComment_Click(object sender, System.EventArgs e)
        {
            txbComment.Text = "";
        }
    }
}
