using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;
namespace ThirdProject
{
    public partial class InputRestaurantInformation : RootForm
    {
        private Map map = null;
        private string PicturePath { get; set; }
        public InputRestaurantInformation()
        {
            InitializeComponent();
        }

        public InputRestaurantInformation(Map _map) : this()
        {
            map = _map;
        }
       
        private void pcbRestaurantImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:";
            open.Filter = "All Files(*.*)|*.*|Image file(*.jpg)|*.jpg|(*.png)|*png";
            open.FilterIndex = 1;
            PicturePath = null;
            if (open.ShowDialog() == DialogResult.OK)
            {
                PicturePath = open.FileName.ToString();
                pcbRestaurantImage.ImageLocation = PicturePath;
                pcbRestaurantImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txeName.Text) || txeName.Text == "가게명을 입력해주세요")
                return;

            if (string.IsNullOrEmpty(cbbFoodType.Text) || cbbFoodType.Text == "음식 종류를 선택해주세요")
                return;

            byte[] image = null;
            try
            {
                if (PicturePath != null)
                    image = ConvertImageToBinary(pcbRestaurantImage.Image);
            }
            catch
            {
                image = null;
            }

            if (MessageBox.Show("입력을 완료하셨나요?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                map.GetRestaurantInformation(txeName.Text, cbbFoodType.Text, image);
            }

            PicturePath = null;
            Close();
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

        private void txeName_MouseEnter(object sender, EventArgs e)
        {
            if (txeName.Text != "가게명을 입력해주세요")
                return;

            txeName.Text = "";

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

        
    }
}
