using System;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MvxItemBinder
{
	public static class MvxRecyclerViewExtensions
	{
		public static MvxRecyclerView BindItems<TItemViewModel>(this MvxRecyclerView source,
			IMvxBindingContextOwner bindingContextOwner,
			Action<View, MvxFluentBindingDescriptionSet<MvxItemBinderRecyclerViewHolder<TItemViewModel>, TItemViewModel>>
				itemBindingAction)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (bindingContextOwner == null)
				throw new ArgumentNullException(nameof(bindingContextOwner));

			return BindItems(source, bindingContextOwner.BindingContext, itemBindingAction);
		}

		public static MvxRecyclerView BindItems<TItemViewModel>(this MvxRecyclerView source, IMvxBindingContext bindingContext,
			Action<View, MvxFluentBindingDescriptionSet<MvxItemBinderRecyclerViewHolder<TItemViewModel>, TItemViewModel>>
				itemBindingAction)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (bindingContext == null)
				throw new ArgumentNullException(nameof(bindingContext));

			source.Adapter = new MvxPlugableViewHolderRecyclerAdapter((IMvxAndroidBindingContext) bindingContext,
				(view, context) => new MvxItemBinderRecyclerViewHolder<TItemViewModel>(view, context, itemBindingAction));

			return source;
		}
	}
}