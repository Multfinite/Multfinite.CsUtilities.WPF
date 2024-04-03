using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace Multfinite.Utilities.WPF
{
	public abstract class ContextBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		public Dispatcher Dispatcher { get; } = Dispatcher.CurrentDispatcher;

		public void InvokeByDispatcher(Delegate del, DispatcherPriority priority = DispatcherPriority.Normal) => Dispatcher.Invoke(priority, del);
		public T InvokeByDispatcher<T>(Delegate del, DispatcherPriority priority = DispatcherPriority.Normal) => (T)Dispatcher.Invoke(priority, del);
	}
}