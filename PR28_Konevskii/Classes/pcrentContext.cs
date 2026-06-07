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
                    DateTime.Today.Add(Data.GetTimeSpan(4))
                    ));
            }
            Connection.CloseConection(connection);
            return AllPcRents;
        }

        public void Add()
        {
            string SQL = "INSERT INTO `pcrent` (`FIoKient`, `idPcClub`, `Date_Rent`, `Time_Rent`) " +
                         "VALUES (@fio, @idPcClub, @dateRent, @timeRent)";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Execute(
                SQL,
                connection,
                new MySqlParameter("@fio", this.FioRent),
                new MySqlParameter("@idPcClub", this.Id_PcClub),
                new MySqlParameter("@dateRent", this.DateRent.ToString("yyyy-MM-dd HH:mm:ss")),
                new MySqlParameter("@timeRent", this.TimeRent.ToString("HH:mm:ss")));
            Connection.CloseConection(connection);
        }
        public void Update()
        {
            string SQL = "UPDATE `pcrent` " +
                         "SET `FIoKient`=@fio, `idPcClub`=@idPcClub, `Date_Rent`=@dateRent, `Time_Rent`=@timeRent " +
                         "WHERE `id`=@id";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Execute(
                SQL,
                connection,
                new MySqlParameter("@fio", this.FioRent),
                new MySqlParameter("@idPcClub", this.Id_PcClub),
                new MySqlParameter("@dateRent", this.DateRent.ToString("yyyy-MM-dd HH:mm:ss")),
                new MySqlParameter("@timeRent", this.TimeRent.ToString("HH:mm:ss")),
                new MySqlParameter("@id", this.Id));
            Connection.CloseConection(connection);
        }

        public void Delete()
        {
            string SQL = "DELETE FROM `pcrent` WHERE `id`=@id";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Execute(SQL, connection, new MySqlParameter("@id", this.Id));
            Connection.CloseConection(connection);
        }
    
    }
}
