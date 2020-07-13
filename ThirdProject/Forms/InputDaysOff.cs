using System;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;

namespace ThirdProject
{
    public partial class InPutDaysOff : RootForm
    {
        Review review;
        public InPutDaysOff()
        {
            InitializeComponent();
        }

        public InPutDaysOff(Review _review): this()
        {
            review = _review;
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            bool[] listDaysOff = new bool[7];
            bool monday = chbMonday.Checked;
            bool tuesday = chbTuesday.Checked;
            bool wednesday = chbWednesday.Checked;
            bool thursday = chbThursday.Checked;
            bool friday = chbFriday.Checked;
            bool saturday = chbSaturday.Checked;
            bool sunday = chbSunday.Checked;

            listDaysOff[0] = monday;
            listDaysOff[1] = tuesday;
            listDaysOff[2] = wednesday;
            listDaysOff[3] = thursday;
            listDaysOff[4] = friday;
            listDaysOff[5] = saturday;
            listDaysOff[6] = sunday;

            if (MessageBox.Show("입력을 완료하셨나요?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                review.GetDaysOffInformation(listDaysOff);
                Close();
            }
        }
    }
}
