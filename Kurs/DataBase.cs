using MySql.Data.MySqlClient;
using System.Data;

namespace Kursach
{
    class DataBase
    {
        MySqlConnection connection = new MySqlConnection("server=sql7.freemysqlhosting.net;port=3306;username=sql7344084;password=5tLvZbLpUK;database=sql7344084");

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
