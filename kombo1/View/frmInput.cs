using kombo1.DAO;
using kombo1.DTO;
using kombo1.Models;
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
    public partial class frmInput : Form
    {
        BindingSource objectList = new BindingSource();
        BindingSource inputList = new BindingSource();
        public frmInput()
        {
            InitializeComponent();
          
            dtgListObject.DataSource = objectList;
            dtgListInput.DataSource = inputList;
            LoadListObject();
            LoadListInput();
            AddObjectBinding();
        }

        void LoadListObject()
        {
            objectList.DataSource = ObjectDAO.Instance.GetListObject1();
        }

       void LoadListInput()
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            inputList.DataSource = InputDAO.Instance.GetListInput();
       }
      
        void AddObjectBinding()
        {
            txtObjectName.DataBindings.Add(new Binding("Text", dtgListObject.DataSource, "objectname"));
            txtUnit.DataBindings.Add(new Binding("Text", dtgListObject.DataSource, "unitname"));
            txtIDobject.DataBindings.Add(new Binding("Text", dtgListObject.DataSource, "id"));
           
           // int id = int.Parse(txtIDUnit.Text);
            //dataGridView1.DataSource = UnitsDAO.Instance.GetUnitsByID1(id);
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void frmInput_Load(object sender, EventArgs e)
        {
            txtIDobject.Visible = false;
           // txtIDInput.Text = InputDAO.Instance.GetIDInput().ToString();
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Now;
            dtgListObject.Columns[0].HeaderText = "ID";
            dtgListObject.Columns[0].Width = 50;
            dtgListObject.Columns[1].HeaderText = "Tên NVL";
           
            dtgListObject.Columns[2].HeaderText = "Tỷ lệ sơ chế";
            dtgListObject.Columns[2].Width = 80;
            dtgListObject.Columns[3].HeaderText = "Đơn vị tính";
            dtgListObject.Columns[3].Width = 100;

            dtgListInput.Columns[0].HeaderText = "ID";
            dtgListInput.Columns[0].Width = 100;
            dtgListInput.Columns[1].HeaderText = "Tên NVL";
            dtgListInput.Columns[2].HeaderText = "Số lượng";
            dtgListInput.Columns[2].Width = 150;
            dtgListInput.Columns[3].HeaderText = "Ngày nhập";
            dtgListInput.Columns[3].Width = 250;
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtObjectName == null)
                {
                    MessageBox.Show("Bạn chưa chọn NVL!");
                    return;
                }
                else
                {
                    
                    int idInput = InputDAO.Instance.GetUnCheckInput();
                    int objectID = int.Parse(txtIDobject.Text);
                    int count = (int)nmSoLuong.Value;
                    if (idInput == -1)
                    {
                        InputDAO.Instance.InsertInput();
                        InputDAO.Instance.InsertInputInfo(InputDAO.Instance.GetMaxIDInput(), objectID, count);
                        LoadListInput();


                    }
                    else
                    {
                        InputDAO.Instance.InsertInputInfo(idInput, objectID, count);
                        LoadListInput();


                    }

                       
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
   

        private void txtIDUnit_TextChanged(object sender, EventArgs e)
        {
            
        }

        void ShowBill(int id)
        {
           
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgListInput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
