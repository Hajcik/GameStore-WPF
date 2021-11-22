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
    /// Logika interakcji dla klasy DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
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

        private static Game game = new Game();

        public DetailsWindow(string id)
        {
            InitializeComponent();

           game = _service.Get(id);
           Console.WriteLine(game.Name);
        }

        // function to edit values based on values inside textfields
        // There are no fields to have a possible edit functionality
        private void EditValues_Button(object sender, RoutedEventArgs e)
        {




            /*
            Console.WriteLine(itemId);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show($"REMOVE SELECTED GAME?");
                          _service.Remove(source.ElementAt(itemId)._id);
                    MessageBox.Show("REMOVED");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        */
        }
    }
}
