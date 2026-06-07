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
                    Data.GetDateTime(3),
                    Data.GetDateTime(4)
                    ));
            }
            Connection.CloseConection(connection);
            return AllPcClubs;
        }

        public void Add()
        {
            string SQL = "INSERT INTO `pcclubs`( " +
                            "`name`, " +
                            "`adress`, " +
                            "`time_start`, " +
                            "`time_end`) " +
                        "VALUES ('" +
                            $"{this.name}'," +
                            $"'{this.adress}'," +
                            $"'{this.time_start.ToString("HH:mm")}'," +
                            $"'{this.time_end.ToString("HH:mm")}')";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConection(connection);
        }
        public void Update()
        {
            string SQL = "UPDATE `pcclubs` " +
                        "SET " +
                            $"`name`='{this.name}'," +
                            $"`adress`='{this.adress}'," +
                            $"`time_start`='{this.time_start.ToString("HH:mm")}'," +
                            $"`time_end`='{this.time_end.ToString("HH:mm")}' " +
                        "WHERE " +
                            $"`id`='{this.id}'";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConection(connection);
        }

        public void Delete()
        {
            string SQL = "DELETE FROM `pcclubs` WHERE " +
                $"`id` = {this.id}";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConection(connection);
        }
    }
}
