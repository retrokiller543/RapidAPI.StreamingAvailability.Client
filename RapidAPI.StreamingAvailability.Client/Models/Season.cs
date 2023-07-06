using System.Collections.Generic;

namespace RapidAPI.StreamingAvailability.Client.Models
{
    public class Season : Show, IPosterURLs
    {
        public int FirstAirYear { get; set; } = 0;
        public int LastAirYear { get; set; } = 0;
        public string PosterPath { get; set; } = "";
        public Dictionary<string, string> PosterURLs { get; set; } = new Dictionary<string, string>();
        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
