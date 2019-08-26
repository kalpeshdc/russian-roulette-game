using System.Windows;
using System.Windows.Controls;

namespace RussianRoulette.Pages
{
    /// <summary>
    /// Interaction logic for StartUpPage.xaml
    /// </summary>
    public partial class StartUpPage : Page
    {
        private readonly Frame driverFrame;
        private readonly GamePlay gamePlay;

        public StartUpPage(Frame driverFrame)
        {
            InitializeComponent();
            this.driverFrame = driverFrame;
            gamePlay = new GamePlay();
            LossScore.Text = GamePlay.TotalLosses.ToString();
            WinScore.Text = GamePlay.TotalWins.ToString();
        }

        private void SpinButton_Click(object sender, RoutedEventArgs e)
        {
            gamePlay.SpinGun();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            gamePlay.LoadGun();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (gamePlay.IsGunReady())
            {
                driverFrame.Navigate(new GamePlayPage(driverFrame, gamePlay));
            }
        }
    }
}
