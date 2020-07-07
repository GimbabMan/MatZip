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
    public partial class SignUp : RootForm
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void txeId_Click(object sender, EventArgs e)
        {
            txeId.Text = string.Empty;
        }

        private void txeId_MouseLeave(object sender, EventArgs e)
        {
            if (txeId.Text.Length == 0)
                txeId.Text = "아이디";
        }

        private void txePassword_Click(object sender, EventArgs e)
        {
            txePassword.Text = string.Empty;
        }

        private void txePassword_MouseLeave(object sender, EventArgs e)
        {
            if (txePassword.Text.Length == 0)
                txePassword.Text = "비밀번호";
        }

        private void txeName_Click(object sender, EventArgs e)
        {
            txeName.Text = string.Empty;
        }

        private void txeName_MouseLeave(object sender, EventArgs e)
        {
            if (txeName.Text.Length == 0)
                txeName.Text = "이름";
        }

        private void txeEmail_Click(object sender, EventArgs e)
        {
            txeEmail.Text = string.Empty;
        }

        private void txeEmail_MouseLeave(object sender, EventArgs e)
        {
            if (txeEmail.Text.Length == 0)
                txeEmail.Text = "이메일";
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            var members = DataRepository.Member.GetAll();
            bool isAlreadyMember = true;
            foreach (Member member in members)
            {
                if (txeId.Text.ToString() == member.Id)
                {
                    isAlreadyMember = false;
                    break;
                }
            }

            if(isAlreadyMember)
            {
                Member newMember = new Member();
                newMember.Id = txeId.Text.ToString();
                newMember.Password = txePassword.Text.ToString();
                newMember.Name = txeName.Text.ToString();
                newMember.Email = txeEmail.Text.ToString();
                DataRepository.Member.Insert(newMember);
                MessageBox.Show("회원가입에 성공했습니다!!!");
                Close();
            }
            else
            {
                MessageBox.Show("이미 회원 가입된 아이디입니다.");
            }

        }
    }
}
