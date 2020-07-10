using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;

namespace ThirdProject
{
    public partial class InPutDaysOff : RootForm
    {
        IInputDaysOffToReview DaysOff { get; set; }
        public InPutDaysOff()
        {
            InitializeComponent();
        }

        public InPutDaysOff(IInputDaysOffToReview daysOff): this()
        {
            DaysOff = daysOff;
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
                DaysOff.SetDaysOff(listDaysOff);
                Close();
            }
        }
    }
}
