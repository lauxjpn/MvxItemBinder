using System;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MvxItemBinder
{
	public class MvxPlugableViewHolderRecyclerAdapter : MvxRecyclerAdapter
	{
		private readonly Func<View, IMvxAndroidBindingContext, RecyclerView.ViewHolder> _viewHolderFactory;

		public MvxPlugableViewHolderRecyclerAdapter(IMvxAndroidBindingContext bindingContext,
			Func<View, IMvxAndroidBindingContext, RecyclerView.ViewHolder> viewHolderFactory)
			: base(bindingContext)
		{
			if (viewHolderFactory == null)
				throw new ArgumentNullException(nameof(viewHolderFactory));

			_viewHolderFactory = viewHolderFactory;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
			var view = InflateViewForHolder(parent, viewType, itemBindingContext);

			return _viewHolderFactory(view, itemBindingContext);
		}
	}
}