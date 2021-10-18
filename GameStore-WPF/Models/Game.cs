using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace GameStore_WPF.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Game
    {
        [JsonProperty]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public float Price { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Modes { get; set; }
        [JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy")]
        public DateTime ReleaseDate { get; set; }
        public List<string> Developers { get; set; }
        public List<string> Publishers { get; set; }
        public int AvailableCopies { get; set; }
        public string Description { get; set; }
        // private Image Image { get; set; }
        public Game(){ }

        public Game(string name, string platform, float price)
        {
            this.Name = name;
            this.Platform = platform;
            this.Price = price;
        }

        public Game(int id, string name, string platform, float price, List<string> genres, List<string> modes, DateTime releaseDate, List<string> developers, List<string> publishers, int availableCopies, string description, Image image)
        {
            this.Id = id;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Platform = platform ?? throw new ArgumentNullException(nameof(platform));
            this.Price = price;
            this.Genres = genres ?? throw new ArgumentNullException(nameof(genres));
            this.Modes = modes ?? throw new ArgumentNullException(nameof(modes));
            this.ReleaseDate = releaseDate;
            this.Developers = developers ?? throw new ArgumentNullException(nameof(developers));
            this.Publishers = publishers ?? throw new ArgumentNullException(nameof(publishers));
            this.AvailableCopies = availableCopies;
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
        //    this.Image = image ?? throw new ArgumentNullException(nameof(image));
        }
    }
}
