using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp5
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Elipses = new ObservableCollection<ElipseControl>();

            Elipses.Add(new ElipseControl() { ElipseName = "One" });
            Elipses.Add(new ElipseControl() { ElipseName = "Two" });
        }

        private ObservableCollection<ElipseControl> _elipses;
        public ObservableCollection<ElipseControl> Elipses
        {
            get => _elipses;
            set => SetProperty(ref _elipses, value);
        }

        private ICommand _elipseSelectedCommand;
        public ICommand ElipseSelectedCommand => _elipseSelectedCommand ??= new RelayCommand(p => ElipseSelected(p));
        private void ElipseSelected(object args)
        {
            if (args != null && args is RoutedEventArgs e && e.OriginalSource != null && e.OriginalSource is ElipseControl elipseControl)
            {
                System.Diagnostics.Debug.WriteLine($"Hit View Model: {elipseControl.ElipseName}");
            }
        }
    }
}
