using GameStore_WPF.Contexts;
using GameStore_WPF.Controllers;
using GameStore_WPF.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
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
        public IMongoCollection<BsonDocument> gamesCollection { get; set; }

        public MainWindow()
        {
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

            gamesCollection = db.GetCollection<BsonDocument>("gamesCollection");
        }

    }
}
