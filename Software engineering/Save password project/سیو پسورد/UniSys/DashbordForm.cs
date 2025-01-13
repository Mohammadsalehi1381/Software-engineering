using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniSys
{
    public partial class DashbordForm : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Path\To\Your\Database.accdb";
        public DashbordForm()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand com;
        OleDbDataAdapter adapter;
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                  
                    dataGridView1.CurrentRow.Cells[1].Value = textBox1.Text;
                    dataGridView1.CurrentRow.Cells[2].Value = textBox2.Text;
                    dataGridView1.CurrentRow.Cells[3].Value = textBox3.Text;

                    string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= Access Databace.accdb;"; // ارتباط
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        string query = "UPDATE passwords SET [username] = @username,[platformname] = @platformname,[password] = @password  WHERE ID = @ID";

                        using (OleDbCommand com = new OleDbCommand(query, con))
                        {
                            com.Parameters.AddWithValue("@username", textBox1.Text);
                            com.Parameters.AddWithValue("@platformname", textBox2.Text);
                            com.Parameters.AddWithValue("@password", textBox3.Text);
                            com.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells[0].Value);
                            con.Open();
                            int rowAffected = com.ExecuteNonQuery();
                            if (rowAffected > 0)
                            {
                                MessageBox.Show("اطلاعات با موفقیت بروزرسانی شد");
                            }
                            else
                            {
                                MessageBox.Show("خطا");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("در ذخیره اطلاعات مشکلی پیش آمد");
                }
            }
        }
        int selected_index;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DashbordForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            con = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source =Access Database.accdb");// ارتباط با پایگاه داده
            adapter = new OleDbDataAdapter("SELECT * FROM passwords", con);

            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) 
            {


                OleDbConnection con = new OleDbConnection(); 
                con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Access Database.accdb"; // مسیر پایگاه داده
                con.Open();
                OleDbCommand com = new OleDbCommand(); 
                com.CommandText = "delete from [passwords] where [ID]=?"; 

                com.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells["ID"].Value);
                com.Connection = con;
                com.ExecuteNonQuery();

                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;

                con.Close(); 
                MessageBox.Show("سطر انتخابی با موفقیت حذف شد");

            }
            else
            {
                MessageBox.Show("در حذف اطلاعات خطایی وجود دارد");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection();
            connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Access Database.accdb";
            connect.Open();
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "insert into [passwords]([username],[platformname],[Password]) values(?,?,?)";
            com.Parameters.AddWithValue("@username", textBox1.Text);
            com.Parameters.AddWithValue("@platformname", textBox2.Text);
            com.Parameters.AddWithValue("@Password", textBox3.Text);
            com.Connection = connect;
            int count = (int)com.ExecuteNonQuery();
            if (count == 1)
            {
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                MessageBox.Show("اطلاعات با موفقیت ذخیره شد");
           
            }
            else
            {
                MessageBox.Show("متاسفانه خطایی رخ داده است با پشتیبانی تماس بگیرید");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            con = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source =Access Database.accdb");// ارتباط با پایگاه داده
            adapter = new OleDbDataAdapter("SELECT * FROM passwords", con);

            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;

        }
    }
}
