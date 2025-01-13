using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniSys
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignupForm signupForm = new SignupForm(); //ایجاد یک نمونه از فرم ثبت نام
            this.Hide();
            signupForm.ShowDialog(); //نمایش فرم ثبت نام

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            if (textUs.Text =="" && textPas.Text =="")
            {
                MessageBox.Show("لطفا نام کاربری و رمزعبور را وارد کنید");
            }
            else if (textUs.Text == "" && textPas.Text != "")
            {
                MessageBox.Show("لطفا نام کاربری را وارد کنید");
            }
            else if (textUs.Text != "" && textPas.Text == "")
            {
                MessageBox.Show("لطفا رمزعبور را وارد کنید");
            }
            else
            {
                OleDbConnection con =new OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Access Database.accdb";
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "SELECT COUNT(*) FROM [Users] WHERE User=? AND Password=?";
                command.Parameters.AddWithValue("@User",textUs.Text);
                command.Parameters.AddWithValue("@Password",textPas.Text);
                command.Connection = con;
                int count=(int)command.ExecuteScalar();
                if (count > 0)
                {
                    DashbordForm main = new DashbordForm();
                    MessageBox.Show("Welcome");
                    this.Hide();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Error");
                }


                

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
