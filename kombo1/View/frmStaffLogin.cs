using kombo1.DAO;
using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kombo1
{
    public partial class frmStaffLogin : Form
    {
        public frmStaffLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            if (LoginNVBan(userName, passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                frmStaffWorkSpace f = new frmStaffWorkSpace(loginAccount);
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu! ");
            }
        }
        bool LoginNVBan(string userName, string passWord)
        {
            return AccountDAO.Instance.LoginNVBan(userName, passWord);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmQuyen f = new frmQuyen();
            this.Close();
            f.Show();

        }

        private void frmStaffLogin_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void frmStaffLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
