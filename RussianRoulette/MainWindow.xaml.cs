using System.Windows;
using RussianRoulette.Pages;

namespace RussianRoulette
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _ = DriverFrame.Navigate(new StartUpPage(DriverFrame));
        }
    }
}
