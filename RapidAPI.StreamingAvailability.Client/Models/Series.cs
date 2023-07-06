using RapidAPI.StreamingAvailability.Client.Models;
using System.Collections.Generic;
using System.Linq;

namespace RapidAPI.StreamingAvailability.Client.Models
{
    public class Series : Show, IGenre, IRegionInfo, IBackdropURLs, IPosterURLs
    {
        public int AdvisedMinimumAudienceAge { get; set; } = 0;
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
        public ICollection<string> Countries { get; set; } = new List<string>();
        public string Status { get; set; } = "";
        public int SeasonCount { get; set; } = 0;
        public int EpisodeCount { get; set; } = 0;
        public ICollection<int> EpisodeRuntimes { get; set; } = new List<int>();
        public int Runtime { get; set; } = 0;
        public int FirstAirYear { get; set; } = 0;
        public int LastAirYear { get; set; } = 0;
        public string PosterPath { get; set; } = "";
        public Dictionary<string, string> PosterURLs { get; set; } = new Dictionary<string, string>();
        public string Tagline { get; set; } = "";
        public ICollection<Season> Seasons { get; set; } = new List<Season>();
        public ICollection<RegionInfo> Regions { get; set; } = new List<RegionInfo>();

        public Series() : base()
        {
            Runtime = CalculateRuntime();
        }

        public int CalculateRuntime()
        {
            if (Seasons == null || !Seasons.Any())
                return 0;

            int runtime = 0;

            foreach (Season season in Seasons)
            {
                foreach (Episode episode in season.Episodes)
                {
                    if (episode.Runtime != 0)
                    {
                        runtime += episode.Runtime;
                    }
                }
            }

            return runtime;
        }
    }
}
