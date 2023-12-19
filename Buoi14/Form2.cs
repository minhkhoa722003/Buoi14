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
    public partial class Form2 : Form
    {
        public string ConnectionString { get; set; }
        public Form2()
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                connection.Open();

                // Câu truy vấn SQL
                string query = "SELECT ColumnName FROM TableName"; // Thay thế ColumnName và TableName bằng các tên thực tế trong CSDL của bạn

                // Thực thi truy vấn
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Đọc dữ liệu và thêm vào ComboBox
                        while (reader.Read())
                        {
                            string value = reader.GetString(0); // Thay đổi số 0 thành chỉ số cột thực tế trong truy vấn của bạn
                            comboBox1.Items.Add(value);
                        }
                    }
                }
            }
            InitializeComponent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
