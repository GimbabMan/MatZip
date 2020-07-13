using System;
using System.Windows.Forms;
using ThirdProject.BaseForm;

namespace ThirdProject.Form
{
    public partial class TestForm : RootForm
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            pcbImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pcbImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\Users\\plant12\\Desktop\\Image";
            open.Filter = "Image file(*.jpg)|*.jpg|(*.png)|*png|All Files(*.*)|*.*";
            open.FilterIndex = 1;
            string picpath = null;
            if (open.ShowDialog() == DialogResult.OK)
            {
                picpath = open.FileName.ToString();
                pcbImage.ImageLocation = picpath;
            }

            MessageBox.Show($"{picpath}");

        }
    }
}
