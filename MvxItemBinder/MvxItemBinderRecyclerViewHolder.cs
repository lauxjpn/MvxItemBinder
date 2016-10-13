using System;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MvxItemBinder
{
	public class MvxItemBinderRecyclerViewHolder<TItemViewModel> : MvxRecyclerViewHolder
	{
		public MvxItemBinderRecyclerViewHolder(View itemView, IMvxAndroidBindingContext context,
			Action<View, MvxFluentBindingDescriptionSet<MvxItemBinderRecyclerViewHolder<TItemViewModel>, TItemViewModel>>
				bindingAction)
			: base(itemView, context)
		{
			this.DelayBind(() =>
			{
				if (bindingAction == null)
					return;

				var set = this.CreateBindingSet<MvxItemBinderRecyclerViewHolder<TItemViewModel>, TItemViewModel>();
				bindingAction(itemView, set);
				set.Apply();
			});
		}
	}
}