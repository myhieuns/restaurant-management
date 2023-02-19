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
    public partial class frmCategory : Form
    {
        BindingSource categoryList = new BindingSource();
        public frmCategory()
        {
            InitializeComponent();
            dtgvCategory.DataSource = categoryList;
            LoadListCategory();
            AddCategoryBinding();


        }

        
        void AddCategoryBinding() 
        {
            txtIdCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID"));
            txtNameCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name"));
        }

        void LoadListCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            dtgvCategory.Columns[0].HeaderText = "ID nhóm món";
            dtgvCategory.Columns[0].Width = 100;
            dtgvCategory.Columns[1].HeaderText = "Tên nhóm món";
        }
        private void btnView_Click(object sender, EventArgs e)
        {
                LoadListCategory();
                txtIdCategory.Text = "";
                txtNameCategory.Text = "";
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameCategory.Text;

                if (CategoryDAO.Instance.InsertFoodCategory(name))
                {
                    MessageBox.Show("Thêm danh mục thành công " + txtNameCategory.Text.Trim());
                    LoadListCategory();
                    if (insertCategory != null) //Kiểm tra danh mục đó có chưa
                        insertCategory(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm danh mục");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }

        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }

        private void btnRepairCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameCategory.Text;
                int id = Convert.ToInt32(txtIdCategory.Text);

                if (CategoryDAO.Instance.UpdateFoodCategory(name, id))
                {
                    MessageBox.Show("Sửa danh mục thành công");
                    LoadListCategory();
                    if (updateCategory != null)
                        updateCategory(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa danh mục!!!");
                }
                //LoadListCategoryByCategoryID((cbDanhMucMon.SelectedItem as Category).ID);
                //if (lvHoaDon.Tag != null)
                //{
                //    ShowBill((lvHoaDon.Tag as Table).ID);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {

            try
            {
                //category.Name = txtTenDanhMuc.Text;
                int id = Convert.ToInt32(txtIdCategory.Text);
                DialogResult check = MessageBox.Show($"Bạn có muốn xóa danh mục {txtNameCategory.Text.Trim()}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    if (CategoryDAO.Instance.DeleteFoodCategory(id))
                    {
                        LoadListCategory();
                        if (deleteCategory != null)
                            deleteCategory(this, new EventArgs());
                        MessageBox.Show("Xóa danh mục thành công");
                    }
                    else
                    {
                        //MessageBox.Show("Có lỗi khi xóa danh mục");
                        MessageBox.Show("Xóa danh mục thành công");
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtIdCategory_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
