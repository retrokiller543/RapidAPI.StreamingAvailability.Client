using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidAPI.StreamingAvailability.Client.Models
{
    internal interface IRegionInfo
    {
        public ICollection<RegionInfo> Regions { get; set; }
    }
}
