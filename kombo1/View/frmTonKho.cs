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
    public partial class frmTonKho : Form
    {
        private TonKho model;
        public frmTonKho()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            btnLast7Days.Select();

            model = new TonKho();
            LoadData();
        }

        private void LoadData()
        {
            var refreshData = model.LoadData(dtpStartDate.Value, dtpEndDate.Value);
            if (refreshData = true)
            {
                
                dtgvFood.DataSource = model.FoodList;
                dtgvInput.DataSource = model.ValuesList;
                dtgvFood.Columns[0].HeaderText = "Tên món ăn";

                dtgvFood.Columns[1].HeaderText = "Số lượng";


                Console.WriteLine("Loader view : ");
            }
            else Console.WriteLine("View not loader");
        }

        private void LoadDataToDay()
        {
            var refreshData = model.LoadData(dtpStartDate.Value, dtpEndDate.Value);
            if (refreshData = true)
            {
                
                dtgvFood.DataSource = model.FoodList;
                dtgvInput.DataSource = model.ValuesListToDay;
                dtgvFood.Columns[0].HeaderText = "Tên món ăn";

                dtgvFood.Columns[1].HeaderText = "Số lượng";


                Console.WriteLine("Loader view : ");
            }
            else Console.WriteLine("View not loader");
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            dtgvFood.Columns[1].Width = 100;
            dtgvInput.Columns[1].Width = 100;
            dtgvInput.Columns[1].DefaultCellStyle.Format = "0.000";
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
            LoadDataToDay();
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
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); ;
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }

        private void btnOKCustomDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            btnOKCustomDate.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
