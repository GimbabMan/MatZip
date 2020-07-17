using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;
using ThirdProject.Properties;

namespace ThirdProject
{
    public partial class Thumbnail : RootForm
    {

        private Member _loggedInMember;
        private Restaurant _thumbnailRestaurant;
        private Thumbnail()
        {
            InitializeComponent();

        }

        public Thumbnail(Member loggedinMember, Restaurant thumbnailRestaurant) : this()
        {
            _loggedInMember = loggedinMember;
            _thumbnailRestaurant = thumbnailRestaurant;
        }

        private void Thumbnail_Load(object sender, EventArgs e)
        {
            Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            //FormBorderStyle = FormBorderStyle.FixedSingle;
            var informations = DataRepository.Information.Get(_thumbnailRestaurant.RestaurantId);
            int codeId = 0;
            foreach (Information information in informations)
            {
                if (information.CodeId >= 1 && information.CodeId <= 4)
                {
                    codeId = information.CodeId;
                    break;
                }
            }

            Code code = DataRepository.Code.Get(codeId);
            int memberId = DataRepository.Registration.GetMemberId(_thumbnailRestaurant.RestaurantId);
            Member registeredThumbnailMember = DataRepository.Member.GetOneMember(memberId);

            Text = code.Text;
            lblUserId.Text = $"{registeredThumbnailMember.Id}";
            lblName.Text = $"{_thumbnailRestaurant.Name}({code.Text})";

            if (_thumbnailRestaurant.Image == null)
            {
                if (code.Text == "한식")
                    pictureBox.Image = Resources.한식;
                else if (code.Text == "중식")
                    pictureBox.Image = Resources.중식;
                else if (code.Text == "일식")
                    pictureBox.Image = Resources.일식;
                else if (code.Text == "양식")
                    pictureBox.Image = Resources.양식;
            }
            else
                pictureBox.Image = ConvertBinaryToImage(_thumbnailRestaurant.Image);

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            //lblGrade.Text;
            var reviews = DataRepository.Review.Get(_thumbnailRestaurant.RestaurantId);
            if (reviews.Count() > 0)
            {
                double reviewsSum = reviews.Sum(x => x.Grade);
                int reviewsCount = reviews.Count();
                lblGrade.Text = $"{reviewsSum/reviewsCount:N1} 점";
            }
            else
            {
                lblGrade.Text = "0.0 점";
            }
        }

        private byte[] ConvertImageToBinary(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                if(ImageFormat.Jpeg.Equals(image.RawFormat))
                {
                    image.Save(memoryStream, ImageFormat.Jpeg);
                }
                else if(ImageFormat.Png.Equals(image.RawFormat))
                {
                    image.Save(memoryStream, ImageFormat.Png);
                } 
                else if(ImageFormat.Gif.Equals(image.RawFormat))
                {
                    image.Save(memoryStream, ImageFormat.Gif);
                }
                return memoryStream.ToArray();
            }
        }

        private Image ConvertBinaryToImage(byte[] image)
        {
            using (MemoryStream memoryStream = new MemoryStream(image))
            {
                return Image.FromStream(memoryStream);
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

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Review review = new Review(_loggedInMember, _thumbnailRestaurant);
            review.ShowDialog();
            Close();
        }
      
    }
}
