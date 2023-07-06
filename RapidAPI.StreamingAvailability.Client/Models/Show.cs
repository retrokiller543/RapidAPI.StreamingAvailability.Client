using System.Collections.Generic;

namespace RapidAPI.StreamingAvailability.Client.Models
{
    public class Show
    {
        public string Type { get; set; } = "";
        public string Title { get; set; } = "";
        public string Overview { get; set; } = "";
        public ICollection<Person> Cast { get; set; } = new List<Person>();
        public ICollection<Person> Directors { get; set; } = new List<Person>();
        public string TrailerID { get; set; } = "";
        public string Trailer { get; set; } = "";
        

    }
}
