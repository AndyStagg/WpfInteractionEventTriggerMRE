using System.Windows.Input;

namespace WpfApp5
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ICommand _elipseSelectedCommand;
        public ICommand ElipseSelectedCommand => _elipseSelectedCommand ??= new RelayCommand(p => ElipseSelected());
        private void ElipseSelected()
        {
            System.Diagnostics.Debug.WriteLine("Hit View Model");
        }
    }
}
