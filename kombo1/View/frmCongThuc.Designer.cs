
namespace kombo1
{
    partial class frmCongThuc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgvListCongThuc = new System.Windows.Forms.DataGridView();
            this.cbFoodCategory = new System.Windows.Forms.ComboBox();
            this.cbFoodName = new System.Windows.Forms.ComboBox();
            this.cbObjectName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDonVi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnRepair = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelCongThucInfo = new System.Windows.Forms.Panel();
            this.nmHamLuong1 = new System.Windows.Forms.NumericUpDown();
            this.btnHuy11 = new System.Windows.Forms.Button();
            this.btnThem2 = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lbTenMon = new System.Windows.Forms.Label();
            this.panelThemCongThuc = new System.Windows.Forms.Panel();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnHuy10 = new System.Windows.Forms.Button();
            this.cbUnitNVL = new System.Windows.Forms.ComboBox();
            this.cbNVL = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIDFood = new System.Windows.Forms.TextBox();
            this.txtIDObject = new System.Windows.Forms.TextBox();
            this.txtIDCTInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListCongThuc)).BeginInit();
            this.panelCongThucInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmHamLuong1)).BeginInit();
            this.panelThemCongThuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvListCongThuc
            // 
            this.dtgvListCongThuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvListCongThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvListCongThuc.Location = new System.Drawing.Point(314, 12);
            this.dtgvListCongThuc.Name = "dtgvListCongThuc";
            this.dtgvListCongThuc.ReadOnly = true;
            this.dtgvListCongThuc.Size = new System.Drawing.Size(682, 238);
            this.dtgvListCongThuc.TabIndex = 0;
            // 
            // cbFoodCategory
            // 
            this.cbFoodCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFoodCategory.FormattingEnabled = true;
            this.cbFoodCategory.Location = new System.Drawing.Point(30, 78);
            this.cbFoodCategory.Name = "cbFoodCategory";
            this.cbFoodCategory.Size = new System.Drawing.Size(255, 24);
            this.cbFoodCategory.TabIndex = 1;
            this.cbFoodCategory.SelectedIndexChanged += new System.EventHandler(this.cbFoodCategory_SelectedIndexChanged);
            // 
            // cbFoodName
            // 
            this.cbFoodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFoodName.FormattingEnabled = true;
            this.cbFoodName.Location = new System.Drawing.Point(30, 139);
            this.cbFoodName.Name = "cbFoodName";
            this.cbFoodName.Size = new System.Drawing.Size(255, 24);
            this.cbFoodName.TabIndex = 2;
            this.cbFoodName.SelectedIndexChanged += new System.EventHandler(this.cbFoodName_SelectedIndexChanged);
            // 
            // cbObjectName
            // 
            this.cbObjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbObjectName.FormattingEnabled = true;
            this.cbObjectName.Location = new System.Drawing.Point(181, 66);
            this.cbObjectName.Name = "cbObjectName";
            this.cbObjectName.Size = new System.Drawing.Size(232, 24);
            this.cbObjectName.TabIndex = 3;
            this.cbObjectName.SelectedIndexChanged += new System.EventHandler(this.cbObjectName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhóm món";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên món";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên nguyên liệu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hàm lượng";
            // 
            // cbDonVi
            // 
            this.cbDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDonVi.FormattingEnabled = true;
            this.cbDonVi.Location = new System.Drawing.Point(181, 155);
            this.cbDonVi.Name = "cbDonVi";
            this.cbDonVi.Size = new System.Drawing.Size(230, 24);
            this.cbDonVi.TabIndex = 3;
            this.cbDonVi.ValueMemberChanged += new System.EventHandler(this.cbDonVi_ValueMemberChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Đơn vị ";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(676, 269);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(120, 34);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "Xem";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnRepair
            // 
            this.btnRepair.Location = new System.Drawing.Point(378, 269);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(120, 34);
            this.btnRepair.TabIndex = 6;
            this.btnRepair.Text = "Sửa";
            this.btnRepair.UseVisualStyleBackColor = true;
            this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(525, 269);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 34);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelCongThucInfo
            // 
            this.panelCongThucInfo.Controls.Add(this.nmHamLuong1);
            this.panelCongThucInfo.Controls.Add(this.btnHuy11);
            this.panelCongThucInfo.Controls.Add(this.btnThem2);
            this.panelCongThucInfo.Controls.Add(this.btnSua);
            this.panelCongThucInfo.Controls.Add(this.btnXoa);
            this.panelCongThucInfo.Controls.Add(this.lbTenMon);
            this.panelCongThucInfo.Controls.Add(this.label4);
            this.panelCongThucInfo.Controls.Add(this.label5);
            this.panelCongThucInfo.Controls.Add(this.label3);
            this.panelCongThucInfo.Controls.Add(this.cbDonVi);
            this.panelCongThucInfo.Controls.Add(this.cbObjectName);
            this.panelCongThucInfo.Location = new System.Drawing.Point(267, 322);
            this.panelCongThucInfo.Name = "panelCongThucInfo";
            this.panelCongThucInfo.Size = new System.Drawing.Size(502, 258);
            this.panelCongThucInfo.TabIndex = 7;
            this.panelCongThucInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCongThucInfo_Paint);
            // 
            // nmHamLuong1
            // 
            this.nmHamLuong1.Location = new System.Drawing.Point(181, 119);
            this.nmHamLuong1.Name = "nmHamLuong1";
            this.nmHamLuong1.Size = new System.Drawing.Size(46, 20);
            this.nmHamLuong1.TabIndex = 10;
            // 
            // btnHuy11
            // 
            this.btnHuy11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy11.Location = new System.Drawing.Point(391, 209);
            this.btnHuy11.Name = "btnHuy11";
            this.btnHuy11.Size = new System.Drawing.Size(66, 33);
            this.btnHuy11.TabIndex = 9;
            this.btnHuy11.Text = "Trở lại";
            this.btnHuy11.UseVisualStyleBackColor = true;
            this.btnHuy11.Click += new System.EventHandler(this.btnHuy11_Click);
            // 
            // btnThem2
            // 
            this.btnThem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem2.Location = new System.Drawing.Point(122, 209);
            this.btnThem2.Name = "btnThem2";
            this.btnThem2.Size = new System.Drawing.Size(66, 33);
            this.btnThem2.TabIndex = 8;
            this.btnThem2.Text = "Thêm";
            this.btnThem2.UseVisualStyleBackColor = true;
            this.btnThem2.Click += new System.EventHandler(this.btnThem2_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(210, 209);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(66, 33);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(301, 209);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(66, 33);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lbTenMon
            // 
            this.lbTenMon.AutoSize = true;
            this.lbTenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenMon.Location = new System.Drawing.Point(119, 30);
            this.lbTenMon.Name = "lbTenMon";
            this.lbTenMon.Size = new System.Drawing.Size(51, 16);
            this.lbTenMon.TabIndex = 7;
            this.lbTenMon.Text = "label6";
            // 
            // panelThemCongThuc
            // 
            this.panelThemCongThuc.Controls.Add(this.nmSoLuong);
            this.panelThemCongThuc.Controls.Add(this.btnHuy10);
            this.panelThemCongThuc.Controls.Add(this.cbUnitNVL);
            this.panelThemCongThuc.Controls.Add(this.cbNVL);
            this.panelThemCongThuc.Controls.Add(this.button2);
            this.panelThemCongThuc.Controls.Add(this.label7);
            this.panelThemCongThuc.Controls.Add(this.label8);
            this.panelThemCongThuc.Controls.Add(this.label9);
            this.panelThemCongThuc.Location = new System.Drawing.Point(267, 322);
            this.panelThemCongThuc.Name = "panelThemCongThuc";
            this.panelThemCongThuc.Size = new System.Drawing.Size(502, 258);
            this.panelThemCongThuc.TabIndex = 7;
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Location = new System.Drawing.Point(171, 114);
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(46, 20);
            this.nmSoLuong.TabIndex = 10;
            // 
            // btnHuy10
            // 
            this.btnHuy10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy10.Location = new System.Drawing.Point(285, 206);
            this.btnHuy10.Name = "btnHuy10";
            this.btnHuy10.Size = new System.Drawing.Size(66, 33);
            this.btnHuy10.TabIndex = 9;
            this.btnHuy10.Text = "Trở lại";
            this.btnHuy10.UseVisualStyleBackColor = true;
            this.btnHuy10.Click += new System.EventHandler(this.btnHuy10_Click);
            // 
            // cbUnitNVL
            // 
            this.cbUnitNVL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUnitNVL.FormattingEnabled = true;
            this.cbUnitNVL.Location = new System.Drawing.Point(171, 157);
            this.cbUnitNVL.Name = "cbUnitNVL";
            this.cbUnitNVL.Size = new System.Drawing.Size(230, 24);
            this.cbUnitNVL.TabIndex = 8;
            this.cbUnitNVL.SelectedIndexChanged += new System.EventHandler(this.cbUnitNVL_SelectedIndexChanged);
            // 
            // cbNVL
            // 
            this.cbNVL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNVL.FormattingEnabled = true;
            this.cbNVL.Location = new System.Drawing.Point(171, 74);
            this.cbNVL.Name = "cbNVL";
            this.cbNVL.Size = new System.Drawing.Size(232, 24);
            this.cbNVL.TabIndex = 8;
            this.cbNVL.SelectedIndexChanged += new System.EventHandler(this.cbNVL_SelectedIndexChanged);
            this.cbNVL.SelectedValueChanged += new System.EventHandler(this.cbNVL_SelectedValueChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(171, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 33);
            this.button2.TabIndex = 6;
            this.button2.Text = "Thêm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Hàm lượng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Đơn vị ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(34, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Tên nguyên liệu";
            // 
            // txtIDFood
            // 
            this.txtIDFood.Location = new System.Drawing.Point(36, 411);
            this.txtIDFood.Name = "txtIDFood";
            this.txtIDFood.Size = new System.Drawing.Size(81, 20);
            this.txtIDFood.TabIndex = 9;
            this.txtIDFood.TextChanged += new System.EventHandler(this.txtIDFood_TextChanged);
            // 
            // txtIDObject
            // 
            this.txtIDObject.Location = new System.Drawing.Point(36, 440);
            this.txtIDObject.Name = "txtIDObject";
            this.txtIDObject.Size = new System.Drawing.Size(81, 20);
            this.txtIDObject.TabIndex = 10;
            this.txtIDObject.TextChanged += new System.EventHandler(this.txtIDObject_TextChanged);
            // 
            // txtIDCTInfo
            // 
            this.txtIDCTInfo.Location = new System.Drawing.Point(36, 470);
            this.txtIDCTInfo.Name = "txtIDCTInfo";
            this.txtIDCTInfo.Size = new System.Drawing.Size(81, 20);
            this.txtIDCTInfo.TabIndex = 11;
            this.txtIDCTInfo.TextChanged += new System.EventHandler(this.txtIDCTInfo_TextChanged);
            // 
            // frmCongThuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 579);
            this.Controls.Add(this.txtIDCTInfo);
            this.Controls.Add(this.txtIDObject);
            this.Controls.Add(this.txtIDFood);
            this.Controls.Add(this.panelThemCongThuc);
            this.Controls.Add(this.panelCongThucInfo);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRepair);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFoodName);
            this.Controls.Add(this.cbFoodCategory);
            this.Controls.Add(this.dtgvListCongThuc);
            this.Name = "frmCongThuc";
            this.Text = "Công thức món ăn";
            this.Load += new System.EventHandler(this.frmCongThuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListCongThuc)).EndInit();
            this.panelCongThucInfo.ResumeLayout(false);
            this.panelCongThucInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmHamLuong1)).EndInit();
            this.panelThemCongThuc.ResumeLayout(false);
            this.panelThemCongThuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvListCongThuc;
        private System.Windows.Forms.ComboBox cbFoodCategory;
        private System.Windows.Forms.ComboBox cbFoodName;
        private System.Windows.Forms.ComboBox cbObjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDonVi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelCongThucInfo;
        private System.Windows.Forms.Label lbTenMon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Panel panelThemCongThuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbUnitNVL;
        private System.Windows.Forms.ComboBox cbNVL;
        private System.Windows.Forms.Button btnThem2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtIDFood;
        private System.Windows.Forms.TextBox txtIDObject;
        private System.Windows.Forms.Button btnHuy10;
        private System.Windows.Forms.Button btnHuy11;
        private System.Windows.Forms.TextBox txtIDCTInfo;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.NumericUpDown nmHamLuong1;
    }
}