﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore_WPF.Models
{
    public class GameStoreDatabaseSettings : IGameStoreDatabaseSettings
    {
        public string GamesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IGameStoreDatabaseSettings
    {
        string GamesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
