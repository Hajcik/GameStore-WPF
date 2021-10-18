using GameStore_WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameStore_WPF.Controllers
{
    public class MainController
    {
        public List<Game> GamesList { get; set; }

        public MainController() { }
        public MainController(List<Game> _games)
        {
            this.GamesList = _games;
        }

        public void GET_GAMES_Data(string fileUrl)
        {
            using (StreamReader file = File.OpenText(fileUrl))
            {
                JsonSerializer serializer = new JsonSerializer();
                GamesList = (List<Game>) serializer.Deserialize(file, typeof(List<Game>));
            }
        }

        public List<Game> SET_GAMES_Data(string fileUrl)
        {
            GET_GAMES_Data(fileUrl);
            return GamesList;
        }
    }
}
