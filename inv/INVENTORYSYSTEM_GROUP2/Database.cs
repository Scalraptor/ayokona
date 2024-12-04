using System;
using System.Data.SqlClient;

namespace INVENTORYSYSTEM_GROUP2
{
    public class Database
    {
        private readonly string connectionString;

        public Database()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\INVENTORYSYSTEM_GROUP2\InventoryDB.mdf;Integrated Security=True";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
