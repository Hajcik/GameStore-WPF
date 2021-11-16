using GameStore_WPF.Controllers;
using GameStore_WPF.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
        

        public IMongoCollection<Game> gamesCollection { get; set; }

        public MainWindow()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;

            InitializeComponent();

            // Run console window for testing purposes
            ConsoleAllocator.ShowConsoleWindow();
            InitializeMongoDb();

            


            gamesCollection.Find(new BsonDocument()).ForEachAsync(x => Console.WriteLine(x));
        }

        public void InitializeMongoDb()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("GamesDb");

            gamesCollection = db.GetCollection<Game>("gamesCollection");
        }

        // CRUD
        // Put them in controller / services later
        public List<Game> Get() =>
            gamesCollection.Find(game => true).ToList();

        public Game Get(string id) =>
            gamesCollection.Find<Game>(game => game._id == id).FirstOrDefault();

        public Game Create(Game game)
        {
            gamesCollection.InsertOne(game);
            return game;
        }

        public void Update(string id, Game gameUpdate) =>
            gamesCollection.ReplaceOne(game => game._id == id, gameUpdate);

        public void Remove(Game gameDel) =>
            gamesCollection.DeleteOne(game => game._id == gameDel._id);

        public void Remove(string id) =>
            gamesCollection.DeleteOne(game => game._id == id);


        // Temporary button logic for testing

        Button add_btn = new Button();

        private void AddButtonEvent_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(Get("61929582c0669196a09accf0").Name);
            Console.WriteLine(Get("61929582c0669196a09accf0").Name);
        }




    }
}
