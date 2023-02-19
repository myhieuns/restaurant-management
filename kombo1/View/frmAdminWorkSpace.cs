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
    public partial class frmAdminWorkSpace : Form
    {
        public frmAdminWorkSpace()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            panelButton1Submenu.Visible = false;
            panelButton2Submenu.Visible = false;
            panelButton3Submenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if(panelButton1Submenu.Visible == true)
               panelButton1Submenu.Visible = false;
            if (panelButton2Submenu.Visible == true)
                panelButton2Submenu.Visible = false;
            if (panelButton3Submenu.Visible == true)
                panelButton3Submenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAdminWorkSpace_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureLogo_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            showSubMenu(panelButton1Submenu);
        }

        private void btn1Submenu1_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDashBoard());
            hideSubMenu();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            showSubMenu(panelButton2Submenu);
        }

        private void btn1Submenu2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn1Submenu3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn2Submenu1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn2Submenu2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn2Submenu3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            showSubMenu(panelButton3Submenu);
        }

        private void btn3Submenu1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn3Submenu2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn3Submenu3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private Form activeForm = null;
        private void openChildForm( Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }
    }
}
