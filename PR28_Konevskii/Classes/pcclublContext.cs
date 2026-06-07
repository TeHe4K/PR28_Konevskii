using MySql.Data.MySqlClient;
using PR28_Konevskii.Classes.Common;
using PR28_Konevskii.Models;
using System;
using System.Collections.Generic;

namespace PR28_Konevskii.Classes
{
    public class pcclublContext : pcclub
    {
        public pcclublContext(int Id, string Name, string Adress, DateTime TimeStart, DateTime TimeEnd) : base(Id,Name, Adress, TimeStart, TimeEnd) { }

        public static List<pcclublContext> Select()
        {
            List<pcclublContext> AllPcClubs = new List<pcclublContext>();
            string SQL = "SELECT * FROM `pcclubs`;";
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader Data = Connection.Query(SQL, connection);
            while (Data.Read())
            {
                AllPcClubs.Add(new pcclublContext(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetString(2),
                    DateTime.Today.Add(Data.GetTimeSpan(3)),
                    DateTime.Today.Add(Data.GetTimeSpan(4))
                    ));
            }
            Connection.CloseConection(connection);
            return AllPcClubs;
        }

        public void Add()
        {
            string SQL = "INSERT INTO `pcclubs` (`name`, `adress`, `time_start`, `time_end`) " +
                         "VALUES (@name, @adress, @time_start, @time_end)";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Execute(
                SQL,
                connection,
                new MySqlParameter("@name", this.name),
                new MySqlParameter("@adress", this.adress),
                new MySqlParameter("@time_start", this.time_start.ToString("HH:mm:ss")),
                new MySqlParameter("@time_end", this.time_end.ToString("HH:mm:ss")));
            Connection.CloseConection(connection);
        }
        public void Update()
        {
            string SQL = "UPDATE `pcclubs` " +
                         "SET `name`=@name, `adress`=@adress, `time_start`=@time_start, `time_end`=@time_end " +
                         "WHERE `id`=@id";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Execute(
                SQL,
                connection,
                new MySqlParameter("@name", this.name),
                new MySqlParameter("@adress", this.adress),
                new MySqlParameter("@time_start", this.time_start.ToString("HH:mm:ss")),
                new MySqlParameter("@time_end", this.time_end.ToString("HH:mm:ss")),
                new MySqlParameter("@id", this.id));
            Connection.CloseConection(connection);
        }

        public void Delete()
        {
            string SQL = "DELETE FROM `pcclubs` WHERE `id`=@id";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Execute(SQL, connection, new MySqlParameter("@id", this.id));
            Connection.CloseConection(connection);
        }
    }
}
