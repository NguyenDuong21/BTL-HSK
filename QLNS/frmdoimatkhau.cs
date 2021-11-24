using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS
{
    public partial class frmdoimatkhau : Form
    {
        Clsdatabase cls = new Clsdatabase();
        public frmdoimatkhau()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text;
            if (ten == "")
            {
                MessageBox.Show("Bạn chưa nhập tên truy cập");
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu");
                }
                else
                {
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu mới");
                    }
                    else
                    {
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập lại mật khẩu");
                        }
                        else
                        {
                            if (textBox3.Text == textBox4.Text)
                            {

                                using (SqlConnection connection = new SqlConnection(Clsdatabase.connectionString))
                                {
                                    string procname = "sp_dangnhap";
                                    connection.Open();
                                    using (SqlCommand command = new SqlCommand(procname, connection))
                                    {
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.AddWithValue("sTendangnhap", textBox1.Text);
                                        command.Parameters.AddWithValue("sMatkhau", textBox2.Text);

                                        SqlDataReader reader = command.ExecuteReader();
                                        if(reader.Read())
                                        {
                                            reader.Close();
                                            string prochangepass = "sp_doimatkhau";
                                            using (SqlCommand commandchangepass = new SqlCommand(prochangepass, connection))
                                            {
                                                commandchangepass.CommandType = CommandType.StoredProcedure;
                                                commandchangepass.Parameters.AddWithValue("sTendangnhap", textBox1.Text);
                                                commandchangepass.Parameters.AddWithValue("sMatkhaumoi", textBox3.Text);
                                                int row_aff = commandchangepass.ExecuteNonQuery();
                                                if(row_aff > 0)
                                                {
                                                    MessageBox.Show("Thay đổi mật khẩu thành công");
                                                } else
                                                {
                                                    MessageBox.Show("Thay đổi mật khẩu thất bại");
                                                } 
                                            }
                                        } else
                                        {
                                            MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                                        }    
                                    }
                                    connection.Close();
                                }    
                            }
                            else
                            {
                                MessageBox.Show("Bạn nhập lại mật khẩu không đúng");
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker))
                {
                    ctr.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources._133;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.xanh;
        }
    }
}
