using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.OleDb;

namespace UniSys
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SignupForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection();
            connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Access Database.accdb";
            connect.Open();
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "insert into [Users]([Number],[User],[Password]) values(?,?,?)";
            com.Parameters.AddWithValue("@Number",textBox1.Text);
            com.Parameters.AddWithValue("@User",textBox2.Text);
            com.Parameters.AddWithValue("@Password",textBox3.Text);
            com.Connection= connect;
            int count = (int)com.ExecuteNonQuery();
            if (count == 1)
            {
                MessageBox.Show("ثیت نام موفیقت آمیز بود");
                LoginForm loginForm = new LoginForm(); 
                this.Hide();
                loginForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("متاسفانه خطایی رخ داده است با پشتیبانی تماس بگیرید");
            }
        }
    }
}
