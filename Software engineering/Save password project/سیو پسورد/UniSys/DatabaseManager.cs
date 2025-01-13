using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UniSys
{
    public static class DatabaseManager
    {
        private static OleDbConnection connection; //اتصال به پایگاه داده

        public static OleDbConnection GetConnection() // متد برای دسترسی به اتصال
        {
            if (connection == null)
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Access Database.accdb");
            }
            return connection;
        }

        public static void OpenConnectin()
        {
            try
            {
                if (connection == null)
                    connection = new OleDbConnection();
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در اتصال به پایگاه داده" + ex.Message);

            }
        }

        public static void CloseConnectin() //متد برای بستن اتصال 
        {
            if(connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
            
    }

    
}
