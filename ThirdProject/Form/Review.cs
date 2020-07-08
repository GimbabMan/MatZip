using System;
using ThirdProject.BaseForm;

namespace ThirdProject.Form
{
    public partial class Review : RootForm
    {
        public Review()
        {
            InitializeComponent();
        }

       
        private void Review_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.chobab;
            pictureBox2.Image = Properties.Resources.star;

            panel3.AutoScroll = true;
        }

       
    }
}
