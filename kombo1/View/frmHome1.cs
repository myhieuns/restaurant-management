using CefSharp;
using CefSharp.WinForms;
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
    public partial class Home1 : Form
    {
        public Home1()
        {
           
            InitializeComponent();
        }

        ChromiumWebBrowser chrome;
        private void Home1_Load(object sender, EventArgs e)
        {
            chrome = new ChromiumWebBrowser("https://kombo.vn/");
            this.chromiumWebBrowser1.Controls.Add(chrome);
        }
    }
}
