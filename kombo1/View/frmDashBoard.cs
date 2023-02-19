using kombo1.Models;
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
    public partial class frmDashBoard : Form
    {
        private DashBoard model;
        public frmDashBoard()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            btnLast7Days.Select();

            model = new DashBoard();
            LoadData();
        }

        private void LoadData()
        {
            var refreshData = model.LoadData(dtpStartDate.Value, dtpEndDate.Value);
            if (refreshData = true)
            {
                CultureInfo culture = new CultureInfo("vi-VN");
                // lbCount1M.Text =;
                //   lbCount2M.Text = ;

                int a = Convert.ToInt32(model.NumCustomers1M.ToString());
                int b = Convert.ToInt32(model.NumCustomers2M.ToString());
                lbTotalCustomer.Text = (a + b).ToString();
                int customer = Convert.ToInt32(lbTotalCustomer.Text);

              //  lbAVGDuration.Text = model.AvgDuration.ToString();

                double sobatcanh = Convert.ToDouble(model.NumSoup.ToString());
                 //double tylecanh = (sobatcanh / customer)*100;
                lbSoup.Text = ((sobatcanh)/customer).ToString("0.00%");
                //lbSoup.Text = model.NumSoup.ToString();


                lbTotalBill.Text = model.NumBill.ToString();

                lbTotalRevenue.Text = model.TotalRevenue.ToString("c", culture);

                double d = Convert.ToDouble(model.TotalRevenue.ToString());
                lbAVGRevenue.Text = (d / customer).ToString("c", culture);

               chartRevenue.DataSource = model.GrossRevenueList;
               chartRevenue.Series[0].XValueMember = "Date";
               chartRevenue.Series[0].YValueMembers = "TotalAmount";
               chartRevenue.DataBind();

               chartTop10Food.DataSource = model.TopFoodCategoryList;
                chartTop10Food.Series[0].XValueMember = "Key";
              chartTop10Food.Series[0].YValueMembers = "Value";
               chartTop10Food.DataBind();

                dtgvTopFood.DataSource = model.TopFoodList;
                dtgvTopFood.Columns[0].HeaderText = "Tên món ăn";
              
                dtgvTopFood.Columns[1].HeaderText = "Số lượng";
                

                Console.WriteLine("Loader view : ");
            }
            else Console.WriteLine("View not loader");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            dtgvTopFood.Columns[1].Width = 100;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DisableCustomDates()
        {
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            btnOKCustomDate.Visible = false;
        }
        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();

        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime( DateTime.Today.Year, DateTime.Today.Month, 1); ;
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            btnOKCustomDate.Visible = true;

        }

        private void btnOKCustomDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chartTop10Food_Click(object sender, EventArgs e)
        {

        }
    }
}
