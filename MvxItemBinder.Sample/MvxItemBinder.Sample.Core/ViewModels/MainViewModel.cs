using System.Collections.Generic;
using System.Linq;
using MvvmCross.Core.ViewModels;

namespace MvxItemBinder.Sample.Core.ViewModels
{
	public class MainViewModel : MvxViewModel
	{
		private IEnumerable<ItemViewModel> _items;

		public IEnumerable<ItemViewModel> Items
		{
			get { return _items; }
			set { SetProperty(ref _items, value); }
		}

		public override void Start()
		{
			_items = Enumerable.Range(0, 26)
				.Select(i => new ItemViewModel("Item " + (char) ('A' + i)))
				.ToArray();

			base.Start();
		}
	}
}