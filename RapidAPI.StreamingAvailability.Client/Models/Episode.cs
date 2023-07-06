using System;
using System.Collections.Generic;

namespace RapidAPI.StreamingAvailability.Client.Models
{
    public class Episode : Show, IRegionInfo
    {
        public int Year { get; set; } = 0;
        public int Runtime { get; set; } = 0;
        public string StillPath { get; set; } = "";
        public Dictionary<string, string> StillURLs { get; set; } = new Dictionary<string, string>();
        public string imdbId { get; set; } = "";
        public int imdbRating { get; set; } = 0;
        public int imdbVoteCount { get; set; } = 0;
        public int tmdbId { get; set; } = 0;
        public int tmdbRating { get; set; } = 0;
        public ICollection<RegionInfo> Regions { get; set; } = new List<RegionInfo>();
    }
}
