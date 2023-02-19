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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmQuyen f = new frmQuyen();
            this.Close();
            f.Show();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
               
        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            if (LoginAdmin(userName, passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                frmAdminWorkSpace1 f = new frmAdminWorkSpace1(loginAccount);
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu! ");
            }
        }
        bool LoginAdmin(string userName, string passWord)
        {
            return AccountDAO.Instance.LoginAdmin(userName, passWord);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
