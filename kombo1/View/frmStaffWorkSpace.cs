using FontAwesome.Sharp;
using kombo1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kombo1
{
    public partial class frmStaffWorkSpace : Form
    {

        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.AccountName); } 
        }
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currenChildForm;
        public frmStaffWorkSpace(Account acc)
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
        private void btnHome_Click(object sender, EventArgs e)
        {
           
        }
        private void frmStaffWorkSpace_Load(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            openChidForm(new frmHome());
            DisableButton();
            leftBorderBtn.Visible = false;
            iconChildFormHome.IconChar = IconChar.Home;
            iconChildFormHome.IconColor = Color.MediumPurple;
            lbChildForm.Text = "Home";
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

      //  private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
      //  {
       //     ReleaseCapture();
      //      SendMessage(this.Handle, 0x112, 0xf012, 0);
      //  }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            openChidForm(new frmAccountLogin(loginAccount));
            ActivateButton(sender, RGBColors.color4);
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
          SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            openChidForm(new frmKhuVucBan());
            ActivateButton(sender, RGBColors.color1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void panelLogo1_MouseClick(object sender, MouseEventArgs e)
        {
            currenChildForm.Close();
            Reset();
        }

        private void btnHome_MouseClick(object sender, MouseEventArgs e)
        {
            currenChildForm.Close();
            Reset();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmQuyen f = new frmQuyen();
            this.Close();
            f.Show();
        }

        private void frmStaffWorkSpace_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            currenChildForm.Close();
            
            Reset();
        }

        private void panelLogo1_Paint(object sender, PaintEventArgs e)
        {
          //  currenChildForm.Close();

            Reset();
        }
    }
}
