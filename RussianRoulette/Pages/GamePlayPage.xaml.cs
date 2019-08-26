using System.Windows;
using System.Windows.Controls;

namespace RussianRoulette.Pages
{
    /// <summary>
    /// Interaction logic for GamePlayPage.xaml
    /// </summary>
    public partial class GamePlayPage : Page
    {
        private Frame driverFrame;
        private GamePlay gamePlay;

        public GamePlayPage(Frame driverFrame, GamePlay gamePlay)
        {
            InitializeComponent();
            this.driverFrame = driverFrame;
            this.gamePlay = gamePlay;
            ShootInAir.IsChecked = true;
            ShootAtHead.IsChecked = false;
            FireInAirImg.Visibility = Visibility.Visible;
            ShotAtHeadImg.Visibility = Visibility.Hidden;
        }

        private void FireButton_Click(object sender, RoutedEventArgs e)
        {
            if (gamePlay.IsShotFired())
            {
                if (gamePlay.IsAway)
                {
                    GamePlay.Win();
                }
                else
                {
                    GamePlay.Loss();
                }
                driverFrame.Navigate(new StartUpPage(driverFrame));
            }
            else
            {
                if(gamePlay.FireInAirChoices == 0)
                {
                    GamePlay.Loss();
                    driverFrame.Navigate(new StartUpPage(driverFrame));
                }
            }
            AwayShots.Text = gamePlay.FireInAirChoices.ToString();
            ShotsRemaining.Text = gamePlay.TotalShotsInGame.ToString();
        }

        private void ShootInAir_Click(object sender, RoutedEventArgs e)
        {
            if (ShootInAir.IsChecked == true)
            {
                gamePlay.IsAway = true;
                ShootAtHead.IsChecked = false;
                FireInAirImg.Visibility = Visibility.Visible;
                ShotAtHeadImg.Visibility = Visibility.Hidden;
            }
        }

        private void ShootAtHead_Click(object sender, RoutedEventArgs e)
        {
            if(ShootAtHead.IsChecked == true)
            {
                gamePlay.IsAway = false;
                ShootInAir.IsChecked = false;
                FireInAirImg.Visibility = Visibility.Hidden;
                ShotAtHeadImg.Visibility = Visibility.Visible;
            }
        }
    }
}
