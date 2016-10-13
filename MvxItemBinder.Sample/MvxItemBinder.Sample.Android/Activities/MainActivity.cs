using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvxItemBinder.Sample.Core.ViewModels;

namespace MvxItemBinder.Sample.Android.Activities
{
	[Activity(Label = "MvxItemBinder.Sample.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : MvxAppCompatActivity<MainViewModel>
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.activity_main);

			var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.RecyclerView);

			var set = this.CreateBindingSet<MainActivity, MainViewModel>();
			set.Bind(recyclerView.BindItems<ItemViewModel>(this, (itemView, itemSet) => itemSet
					.Bind(itemView.FindViewById<TextView>(Resource.Id.item_template))
					.For(v => v.Text)
					.To(vm => vm.Title)))
				.For(v => v.ItemsSource)
				.To(vm => vm.Items);
			set.Apply();
		}
	}
}