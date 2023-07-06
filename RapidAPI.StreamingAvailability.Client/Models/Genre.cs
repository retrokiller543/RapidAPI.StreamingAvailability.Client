namespace RapidAPI.StreamingAvailability.Client.Models
{
    public class Genre
    {
        public string Name { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
