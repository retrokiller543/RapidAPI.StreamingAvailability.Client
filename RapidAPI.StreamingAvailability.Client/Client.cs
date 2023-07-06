using Newtonsoft.Json.Linq;
using RapidAPI.StreamingAvailability.Client.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RapidAPI.StreamingAvailability.Client
{
    public class Client
    {
        public string APIKey { get; set; }
        public Client(string apiKey)
        {
            APIKey = apiKey;
        }

        private Show ProcessShowData(JToken showData)
        {
            string type = showData.Value<string>("type");


            switch (type)
            {
                case "movie":
                    return ProcessMovieData(showData);
                case "series":
                    return ProcessSeriesData(showData);
                default:
                    throw new Exception($"Unsupported type: {type}");
            }
        }

        public Movie ProcessMovieData(JToken movieData)
        {
            var movie = new Movie
            {
                // your existing movie initialization code
                Type = movieData.Value<string>("type"),
                Title = movieData.Value<string>("title"),
                Overview = movieData.Value<string>("overview"),
                ReleaseYear = movieData.Value<int>("year"),
                imdbId = movieData.Value<string>("id"),
                imdbRating = movieData.Value<int>("imdbRating"),
                imdbVoteCount = movieData.Value<int>("imdbVoteCount"),
                tmdbId = movieData.Value<int>("tmdbId"),
                tmdbRating = movieData.Value<int>("tmdbRating"),
                OriginalTitle = movieData.Value<string>("originalTitle"),
                BackdropPath = movieData.Value<string>("backdropPath"),
                Runtime = movieData.Value<int>("runtime"),
                Trailer = movieData.Value<string>("youtubeTrailerVideoLink"),
                TrailerID = movieData.Value<string>("youtubeTrailerVideoId"),
                PosterPath = movieData.Value<string>("posterPath"),
                Tagline = movieData.Value<string>("tagline")
            };

            ProcessRegions(movieData, movie);
            ProcessCast(movieData, movie);
            ProcessDirectors(movieData, movie);
            ProcessGenres(movieData, movie);

            return movie;
        }

        public Series ProcessSeriesData(JToken seriesData)
        {
            var series = new Series
            {
                AdvisedMinimumAudienceAge = seriesData.Value<int>("advisedMinimumAudienceAge"),
                Type = seriesData.Value<string>("type"),
                Title = seriesData.Value<string>("title"),
                Overview = seriesData.Value<string>("overview"),
                FirstAirYear = seriesData.Value<int>("firstAirYear"),
                LastAirYear = seriesData.Value<int>("lastAirYear"),
                imdbId = seriesData.Value<string>("imdbId"),
                imdbRating = seriesData.Value<int>("imdbRating"),
                imdbVoteCount = seriesData.Value<int>("imdbVoteCount"),
                tmdbId = seriesData.Value<int>("tmdbId"),
                tmdbRating = seriesData.Value<int>("tmdbRating"),
                OriginalTitle = seriesData.Value<string>("originalTitle"),
                OriginalLanguage = seriesData.Value<string>("originalLanguage"),
                BackdropPath = seriesData.Value<string>("backdropPath"),
                Trailer = seriesData.Value<string>("youtubeTrailerVideoLink"),
                TrailerID = seriesData.Value<string>("youtubeTrailerVideoId"),
                PosterPath = seriesData.Value<string>("posterPath"),
                Tagline = seriesData.Value<string>("tagline"),
                Status = seriesData.Value<JToken>("status").Value<string>("statusText"),
                SeasonCount = seriesData.Value<int>("seasonCount"),
                EpisodeCount = seriesData.Value<int>("episodeCount"),
            };

            // If series also have regions, cast, directors, and genres,
            // you can use the same methods.
            ProcessRegions(seriesData, series);
            ProcessCast(seriesData, series);
            ProcessDirectors(seriesData, series);
            ProcessGenres(seriesData, series);
            ProcessSeasons(seriesData, series);
            ProcessPosterURLs(seriesData, series);
            ProcessBackdropURLs(seriesData, series);

            return series;
        }

        internal void ProcessRegions(JToken showData, Show show)
        {
            if (show is IRegionInfo regionShow) { 
                foreach (KeyValuePair<string, JToken> region in showData["streamingInfo"].ToObject<JObject>())
                {
                    var regionInfo = new RegionInfo
                    {
                        RegionName = region.Key,
                        StreamingServices = new List<StreamingService>(),
                    };

                    foreach (KeyValuePair<string, JToken> service in region.Value.ToObject<JObject>())
                    {
                        foreach (JObject info in service.Value.ToObject<JArray>())
                        {
                            var streamingService = new StreamingService
                            {
                                Service = service.Key,
                                Type = info.Value<string>("type"),
                                Quality = info.Value<string>("quality"),
                                AddOn = info.Value<string>("addOn"),
                                Link = info.Value<string>("link"),
                                watchLink = info.Value<string>("watchLink"),
                                Audios = new List<Audios>(),
                                Subtitles = new List<Subtitles>(),
                            };

                            if (info.TryGetValue("audios", out JToken? audiosList) && audiosList.HasValues)
                            {
                                foreach (JObject audio in audiosList.ToObject<JArray>())
                                {
                                    var audios = new Audios
                                    {
                                        Language = audio.Value<string>("language"),
                                        Region = audio.Value<string>("region"),
                                    };
                                    streamingService.Audios.Add(audios);
                                }
                            }

                            if (info.TryGetValue("subtitles", out JToken? subtitlesList) && subtitlesList.HasValues)
                            {
                                foreach (JObject subtitle in subtitlesList.ToObject<JArray>())
                                {
                                    var subtitles = new Subtitles
                                    {
                                        Language = subtitle["locale"].ToObject<JObject>().Value<string>("language"),
                                        Region = subtitle["locale"].ToObject<JObject>().Value<string>("region"),
                                        ClosedCaptions = subtitle["locale"].ToObject<JObject>().Value<bool>("closedCaptions"),
                                    };
                                    streamingService.Subtitles.Add(subtitles);
                                }
                            }

                            regionInfo.StreamingServices.Add(streamingService);
                        }
                    }

                    regionShow?.Regions.Add(regionInfo);
                }
            }
        }

        internal void ProcessCast(JToken showData, Show show)
        {
            JToken cast = showData["cast"];
            if (cast != null)
            {
                foreach (var person in cast)
                {
                    var actor = new Person
                    {
                        Name = (string)person,
                        
                    };
                    show?.Cast.Add(actor);
                }
            }
        }

        internal void ProcessDirectors(JToken showData, Show show)
        {
            JToken directors = showData["directors"];
            if (directors != null)
            {
                foreach (var person in directors)
                {
                    var actor = new Person
                    {
                        Name = (string)person,

                    };
                    show?.Directors.Add(actor);
                }
            } else
            {
                // Dealing with the fact that directors are called Creators for series...
                directors = showData["creators"];
                if (directors != null)
                {
                    foreach (var person in directors)
                    {
                        var actor = new Person
                        {
                            Name = (string)person,

                        };
                        show?.Directors.Add(actor);
                    }
                }
            }
        }

        internal void ProcessGenres(JToken showData, Show show)
        {
            
            if (show is IGenre genreShow)
            {
                JToken genresList = showData["genres"];
                if (genresList != null)
                {
                    genreShow.Genres = new List<Genre>();

                    foreach (JObject genre in genresList.ToObject<JArray>())
                    {
                        var newGenre = new Genre
                        {
                            Name = genre.Value<string>("name"),

                        };

                        genreShow.Genres.Add(newGenre);
                    }
                }
            }
        }

        internal void ProcessBackdropURLs(JToken showData, Show show)
        {
            if (show is IBackdropURLs backdropURLsShow)
            {
                JObject urlList = (JObject)showData["backdropURLs"];
                foreach (var path in urlList)
                {
                    backdropURLsShow.BackdropURLs.TryAdd(path.Key, path.Value.ToString());
                }
            }
        }

        internal void ProcessPosterURLs(JToken showData, Show show)
        {
            if (show is IPosterURLs posterURLsShow)
            {
                JObject urlList = (JObject)showData["posterURLs"];
                foreach (var path in urlList)
                {
                    posterURLsShow.PosterURLs.TryAdd(path.Key, path.Value.ToString());
                }
            }
        }

        internal void ProcessSeasons(JToken showData, Series show)
        {
            JArray seasons = (JArray)showData["seasons"];
            foreach (var season in seasons)
            {
                Season newSeason = new Season
                {
                    Title = season["title"].ToString(),
                    Overview = season["overview"].ToString(),
                    FirstAirYear = (int)season["firstAirYear"],
                    LastAirYear = (int)season["lastAirYear"],
                    PosterPath = season["posterPath"].ToString(),
                    Trailer = season["youtubeTrailerVideoLink"].ToString(),
                    TrailerID = season["youtubeTrailerVideoId"].ToString(),
                    Type = season["type"].ToString()
                };

                ProcessPosterURLs(season, newSeason);
                ProcessEpisodes(season, newSeason);
                ProcessCast(season, newSeason);
                ProcessDirectors(season, newSeason);
                show.Seasons.Add(newSeason);
            }
        }

        internal void ProcessEpisodes(JToken seasonData, Season season)
        {
            if (seasonData["episodes"] != null && seasonData["episodes"].Type != JTokenType.Null)
            {
                JArray episodesList;
                if (seasonData["episodes"].Type == JTokenType.Array)
                {
                    episodesList = (JArray)seasonData["episodes"];
                }
                else
                {
                    episodesList = new JArray(seasonData["episodes"]);
                }

                foreach (var episode in episodesList)
                {
                    Episode newEpisode = new Episode
                    {
                        Title = episode["title"]?.ToString(),
                        Overview = episode["overview"]?.ToString(),
                        Year = episode["year"] != null ? (int)episode["year"] : 0,
                        Runtime = episode["runtime"] != null ? (int)episode["runtime"] : 0,
                        StillPath = episode["stillPath"]?.ToString(),
                        Trailer = episode["youtubeTrailerVideoLink"]?.ToString(),
                        TrailerID = episode["youtubeTrailerVideoId"]?.ToString(),
                        Type = episode["type"]?.ToString(),
                        imdbId = episode["imdbId"]?.ToString(),
                        imdbRating = episode["imdbRating"] != null ? (int)episode["imdbRating"] : 0,
                        imdbVoteCount = episode["imdbVoteCount"] != null ? (int)episode["imdbVoteCount"] : 0,
                        tmdbId = episode["tmdbId"] != null ? (int)episode["tmdbId"] : 0,
                        tmdbRating = episode["tmdbRating"] != null ? (int)episode["tmdbRating"] : 0
                    };

                    JObject stillURLs = (JObject)episode["stillURLs"];
                    foreach (var path in stillURLs)
                    {
                        newEpisode.StillURLs.Add(path.Key, path.Value.ToString());
                    }
                    ProcessCast(episode, newEpisode);
                    ProcessRegions(episode, newEpisode);
                    season.Episodes.Add(newEpisode);
                }
            }
                
        }

        public ICollection<Show> SearchByTitle(string title, string? country, string? show_type, string? output_language)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title");

            }
            if (string.IsNullOrEmpty(country))
            {
                country = "us";
            }
            if (string.IsNullOrEmpty(show_type))
            {
                show_type = "all";
            }
            if (string.IsNullOrEmpty(output_language))
            {
                output_language = "en";
            }
            var client = new RestClient($"https://streaming-availability.p.rapidapi.com/v2/search/title?title={title}&country={country}&show_type={show_type}&output_language={output_language}");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", APIKey);
            request.AddHeader("X-RapidAPI-Host", "streaming-availability.p.rapidapi.com");
            RestResponse response = client.Execute(request);

            var shows = new List<Show>();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JObject json = JObject.Parse(response.Content);

                foreach (var showData in json.GetValue("result"))
                {
                    shows.Add(ProcessShowData(showData));
                }
            }

            return shows;
        }
    }
}
