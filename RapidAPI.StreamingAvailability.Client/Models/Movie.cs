using RapidAPI.StreamingAvailability.Client.Models;
using System.Collections.Generic;

namespace RapidAPI.StreamingAvailability.Client.Models
{
    public class Movie : Show, IGenre, IRegionInfo
    {
        public int ReleaseYear { get; set; } = 0;
        public string imdbId { get; set; } = "";
        public int imdbRating { get; set; } = 0;
        public int imdbVoteCount { get; set; } = 0;
        public int tmdbId { get; set; } = 0;
        public int tmdbRating { get; set; } = 0;
        public string OriginalTitle { get; set; } = "";
        public string OriginalLanguage { get; set; } = "";
        public string BackdropPath { get; set; } = "";
        public Dictionary<string, string> BackdropURLs { get; set; } = new Dictionary<string, string>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public int Runtime { get; set; } = 0;
        public string PosterPath { get; set; } = "";
        public Dictionary<string, string> PosterURLs { get; set; } = new Dictionary<string, string>();
        public string Tagline { get; set; } = "";
        public ICollection<RegionInfo> Regions { get; set; } = new List<RegionInfo>();
    }
}
