using System.Windows;
using System.Windows.Controls;

namespace DSD_01.view
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {

        public MainWindow mainWindow;

        public Home()
        {
            InitializeComponent();
        }

        public Home(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            Losses.Content = "Losses: " + RussianRoulette.Losses;
            Wins.Content = "Wins: " + RussianRoulette.Wins;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            _ = mainWindow.MainFrame.Navigate(new PreGame(mainWindow, new RussianRoulette()));
        }
    }
}
