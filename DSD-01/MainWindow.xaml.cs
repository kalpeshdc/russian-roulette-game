using DSD_01.view;

namespace DSD_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            _ = MainFrame.Navigate(content: new Home(this));
        }
    }
}
