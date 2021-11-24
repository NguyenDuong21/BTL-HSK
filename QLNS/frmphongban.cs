using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS
{
    public partial class frmphongban : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public frmphongban()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        private void frmphongban_Load(object sender, EventArgs e)
        {
            loadPhongban();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }
        private void loadPhongban()
        {
            DataTable phongban = Clsdatabase.loadtable("sp_Phongbanget");
            DataView dataViewphongban = new DataView(phongban);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.DataSource = dataViewphongban;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string procname = "sp_PhongbanInsert";
            string tenphong = textBox3.Text;
            string ngaythanhlap = dateTimePicker1.Text;
            string chucnang = textBox5.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(procname, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("sTenphong", tenphong);
                        command.Parameters.AddWithValue("dNgaythanhlap", ngaythanhlap);
                        command.Parameters.AddWithValue("sPhutrach", chucnang);
                        int row_aff = command.ExecuteNonQuery();
                        if (row_aff > 0)
                        {
                            MessageBox.Show("Thêm phòng ban thành công");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                    connection.Close();
                }
            }
            loadPhongban();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataView dataView = (DataView)dataGridView1.DataSource;
            DataRowView row = dataView[dataGridView1.CurrentRow.Index];
            if(row["sTenphong"] != System.DBNull.Value)
            {
                textBox3.Text = (string)row["sTenphong"];
                dateTimePicker1.Text = row["dNgaythanhlap"].ToString();
                textBox5.Text = (string)row["sPhutrach"];
                button2.Tag = row["PK_PhongbanID"];
            }    
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maphongban = button2.Tag.ToString();
            if(!string.IsNullOrEmpty(maphongban))
            {
                string procname = "sp_PhongbanUpdate";
                string tenphong = textBox3.Text;
                string ngaythanhlap = dateTimePicker1.Text;
                string chucnang = textBox5.Text;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(procname, connection))
                    {
                        try
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("sTenphong", tenphong);
                            command.Parameters.AddWithValue("dNgaythanhlap", ngaythanhlap);
                            command.Parameters.AddWithValue("sPhutrach", chucnang);
                            command.Parameters.AddWithValue("PK_PhongbanID", maphongban);
                            int row_aff = command.ExecuteNonQuery();
                            if (row_aff > 0)
                            {
                                MessageBox.Show("Sửa phòng ban thành công");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Sửa thất bại");
                        }
                        connection.Close();
                    }
                }
                loadPhongban();
            } else
            {
                MessageBox.Show("Hãy chọn phòng ban cần chỉnh sửa");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string maphongban = button2.Tag.ToString();
            if (!string.IsNullOrEmpty(maphongban))
            {
                string procname = "sp_PhongbanDelete";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(procname, connection))
                    {
                        try
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("PK_PhongbanID", maphongban);
                            int row_aff = command.ExecuteNonQuery();
                            if (row_aff > 0)
                            {
                                MessageBox.Show("Xóa phòng ban thành công");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Xóa thất bại. Phòng ban đã được sử dụng");
                        }
                        connection.Close();
                    }
                }
                loadPhongban();
            }
            else
            {
                MessageBox.Show("Hãy chọn phòng ban để xóa");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources._133;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.xanh;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
