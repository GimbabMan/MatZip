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
        private Thumbnail()
        {
            InitializeComponent();
            
        }

        public Thumbnail(Data.Member loggedinMember) : this()
        {
            LoggedInMember = loggedinMember;
        }

        private void Thumbnail_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Registration registration = DataRepository.Registration.Get(LoggedInMember.MemberId);
            Restaurant restaurant = DataRepository.Restaurant.Get(registration.RestaurantId);
            var informations = DataRepository.Information.Get(restaurant.RestaurantId);
            int codeId = 0;
            foreach(Information information in informations)
            {
                if(information.CodeId >= 1 && information.CodeId <= 4)
                {
                    codeId = information.CodeId;
                    break;
                }
            }

            Code code = DataRepository.Code.Get(codeId);
            Text = code.Text;
            lblName.Text = $"{restaurant.Name}";

            if (code.Text == "KoreanFood")
                pictureBox.Image = Resources.한식;
            else if (code.Text == "ChineseFood")
                pictureBox.Image = Resources.중식;
            else if (code.Text == "JapaneseFood")
                pictureBox.Image = Resources.일식;
            else if (code.Text == "WesternFood")
                pictureBox.Image = Resources.양식;

           
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void lblMoreData_Click(object sender, EventArgs e)
        {
            Close();
            
        }

    }
}
