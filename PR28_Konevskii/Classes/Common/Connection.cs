using MySql.Data.MySqlClient;

namespace PR28_Konevskii.Classes.Common
{
    public class Connection
    {
        public static readonly string config = "server=127.0.0.1;uid=root;pwd=;database=pc_clubs";
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(config);
            connection.Open();
            return connection;
        }
        public static MySqlDataReader Query(string SQL, MySqlConnection connection)
        {
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }
        public static int Execute(string SQL, MySqlConnection connection, params MySqlParameter[] parameters)
        {
            using (MySqlCommand command = new MySqlCommand(SQL, connection))
            {
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                return command.ExecuteNonQuery();
            }
        }
        public static void CloseConection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearAllPools();
        }
    }
}
