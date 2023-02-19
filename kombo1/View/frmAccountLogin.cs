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
    public partial class frmAccountLogin : Form
    {
        private Account loginAccount;
        public frmAccountLogin(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); } // ChangeAccount(LoginAccount.IdRole);
        }

        void ChangeAccount(Account acc)
        {
            txtUserName.Text = LoginAccount.UserName;
            txtName.Text = LoginAccount.AccountName;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        void UpdateAccountInfo()
        {
            string accountName = txtName.Text;
            string password = txtPassWord.Text;
            string newpass = txtxNewPassWord.Text;
            string renewpass = txtReNewPassWord.Text;
            string username = txtUserName.Text;

            if (!newpass.Equals(renewpass))
            {
                MessageBox.Show("Mật khẩu mới không khớp nhau");
            }
            else
            {
                if(AccountDAO.Instance.UpdateAccount(username, accountName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(username)));
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu!");
                }
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class AccountEvent : EventArgs
        {
            private Account acc;

            public Account Acc { get => acc; set => acc = value; }

            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }

        private void frmAccountLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
