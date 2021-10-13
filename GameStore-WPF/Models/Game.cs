using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore_WPF.Models
{
    public class Game
    {
        public int Id { get; set; }
        private string Name { get; set; }
        private string Platform { get; set; }
        private float Price { get; set; }
        private List<string> Genres { get; set; }
        private List<string> Modes { get; set; }
        private DateTime ReleaseDate { get; set; }
        private List<string> Developers { get; set; }
        private List<string> Publishers { get; set; }
        public int AvailableCopies { get; set; }
        private string Description { get; set; }

        public Game(){ }

        public Game(string name, string platform, float price)
        {
            this.Name = name;
            this.Platform = platform;
            this.Price = price;
        }

        public Game(int id, string name, string platform, float price, List<string> genres, List<string> modes, DateTime releaseDate, List<string> developers, List<string> publishers, int availableCopies, string description)
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
        }
    }
}
