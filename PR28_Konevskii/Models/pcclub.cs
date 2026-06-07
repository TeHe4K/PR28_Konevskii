using System;

namespace PR28_Konevskii.Models
{
    public class pcclub
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public DateTime time_start { get; set; }
        public DateTime time_end { get; set; }

        public pcclub(int id, string name, string adress, DateTime time_start, DateTime time_end)
        {
            this.id = id;
            this.name = name;
            this.adress = adress;
            this.time_start = time_start;
            this.time_end = time_end;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
