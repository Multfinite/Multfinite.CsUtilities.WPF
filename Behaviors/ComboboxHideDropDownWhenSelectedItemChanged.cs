using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;

namespace Multfinite.Utilities.WPF.Behaviors
{
	public class ComboboxHideDropDownWhenSelectedItemChanged : Behavior<ComboBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            
            this.AssociatedObject.SelectionChanged += AssociatedObjectOnSelectionChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.SelectionChanged -= AssociatedObjectOnSelectionChanged;
        }


        private void AssociatedObjectOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            AssociatedObject.IsDropDownOpen = false;
        }
    }
}