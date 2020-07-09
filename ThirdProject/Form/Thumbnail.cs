using System;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;
using ThirdProject.Properties;


namespace ThirdProject
{
    public partial class Thumbnail : RootForm
    {

        private Data.Member LoggedInMember { get; set; }
        private Data.Restaurant ThumbnailRestaurant { get; set; }
        private Thumbnail()
        {
            InitializeComponent();

        }

        public Thumbnail(Data.Member loggedinMember, Data.Restaurant thumbnailRestaurant) : this()
        {
            LoggedInMember = loggedinMember;
            ThumbnailRestaurant = thumbnailRestaurant;
        }

        private void Thumbnail_Load(object sender, EventArgs e)
        {
            //FormBorderStyle = FormBorderStyle.FixedSingle;
            var informations = DataRepository.Information.Get(ThumbnailRestaurant.RestaurantId);
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
            int memberId = DataRepository.Registration.GetMemberId(ThumbnailRestaurant.RestaurantId);
            Member registeredThumbnailMember = DataRepository.Member.GetOneMember(memberId);

            Text = code.Text;
            lblUserId.Text = $"{registeredThumbnailMember.Id}";
            lblName.Text = $"{ThumbnailRestaurant.Name}({code.Text})";

            if (string.IsNullOrEmpty(ThumbnailRestaurant.ImageLocation))
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
                pictureBox.ImageLocation = ThumbnailRestaurant.ImageLocation;

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

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
            Review review = new Review(LoggedInMember, ThumbnailRestaurant);
            review.ShowDialog();
            Close();
        }
    }
}
