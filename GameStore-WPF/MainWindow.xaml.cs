using GameStore_WPF.Controllers;
using GameStore_WPF.Models;
using GameStore_WPF.Services;
using GameStore_WPF.Views;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameStore_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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
            
        public MainWindow()
        {
            
            InitializeComponent();

            // Run console window for testing purposes
            ConsoleAllocator.ShowConsoleWindow();

            games = _service.Get();
            games_LV.ItemsSource = games.ToList();

            foreach(var game in games)
            {
                Console.WriteLine(game.ToString());
            }
        }

        private void AddButtonEvent_Click(object sender, RoutedEventArgs e)
        {
            NewGame newGame = new NewGame();
            newGame.Show();
        }

        private void ListViewItem_Click(object sender, RoutedEventArgs e)
        {
            var data = games_LV.SelectedItems
                .Cast<Game>()
                .ToList();

            var source = (List<Game>)games_LV.ItemsSource;
            //     var pick = source.ElementAtOrDefault(itemId)._id;

            string mockId = "1";

            DetailsWindow detailsWindow = new DetailsWindow(mockId);
            detailsWindow.Show();
        }
    }
}
