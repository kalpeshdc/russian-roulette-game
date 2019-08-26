using System.Windows;
using System.Windows.Controls;

namespace DSD_01.view
{
    /// <summary>
    /// Interaction logic for PreGame.xaml
    /// </summary>
    public partial class PreGame : Page
    {
        private readonly RussianRoulette russianRoulette;
        private readonly MainWindow mainWindow;

        public PreGame()
        {
            InitializeComponent();
        }

        public PreGame(MainWindow mainWindow, RussianRoulette russianRoulette)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.russianRoulette = russianRoulette;
        }

        private void LetsPlay_Click(object sender, RoutedEventArgs e)
        {
            if (russianRoulette.IsGunSpunAndLoaded())
            {
                mainWindow.MainFrame.Navigate(new PlayArea(mainWindow, russianRoulette));
            }
        }

        private void LoadGun_Click(object sender, RoutedEventArgs e)
        {
            russianRoulette.LoadGun();
        }

        private void Spin_Click(object sender, RoutedEventArgs e)
        {
            russianRoulette.SpinChamber();
        }
    }
}
