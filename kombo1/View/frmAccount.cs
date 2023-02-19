using kombo1.DAO;
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
    public partial class frmAccount : Form
    {

        BindingSource accountList = new BindingSource();
        public frmAccount()
        {
            InitializeComponent();
         
           
            dtgvAccount.DataSource = accountList;
            LoadAccount();
           // LoadRoleNameIntoCombobox(cbRole);
            LoadIDRoleIntoCombobox(cbIDRole);
            AddAccountBinding(txtAccountName.Text);
        }
        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void AddAccountBinding(string textbox) //Hiển thị thông tin từ datagridview sang textbox ( dùng để truyền dữ liệu qua form đổi mật khẩu)
        {
            txtIdAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtAccountName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "AccountName", true, DataSourceUpdateMode.Never));
          //cbRole.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "rolename", true, DataSourceUpdateMode.Never));
            cbIDRole.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "ID", true, DataSourceUpdateMode.Never));

                txtRoleName.DataBindings.Add(new Binding("Text", cbIDRole.DataSource, "roleName", true, DataSourceUpdateMode.Never));
            
           
           
           
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void AddAccount(string userName, string displayName, string type) //Thêm tài khoản
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }
        void EditAccount(string userName, string displayName, string type) //Sửa tài khoản
        {
            string Name = txtAccountName.Text;
            string User = txtIdAccount.Text;
            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn sửa tài khoản của {0} - {1} không?", Name, User), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (AccountDAO.Instance.UpdateAccount1(userName, displayName, type))
                {
                    MessageBox.Show("Cập nhật tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại");
                }

                LoadAccount();
            }
           
        }
        void DeleteAccount(string userName) //Xóa tài khoản
        {
            
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
           // dtgvAccount.Columns[0].Width = 100;
           // dtgvAccount.Columns[1].Width = 200;
            dtgvAccount.Columns[0].HeaderText = "Mã nhân viên";
            dtgvAccount.Columns[1].HeaderText = "Họ và tên";
            dtgvAccount.Columns[2].HeaderText = "Tên quyền hạn";
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string User = txtIdAccount.Text;
            string Name = txtAccountName.Text;

            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn thêm tài khoản của {0} - {1} không?", Name, User), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                string userName = txtIdAccount.Text;
                string displayName = txtAccountName.Text;
                string type = cbIDRole.Text;
                //  string type = (cbRole.SelectedItem as Account).ID;
                AddAccount(userName, displayName, type);
            }
   }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            //  if(loginAccount.UserName.Eq)
            
                string User = txtIdAccount.Text;
                string Name = txtAccountName.Text;

                if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn xóa tài khoản của {0} - {1} không?", Name, User), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    string userName = txtIdAccount.Text;
                    DeleteAccount(userName);
                }
        }

        private void btnRepairAccount_Click(object sender, EventArgs e)
        {

            string userName = txtIdAccount.Text;
            string displayName = txtAccountName.Text;
            string type = cbIDRole.Text;
            //string type = (cbRole.SelectedItem as Account).ID;
            string User = txtIdAccount.Text;
            string Name = txtAccountName.Text;

            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn sửa tài khoản của {0} - {1} không?", Name, User), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                EditAccount(userName, displayName, type);
                LoadAccount();
            }
                
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
           
        }

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            
        }

        void LoadRoleNameIntoCombobox(ComboBox cb)
        {
            cb.DataSource = AccountDAO.Instance.GetListAccount();
            cb.DisplayMember = "RoleName";
        }

        void LoadIDRoleIntoCombobox(ComboBox cb)
        {
            cb.DataSource = AccountDAO.Instance.GetListIDRole();
            cb.DisplayMember = "ID";
        }
        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbIDRole_ValueMemberChanged(object sender, EventArgs e)
        {
           if(cbIDRole.ValueMember == "QuanLy")
            {
                txtRoleName.Text = "Quản lý nhà hàng";
                if(cbIDRole.ValueMember == "NVBep")
                {
                    txtRoleName.Text = "Nhân viên bếp";
                    if(cbIDRole.ValueMember == "Admin")
                    {
                        txtRoleName.Text = "Admin";
                        if(cbIDRole.ValueMember == "ThuNgan")
                        {
                            txtRoleName.Text = "Thu Ngân";
                           if(cbIDRole.ValueMember == "NVBan")
                            {
                                txtRoleName.Text = "Nhân viên bàn";
                            }
                            else
                            {
                                txtRoleName.Text = "";
                            }
                        }

                        
                    }
                }

            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string User = txtIdAccount.Text;
            string Name = txtAccountName.Text;

            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn đổi mật khẩu về mặc định cho tài khoản của {0} - {1} không?", Name, User), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                string userName = txtIdAccount.Text;
                ResetPass(userName);
            }
                
        }

       

        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show($"Đổi mật khẩu tài khoản {txtAccountName.Text.Trim()} thành công");
            }
            else
            {
                MessageBox.Show($"Đổi mật khẩu tài khoản {txtAccountName.Text.Trim()} thất bại");
            }
        }

    }
}
