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
    public partial class DashbordForm : Form
    {
        public DashbordForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection();
            connect.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Access Database.accdb";
            connect.Open();
            
            
            
            
            
            
            
            
            
            // string connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Access Database.accdb");
        }
    }
}
