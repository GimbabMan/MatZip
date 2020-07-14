using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;

namespace ThirdProject
{
    public partial class inputReview : RootForm
    {
        private Review review;
        private Member loggedInMember;
        private string picturePath;
        public inputReview()
        {
            InitializeComponent();
        }

        public inputReview(Review _review, Member _loggedInMember) : this()
        {
            review = _review;
            loggedInMember = _loggedInMember;
        }

        private void pcbReviewPicture_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:";
            open.Filter = "All Files(*.*)|*.*|Image file(*.jpg)|*.jpg|(*.png)|*png";
            open.FilterIndex = 1;
            picturePath = null;
            if (open.ShowDialog() == DialogResult.OK)
            {
                picturePath = open.FileName.ToString();
                pcbReviewPicture.ImageLocation = picturePath;
                pcbReviewPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void InputReview_Load(object sender, System.EventArgs e)
        {
            lblUserId.Text = $"{loggedInMember.Id}";
        }

        private void btnComplete_Click(object sender, System.EventArgs e)
        {
            string comment = txbComment.Text;
            byte[] image = null;
            
            int? grade = null;
            try
            {
                grade = int.Parse(cbbGrade.Text[0].ToString());
            }
            catch
            {
                grade = null;
            }

            if (string.IsNullOrEmpty(comment) || comment == "코멘트를 남겨주세요" || grade == null)
            {
                MessageBox.Show("코멘트, 평점 입력을 완료해주세요");
                return;
            }

            if (picturePath != null)
                image = ConvertImageToBinary(pcbReviewPicture.Image);


            if (MessageBox.Show("입력을 완료하셨나요?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                review.GetReviewInformation(comment, image, (int)grade);
                Close();
            }

        }

        private byte[] ConvertImageToBinary(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                if (ImageFormat.Jpeg.Equals(image.RawFormat))
                {
                    image.Save(memoryStream, ImageFormat.Jpeg);
                }
                else if (ImageFormat.Png.Equals(image.RawFormat))
                {
                    image.Save(memoryStream, ImageFormat.Png);
                }
                else if (ImageFormat.Gif.Equals(image.RawFormat))
                {
                    image.Save(memoryStream, ImageFormat.Gif);
                }
                return memoryStream.ToArray();
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
