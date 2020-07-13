﻿using System;
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
        private Member LoggedInMember { get; set; }
        private string PicturePath { get; set; }
        public inputReview()
        {
            InitializeComponent();
        }

        public inputReview(Review _review, Member loggedInMember) : this()
        {
            review = _review;
            LoggedInMember = loggedInMember;
        }

        private void pcbReviewPicture_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:";
            open.Filter = "All Files(*.*)|*.*|Image file(*.jpg)|*.jpg|(*.png)|*png";
            open.FilterIndex = 1;
            PicturePath = null;
            if (open.ShowDialog() == DialogResult.OK)
            {
                PicturePath = open.FileName.ToString();
                pcbReviewPicture.ImageLocation = PicturePath;
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

            if (PicturePath != null)
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