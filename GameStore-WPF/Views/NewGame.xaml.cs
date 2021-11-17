using GameStore_WPF.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
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
            if(ofd.ShowDialog() == true)
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

        private void Add_Game_ButtonClick(object sender, RoutedEventArgs e)
        {
             ComboBoxItem platform = (ComboBoxItem)Platform_ComboBox.SelectedItem;
            string pick = platform.Content.ToString();



              game.Name = Name_textBox.Text;
              game.Price = double.Parse(Price_textBox.Text);
              game.Genres = Delimiter(Genres_textBox.Text);
              game.Modes = Delimiter(Modes_textBox.Text);
              game.Developers = Delimiter(Developers_textBox.Text);
              game.Platform = pick;
              game.Publishers = Delimiter(Publishers_textBox.Text);
              game.ReleaseDate = ReleaseDate_DatePicker.ToString();
              game.AvailableCopies = int.Parse(AvailableCopies_textBox.Text);
              game.Description = Description_textBox.Text;
              game.ImageUrl = Cover_Image.Source.ToString().Substring(43);
            
            

            MessageBox.Show(game.ToString());
        }
    }
}
