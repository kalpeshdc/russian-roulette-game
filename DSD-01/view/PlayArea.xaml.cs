using System.Windows;

namespace DSD_01.view
{
    /// <summary>
    /// Interaction logic for PlayArea.xaml
    /// </summary>
    public partial class PlayArea
    {
        private readonly RussianRoulette russianRoulette;
        private readonly MainWindow mainWindow;

        public PlayArea()
        {
            InitializeComponent();
        }

        public PlayArea(MainWindow mainWindow, RussianRoulette russianRoulette)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.russianRoulette = russianRoulette;
            this.russianRoulette.PlayArea = this;
            this.russianRoulette.UpdateShotsLabel();
        }

        private void AwayFire_Click(object sender, RoutedEventArgs e)
        {
            if (russianRoulette.FireShot(true))
            {
                _ = mainWindow.MainFrame.Navigate(new Home(mainWindow));
            }
        }

        private void HeadFire_Click(object sender, RoutedEventArgs e)
        {
            if (russianRoulette.FireShot(false))
            {
                _ = mainWindow.MainFrame.Navigate(new Home(mainWindow));
            }
        }
    }
}
