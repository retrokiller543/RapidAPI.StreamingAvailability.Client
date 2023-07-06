using RapidAPI.StreamingAvailability.Client;
using RapidAPI.StreamingAvailability.Client.Models;

namespace TestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string apiKey = Environment.GetEnvironmentVariable("APIKEY");
            Client client = new Client(apiKey);
            var movies = client.SearchByTitle("lucifer", "se", "all", "en");
            foreach (var item in movies)
            {
                if (item == null) continue;
                if (item is Series series)
                {
                    // Access properties specific to the Series class
                    Console.WriteLine(series.Seasons);
                }
                else if (item is Movie movie)
                {
                    // Access properties specific to the Movies class
                    Console.WriteLine(movie.Type);
                }
            }
        }
    }
}