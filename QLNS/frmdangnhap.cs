using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace QLNS
{
    public partial class frmdangnhap : Form
    {
        private SqlConnection Con = null;

        public frmdangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Clsdatabase.connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("sp_dangnhap", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("sTendangnhap", textBox1.Text);
                    command.Parameters.AddWithValue("sMatkhau", textBox2.Text);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Đăng nhập vào hệ thống ", "Thông báo !");
                        FrmMain.quyen = (string)reader["sTenquyen"];
                        this.Hide();
                        this.Close();
                        FrmMain frm = new FrmMain();
                        //frm.Show();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không chính xácc", "Thông báo !");
                    }
                }    
            }    
            
            
            
            }

        }

               // else MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        
//    }
//}
