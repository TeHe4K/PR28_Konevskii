using MySql.Data.MySqlClient;
using PR28_Konevskii.Classes.Common;
using PR28_Konevskii.Models;
using System;
using System.Collections.Generic;

namespace PR28_Konevskii.Classes
{
    public class pcrentContext : pcrent
    {
        public pcrentContext(int Id, int Id_PcClub ,string FioRent, DateTime DateRent, DateTime TimeRent): base(Id, Id_PcClub ,FioRent, DateRent, TimeRent) { }
        

        public static List<pcrentContext> Select()
        {
            List<pcrentContext> AllPcRents = new List<pcrentContext>();
            string SQL = "SELECT * FROM `pcrent`;";
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader Data = Connection.Query(SQL, connection);
            while (Data.Read())
            {
                AllPcRents.Add(new pcrentContext(
                    Data.GetInt32(0),
                    Data.GetInt32(1),
                    Data.GetString(2),
                    Data.GetDateTime(3),
                    Data.GetDateTime(4)
                    ));
            }
            Connection.CloseConection(connection);
            return AllPcRents;
        }

        public void Add()
        {
            string SQL = "INSERT INTO `pcrent`( " +
                            "`FIoKient`, " +
                            "`idPcClub`, " +
                            "`Date_Rent`, " +
                            "`Time_Rent`, " +
                        "VALUES ('" +
                            $"{this.FioRent}'," +
                            $"{this.Id_PcClub}', " + 
                            $"'{this.DateRent.ToString("dd:MM:yyyy HH:mm")}'," +
                            $"'{this.TimeRent.ToString("HH:mm")}')";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConection(connection);
        }
        public void Update()
        {
            string SQL = "UPDATE `pcrent` " +
                        "SET " +
                            $"`FIoKient`='{this.FioRent}'," +
                            $"`idPcClub`='{this.Id_PcClub}'," +
                            $"`Date_Rent`='{this.DateRent.ToString("dd:MM:yyyy HH:mm")}'," +
                            $"`Time_Rent`='{this.TimeRent.ToString("HH:mm")}' " +
                        "WHERE " +
                            $"`id`='{this.Id}'";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConection(connection);
        }

        public void Delete()
        {
            string SQL = "DELETE FROM `pcrent` WHERE " +
                $"`id` = {this.Id}";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConection(connection);
        }
    
    }
}
