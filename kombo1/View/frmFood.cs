using kombo1.DAO;
using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kombo1
{
    public partial class frmFood : Form
    {
        BindingSource foodList = new BindingSource();
        public frmFood()
        {
            InitializeComponent();
            dtgvFood.DataSource = foodList;
            LoadListFood();
            LoadCategoryIntoCombobox(cbFoodCategory);
            AddFoodBinding();
        }

        void AddFoodBinding()
        {
            txtFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name"));
            txtFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID"));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price"));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmFood_Load(object sender, EventArgs e)
        {
           
            dtgvFood.Columns[0].DefaultCellStyle.Format = "0,0"+" VND";
            dtgvFood.Columns[0].HeaderText = "Giá bán";
            dtgvFood.Columns[1].HeaderText = "ID Loại";
            dtgvFood.Columns[2].HeaderText = "Tên món";
            dtgvFood.Columns[3].HeaderText = "ID Món";
            dtgvFood.Columns[0].Width = 100;
            dtgvFood.Columns[1].Width = 60;
           
            dtgvFood.Columns[3].Width = 80;
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        void LoadFoodListByCategoryID(int id) 
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFoodCategory.DataSource = listFood;
            cbFoodCategory.DisplayMember = "Name";
        }


        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void txtFoodID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
                Category category = CategoryDAO.Instance.GetCategoryByID(id);

                cbFoodCategory.SelectedItem = category;

                int index = -1;
                int i = 0;
                foreach (Category item in cbFoodCategory.Items)
                {
                    if (item.ID == category.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbFoodCategory.SelectedIndex = index;
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txtFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            if (name.Equals("") || price.Equals("") || categoryID == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
            }
            else
            {
                try
                {
                    DialogResult check = MessageBox.Show($"Bạn có muốn thêm món {txtFoodName.Text.Trim()}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (check == DialogResult.Yes)
                    {
                        if (FoodDAO.Instance.InsertFood(name, categoryID, price))
                        {
                            MessageBox.Show("Thêm món thành công!");
                            LoadListFood();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi thêm món ăn!");
                        }
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string name = txtFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txtFoodID.Text);
            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa món ăn!");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtFoodID.Text);
                DialogResult check = MessageBox.Show($"Bạn có muốn xóa món {txtFoodName.Text.Trim()}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    if (FoodDAO.Instance.DeleteFood(id))
                    {
                        MessageBox.Show("Xóa món thành công");
                        LoadListFood();
                        if (deleteFood != null)
                            deleteFood(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa thức ăn");
                    }
                    
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        List<Food> SearchFoodByName(string name) 
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }


        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           foodList.DataSource =  SearchFoodByName(txtTimKiem.Text);
        }

        private void cbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
