using kombo1.DAO;
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
    public partial class frmListBill : Form
    {
       // BindingSource InfoBillList = new BindingSource();
        public frmListBill()
        {
            InitializeComponent();
            
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
           // 
        }

        #region Method

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
          dtgvBill.DataSource =   BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
           
        }
       
        void LoadInfoBillList(int id )
        {
          
            dtgvBillInfo.DataSource = ViewBillInfoDAO.Instance.ViewBillInfo(id);
        }
        #endregion
      //  void Binding()
    //    {
//txtIDBill.DataBindings.Add(new Binding("Text", dtgvBill.DataSource, "ID"));
          
   //     }

        #region Event

        //envent click vao button ViewBill
        private void btnViewBill_Click(object sender, EventArgs e)
        {
           
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            TotalRevenue();
        }

        #endregion


        public void TotalRevenue() //Tính tổng doanh thu
        {
            try
            {
                int tien = dtgvBill.Rows.Count;
                float thanhtien = 0;
                for (int i = 0; i < tien-1; i++)
                {
                    thanhtien += float.Parse(dtgvBill.Rows[i].Cells[2].Value.ToString());
                }
                txtTotalRevenue.Text = thanhtien.ToString();
                CultureInfo culture = new CultureInfo("vi-VN"); 
               txtTotalRevenue.Text = thanhtien.ToString("C3", culture); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmListBill_Load(object sender, EventArgs e)
        {
            dtgvBill.Columns[2].DefaultCellStyle.Format = "0,0.0" + " VND";
            dtgvBill.Columns[5].DefaultCellStyle.Format = "0\\%";

          //  dtgvBillInfo.Columns[3].DefaultCellStyle.Format = "0,0.0" + " VND";
            // dtgvBillInfo.Columns[0].HeaderText = "ID";
            // dtgvBillInfo.Columns[1].HeaderText = "Tên món ăn";
            //dtgvBillInfo.Columns[2].HeaderText = "Số lượng";
            //  dtgvBillInfo.Columns[3].HeaderText = "Giá bán";
        }

        private void txtIDBill_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void dtgvBill_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dtgvBill.Rows[e.RowIndex];
                txtIDBill.Text = row.Cells[0].Value.ToString();
                

            }
            catch (Exception)
            {


            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            void LoadBillInfo(int id)
            {
                dtgvBillInfo.DataSource = ViewBillInfoDAO.Instance.ViewBillInfo(id);

            }

            if (txtIDBill.Text == "")
            {
                dtgvBillInfo.DataSource = null;
                MessageBox.Show("Bạn chưa chọn hóa đơn cần xem!");
            }
            else
            {
                LoadBillInfo(int.Parse(txtIDBill.Text));
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvBillInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //   private void btnViewBillInfo_Click(object sender, EventArgs e)
        // {

        // }
    }
}
