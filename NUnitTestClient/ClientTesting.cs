using Newtonsoft.Json.Linq;
using RapidAPI.StreamingAvailability.Client;
using RapidAPI.StreamingAvailability.Client.Models;

namespace NUnitTestClient
{
    public class Tests
    {
        // this test class is very much work in progress, its really annoying to make test xD
        public JObject SeriesData { get; set; }

        [SetUp]
        public void Setup()
        {
            SeriesData = JObject.Parse(@"            
            {
              ""type"": ""series"",
              ""title"": ""Test Series"",
              ""overview"": ""This is a test series. Lorem ipsum dolor sit amet, consectetur adipiscing elit."",
              ""streamingInfo"": {
                ""se"": {
                  ""netflix"": [
                    {
                      ""type"": ""subscription"",
                      ""quality"": """",
                      ""addOn"": """",
                      ""link"": ""https://www.netflix.com/title/00000000/"",
                      ""watchLink"": """",
                      ""audios"": null,
                      ""subtitles"": null,
                      ""price"": null,
                      ""leaving"": 0,
                      ""availableSince"": 1650105382
                    }
                  ]
                }
              },
              ""cast"": [
                ""Actor 1"",
                ""Actor 2"",
                ""Actor 3"",
                ""Actor 4""
              ],
              ""firstAirYear"": 2022,
              ""lastAirYear"": 2023,
              ""advisedMinimumAudienceAge"": 12,
              ""imdbId"": ""tt0000000"",
              ""imdbRating"": 75,
              ""imdbVoteCount"": 1234,
              ""tmdbId"": 12345,
              ""tmdbRating"": 80,
              ""originalTitle"": ""Test Series"",
              ""backdropPath"": ""/backdrop.jpg"",
              ""backdropURLs"": {
                ""300"": ""https://image.tmdb.org/t/p/w300/backdrop.jpg"",
                ""780"": ""https://image.tmdb.org/t/p/w780/backdrop.jpg"",
                ""1280"": ""https://image.tmdb.org/t/p/w1280/backdrop.jpg"",
                ""original"": ""https://image.tmdb.org/t/p/original/backdrop.jpg""
              },
              ""genres"": [
                {
                  ""id"": 1,
                  ""name"": ""Genre 1""
                },
                {
                  ""id"": 2,
                  ""name"": ""Genre 2""
                }
              ],
              ""originalLanguage"": ""en"",
              ""countries"": [
                ""US""
              ],
              ""creators"": [
                ""Creator 1"",
                ""Creator 2""
              ],
              ""status"": {
                ""statusCode"": 1,
                ""statusText"": ""Ongoing""
              },
              ""seasonCount"": 3,
              ""episodeCount"": 30,
              ""episodeRuntimes"": [
                40,
                50
              ],
              ""youtubeTrailerVideoId"": ""abcdefghijklmnopqrstuvwxyz"",
              ""youtubeTrailerVideoLink"": ""https://www.youtube.com/watch?v=abcdefghijklmnopqrstuvwxyz"",
              ""posterPath"": ""/poster.jpg"",
              ""posterURLs"": {
                ""92"": ""https://image.tmdb.org/t/p/w92/poster.jpg"",
                ""154"": ""https://image.tmdb.org/t/p/w154/poster.jpg"",
                ""185"": ""https://image.tmdb.org/t/p/w185/poster.jpg"",
                ""342"": ""https://image.tmdb.org/t/p/w342/poster.jpg"",
                ""500"": ""https://image.tmdb.org/t/p/w500/poster.jpg"",
                ""780"": ""https://image.tmdb.org/t/p/w780/poster.jpg"",
                ""original"": ""https://image.tmdb.org/t/p/original/poster.jpg""
              },
              ""tagline"": ""Test series tagline"",
              ""seasons"": [
                {
                  ""type"": ""season"",
                  ""title"": ""Season 1"",
                  ""overview"": ""This is Season 1 ofthe test series."",
                  ""streamingInfo"": {
                    ""se"": {
                      ""netflix"": [
                        {
                          ""type"": ""subscription"",
                          ""quality"": ""HD"",
                          ""addOn"": """",
                          ""link"": ""https://www.netflix.com/title/00000001/"",
                          ""watchLink"": """",
                          ""audios"": [
                            ""English"",
                            ""Spanish""
                          ],
                          ""subtitles"": [
                            ""English"",
                            ""Spanish""
                          ],
                          ""price"": 9.99,
                          ""leaving"": 0,
                          ""availableSince"": 1666152000
                        }
                      ]
                    }
                  },
                  ""cast"": [
                    ""Actor A"",
                    ""Actor B"",
                    ""Actor C""
                  ],
                  ""firstAirYear"": 2022,
                  ""lastAirYear"": 2022,
                  ""youtubeTrailerVideoId"": ""abcdefghijklmnopqrstuvwxyz"",
                  ""youtubeTrailerVideoLink"": ""https://www.youtube.com/watch?v=abcdefghijklmnopqrstuvwxyz"",
                  ""posterPath"": ""/season1_poster.jpg"",
                  ""posterURLs"": {
                    ""92"": ""https://image.tmdb.org/t/p/w92/season1_poster.jpg"",
                    ""154"": ""https://image.tmdb.org/t/p/w154/season1_poster.jpg"",
                    ""185"": ""https://image.tmdb.org/t/p/w185/season1_poster.jpg"",
                    ""342"": ""https://image.tmdb.org/t/p/w342/season1_poster.jpg"",
                    ""500"": ""https://image.tmdb.org/t/p/w500/season1_poster.jpg"",
                    ""780"": ""https://image.tmdb.org/t/p/w780/season1_poster.jpg"",
                    ""original"": ""https://image.tmdb.org/t/p/original/season1_poster.jpg""
                  },
                  ""episodes"": [
                    {
                      ""type"": ""episode"",
                      ""title"": ""Episode 1"",
                      ""overview"": ""This is Episode 1 of Season 1."",
                      ""streamingInfo"": {
                        ""se"": {
                          ""netflix"": [
                            {
                              ""type"": ""subscription"",
                              ""quality"": ""HD"",
                              ""addOn"": """",
                              ""link"": ""https://www.netflix.com/watch/00000001"",
                              ""watchLink"": """",
                              ""audios"": [
                                ""English"",
                                ""Spanish""
                              ],
                              ""subtitles"": [
                                ""English"",
                                ""Spanish""
                              ],
                              ""price"": null,
                              ""leaving"": 0,
                              ""availableSince"": 1666152000
                            }
                          ]
                        }
                      },
                      ""cast"": [
                        ""Actor A"",
                        ""Actor B""
                      ],
                      ""year"": 2022,
                      ""directors"": [
                        ""Director 1""
                      ],
                      ""runtime"": 45,
                      ""stillPath"": ""/episode1_still.jpg"",
                      ""stillURLs"": {
                        ""92"": ""https://image.tmdb.org/t/p/w92/episode1_still.jpg"",
                        ""185"": ""https://image.tmdb.org/t/p/w185/episode1_still.jpg"",
                        ""300"": ""https://image.tmdb.org/t/p/w300/episode1_still.jpg"",
                        ""original"": ""https://image.tmdb.org/t/p/original/episode1_still.jpg""
                      },
                      ""imdbId"": ""tt0000001"",
                      ""imdbRating"": 80,
                      ""imdbVoteCount"": 0,
                      ""tmdbRating"": 75,
                      ""youtubeTrailerVideoId"": """",
                      ""youtubeTrailerVideoLink"": """"
                    },
                    {
                      ""type"": ""episode"",
                     ""title"": ""Episode 2"",
                      ""overview"": ""This is Episode 2 of Season 1."",
                      ""streamingInfo"": {
                        ""se"": {
                          ""netflix"": [
                            {
                              ""type"": ""subscription"",
                              ""quality"": ""HD"",
                              ""addOn"": """",
                              ""link"": ""https://www.netflix.com/watch/00000002"",
                              ""watchLink"": """",
                              ""audios"": [
                                ""English"",
                                ""Spanish""
                              ],
                              ""subtitles"": [
                                ""English"",
                                ""Spanish""
                              ],
                              ""price"": null,
                              ""leaving"": 0,
                              ""availableSince"": 1666152000
                            }
                          ]
                        }
                      },
                      ""cast"": [
                        ""Actor B"",
                        ""Actor C""
                      ],
                      ""year"": 2022,
                      ""directors"": [
                        ""Director 2""
                      ],
                      ""runtime"": 40,
                      ""stillPath"": ""/episode2_still.jpg"",
                      ""stillURLs"": {
                        ""92"": ""https://image.tmdb.org/t/p/w92/episode2_still.jpg"",
                        ""185"": ""https://image.tmdb.org/t/p/w185/episode2_still.jpg"",
                        ""300"": ""https://image.tmdb.org/t/p/w300/episode2_still.jpg"",
                        ""original"": ""https://image.tmdb.org/t/p/original/episode2_still.jpg""
                      },
                      ""imdbId"": ""tt0000002"",
                      ""imdbRating"": 70,
                      ""imdbVoteCount"": 0,
                      ""tmdbRating"": 65,
                      ""youtubeTrailerVideoId"": """",
                      ""youtubeTrailerVideoLink"": """"
                    }
                  ]
                },
                {
                  ""type"": ""season"",
                  ""title"": ""Season 2"",
                  ""overview"": ""This is Season 2 of the test series."",
                  ""streamingInfo"": {
                    ""se"": {
                      ""netflix"": [
                        {
                          ""type"": ""subscription"",
                          ""quality"": ""HD"",
                          ""addOn"": """",
                          ""link"": ""https://www.netflix.com/title/00000002/"",
                          ""watchLink"": """",
                          ""audios"": [
                            ""English"",
                            ""Spanish""
                          ],
                          ""subtitles"": [
                            ""English"",
                            ""Spanish""
                          ],
                          ""price"": 9.99,
                          ""leaving"": 0,
                          ""availableSince"": 1666152000
                        }
                      ]
                    }
                  },
                  ""cast"": [
                    ""Actor A"",
                    ""Actor B"",
                    ""Actor C""
                  ],
                  ""firstAirYear"": 2023,
                  ""lastAirYear"": 2023,
                  ""youtubeTrailerVideoId"": ""abcdefghijklmnopqrstuvwxyz"",
                  ""youtubeTrailerVideoLink"": ""https://www.youtube.com/watch?v=abcdefghijklmnopqrstuvwxyz"",
                  ""posterPath"": ""/season2_poster.jpg"",
                  ""posterURLs"": {
                    ""92"": ""https://image.tmdb.org/t/p/w92/season2_poster.jpg"",
                    ""154"": ""https://image.tmdb.org/t/p/w154/season2_poster.jpg"",
                    ""185"": ""https://image.tmdb.org/t/p/w185/season2_poster.jpg"",
                    ""342"": ""https://image.tmdb.org/t/p/w342/season2_poster.jpg"",
                    ""500"": ""https://image.tmdb.org/t/p/w500/season2_poster.jpg"",
                    ""780"": ""https://image.tmdb.org/t/p/w780/season2_poster.jpg"",
                    ""original"": ""https://image.tmdb.org/t/p/original/season2_poster.jpg""
                  },
                  ""episodes"": [
                    {
                      ""type"": ""episode"",
                      ""title"": ""Episode 1"",
                      ""overview"": ""This is Episode 1 of Season 2."",
                      ""streamingInfo"": {
                        ""se"": {
                          ""netflix"": [
                            {
                              ""type"": ""subscription"",
                              ""quality"": ""HD"",
                              ""addOn"": """",
                              ""link"": ""https://www.netflix.com/watch/00000003"",
                              ""watchLink"": """",
                              ""audios"": [
                                ""English"",
                                ""Spanish""
                              ],
                              ""subtitles"": [
                                ""English"",
                                ""Spanish""
                              ],
                              ""price"": null,
                              ""leaving"": 0,
                              ""availableSince"": 1666152000
                            }
                          ]
                        }
                      },
                      ""cast"": [
                        ""Actor A"",
                        ""Actor C""
                      ],
                      ""year"": 2023,
                      ""directors"": [
                        ""Director 1""
                      ],
                      ""runtime"": 50,
                      ""stillPath"": ""/episode1_still.jpg"",
                      ""stillURLs"": {
                        ""92"": ""https://image.tmdb.org/t/p/w92/episode1_still.jpg"",
                        ""185"": ""https://image.tmdb.org/t/p/w185/episode1_still.jpg"",
                        ""300"": ""https://image.tmdb.org/t/p/w300/episode1_still.jpg"",
                        ""original"": ""https://image.tmdb.org/t/p/original/episode1_still.jpg""
                      },
                      ""imdbId"": ""tt0000003"",
                      ""imdbRating"": 75,
                      ""imdbVoteCount"": 0,
                      ""tmdbRating"": 70,
                      ""youtubeTrailerVideoId"": """",
                      ""youtubeTrailerVideoLink"": """"
                    },
                    {
                      ""type"": ""episode"",
                      ""title"": ""Episode 2"",
                      ""overview"": ""This is Episode 2 of Season 2."",
                      ""streamingInfo"": {
                        ""se"": {
                          ""netflix"": [
                            {
                              ""type"": ""subscription"",
                              ""quality"": ""HD"",
                              ""addOn"": """",
                              ""link"": ""https://www.netflix.com/watch/00000004"",
                              ""watchLink"": """",
                              ""audios"": [
                                ""English"",
                                ""Spanish""
                              ],
                              ""subtitles"": [
                                ""English"",
                                ""Spanish""
                              ],
                              ""price"": null,
                              ""leaving"": 0,
                              ""availableSince"": 1666152000
                            }
                          ]
                        }
                      },
                      ""cast"": [
                        ""Actor B"",
                        ""Actor C""
                      ],
                      ""year"": 2023,
                      ""directors"": [
                        ""Director 2""
                      ],
                      ""runtime"": 45,
                      ""stillPath"": ""/episode2_still.jpg"",
                      ""stillURLs"": {
                        ""92"": ""https://image.tmdb.org/t/p/w92/episode2_still.jpg"",
                        ""185"": ""https://image.tmdb.org/t/p/w185/episode2_still.jpg"",
                        ""300"": ""https://image.tmdb.org/t/p/w300/episode2_still.jpg"",
                        ""original"": ""https://image.tmdb.org/t/p/original/episode2_still.jpg""
                      },
                      ""imdbId"": ""tt0000004"",
                      ""imdbRating"": 80,
                      ""imdbVoteCount"": 0,
                      ""tmdbRating"": 75,
                      ""youtubeTrailerVideoId"": """",
                      ""youtubeTrailerVideoLink"": """"
                    }
                  ]
                }
              ]
            }
            ");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void ProcessSeries_WithValidData_ProcessesCorrectly()
        {
            var client = new Client("");
            // Act
            //client.ProcessSeriesData(SeriesData);

            // Assert streamingInfo
            var streamingInfo = SeriesData["streamingInfo"]["se"]["netflix"][0];
            Assert.AreEqual("subscription", (string)streamingInfo["type"]);
            Assert.AreEqual("HD", (string)streamingInfo["quality"]);
            Assert.AreEqual("", (string)streamingInfo["addOn"]);
            Assert.AreEqual("https://www.netflix.com/title/00000000/", (string)streamingInfo["link"]);
            Assert.IsNull(streamingInfo["watchLink"]);
            Assert.IsNull(streamingInfo["audios"]);
            Assert.IsNull(streamingInfo["subtitles"]);
            Assert.IsNull(streamingInfo["price"]);
            Assert.AreEqual(0, (int)streamingInfo["leaving"]);
            Assert.AreEqual(1650105382, (int)streamingInfo["availableSince"]);

            // Assert cast
            var cast = SeriesData["cast"].ToObject<string[]>();
            Assert.AreEqual(4, cast.Length);
            Assert.Contains("Actor 1", cast);
            Assert.Contains("Actor 2", cast);
            Assert.Contains("Actor 3", cast);
            Assert.Contains("Actor 4", cast);

            // Assert firstAirYear and lastAirYear
            Assert.AreEqual(2022, (int)SeriesData["firstAirYear"]);
            Assert.AreEqual(2023, (int)SeriesData["lastAirYear"]);

            // Assert imdbId, imdbRating, and imdbVoteCount
            Assert.AreEqual("tt0000000", (string)SeriesData["imdbId"]);
            Assert.AreEqual(75, (int)SeriesData["imdbRating"]);
            Assert.AreEqual(1234, (int)SeriesData["imdbVoteCount"]);

            // Assert tmdbId and tmdbRating
            Assert.AreEqual(12345, (int)SeriesData["tmdbId"]);
            Assert.AreEqual(80, (int)SeriesData["tmdbRating"]);

            // Assert originalTitle
            Assert.AreEqual("Test Series", (string)SeriesData["originalTitle"]);

            // Assert backdropPath and backdropURLs
            Assert.AreEqual("/backdrop.jpg", (string)SeriesData["backdropPath"]);
            var backdropURLs = SeriesData["backdropURLs"].ToObject<JObject>();
            Assert.AreEqual("https://image.tmdb.org/t/p/w300/backdrop.jpg", (string)backdropURLs["300"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w780/backdrop.jpg", (string)backdropURLs["780"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w1280/backdrop.jpg", (string)backdropURLs["1280"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/original/backdrop.jpg", (string)backdropURLs["original"]);

            // Assert genres
            var genres = SeriesData["genres"].ToObject<JArray>();
            Assert.AreEqual(2, genres.Count);
            var genre1 = genres[0].ToObject<JObject>();
            Assert.AreEqual(1, (int)genre1["id"]);
            Assert.AreEqual("Genre 1", (string)genre1["name"]);
            var genre2 = genres[1].ToObject<JObject>();
            Assert.AreEqual(2, (int)genre2["id"]);
            Assert.AreEqual("Genre 2", (string)genre2["name"]);

            // Assert originalLanguage
            Assert.AreEqual("en", (string)SeriesData["originalLanguage"]);

            // Assert countries
            var countries = SeriesData["countries"].ToObject<string[]>();
            Assert.AreEqual(1, countries.Length);
            Assert.AreEqual("US", countries[0]);

            // Assert creators
            var creators = SeriesData["creators"].ToObject<string[]>();
            Assert.AreEqual(2, creators.Length);
            Assert.Contains("Creator 1", creators);
            Assert.Contains("Creator 2", creators);

            // Assert status
            var status = SeriesData["status"].ToObject<JObject>();
            Assert.AreEqual(1, (int)status["statusCode"]);
            Assert.AreEqual("Ongoing", (string)status["statusText"]);

            // Assert seasonCount and episodeCount
            Assert.AreEqual(3, (int)SeriesData["seasonCount"]);
            Assert.AreEqual(30, (int)SeriesData["episodeCount"]);

            // Assert episodeRuntimes
            var episodeRuntimes = SeriesData["episodeRuntimes"].ToObject<int[]>();
            Assert.AreEqual(2, episodeRuntimes.Length);
            Assert.AreEqual(40, episodeRuntimes[0]);
            Assert.AreEqual(50, episodeRuntimes[1]);

            // Assert youtubeTrailerVideoId and youtubeTrailerVideoLink
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", (string)SeriesData["youtubeTrailerVideoId"]);
            Assert.AreEqual("https://www.youtube.com/watch?v=abcdefghijklmnopqrstuvwxyz", (string)SeriesData["youtubeTrailerVideoLink"]);

            // Assert posterPath and posterURLs
            Assert.AreEqual("/poster.jpg", (string)SeriesData["posterPath"]);
            var posterURLs = SeriesData["posterURLs"].ToObject<JObject>();
            Assert.AreEqual("https://image.tmdb.org/t/p/w92/poster.jpg", (string)posterURLs["92"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w154/poster.jpg", (string)posterURLs["154"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w185/poster.jpg", (string)posterURLs["185"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w342/poster.jpg", (string)posterURLs["342"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w500/poster.jpg", (string)posterURLs["500"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w780/poster.jpg", (string)posterURLs["780"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/original/poster.jpg", (string)posterURLs["original"]);

            // Assert tagline
            Assert.AreEqual("Test series tagline", (string)SeriesData["tagline"]);

            // Assert seasons
            var seasons = SeriesData["seasons"].ToObject<JArray>();
            Assert.AreEqual(2, seasons.Count);

            var season1 = seasons[0].ToObject<JObject>();
            Assert.AreEqual("season", (string)season1["type"]);
            Assert.AreEqual("Season 1", (string)season1["title"]);
            Assert.AreEqual("This is Season 1 of the test series.", (string)season1["overview"]);

            var season1StreamingInfo = season1["streamingInfo"]["se"]["netflix"][0];
            Assert.AreEqual("subscription", (string)season1StreamingInfo["type"]);
            Assert.AreEqual("HD", (string)season1StreamingInfo["quality"]);
            Assert.AreEqual("", (string)season1StreamingInfo["addOn"]);
            Assert.AreEqual("https://www.netflix.com/title/00000001/", (string)season1StreamingInfo["link"]);
            Assert.IsNull(season1StreamingInfo["watchLink"]);
            Assert.AreEqual(2, season1StreamingInfo["audios"].ToObject<string[]>().Length);
            Assert.Contains("English", season1StreamingInfo["audios"].ToObject<string[]>());
            Assert.Contains("Spanish", season1StreamingInfo["audios"].ToObject<string[]>());
            Assert.AreEqual(2, season1StreamingInfo["subtitles"].ToObject<string[]>().Length);
            Assert.Contains("English", season1StreamingInfo["subtitles"].ToObject<string[]>());
            Assert.Contains("Spanish", season1StreamingInfo["subtitles"].ToObject<string[]>());
            Assert.AreEqual(null, season1StreamingInfo["price"]);
            Assert.AreEqual(0, (int)season1StreamingInfo["leaving"]);
            Assert.AreEqual(1666152000, (int)season1StreamingInfo["availableSince"]);

            var season1Cast = season1["cast"].ToObject<string[]>();
            Assert.AreEqual(3, season1Cast.Length);
            Assert.Contains("Actor A", season1Cast);
            Assert.Contains("Actor B", season1Cast);
            Assert.Contains("Actor C", season1Cast);

            Assert.AreEqual(2022, (int)season1["firstAirYear"]);
            Assert.AreEqual(2022, (int)season1["lastAirYear"]);
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", (string)season1["youtubeTrailerVideoId"]);
            Assert.AreEqual("https://www.youtube.com/watch?v=abcdefghijklmnopqrstuvwxyz", (string)season1["youtubeTrailerVideoLink"]);
            Assert.AreEqual("/season1_poster.jpg", (string)season1["posterPath"]);

            var season1PosterURLs = season1["posterURLs"].ToObject<JObject>();
            Assert.AreEqual("https://image.tmdb.org/t/p/w92/season1_poster.jpg", (string)season1PosterURLs["92"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w154/season1_poster.jpg", (string)season1PosterURLs["154"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w185/season1_poster.jpg", (string)season1PosterURLs["185"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w342/season1_poster.jpg", (string)season1PosterURLs["342"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w500/season1_poster.jpg", (string)season1PosterURLs["500"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w780/season1_poster.jpg", (string)season1PosterURLs["780"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/original/season1_poster.jpg", (string)season1PosterURLs["original"]);

            var season1Episode1 = season1["episodes"][0].ToObject<JObject>();
            Assert.AreEqual("episode", (string)season1Episode1["type"]);
            Assert.AreEqual("Episode 1", (string)season1Episode1["title"]);
            Assert.AreEqual("This is Episode 1 of Season 1.", (string)season1Episode1["overview"]);

            var season1Episode1StreamingInfo = season1Episode1["streamingInfo"]["se"]["netflix"][0];
            Assert.AreEqual("subscription", (string)season1Episode1StreamingInfo["type"]);
            Assert.AreEqual("HD", (string)season1Episode1StreamingInfo["quality"]);
            Assert.AreEqual("", (string)season1Episode1StreamingInfo["addOn"]);
            Assert.AreEqual("https://www.netflix.com/watch/00000001", (string)season1Episode1StreamingInfo["link"]);
            Assert.IsNull(season1Episode1StreamingInfo["watchLink"]);
            Assert.AreEqual(2, season1Episode1StreamingInfo["audios"].ToObject<string[]>().Length);
            Assert.Contains("English", season1Episode1StreamingInfo["audios"].ToObject<string[]>());
            Assert.Contains("Spanish", season1Episode1StreamingInfo["audios"].ToObject<string[]>());
            Assert.AreEqual(2, season1Episode1StreamingInfo["subtitles"].ToObject<string[]>().Length);
            Assert.Contains("English", season1Episode1StreamingInfo["subtitles"].ToObject<string[]>());
            Assert.Contains("Spanish", season1Episode1StreamingInfo["subtitles"].ToObject<string[]>());
            Assert.IsNull(season1Episode1StreamingInfo["price"]);
            Assert.AreEqual(0, (int)season1Episode1StreamingInfo["leaving"]);
            Assert.AreEqual(1666152000, (int)season1Episode1StreamingInfo["availableSince"]);

            var season1Episode1Cast = season1Episode1["cast"].ToObject<string[]>();
            Assert.AreEqual(2, season1Episode1Cast.Length);
            Assert.Contains("Actor A", season1Episode1Cast);
            Assert.Contains("Actor B", season1Episode1Cast);

            Assert.AreEqual(2022, (int)season1Episode1["year"]);

            var season1Episode1Directors = season1Episode1["directors"].ToObject<string[]>();
            Assert.AreEqual(1, season1Episode1Directors.Length);
            Assert.Contains("Director 1", season1Episode1Directors);

            Assert.AreEqual(45, (int)season1Episode1["runtime"]);
            Assert.AreEqual("/episode1_still.jpg", (string)season1Episode1["stillPath"]);

            var season1Episode1StillURLs = season1Episode1["stillURLs"].ToObject<JObject>();
            Assert.AreEqual("https://image.tmdb.org/t/p/w92/episode1_still.jpg", (string)season1Episode1StillURLs["92"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w185/episode1_still.jpg", (string)season1Episode1StillURLs["185"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w300/episode1_still.jpg", (string)season1Episode1StillURLs["300"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/original/episode1_still.jpg", (string)season1Episode1StillURLs["original"]);

            Assert.AreEqual("tt0000001", (string)season1Episode1["imdbId"]);
            Assert.AreEqual(80, (int)season1Episode1["imdbRating"]);
            Assert.AreEqual(0, (int)season1Episode1["imdbVoteCount"]);
            Assert.AreEqual(75, (int)season1Episode1["tmdbRating"]);
            Assert.AreEqual("", (string)season1Episode1["youtubeTrailerVideoId"]);
            Assert.AreEqual("", (string)season1Episode1["youtubeTrailerVideoLink"]);

            var season1Episode2 = season1["episodes"][1].ToObject<JObject>();
            Assert.AreEqual("episode", (string)season1Episode2["type"]);
            Assert.AreEqual("Episode 2", (string)season1Episode2["title"]);
            Assert.AreEqual("This is Episode 2 of Season 1.", (string)season1Episode2["overview"]);

            var season1Episode2StreamingInfo = season1Episode2["streamingInfo"]["se"]["netflix"][0];
            Assert.AreEqual("subscription", (string)season1Episode2StreamingInfo["type"]);
            Assert.AreEqual("HD", (string)season1Episode2StreamingInfo["quality"]);
            Assert.AreEqual("", (string)season1Episode2StreamingInfo["addOn"]);
            Assert.AreEqual("https://www.netflix.com/watch/00000002", (string)season1Episode2StreamingInfo["link"]);
            Assert.IsNull(season1Episode2StreamingInfo["watchLink"]);
            Assert.AreEqual(2, season1Episode2StreamingInfo["audios"].ToObject<string[]>().Length);
            Assert.Contains("English", season1Episode2StreamingInfo["audios"].ToObject<string[]>());
            Assert.Contains("Spanish", season1Episode2StreamingInfo["audios"].ToObject<string[]>());
            Assert.AreEqual(2, season1Episode2StreamingInfo["subtitles"].ToObject<string[]>().Length);
            Assert.Contains("English", season1Episode2StreamingInfo["subtitles"].ToObject<string[]>());
            Assert.Contains("Spanish", season1Episode2StreamingInfo["subtitles"].ToObject<string[]>());
            Assert.IsNull(season1Episode2StreamingInfo["price"]);
            Assert.AreEqual(0, (int)season1Episode2StreamingInfo["leaving"]);
            Assert.AreEqual(1666152000, (int)season1Episode2StreamingInfo["availableSince"]);

            var season1Episode2Cast = season1Episode2["cast"].ToObject<string[]>();
            Assert.AreEqual(2, season1Episode2Cast.Length);
            Assert.Contains("Actor B", season1Episode2Cast);
            Assert.Contains("Actor C", season1Episode2Cast);

            Assert.AreEqual(2022, (int)season1Episode2["year"]);

            var season1Episode2Directors = season1Episode2["directors"].ToObject<string[]>();
            Assert.AreEqual(1, season1Episode2Directors.Length);
            Assert.Contains("Director 2", season1Episode2Directors);

            Assert.AreEqual(40, (int)season1Episode2["runtime"]);
            Assert.AreEqual("/episode2_still.jpg", (string)season1Episode2["stillPath"]);

            var season1Episode2StillURLs = season1Episode2["stillURLs"].ToObject<JObject>();
            Assert.AreEqual("https://image.tmdb.org/t/p/w92/episode2_still.jpg", (string)season1Episode2StillURLs["92"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w185/episode2_still.jpg", (string)season1Episode2StillURLs["185"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/w300/episode2_still.jpg", (string)season1Episode2StillURLs["300"]);
            Assert.AreEqual("https://image.tmdb.org/t/p/original/episode2_still.jpg", (string)season1Episode2StillURLs["original"]);

            Assert.AreEqual("tt0000002", (string)season1Episode2["imdbId"]);
            Assert.AreEqual(70, (int)season1Episode2["imdbRating"]);
            Assert.AreEqual(0, (int)season1Episode2["imdbVoteCount"]);
            Assert.AreEqual(65, (int)season1Episode2["tmdbRating"]);
            Assert.AreEqual("", (string)season1Episode2["youtubeTrailerVideoId"]);
            Assert.AreEqual("", (string)season1Episode2["youtubeTrailerVideoLink"]);

            var season2 = seasons[1].ToObject<JObject>();
            Assert.AreEqual("season", (string)season2["type"]);
            Assert.AreEqual("Season 2", (string)season2["title"]);
            Assert.AreEqual("This isSeason 2 of the test series.", (string)season2["overview"]);

            var season2StreamingInfo = season2["streamingInfo"]["se"]["netflix"][0];
            Assert.AreEqual("subscription", (string)season2StreamingInfo["type"]);
            Assert.AreEqual("HD", (string)season2StreamingInfo["quality"]);
            Assert.AreEqual("", (string)season2StreamingInfo["addOn"]);
            Assert.AreEqual("https://...", (string)season2StreamingInfo["link"]);
            Assert.IsNull(season2StreamingInfo["watchLink"]);
            Assert.IsNull(season2StreamingInfo["audios"]);
            Assert.IsNull(season2StreamingInfo["subtitles"]);
            Assert.IsNull(season2StreamingInfo["price"]);
            Assert.AreEqual(0, (int)season2StreamingInfo["leaving"]);
            Assert.AreEqual(0, (int)season2StreamingInfo["availableSince"]);

            var season2Cast = season2["cast"].ToObject<string[]>();
            Assert.IsEmpty(season2Cast);

            Assert.AreEqual(0, (int)season2["firstAirYear"]);
            Assert.AreEqual(0, (int)season2["lastAirYear"]);
            Assert.IsNull(season2["youtubeTrailerVideoId"]);
            Assert.IsNull(season2["youtubeTrailerVideoLink"]);
            Assert.IsNull(season2["posterPath"]);

            var season2PosterURLs = season2["posterURLs"].ToObject<JObject>();
            Assert.IsEmpty(season2PosterURLs);

            var season2Episodes = season2["episodes"].ToObject<JArray>();
            Assert.IsEmpty(season2Episodes);
        }
    }
}