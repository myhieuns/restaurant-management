using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace kombo1
{
    public partial class frmMomo : Form
    {
        public frmMomo()
        {
            InitializeComponent();
        }

        private void frmMomo_Load(object sender, EventArgs e)
        {
            txtTien.Text = temp;
        }
        public string temp;
        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTien.Text == "")
                    throw new Exception("Vui lòng nhập số tiền thanh toán!");
                else
                {
                    var qrcode_text = $"2|99|0834187567|{txtHoTen.Text.Trim()}|{txtGhiChu.Text.Trim()}|0|0|{float.Parse(txtTien.Text.Split(',')[0].Trim())}";

                   // MessageBox.Show("Tạo mã thành công!^^");
                    BarcodeWriter barcodeWriter = new BarcodeWriter();
                    EncodingOptions encodingOptions = new EncodingOptions() { Width = 250, Height = 250, Margin = 0, PureBarcode = false };
                    encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
                    barcodeWriter.Renderer = new BitmapRenderer();
                    barcodeWriter.Options = encodingOptions;
                    barcodeWriter.Format = BarcodeFormat.QR_CODE;
                    Bitmap bitmap = barcodeWriter.Write(qrcode_text);
                    Bitmap logo = resizeImage(Properties.Resources.MoMo_Logo, 64, 64) as Bitmap;
                    Graphics g = Graphics.FromImage(bitmap);
                    g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));
                    picMomo.Image = bitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }
        public Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }
    }
}
