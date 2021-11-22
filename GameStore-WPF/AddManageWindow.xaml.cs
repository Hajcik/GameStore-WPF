using GameStore_WPF.Models;
using GameStore_WPF.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameStore_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy AddManageWindow.xaml
    /// </summary>
    public partial class AddManageWindow : Window
    {
        private static string connectionStringClient = "mongodb+srv://Hajcik:hajcik@cluster0.ilqki.mongodb.net/GamesDb?retryWrites=true&w=majority";
        private static string gamesCollectionString = "gamesCollection";
        private static string databaseString = "GamesDb";

        private static IMongoDatabase db;
        private static IMongoClient client;

        private static List<Game> games;

        public GameService _service =
            new GameService(connectionStringClient, databaseString,
                        gamesCollectionString, db, client);

        public AddManageWindow()
        {
            InitializeComponent();
        }
    }
}
