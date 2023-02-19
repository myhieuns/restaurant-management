using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using kombo1.DAO;
using kombo1.DTO;
using static kombo1.frmAccountLogin;


namespace kombo1
{
    public partial class frmAdminWorkSpace1 : Form
    {
        
        
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.AccountName); } //ChangeAccount(loginAccount.IdRole);
        }
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currenChildForm;
        public frmAdminWorkSpace1(Account acc)
        {
            InitializeComponent();
            

            this.LoginAccount = acc;
            
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 40);
            panelSlideMenu1.Controls.Add(leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            customizeDesign1();
           
        }


        void ChangeAccount(string idRole)
        {
            lbNameLogin.Text = LoginAccount.AccountName;
       }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 211);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }


        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconChildFormHome.IconChar = currentBtn.IconChar;
                iconChildFormHome.IconColor = color;

            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }

        }

        private void openChidForm(Form childForm)
        {
            if (currenChildForm != null)
            {
                currenChildForm.Close();

            }
            currenChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbChildForm.Text = childForm.Text;
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSlideMenu1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customizeDesign1()
        {
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
        }

        private void hideSubMenu1()
        {
            if (panelSubMenu1.Visible == true)
                panelSubMenu1.Visible = false;
            if (panelSubMenu2.Visible == true)
                panelSubMenu2.Visible = false;
            if (panelSubMenu3.Visible == true)
                panelSubMenu3.Visible = false;
        }

        private void showSubMenu1(Panel subMenu1)
        {
            if (subMenu1.Visible == false)
            {
                hideSubMenu1();
                subMenu1.Visible = true;
            }
            else
                subMenu1.Visible = false;
        }

        private void iconBtnMenu1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

            showSubMenu1(panelSubMenu1);
        }

        private void iconBtnMenu2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            showSubMenu1(panelSubMenu2);
        }

        private void iconBtnMenu3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            showSubMenu1(panelSubMenu3);
        }

       

        private void frmAdminWorkSpace1_Load(object sender, EventArgs e)
        {
            Reset();
        }



        private void iconBtnMenu4_Click(object sender, EventArgs e)
        {
            openChidForm(new frmAccountLogin(loginAccount));
            ActivateButton(sender, RGBColors.color4);
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
        }

        private void iconBtnMenu5_Click(object sender, EventArgs e)
        {
            openChidForm(new frmAccount());
            ActivateButton(sender, RGBColors.color5);
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
        }

        private void iconBtnMenu6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            openChidForm(new frmDashBoard());
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            currenChildForm.Close();
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
            Reset();
        }

        private void Reset()
        {
            openChidForm(new Home1());
            DisableButton();
            leftBorderBtn.Visible = false;
            iconChildFormHome.IconChar = IconChar.Home;
            iconChildFormHome.IconColor = Color.MediumPurple;
            lbChildForm.Text = "Home";
        }

        // using System.Runtime.InteropServices; (phai co cau using moi chay)cho ben duoi la de keo tha o panelTitleBar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void btnSlideMenu_Click(object sender, EventArgs e)
        {
           
        }

        

        private void panelLogo1_Paint(object sender, PaintEventArgs e)
        {
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
        }

        private void iconBtn1SubMenu3_Click(object sender, EventArgs e)
        {
            openChidForm(new frmListBill());
        }

        private void iconBtn1SubMenu2_Click(object sender, EventArgs e)
        {
            openChidForm(new frmFood());
        }

        private void iconBtn1SubMenu1_Click(object sender, EventArgs e)
        {
            openChidForm(new frmInput());
        }

        private void txtAccountName_TextChanged(object sender, EventArgs e)
        {
           // Account acc;
           
            
            lbNameLogin.Text += " (" + LoginAccount.AccountName + ")" ;
            
        }

        private void lb1_Click(object sender, EventArgs e)
        {

        }

        void lbNameLoginUpdate(object sender, AccountEvent e)
        {
            lbNameLogin.Text = " (" + e.Acc.AccountName + ")";
        }

        private void lbNameLogin_Click(object sender, EventArgs e)
        {

        }

        private void iconBtn2SubMenu2_Click(object sender, EventArgs e)
        {
            openChidForm(new frmCategory());
        }

        private void iconBtn3SubMenu2_Click(object sender, EventArgs e)
        {
            openChidForm(new frmTable());
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

    //    MaterialSkinManager TManager = MaterialSkinManager.Instance;
        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmQuyen f = new frmQuyen();
            this.Close();
            f.Show();


        }

        private void iconBtn2SubMenu1_Click(object sender, EventArgs e)
        {
            openChidForm(new frmCongThuc());
        }

        private void iconBtn3SubMenu1_Click(object sender, EventArgs e)
        {
            openChidForm(new frmTonKho());
        }

        private void iconBtn2SubMenu3_Click(object sender, EventArgs e)
        {
            openChidForm(new frmKhuVucBan());
        }
    }
}
