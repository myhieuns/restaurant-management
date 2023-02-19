
namespace kombo1
{
    partial class frmCategory
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
            this.dtgvCategory = new System.Windows.Forms.DataGridView();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnRepairCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.txtIdCategory = new System.Windows.Forms.TextBox();
            this.txtNameCategory = new System.Windows.Forms.TextBox();
            this.lbIdCategory = new System.Windows.Forms.Label();
            this.lbNameCategory = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvCategory
            // 
            this.dtgvCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCategory.Location = new System.Drawing.Point(33, 29);
            this.dtgvCategory.Name = "dtgvCategory";
            this.dtgvCategory.ReadOnly = true;
            this.dtgvCategory.Size = new System.Drawing.Size(540, 499);
            this.dtgvCategory.TabIndex = 0;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.Location = new System.Drawing.Point(671, 343);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(99, 24);
            this.btnAddCategory.TabIndex = 1;
            this.btnAddCategory.Text = "Thêm";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnRepairCategory
            // 
            this.btnRepairCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepairCategory.Location = new System.Drawing.Point(836, 343);
            this.btnRepairCategory.Name = "btnRepairCategory";
            this.btnRepairCategory.Size = new System.Drawing.Size(95, 24);
            this.btnRepairCategory.TabIndex = 1;
            this.btnRepairCategory.Text = "Sửa";
            this.btnRepairCategory.UseVisualStyleBackColor = true;
            this.btnRepairCategory.Click += new System.EventHandler(this.btnRepairCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCategory.Location = new System.Drawing.Point(671, 398);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(99, 29);
            this.btnDeleteCategory.TabIndex = 1;
            this.btnDeleteCategory.Text = "Xóa";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // txtIdCategory
            // 
            this.txtIdCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCategory.Location = new System.Drawing.Point(723, 87);
            this.txtIdCategory.Name = "txtIdCategory";
            this.txtIdCategory.ReadOnly = true;
            this.txtIdCategory.Size = new System.Drawing.Size(171, 22);
            this.txtIdCategory.TabIndex = 2;
            this.txtIdCategory.TextChanged += new System.EventHandler(this.txtIdCategory_TextChanged);
            // 
            // txtNameCategory
            // 
            this.txtNameCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameCategory.Location = new System.Drawing.Point(723, 143);
            this.txtNameCategory.Name = "txtNameCategory";
            this.txtNameCategory.Size = new System.Drawing.Size(171, 22);
            this.txtNameCategory.TabIndex = 2;
            // 
            // lbIdCategory
            // 
            this.lbIdCategory.AutoSize = true;
            this.lbIdCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdCategory.Location = new System.Drawing.Point(626, 94);
            this.lbIdCategory.Name = "lbIdCategory";
            this.lbIdCategory.Size = new System.Drawing.Size(82, 16);
            this.lbIdCategory.TabIndex = 3;
            this.lbIdCategory.Text = "ID danh mục";
            // 
            // lbNameCategory
            // 
            this.lbNameCategory.AutoSize = true;
            this.lbNameCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameCategory.Location = new System.Drawing.Point(626, 143);
            this.lbNameCategory.Name = "lbNameCategory";
            this.lbNameCategory.Size = new System.Drawing.Size(93, 16);
            this.lbNameCategory.TabIndex = 3;
            this.lbNameCategory.Text = "Tên danh mục";
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(836, 398);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(95, 29);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "Làm mới";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 579);
            this.Controls.Add(this.lbNameCategory);
            this.Controls.Add(this.lbIdCategory);
            this.Controls.Add(this.txtNameCategory);
            this.Controls.Add(this.txtIdCategory);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnRepairCategory);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.dtgvCategory);
            this.Name = "frmCategory";
            this.Text = "Quản lý danh mục";
            this.Load += new System.EventHandler(this.frmCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnRepairCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.TextBox txtIdCategory;
        private System.Windows.Forms.TextBox txtNameCategory;
        private System.Windows.Forms.Label lbIdCategory;
        private System.Windows.Forms.Label lbNameCategory;
        private System.Windows.Forms.Button btnView;
    }
}