using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Buoi14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string ConnectionString { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string .IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập tên CSDL", "Thông báo",MessageBoxButtons.OKCancel);
                if(string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.Focus();
                }
                else
                {
                    textBox2.Focus();
                }
                return;
            }
            string serverName = textBox1.Text;
            string databaseName = textBox2.Text;
            string userName = textBox3.Text;
            string password = textBox4.Text;
            ConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", serverName, databaseName, userName, password);
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Kết nối thành công!");
                    // Tiếp tục với các hoạt động trên CSDL
                    Form2 form2 = new Form2();
                    form2.ConnectionString = this.ConnectionString;
                    form2.ShowDialog();
                    this.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
