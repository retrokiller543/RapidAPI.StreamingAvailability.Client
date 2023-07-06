using System.Collections.Generic;

namespace RapidAPI.StreamingAvailability.Client.Models
{
    public class StreamingService
    {
        public string Type { get; set; } = "";
        public string Service { get; set; } = "";
        public string Quality { get; set; } = "";
        public string AddOn { get; set; } = "";
        public string Link { get; set; } = "";
        public string watchLink { get; set; } = "";
        public ICollection<Audios> Audios { get; set; }
        public ICollection<Subtitles> Subtitles { get; set; }
    }
}
