# RapidAPI.StreamingAvailability.Client

This is a .NET client library for the Streaming Availability API provided by RapidAPI. It allows you to fetch and process data about movies and series, including details about streaming availability, cast, directors, genres, and more.

## Getting Started

To use this library, you need to have an API key from RapidAPI. You can get it by signing up on their website.

```csharp
var client = new RapidAPI.StreamingAvailability.Client.Client("your-api-key");
```

## Usage

### Get a list of movies and series

```csharp
// This will search for all movies and series with the title "The Matrix" in Sweden with the language set to English.
var shows = client.SearchByTitle("The Matrix", "se", "all", "en");

// If you search for both movies and series, you can filter out the series by checking the type of the object.
foreach (var item in shows)
{
    if (item == null) continue;
    if (item is Series series)
    {
        // Access properties specific to the Series class
    }
    else if (item is Movie movie)
    {
        // Access properties specific to the Movies class
    }
}
```

More api endpoints will be added in the future.

## Dependencies

This library uses the following packages:

- Newtonsoft.Json
- RestSharp

## License

This project is licensed under the MIT License.
