using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace LunchChartWebAPI.Models
{
    public class Menu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Day { get; set; } = null!;

        [BsonElement("ItemName")]
        [JsonPropertyName("ItemName")]
        public string ItemName { get; set; } = null!;

        public string Dessert { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
