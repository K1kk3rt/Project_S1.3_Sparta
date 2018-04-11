using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Sparta.Dal
{
    public static class DALConnection
    {
        public static SqlConnection openConnectieDB()
        {
            string host = "den1.mssql4.gear.host";
            string db = "projectgroepa3";
            string user = "projectgroepa3";
            string password = "Zi9F5-~ksuPn";

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = host;
                builder.UserID = user;
                builder.Password = password;
                builder.InitialCatalog = db;

                SqlConnection connection = new SqlConnection(builder.ConnectionString);

                connection.Open();
                return connection;

            }
            catch (SqlException e)
            {
                SqlConnection connection = null;
                Console.WriteLine(e.ToString());
                return connection;
            }
        }

        public static void sluitConnectieDB(SqlConnection connection)
        {
            connection.Close();
        }
    }
}
