using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Multfinite.Utilities.WPF.DataGrid
{
	public abstract class DataGridIndexedColumn : DataGridColumn
	{
		public static DependencyProperty IndexProperty = DependencyProperty.Register(nameof(Index), typeof(int), typeof(DataGridTemplateColumn));

		public int Index
		{
			get => (int)GetValue(IndexProperty);
			set => SetValue(IndexProperty, value);
		}

		public Binding CurrentDbRowBinding => new Binding($"Items[{Index}]");
		public abstract Binding CurrentDbRowNullableBinding { get; }

		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			Label label = new Label()
			{
				DataContext = dataItem
			};
			label.SetBinding(Label.ContentProperty, CurrentDbRowBinding);
			return label;
		}
	}
}
