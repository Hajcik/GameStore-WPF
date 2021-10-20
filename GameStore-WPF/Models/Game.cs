using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace GameStore_WPF.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public float Price { get; set; }
        public string Genres { get; set; }
        public string Modes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
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

        public Game(int id, string name, string platform, float price, string genres, string modes, DateTime releaseDate, string developer, string publisher, int availableCopies, string description)
        {
            this.Id = id;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Platform = platform ?? throw new ArgumentNullException(nameof(platform));
            this.Price = price;
            this.Genres = genres ?? throw new ArgumentNullException(nameof(genres));
            this.Modes = modes ?? throw new ArgumentNullException(nameof(modes));
            this.ReleaseDate = releaseDate;
            this.Developer = developer ?? throw new ArgumentNullException(nameof(developer));
            this.Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            this.AvailableCopies = availableCopies;
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
