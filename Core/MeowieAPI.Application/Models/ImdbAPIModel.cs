using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MeowieAPI.Application.Models
{


    public static class ImdbAPIModel
    {
        public static string jsonText = File.ReadAllText("imdb.json");
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Actor
    {
        public string name { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
        public string url { get; set; }
    }

    public class AggregateRating
    {
        public string bestRating { get; set; }
        public int ratingCount { get; set; }
        public double ratingValue { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
        public string worstRating { get; set; }
    }

    public class Creator
    {
        [JsonProperty("@type")]
        public string type { get; set; }
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Director
    {
        [JsonProperty("@type")]
        public string type { get; set; }
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Root
    {
        public List<Actor> actor { get; set; }
        public AggregateRating aggregateRating { get; set; }
        public string contentRating { get; set; }

        [JsonProperty("@context")]
        public string context { get; set; }
        public List<Creator> creator { get; set; }
        public string datePublished { get; set; }
        public string description { get; set; }
        public List<Director> director { get; set; }
        public string duration { get; set; }
        public List<string> genre { get; set; }
        public string image { get; set; }
        public string keywords { get; set; }
        public string name { get; set; }
        public Trailer trailer { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Thumbnail
    {
        public string contentUrl { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
    }

    public class Trailer
    {
        public string description { get; set; }
        public string embedUrl { get; set; }
        public string name { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string thumbnailUrl { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
        public DateTime uploadDate { get; set; }
    }


}
