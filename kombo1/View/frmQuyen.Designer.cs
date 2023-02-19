
namespace kombo1
{
    partial class frmQuyen
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
            this.btnQL = new System.Windows.Forms.Button();
            this.btnNV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnQL
            // 
            this.btnQL.Location = new System.Drawing.Point(30, 63);
            this.btnQL.Name = "btnQL";
            this.btnQL.Size = new System.Drawing.Size(128, 60);
            this.btnQL.TabIndex = 0;
            this.btnQL.Text = "Quản lý";
            this.btnQL.UseVisualStyleBackColor = true;
            this.btnQL.Click += new System.EventHandler(this.btnQL_Click);
            // 
            // btnNV
            // 
            this.btnNV.Location = new System.Drawing.Point(202, 63);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(128, 60);
            this.btnNV.TabIndex = 1;
            this.btnNV.Text = "Nhân viên";
            this.btnNV.UseVisualStyleBackColor = true;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vai trò đăng nhập";
            // 
            // frmQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 170);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNV);
            this.Controls.Add(this.btnQL);
            this.Name = "frmQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn quyền hạn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuyen_FormClosing);
            this.Load += new System.EventHandler(this.frmQuyen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQL;
        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.Label label1;
    }
}