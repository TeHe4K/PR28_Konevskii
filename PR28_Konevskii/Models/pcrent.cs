using System;

namespace PR28_Konevskii.Models
{
    public class pcrent
    {
        public int Id { get; set; }
        public string FioRent { get; set; }
        public DateTime DateRent { get; set; }
        public DateTime TimeRent { get; set; }

        public pcrent(int id, string fioRent, DateTime dateRent, DateTime timeRent)
        {
            Id = id;
            FioRent = fioRent;
            DateRent = dateRent;
            TimeRent = timeRent;
        }
    }
}
