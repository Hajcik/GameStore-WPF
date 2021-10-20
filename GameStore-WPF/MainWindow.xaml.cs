using GameStore_WPF.Contexts;
using GameStore_WPF.Controllers;
using GameStore_WPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly GameContext _context = new GameContext();
        private CollectionViewSource gamesViewSource;

        public MainController _controller { get; set; }
        private List<Game> Games { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            // Run console window for testing purposes
            ConsoleAllocator.ShowConsoleWindow();

            gamesViewSource = (CollectionViewSource)FindResource(nameof(gamesViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Games.Load();
            gamesViewSource.Source = _context.Games.Local.ToObservableCollection();
        }


        // _context.SaveChanges(); after button click or smth
        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Dispose();
            base.OnClosing(e);
        }
    }
}
