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
    public partial class frmTable : Form
    {
        BindingSource tableList = new BindingSource();
        public frmTable()
        {
            InitializeComponent();
            dtgvTable.DataSource = tableList;
            AddTableBinding();

            LoadListTable();
        }

        void AddTableBinding() //Hiển thị thông tin từ datagridview sang textbox
        {
            txtIdTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID"));
            txtTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "TableFoodName"));
            txtStatusTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status"));
        }

        void LoadListTable() //Lấy danh sách bàn
        {
            tableList.DataSource = TableDAO.Instance.GetListTable();
        }
        private void frmTable_Load(object sender, EventArgs e)
        {
            dtgvTable.Columns[0].HeaderText ="Trạng thái";
            dtgvTable.Columns[1].HeaderText = "Tên bàn";
            dtgvTable.Columns[2].HeaderText = "ID bàn";
        }

      
        

        

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }

        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

      

        private void btnAddTable_Click_1(object sender, EventArgs e)
        {
            try
            {
                string name = txtTableName.Text;
                string status = txtStatusTable.Text;
                DialogResult check = MessageBox.Show($"Bạn có muốn thêm bàn {txtTableName.Text.Trim()}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    if (TableDAO.Instance.InsertTable(name, status))
                    {
                        MessageBox.Show("Thêm bàn thành công");
                        LoadListTable();
                        if (insertTable != null) //Kiểm tra bàn đó có chưa
                            insertTable(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm bàn");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtIdTable.Text);

                DialogResult check = MessageBox.Show($"Bạn có muốn xóa bàn {txtTableName.Text.Trim()}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    if (TableDAO.Instance.DeleteTable(id))
                    {
                        MessageBox.Show("Xóa bàn thành công.");
                        LoadListTable();
                        if (deleteTable != null)
                            deleteTable(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa bàn");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void btnRepairTable_Click(object sender, EventArgs e)
        {
            string status = txtStatusTable.Text;
            string name = txtTableName.Text;
            int id = Convert.ToInt32(txtIdTable.Text);

            if (TableDAO.Instance.UpdateTable(name, status, id))
            {
                MessageBox.Show("Sửa bàn thành công");
                // LoadListCategory();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn");
            }
        }
    }
}

