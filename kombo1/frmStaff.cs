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
    public partial class frmStaff : Form
    {
        BindingSource staffList = new BindingSource();
        public frmStaff()
        {
            InitializeComponent();
            dtgvStaff.DataSource = staffList;
            LoadListStaff();
            AddStaffBinding();
        }

        void LoadListStaff()
        {
            staffList.DataSource = StaffDAO.Instance.GetListStaff();
        }

        void AddStaffBinding()
        {
            txtStaffName.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "Staffname"));
            txtAdress.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "address"));
            txtSDT.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "phone"));
            txtEmail.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "Email"));
            txtMoreInfo.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "moreinfo"));
            txtID.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "id"));
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtStaffName.Text;
                string id = txtID.Text;
                string phone = txtSDT.Text;
                string email = txtEmail.Text;
                string address = txtAdress.Text;
                string moreinfo = txtMoreInfo.Text;

                if (StaffDAO.Instance.UpdateStaff(name, address, phone, email, moreinfo,id))
                {
                    MessageBox.Show("Sửa thông tin nhân viên thành công");
                    LoadListStaff();
                    if (updateStaff != null)
                        updateStaff(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa danh mục!!!");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private event EventHandler updateStaff;
        public event EventHandler UpdateStaff
        {
            add { updateStaff += value; }
            remove { updateStaff -= value; }
        }

        private event EventHandler insertStaff;
        public event EventHandler InsertStaff
        {
            add { insertStaff += value; }
            remove { insertStaff -= value; }
        }
        private event EventHandler deleteStaff;
        public event EventHandler DeleteStaff
        {
            add { deleteStaff += value; }
            remove { deleteStaff -= value; }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtStaffName.Text;
                string id = txtID.Text;
                string phone = txtSDT.Text;
                string email = txtEmail.Text;
                string address = txtAdress.Text;
                string moreinfo = txtMoreInfo.Text;

                if (StaffDAO.Instance.InsertStaff(id,name, address, phone, email, moreinfo))
                {
                    MessageBox.Show("Thêm thông tin nhân viên thành công");
                    LoadListStaff();
                    if (insertStaff != null)
                        insertStaff(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm nhân viên!!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text;
                DialogResult check = MessageBox.Show($"Bạn có muốn xóa nhân viên {txtStaffName.Text.Trim()}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    if (StaffDAO.Instance.DeleteStaff(id))
                    {
                        MessageBox.Show("Xóa nhân viên thành công");
                        LoadListStaff();
                        if (deleteStaff != null)
                            deleteStaff(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa nhân viên");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            dtgvStaff.Columns[0].Width = 50;
            dtgvStaff.Columns[1].Width = 200;
            dtgvStaff.Columns[0].HeaderText = "ID";
            dtgvStaff.Columns[1].HeaderText = "Tên nhân viên";
            dtgvStaff.Columns[2].HeaderText = "Tên đăng nhâp";
            dtgvStaff.Columns[3].HeaderText = "Địa chỉ";
            dtgvStaff.Columns[4].HeaderText = "Số điện thoại";
            dtgvStaff.Columns[5].HeaderText = "Email";
            dtgvStaff.Columns[6].HeaderText = "Thông tin khác";
        }
    }
}
