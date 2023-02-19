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
    public partial class frmKhuVucBan : Form
    {
       
        public frmKhuVucBan()
        {
            InitializeComponent();

            LoadTable();
            LoadCategory();
            LoadComboBoxTable(cbSwitchTable);
        }

        #region Methods

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        } 
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFoodName.DataSource = listFood;
            cbFoodName.DisplayMember = "Name";
        }
        void LoadTable()
        {
            flpTable.Controls.Clear();
           List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.TableFoodName + Environment.NewLine + item.Status;
                btn.ForeColor = Color.Black;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.White;
                        btn.TextAlign = ContentAlignment.TopLeft;
                         string pathToIcoFile = AppDomain.CurrentDomain.BaseDirectory + @"Resources\Banantrong.JPG";
                       // string duongdan = @"C:\Users\Admin\Pictures\project\Resources\Banantrong.JPG";
                        btn.Image = Image.FromFile(pathToIcoFile);
                        break;
                    default:
                        btn.BackColor = Color.White;
                       btn.TextAlign = ContentAlignment.BottomLeft;
                       
                       string pathToIcoFile1 = AppDomain.CurrentDomain.BaseDirectory + @"Resources\Banconguoi.JPG";
                       // string duongdan1 = @"C:\Users\Admin\Pictures\project\Resources\Resources\Banconguoi.JPG";
                        btn.Image = Image.FromFile(pathToIcoFile1);
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<kombo1.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach(kombo1.DTO.Menu item in listBillInfo)
            {
                ListViewItem listViewItem = new ListViewItem(item.FoodName.ToString());
                listViewItem.SubItems.Add(item.Count.ToString());
                listViewItem.SubItems.Add(item.Price.ToString());
                listViewItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(listViewItem);
            }
            int discount = (int)nmDisCount.Value;


          //  double totalPrice = double.Parse(txtTotalPrice.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
            //double totalPrice = Convert.ToDouble(txtTotalPrice.Text.Split(',')[0].Replace(".", "")); 

            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTotalPayment.Text = finalTotalPrice.ToString("c", culture);
           // CultureInfo culture = new CultureInfo("vi-VN");
            txtTotalPrice.Text = totalPrice.ToString("c", culture);
           // txtTotalPayment.Text = TotalPayment.ToString("c", culture);

            
        }

        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "TableFoodName";
        }
        #endregion

        #region Events

        //button hien thi Bill cho tung ban
        void btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button ).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(idTable);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBan11_Click(object sender, EventArgs e)
        {

        }

        private void frmKhuVucBan_Load(object sender, EventArgs e)
        {

        }
        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        //combobox danh muc mon an
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            LoadFoodListByCategoryID(id);
        }

        //Them mon an
        private void btnAddFood_Click(object sender, EventArgs e)
        {
          
            try
            {
                Table table = lsvBill.Tag as Table;
                if(table == null)
                {
                    MessageBox.Show("Bạn chưa chọn bàn!");
                    return;
                }

                  nmDisCount.Value = 0;
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                int foodID = (cbFoodName.SelectedItem as Food).ID;
                int count = (int)nmFoodCount.Value;
                if (idBill == -1)
                {
                    BillDAO.Instance.InsertBill(table.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                    //BillInfo_logDAO.Instance.InsertBillInfo_log(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                    // BillInfo_logDAO.Instance.InsertBillInfo_log(idBill, foodID, count);
                }
                ShowBill(table.ID);
                LoadTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

  

        //btn Thanh toan
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                Table table = lsvBill.Tag as Table;
                if(table != null)
                {
                    int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                    int discount = (int)nmDisCount.Value;


                    double totalPrice = double.Parse(txtTotalPrice.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
                    //double totalPrice = Convert.ToDouble(txtTotalPrice.Text.Split(',')[0].Replace(".", "")); 

                    double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
                    CultureInfo culture = new CultureInfo("vi-VN");
                    txtTotalPayment.Text = finalTotalPrice.ToString("c", culture);
                    if (idBill != 1 & lsvBill.Items.Count > 0)
                    {
                        if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn thanh toán hóa đơn cho bàn {0}\n Tổng tiền phải thanh toán là: {1} VND", table.TableFoodName, finalTotalPrice), "Thống báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                            ShowBill(table.ID);
                            LoadTable();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bàn trống không thể thanh toán", "Thông báo!");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn bàn", "Thông báo!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            try
            {
                if(lsvBill.Tag == null)
                {
                    MessageBox.Show("Vui lòng chọn bàn để chuyển bàn ăn!", "Thông báo");
                }
                else
                {
                    if(lsvBill.Items.Count <= 0)
                    {
                        MessageBox.Show("Bàn trống không thể chuyển!", "Thông báo");
                    }
                    else
                    {
                        int id1 = (lsvBill.Tag as Table).ID;
                        int id2 = (cbSwitchTable.SelectedItem as Table).ID;

                        if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1} không?", (lsvBill.Tag as Table).TableFoodName, (cbSwitchTable.SelectedItem as Table).TableFoodName), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            TableDAO.Instance.SwitchTable(id1, id2);
                            LoadTable();
                        }
                    }
                   

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picMomo_Click(object sender, EventArgs e)
        {
            try
            {
                Table table = lsvBill.Tag as Table;
                if (table == null)
                {
                    MessageBox.Show("Bạn chưa chọn bàn!");
                    return;
                }
                else
                {
                    if(lsvBill.Items.Count <= 0)
                    {
                        MessageBox.Show("Bàn trống không thể thanh toán", "Thông báo");
                    }
                    else
                    {
                        frmMomo frm = new frmMomo();
                        frm.temp = txtTotalPayment.Text;
                        frm.ShowDialog();
                    }
                    
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void nmDisCount_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if(lsvBill.Tag == null)
            {
                MessageBox.Show("Bạn chưa chọn bàn", "Thông báo");
            }
            else
            {
                if(lsvBill.Items.Count <= 0)
                {
                    MessageBox.Show("Bàn trống không thể giảm giá!", "Thông báo");
                }
                else
                {
                    int ban = (lsvBill.Tag as Table).ID;
                    int km = (int)nmDisCount.Value;
                    if (km > 0 & MessageBox.Show(string.Format("Bạn có chắc chắn muốn khuyến mại cho bàn {0}?\n Khuyến mại là: {1}% trên tổng hóa đơn", ban, km), "Thống báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        ShowBill(table.ID);
                    }
                }
               
            }

            
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
