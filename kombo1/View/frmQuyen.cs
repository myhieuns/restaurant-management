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
    public partial class frmQuyen : Form
    {
        public frmQuyen()
        {
            InitializeComponent();
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            this.Hide();
            f.ShowDialog();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            frmStaffLogin f = new frmStaffLogin();
            this.Hide();
            f.ShowDialog();
        }

        private void frmQuyen_Load(object sender, EventArgs e)
        {

        }

        private void frmQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
         
        }
    }
}
