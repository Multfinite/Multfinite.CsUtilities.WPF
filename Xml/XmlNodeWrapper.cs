using System.Collections.ObjectModel;
using System.Xml;

namespace Multfinite.Utilities.WPF.Xml
{
	public class XmlNodeWrapper : ContextBase
	{
		public readonly XmlNode _item;
		public XmlNode Item => _item;

		public readonly int _level;
		public int Level => _level;

		public int MaxLevel;

		public XmlNodeWrapper(XmlNode item, int level = 0, int maxLevel = int.MaxValue)
		{
			_item = item;
			_level = level;
			MaxLevel = maxLevel;

			Rebuild();
		}

		public string Name
		{
			get => _item.Name;
		}

		public string Value
		{
			get => _item.Value;
			set
			{
				_item.Value = value;
				RaisePropertyChanged();
			}
		}

		private readonly ObservableCollection<XmlNodeWrapper> _chlids = new ObservableCollection<XmlNodeWrapper>();
		public ObservableCollection<XmlNodeWrapper> Chlids
		{
			get => _chlids;
		}

		public void Rebuild()
		{
			_chlids.Clear();
			if (_level > MaxLevel)
				return;
			_chlids.AddRange(_item.ChildNodes.GetEnumerator().ToList<XmlNode>().ConvertAll((x) => new XmlNodeWrapper(x, _level + 1, MaxLevel)));
		}

		public override string ToString() => $"{_item.Name} [{_level}] = {_item.Value}";
	}
}
