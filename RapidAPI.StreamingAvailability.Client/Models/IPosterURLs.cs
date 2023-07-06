using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidAPI.StreamingAvailability.Client.Models
{
    internal interface IPosterURLs
    {
        public Dictionary<string, string> PosterURLs { get; set; }
    }
}
