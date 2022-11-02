using System.Windows;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;
        }

        private void Window_Select(object sender, RoutedEventArgs e)
        {
            if (e != null && e.Source != null && e.Source is ElipseControl elipseControl)
            {
                System.Diagnostics.Debug.WriteLine($"Hit Code Behind: {elipseControl.ElipseName}");
            }
        }
    }
}
