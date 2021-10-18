using GameStore_WPF.Controllers;
using GameStore_WPF.Models;
using System;
using System.Collections.Generic;
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
        public MainController _controller { get; set; }
        private List<Game> Games { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Run console window for testing purposes
            ConsoleAllocator.ShowConsoleWindow();

            _controller = new MainController(Games);
            Games = _controller.SET_GAMES_Data("D:\\Git\\GameStore-WPF\\GameStore-WPF\\Resources\\Data\\games.json");

            Console.WriteLine(Games.Count);
        }
    }
}
