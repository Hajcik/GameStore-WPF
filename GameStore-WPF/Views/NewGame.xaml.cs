using GameStore_WPF.Models;
using GameStore_WPF.Services;
using Microsoft.Win32;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameStore_WPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {

        private static string connectionStringClient = "mongodb+srv://Hajcik:hajcik@cluster0.ilqki.mongodb.net/GamesDb?retryWrites=true&w=majority";
        private static string gamesCollectionString = "gamesCollection";
        private static string databaseString = "GamesDb";

        private static IMongoDatabase db;
        private static IMongoClient client;

        public GameService _service =
            new GameService(connectionStringClient, databaseString, gamesCollectionString, db, client);


        public Game game = new Game();
        public NewGame()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            ci.DateTimeFormat.LongDatePattern = "dd-MM-yyyy";
            ci.DateTimeFormat.ShortTimePattern = "";
            ci.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = ci;

            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Accept Integer positive numbers only
            Regex reg = new Regex("[^0-9]+");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void DoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Accept Floating point positive numbers only
            Regex reg = new Regex("");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void PickImage_ButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                Uri fileUri = new Uri(ofd.FileName);
                Cover_Image.Source = new BitmapImage(fileUri);
            }
        }

        private List<string> Delimiter(string phrase)
        {
            // Delimit strings to put them in List<string> in Game model
            string[] words = phrase.Split(',');
            List<string> list = new List<string>(words);
            return list;
        }

        private bool IsAnyFieldNullOrEmpty(object game)
        {
            foreach(var field in game.GetType().GetProperties())
            {
                if(field.PropertyType == typeof(string))
                {
                    string value = (string)field.GetValue(game);
                    if(string.IsNullOrEmpty(value))
                        return true;
                }
                if(field.PropertyType == typeof(double))
                {
                    double value = (double)field.GetValue(game);
                    if (double.IsNaN(value))
                        return true;
                }
                if (field.PropertyType == typeof(List<string>))
                {
                    List<string> values = (List<string>)field.GetValue(game);
                    foreach(string fd in values)
                    {
                        if (string.IsNullOrEmpty(fd))
                            return true;
                    }
                }
            }
            return false;
        }

        private BsonDocument SerializingDoc(Game game)
        {
            string jsonString = JsonSerializer.Serialize<Game>(game);
            return MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(jsonString);
        }


        private void Add_Game_ButtonClick(object sender, RoutedEventArgs e)
        {
            ComboBoxItem platform = (ComboBoxItem)Platform_ComboBox.SelectedItem;

            if (string.IsNullOrEmpty(Name_textBox.Text) ||
                string.IsNullOrEmpty(Price_textBox.Text) ||
                string.IsNullOrEmpty(Genres_textBox.Text) ||
                string.IsNullOrEmpty(Modes_textBox.Text) ||
                string.IsNullOrEmpty(Developers_textBox.Text) ||
                string.IsNullOrEmpty(platform.Content.ToString()) ||
                string.IsNullOrEmpty(Publishers_textBox.Text) ||
                string.IsNullOrEmpty(ReleaseDate_DatePicker.ToString()) ||
                string.IsNullOrEmpty(AvailableCopies_textBox.Text) ||
                string.IsNullOrEmpty(Description_textBox.Text))
            {
                MessageBox.Show("Incorrect data, fix any issues and try again!");
            }
            else
            {
                game.Name = Name_textBox.Text;
                game.Price = double.Parse(Price_textBox.Text);
                game.Genres = Delimiter(Genres_textBox.Text);
                game.Modes = Delimiter(Modes_textBox.Text);
                game.Developers = Delimiter(Developers_textBox.Text);
                game.Platform = platform.Content.ToString();
                game.Publishers = Delimiter(Publishers_textBox.Text);
                game.ReleaseDate = ReleaseDate_DatePicker.ToString();
                game.AvailableCopies = int.Parse(AvailableCopies_textBox.Text);
                game.Description = Description_textBox.Text;
                try
                {
                    game.ImageUrl = Cover_Image.Source.ToString().Substring(43);
                } 
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }

                MessageBox.Show($"Data correct, new game:\n\n{game.ToString()}");
                BsonDocument bsonDoc = SerializingDoc(game);
                try
                {
                    _service.Create(game);
                    MessageBox.Show(bsonDoc.ToString());
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
                
            }
        }
    }
}
