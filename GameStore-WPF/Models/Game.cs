using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace GameStore_WPF.Models
{
    [Serializable]
    public class Game
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("Name"), BsonRepresentation(BsonType.String)]
        public string Name { get; set; }
        [BsonElement("Platform"), BsonRepresentation(BsonType.String)]
        public string Platform { get; set; }

        [BsonElement("Price"), BsonRepresentation(BsonType.Double)]
        public double Price { get; set; }

        [BsonElement("Genres")]
        public List<string> Genres { get; set; }

        [BsonElement("Modes")]
        public List<string> Modes { get; set; }

        [BsonElement("ReleaseDate"), BsonRepresentation(BsonType.String)]
        public string ReleaseDate { get; set; }

        [BsonElement("Developers")]

        public List<string> Developers { get; set; }
        [BsonElement("Publishers")]
        public List<string> Publishers { get; set; }

        [BsonElement("AvailableCopies"), BsonRepresentation(BsonType.Int32)]
        public int AvailableCopies { get; set; }

        [BsonElement("Description"), BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonElement("ImageUrl"), BsonRepresentation(BsonType.String)]
        public string ImageUrl { get; set; }
        public Game() { }

        public Game(string name, string platform, float price)
        {
            this.Name = name;
            this.Platform = platform;
            this.Price = price;
        }

        // Release Date change format to DateTime, currently
        // left as string to test application

        public Game(string id, string name, string platform, double price, List<string> genres, List<string> modes, string releaseDate, List<string> developers, List<string> publishers, int availableCopies, string description, string imageUrl)
        {
            _id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Platform = platform ?? throw new ArgumentNullException(nameof(platform));
            Price = price;
            Genres = genres ?? throw new ArgumentNullException(nameof(genres));
            Modes = modes ?? throw new ArgumentNullException(nameof(modes));
            ReleaseDate = releaseDate;
            Developers = developers ?? throw new ArgumentNullException(nameof(developers));
            Publishers = publishers ?? throw new ArgumentNullException(nameof(publishers));
            AvailableCopies = availableCopies;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ImageUrl = imageUrl ?? throw new ArgumentNullException(nameof(imageUrl));
        }
    }
}