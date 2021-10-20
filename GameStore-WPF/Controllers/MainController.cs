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
            
        }

        public List<Game> SET_GAMES_Data(string fileUrl)
        {
            GET_GAMES_Data(fileUrl);
            return GamesList;
        }
    }
}
