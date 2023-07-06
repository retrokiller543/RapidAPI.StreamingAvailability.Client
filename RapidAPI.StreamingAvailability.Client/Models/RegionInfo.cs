using System.Collections.Generic;

namespace RapidAPI.StreamingAvailability.Client.Models
{
    public class RegionInfo
    {

        public string RegionName { get; set; } = "";

        public ICollection<StreamingService> StreamingServices { get; set; } = new List<StreamingService>();
    }
}
