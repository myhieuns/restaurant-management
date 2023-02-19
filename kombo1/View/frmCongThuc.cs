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
using Object1 = kombo1.DTO.Object1;

namespace kombo1
{
    public partial class frmCongThuc : Form
    {
        BindingSource congThuctList = new BindingSource();
        public frmCongThuc()
        {
            InitializeComponent();
            dtgvListCongThuc.DataSource = congThuctList;
            LoadCategory();
            LoadObject();
            CongThucBinding(cbFoodName.Text);
         
           // LoadFoodListByCategoryID(int id);
        }

        void LoadListCongThuc(int id)
        {
            congThuctList.DataSource = CongThucInfoDAO.Instance.GetListCongThuc(id);
        }
        void CongThucBinding(string textbox) 
        {
            // txtIdAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));

            //cbRole.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "rolename", true, DataSourceUpdateMode.Never));

            // txtRoleName.DataBindings.Add(new Binding("Text", cbIDRole.DataSource, "roleName", true, DataSourceUpdateMode.Never));
            lbTenMon.DataBindings.Add(new Binding("Text", dtgvListCongThuc.DataSource, "FoodName", true));
          //  lbTenMon.DataBindings.Add(new Binding("Text", dtgvListCongThuc.DataSource, "FoodName", true));
            cbObjectName.DataBindings.Add(new Binding("Text", dtgvListCongThuc.DataSource, "ObjectName", true));
           // txtHamLuong.DataBindings.Add(new Binding("Text", dtgvListCongThuc.DataSource, "HamLuong", true));
            nmSoLuong.DataBindings.Add(new Binding("Text", dtgvListCongThuc.DataSource, "HamLuong", true));
            cbDonVi.DataBindings.Add(new Binding("Text", dtgvListCongThuc.DataSource, "UnitName", true));
            txtIDCTInfo.DataBindings.Add(new Binding("Text", dtgvListCongThuc.DataSource, "id", true));
           // lbTenMon.Text = lbFoodName1.Text;
           // txtIDObject.DataBindings.Add(new Binding("Text", dtgvListCongThuc.DataSource, "IDObject", true));
          //  cbIDFood.DataBindings.Add(new Binding("Text", dtgvListCongThuc.DataSource, "idFood", true));

        }
        private void frmCongThuc_Load(object sender, EventArgs e)
        {
            txtIDObject.Visible = false;
            txtIDFood.Visible = false;
            txtIDCTInfo.Visible = false;
            cbFoodCategory.Enabled = true;
            cbFoodName.Enabled = true;
            //cbDonVi.Visible = false;
            panelCongThucInfo.Visible = false;
            panelThemCongThuc.Visible = false;
           dtgvListCongThuc.Columns[4].Visible = false;

            dtgvListCongThuc.Columns[1].Width = 200;
            dtgvListCongThuc.Columns[2].Width = 100;
            dtgvListCongThuc.Columns[3].Width = 100;
            dtgvListCongThuc.Columns[0].HeaderText = "Tên món ăn";
            dtgvListCongThuc.Columns[1].HeaderText = "Tên nguyên liệu";
            dtgvListCongThuc.Columns[2].HeaderText = "Hàm lượng";
            dtgvListCongThuc.Columns[3].HeaderText = "Đơn vị tính";
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbFoodCategory.DataSource = listCategory;
            cbFoodCategory.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFoodName.DataSource = listFood;
            cbFoodName.DisplayMember = "Name";
        }

        private void cbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            LoadFoodListByCategoryID(id);
        }

        void LoadObject()
        {
            List<Object1> listObject = ObjectDAO.Instance.GetListObject();
            cbNVL.DataSource = listObject;
            cbNVL.DisplayMember = "ObjectName";
           
        }

        void LoadUnitByObject(int id)
        {
            List<Object1> listObject = ObjectDAO.Instance.GetUnitByObject(id);
            cbUnitNVL.DataSource = listObject;
            cbUnitNVL.DisplayMember = "IDUnit";
           
        }
        void LoadUnitName(int id)
        {
            List<Units> listUnit = UnitsDAO.Instance.GetUnitsByID(id);
            
        }

      
        private void cbObjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Object1 selected = cb.SelectedItem as Object1;
            id = selected.ID;
            LoadUnitByObject(id);
            LoadObject();
        }

        private void cbDonVi_ValueMemberChanged(object sender, EventArgs e)
        {
          int  id = int.Parse(cbDonVi.ValueMember);
            LoadUnitName(id);

        }

        private void txtUnitName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            cbFoodCategory.Enabled = false;
            cbFoodName.Enabled = false;
            btnAdd.Enabled = false;
            if (dtgvListCongThuc.RowCount > 1)
            {
               // panelCongThucInfo.Visible = true;
                panelThemCongThuc.Hide();
                panelCongThucInfo.Show();
                panelCongThucInfo.BringToFront();
                
            }
            else
            {
                MessageBox.Show("Món ăn chưa có công thức, không thể sửa");
                cbFoodCategory.Enabled = true;
                cbFoodName.Enabled = true;
                btnAdd.Enabled = true;
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            cbFoodCategory.Enabled = false;
            cbFoodName.Enabled = false;
            if ( dtgvListCongThuc.RowCount > 1)
            {
                MessageBox.Show("Món ăn đã có công thức, vui lòng chọn món chưa có công thức!");
                cbFoodCategory.Enabled = true;
                cbFoodName.Enabled = true;
            }
            else
            {
                btnRepair.Enabled = false;
                panelCongThucInfo.Hide() ;
                panelThemCongThuc.Show();
                panelThemCongThuc.BringToFront() ;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            cbFoodCategory.Enabled = true;
            cbFoodName.Enabled = true;
            panelCongThucInfo.Visible = false;
            panelThemCongThuc.Visible = false;
            btnAdd.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cbFoodCategory.Enabled = true;
            cbFoodName.Enabled = true;
            panelCongThucInfo.Visible = false;
            panelThemCongThuc.Visible = false;
        }

        private void cbFoodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Food selected = cb.SelectedItem as Food;
            id = selected.ID;
            txtIDFood.Text = id.ToString();
            LoadListCongThuc(id);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cbFoodCategory.Enabled = true;
            cbFoodName.Enabled = true;
            panelCongThucInfo.Visible = false;
            

            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn thêm nguyên liệu không?"), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int idfood = int.Parse(txtIDFood.Text);
                int idobject = int.Parse(txtIDObject.Text);
                //double hamluong = double.Parse(txtHamLuong1.Text);
                decimal hamluong = nmSoLuong.Value;
             
                AddCongThuc(idfood, idobject, hamluong);
                int id = int.Parse(txtIDFood.Text);
                LoadListCongThuc(id);
            }

        }

        private void btnHuy1_MouseClick(object sender, MouseEventArgs e)
        {
            cbFoodCategory.Enabled = true;
            cbFoodName.Enabled = true;
            panelCongThucInfo.Visible = false;
            panelThemCongThuc.Visible = false;
            btnAdd.Enabled = true;
        }

        private void cbNVL_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void cbNVL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Object1 selected = cb.SelectedItem as Object1;
            id = selected.ID;
            txtIDObject.Text = id.ToString();
            LoadUnitByObject(id);
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        { 
            
                dtgvListCongThuc.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtgvListCongThuc.Refresh();
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {
            cbFoodCategory.Enabled = true;
            cbFoodName.Enabled = true;
            panelCongThucInfo.Visible = false;
            panelThemCongThuc.Visible = true;

        }

        void AddCongThuc(int idfood, int idobject, decimal hamluong)
        {
            if (CongThucInfoDAO.Instance.InsertCongThuc(idfood, idobject, hamluong))
            {
                MessageBox.Show("Thêm nguyên liệu thành công");
            }
            else
            {
                MessageBox.Show("Thêm nguyên liệu thất bại");
            }

            
        }

        void DeleteCongThuc(int id)
        {
            if (CongThucInfoDAO.Instance.DeleteCongThuc(id))
            {
                MessageBox.Show("Xóa nguyên liệu thành công");
            }
            else
            {
                MessageBox.Show("Xóa nguyên liệu thất bại");
            }

        }

        private void btnHuy10_Click(object sender, EventArgs e)
        {
            btnRepair.Enabled = true;
            cbFoodCategory.Enabled = true;
            cbFoodName.Enabled = true;
            panelCongThucInfo.Visible = false;
            panelThemCongThuc.Visible = false;
            btnRepair.Visible = true;
        }

        private void btnHuy11_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            cbFoodCategory.Enabled = true;
            cbFoodName.Enabled = true;
            panelCongThucInfo.Visible = false;
            panelThemCongThuc.Visible = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn xóa nguyên liệu  không?"), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int id = int.Parse(txtIDCTInfo.Text);
                

                DeleteCongThuc(id);
                int id1 = int.Parse(txtIDFood.Text);
                LoadListCongThuc(id1);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtIDCTInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDObject_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDFood_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHamLuong1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelCongThucInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtHamLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbUnitNVL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
