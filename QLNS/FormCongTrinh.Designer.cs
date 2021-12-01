
namespace QLNS
{
    partial class FormCongTrinh
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ngayhoanthanh = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ngaykhoicong = new System.Windows.Forms.MaskedTextBox();
            this.ngaycapphep = new System.Windows.Forms.MaskedTextBox();
            this.txtCongtrinh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBaocao = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nkc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nht = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(334, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(414, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quản lý công trình";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ngayhoanthanh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ngaykhoicong);
            this.groupBox1.Controls.Add(this.ngaycapphep);
            this.groupBox1.Controls.Add(this.txtCongtrinh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1041, 125);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin công trình";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(575, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Ngày hoàn thành";
            // 
            // ngayhoanthanh
            // 
            this.ngayhoanthanh.Location = new System.Drawing.Point(694, 78);
            this.ngayhoanthanh.Mask = "00/00/0000";
            this.ngayhoanthanh.Name = "ngayhoanthanh";
            this.ngayhoanthanh.Size = new System.Drawing.Size(273, 26);
            this.ngayhoanthanh.TabIndex = 23;
            this.ngayhoanthanh.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Ngày khởi công";
            // 
            // ngaykhoicong
            // 
            this.ngaykhoicong.Location = new System.Drawing.Point(173, 81);
            this.ngaykhoicong.Mask = "00/00/0000";
            this.ngaykhoicong.Name = "ngaykhoicong";
            this.ngaykhoicong.Size = new System.Drawing.Size(273, 26);
            this.ngaykhoicong.TabIndex = 21;
            this.ngaykhoicong.ValidatingType = typeof(System.DateTime);
            // 
            // ngaycapphep
            // 
            this.ngaycapphep.Location = new System.Drawing.Point(694, 35);
            this.ngaycapphep.Mask = "00/00/0000";
            this.ngaycapphep.Name = "ngaycapphep";
            this.ngaycapphep.Size = new System.Drawing.Size(273, 26);
            this.ngaycapphep.TabIndex = 20;
            this.ngaycapphep.ValidatingType = typeof(System.DateTime);
            // 
            // txtCongtrinh
            // 
            this.txtCongtrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCongtrinh.Location = new System.Drawing.Point(173, 38);
            this.txtCongtrinh.Name = "txtCongtrinh";
            this.txtCongtrinh.Size = new System.Drawing.Size(273, 23);
            this.txtCongtrinh.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(575, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày cấp phép";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên công trình";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBaocao);
            this.groupBox2.Controls.Add(this.btnBoqua);
            this.groupBox2.Controls.Add(this.btnTimkiem);
            this.groupBox2.Controls.Add(this.insert);
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1041, 92);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btnBaocao
            // 
            this.btnBaocao.Location = new System.Drawing.Point(613, 35);
            this.btnBaocao.Name = "btnBaocao";
            this.btnBaocao.Size = new System.Drawing.Size(107, 36);
            this.btnBaocao.TabIndex = 7;
            this.btnBaocao.Text = "Báo cáo";
            this.btnBaocao.UseVisualStyleBackColor = true;
            // 
            // btnBoqua
            // 
            this.btnBoqua.Location = new System.Drawing.Point(752, 36);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(107, 35);
            this.btnBoqua.TabIndex = 6;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = true;
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(476, 34);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(107, 37);
            this.btnTimkiem.TabIndex = 5;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(59, 33);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(107, 37);
            this.insert.TabIndex = 4;
            this.insert.Text = "Thêm";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(887, 35);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(107, 36);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(339, 33);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(107, 38);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(199, 33);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(107, 38);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tct,
            this.ncp,
            this.nkc,
            this.nht});
            this.dataGridView1.Location = new System.Drawing.Point(13, 323);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 197);
            this.dataGridView1.TabIndex = 16;
            // 
            // tct
            // 
            this.tct.DataPropertyName = "sTencongtrinh";
            this.tct.HeaderText = "Tên công trình";
            this.tct.MinimumWidth = 6;
            this.tct.Name = "tct";
            this.tct.Width = 300;
            // 
            // ncp
            // 
            this.ncp.DataPropertyName = "dNgaycapphep";
            this.ncp.HeaderText = "Ngày cấp phép";
            this.ncp.MinimumWidth = 6;
            this.ncp.Name = "ncp";
            this.ncp.Width = 150;
            // 
            // nkc
            // 
            this.nkc.DataPropertyName = "dNgaykhoicong";
            this.nkc.HeaderText = "Ngày khởi công";
            this.nkc.MinimumWidth = 6;
            this.nkc.Name = "nkc";
            this.nkc.Width = 150;
            // 
            // nht
            // 
            this.nht.DataPropertyName = "dNgayhoanthanh";
            this.nht.HeaderText = "Ngày hoàn thành";
            this.nht.MinimumWidth = 6;
            this.nht.Name = "nht";
            this.nht.Width = 150;
            // 
            // FormCongTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 528);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Name = "FormCongTrinh";
            this.Text = "FormCongTrinh";
            this.Load += new System.EventHandler(this.FormCongTrinh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox ngaycapphep;
        private System.Windows.Forms.TextBox txtCongtrinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBaocao;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox ngayhoanthanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox ngaykhoicong;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncp;
        private System.Windows.Forms.DataGridViewTextBoxColumn nkc;
        private System.Windows.Forms.DataGridViewTextBoxColumn nht;
    }
}