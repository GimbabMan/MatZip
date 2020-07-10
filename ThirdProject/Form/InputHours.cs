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
    public partial class InputHours : RootForm
    {
        IInputHoursToReview  InputTimes { get; set; }
        private InputHours()
        {
            InitializeComponent();
        }

        public InputHours(IInputHoursToReview hours) : this()
        {
            InputTimes = hours;
        }


        private void btnComplete_Click(object sender, EventArgs e)
        {
            string startTime = cbbStartTime.Text.ToString();
            string finishTime = cbbFinishTime.Text.ToString();

            if (string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(finishTime))
            {
                MessageBox.Show("메뉴, 가격 입력을 완료해주세요");
                return;
            }

            if (MessageBox.Show("입력을 완료하셨나요?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InputTimes.SetHours(startTime, finishTime);
                Close();
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
    }
}
