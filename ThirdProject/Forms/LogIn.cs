using System;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;

namespace ThirdProject
{
    public partial class LogIn : RootForm
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //layout.BackColor = Color.White;
            //lblLogIn.BackColor = black;
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
                txePassword.Text = "비밀번호를 입력하세요";
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            CheckLogIn();
        }
       
        private void CheckLogIn()
        {
            string id = txeId.Text.ToString();
            string password = txePassword.Text.ToString();

            if (id == "아이디" || string.IsNullOrEmpty(id))
                return;

            if (password == "비밀번호를 입력하세요" || string.IsNullOrEmpty(password))
                return;

            var members = DataRepository.Member.GetAll();
            Member loggedInMember = null;
            foreach (Member member in members)
            {
                if (member.Id == id && member.Password == password)
                {
                    loggedInMember = member;
                    break;
                }
            }

            if (loggedInMember != null)
            {
                if(loggedInMember.IsLogIn == true)
                {
                    MessageBox.Show("이미 로그인 상태입니다.");
                    return;
                }
                loggedInMember.IsLogIn = true;
                DataRepository.Member.Update(loggedInMember);
                MessageBox.Show("로그인에 성공했습니다.");
                Map map = new Map(loggedInMember);
                map.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("아이디나 비밀번호를 다시 확인해주세요.");
            }
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                CheckLogIn();
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
