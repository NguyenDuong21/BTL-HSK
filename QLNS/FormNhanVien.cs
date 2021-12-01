using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class FormNhanVien : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectMysql"].ConnectionString;
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdoNam.Checked = true;
            LayDSNS();
            getDataPhongBan();
        }


        private void getDataPhongBan()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string procname = "sp_Getphongban";
                using (SqlCommand cmd = new SqlCommand(procname, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dttb = new DataTable("tbl_phongban");
                        da.Fill(dttb);

                        DataView dbv = new DataView(dttb);

                        comboBox1.DisplayMember = "sTenphong";
                        comboBox1.ValueMember = "PK_PhongbanID";
                        comboBox1.DataSource = dbv;
                    }
                }
            }
        }

        private void LayDSNS()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string procname = "sp_GetNhanVien";
                using (SqlCommand cmd = new SqlCommand(procname, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dttb = new DataTable("tbl_nhanvien");
                        da.Fill(dttb);
                        DataView dbv = new DataView(dttb);

                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = dbv;
                    }
                }
            }
        }

        private void Reset()
        {
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtPhone.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            chucvu.Text = "";
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Phong ban 1");
            ngaysinh.Text = "";
            btnXoa.Enabled = btnSua.Enabled = true;
            insert.Text = "Thêm";
            insert.Tag = "";
            LayDSNS();
        }

        private bool KiemTraThongTin()
        {
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng điền họ và tên nhân viên.", 
                    "Thông báo", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (ngaysinh.Text == "")
            {
                MessageBox.Show("Vui lòng điền ngày sinh nhân viên.", 
                    "Thông báo", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                ngaysinh.Focus();
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng điền địa chỉ của nhân viên.", 
                    "Thông báo", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính cho nhân viên.", 
                    "Thông báo", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return false;
            }
            if (txtPhone.Text == "")
            {
                MessageBox.Show("Vui lòng điền số điện thoại của nhân viên.", 
                    "Thông báo", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                txtPhone.Focus();
                return false;
            }
            if (chucvu.Text == "")
            {
                MessageBox.Show("Vui lòng điền chức vụ của nhân viên.", 
                    "Thông báo", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPhone.Focus();
                return false;
            }
            return true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dvNhanVien = (DataView)dataGridView1.DataSource;
            DataRowView row = dvNhanVien[dataGridView1.CurrentRow.Index];
            txtHoTen.Text = row["sHoten"].ToString();
            txtDiaChi.Text = row["sDiachi"].ToString();
            var d = row["dNgaysinh"].ToString().Split('/');
            ngaysinh.Text = String.Format("" + ((int.Parse(d[0]) < 10) ? "0" : "") + "{0:00}/" + ((int.Parse(d[1]) < 10) ? "0" : "") + "{1:00}/{2:0000}", d[1], d[0], d[2]);
            if (row["bGioitinh"].ToString() == "Nam")
                rdoNam.Checked = true;
            else
                rdoNu.Checked = true;
            txtPhone.Text = row["sDienthoai"].ToString();
            chucvu.Text = row["sChucvu"].ToString();
            comboBox1.SelectedIndex = comboBox1.FindStringExact(row["sTenphong"].ToString());
            btnXoa.Enabled = btnSua.Enabled = false;
            insert.Text = "Cập nhật";
            insert.Tag = row["PK_NhanvienID"].ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dvnv = (DataView)dataGridView1.DataSource;
                DataRowView row = dvnv[dataGridView1.CurrentRow.Index];

                string id = row["PK_NhanvienID"].ToString();
                string hoten = row["sHoten"].ToString();

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand("spNhanvien_delete", cnn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("@PK_NhanvienID", SqlDbType.Int).Value = id;

                        cnn.Open();
                        int i = cm.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show(string.Format("Xóa nhân viên {0} thành công", hoten),
                                    "Message",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            LayDSNS();
                            Reset();
                        }
                        cnn.Close();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (KiemTraThongTin())
            {
                try
                {
                    string ht = txtHoTen.Text;
                    var d = ngaysinh.Text.Split('/');
                    string ns = String.Format("{0:0000}-{1:00}-{2:00}", d[2], d[1], d[0]);
                    int gt = 0;

                    bool gtchecked = rdoNam.Checked;
                    if (gtchecked)
                        gt = 1;
                    else
                        gt = 0;
                    string dc = txtDiaChi.Text;
                    string sdt = txtPhone.Text;
                    string cv = chucvu.Text;
                    string pb = comboBox1.SelectedValue.ToString();

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        string procname = "spNhanvien_insert";
                        if (insert.Tag.ToString() != "")
                        {
                            procname = "spNhanvien_update";
                        }
                        using (SqlCommand cm = new SqlCommand(procname, cnn))
                        {
                            cm.CommandType = CommandType.StoredProcedure;

                            if (insert.Tag.ToString() != "")
                            {
                                cm.Parameters.Add("@PK_NhanvienID", SqlDbType.Int).Value = insert.Tag;
                            }
                            cm.Parameters.Add("@sHoten", SqlDbType.NVarChar, 255).Value = ht;
                            cm.Parameters.Add("@dNgaysinh", SqlDbType.SmallDateTime).Value = ns;
                            cm.Parameters.Add("@bGioitinh", SqlDbType.Bit).Value = gt;
                            cm.Parameters.Add("@sDiachi", SqlDbType.NVarChar, 255).Value = dc;
                            cm.Parameters.Add("@sDienthoai", SqlDbType.VarChar, 20).Value = sdt;
                            cm.Parameters.Add("@sChucvu", SqlDbType.VarChar, 255).Value = cv;
                            cm.Parameters.Add("@FK_PhongbanID", SqlDbType.Int).Value = pb;

                            cnn.Open();
                            int i = cm.ExecuteNonQuery();
                            if (i > 0)
                            {
                                if (insert.Tag.ToString() != "")
                                {
                                    MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo");
                                }
                                else
                                {
                                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo");
                                }
                                LayDSNS();
                                Reset();
                            }
                            cnn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            Reset();
            btnXoa.Enabled = btnSua.Enabled = true;
            insert.Text = "Thêm";
            insert.Tag = "";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string ht = txtHoTen.Text;
            var d = ngaysinh.Text.Split('/');
            /*string ns = "";
            if (d[2] == "" && d[0] != "" && d[1] != "")
                ns = String.Format("{0:00}-{1:00}", d[0], d[1]);
            else if (d[2] == "" && d[1] == "" && d[0] != "")
                ns = String.Format("{0:00}", d[0]);
            else if (d[1] == "" && d[0] == "" && d[2] != "")
                ns = String.Format("{0:0000}", d[2]);
            else
                ns = String.Format("{0:0000}-{1:00}-{2:00}", d[2], d[1], d[0]);*/
            //ns = String.Format(""+ ( (d[2] != "")  ? "{0:0000}-" : "") + ( (d[1] != "") ? "{1:00}-" : "") + ( (d[0] != "") ? "{2:00}" : ""), d[2], d[1], d[0]);
            string gtinh = "";
            bool gtchecked = rdoNam.Checked;
            if (gtchecked)
                gtinh = "Nam";
            else
                gtinh = "Nữ";
            string address = txtDiaChi.Text;
            string phonenumer = txtPhone.Text;
            string cvu = chucvu.Text;
            string pban = comboBox1.Text;

            string dieukienloc = "PK_NhanvienID > 0";
            dieukienloc += string.Format(" AND dNgaysinh LIKE '%{0}%' ", 26);
            if (!string.IsNullOrEmpty(ht))
            {
                dieukienloc += string.Format(" AND sHoten LIKE '%{0}%' ", ht);
            }
            DialogResult dialogResult = MessageBox.Show("Có tìm kiếm theo giới tính không", "Tìm kiếm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dieukienloc += string.Format(" AND bGioitinh  LIKE '%{0}%'", gtinh);
            }
            if (!string.IsNullOrEmpty(address))
            {
                dieukienloc += string.Format(" AND sDiachi LIKE '%{0}%' ", address);
            }
            if (!string.IsNullOrEmpty(phonenumer))
            {
                dieukienloc += string.Format(" AND sDienthoai LIKE '%{0}%'", phonenumer);
            }
            if (!string.IsNullOrEmpty(cvu))
            {
                dieukienloc += string.Format(" AND sChucvu LIKE '%{0}%'", cvu);
            }
            if (!string.IsNullOrEmpty(pban))
            {
                dieukienloc += string.Format(" AND sTenphong LIKE '%{0}%'", pban);
            }

            DataView dvKhachhang = dataGridView1.DataSource as DataView;
            dvKhachhang.RowFilter = dieukienloc;
            dataGridView1.DataSource = dvKhachhang;
        }
    }
}
