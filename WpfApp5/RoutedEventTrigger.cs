using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;

namespace WpfApp5
{
    public class RoutedEventTrigger : EventTriggerBase<DependencyObject>
    {
        public RoutedEvent RoutedEvent { get; set; }

        public RoutedEventTrigger()
        {

        }

        protected override void OnAttached()
        {
            var behavior = base.AssociatedObject as Behavior;
            var associatedElement = base.AssociatedObject as FrameworkElement;

            if (behavior != null)
            {
                associatedElement = ((IAttachedObject)behavior).AssociatedObject as FrameworkElement;
            }

            if (associatedElement == null)
            {
                throw new ArgumentException("Routed Event Trigger can only be associated to framework elements");
            }

            if (RoutedEvent != null)
            {
                associatedElement.AddHandler(RoutedEvent, new RoutedEventHandler(OnRoutedEvent));
            }
        }

        private void OnRoutedEvent(object sender, RoutedEventArgs e) => base.OnEvent(e);

        protected override string GetEventName() => RoutedEvent?.Name ?? string.Empty;
    }
}
