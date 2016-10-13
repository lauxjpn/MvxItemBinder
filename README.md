# MvxItemBinder
Item binding support with fluent API in MvvmCross for MvxRecyclerView

Using the support classes and extension methods of this repository, you can bind items as in the following code:

  var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.RecyclerView);

  var set = this.CreateBindingSet<MainActivity, MainViewModel>();
  set.Bind(recyclerView)
      .For(v => v.ItemsSource)
      .To(vm => vm.Items);
  set.Apply();

  recyclerView.BindItems<ItemViewModel>(this, (itemView, itemSet) =>
      itemSet.Bind(itemView.FindViewById<TextView>(Resource.Id.item_template))
          .For(v => v.Text)
          .To(vm => vm.Title)
  );

Or event shorter:

	var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.RecyclerView);

	var set = this.CreateBindingSet<MainActivity, MainViewModel>();
	set.Bind(recyclerView.BindItems<ItemViewModel>(this, (itemView, itemSet) =>
			itemSet.Bind(itemView.FindViewById<TextView>(Resource.Id.item_template))
				.For(v => v.Text)
				.To(vm => vm.Title)))
		.For(v => v.ItemsSource)
		.To(vm => vm.Items);
	set.Apply();
