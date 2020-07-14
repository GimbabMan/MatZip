using System;
using System.Text.RegularExpressions;
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
            SignUpComplete();
        }

        public bool IsEmailForm(string email)
        {
            bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
            return valid;
        }

        private void SignUpComplete()
        {
            if(txeId.Text == "아이디" || string.IsNullOrEmpty(txeId.Text))
            {
                return;
            } else if(txePassword.Text == "비밀번호" || string.IsNullOrEmpty(txePassword.Text))
            {
                return;
            }
            else if (txeName.Text == "이름" || string.IsNullOrEmpty(txeName.Text))
            {
                return;
            }
            else if (txeEmail.Text == "이메일" || string.IsNullOrEmpty(txeEmail.Text))
            {
                return;
            } else if(!IsEmailForm(txeEmail.Text))
            {
                MessageBox.Show("이메일 형식을 지켜주세요(ㅁ@ㅁ.ㅁ)");
                return;
            }

            var members = DataRepository.Member.GetAll();
            bool isNotAlreadyMember = true;
            foreach (Member member in members)
            {
                if (txeId.Text.ToString() == member.Id)
                {
                    isNotAlreadyMember = false;
                    break;
                }
            }

            if (isNotAlreadyMember)
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SignUpComplete();
                return true;
            } else if(keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
      
    }
}
