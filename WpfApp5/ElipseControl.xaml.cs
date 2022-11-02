using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class ElipseControl : UserControl
    {
        public ElipseControl()
        {
            InitializeComponent();
        }

        #region Dependency Properties
        public static readonly DependencyProperty ElipseNameProperty =
            DependencyProperty.Register(
                "ElipseName",
                typeof(string),
                typeof(ElipseControl),
                new PropertyMetadata(null));

        public string ElipseName
        {
            get => (string)GetValue(ElipseNameProperty);
            set => SetValue(ElipseNameProperty, value);
        }
        #endregion

        #region Routed Events
        public static readonly RoutedEvent SelectEvent =
            EventManager.RegisterRoutedEvent(
                "Select",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(ElipseControl));

        public event RoutedEventHandler Select
        {
            add { AddHandler(SelectEvent, value); }
            remove { RemoveHandler(SelectEvent, value); }
        }

        protected virtual void RaiseSelectEvent()
        {
            var args = new RoutedEventArgs(SelectEvent);
            RaiseEvent(args);
        }
        #endregion

        #region Event Handlers
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RaiseSelectEvent();
        }
        #endregion
    }
}
