using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvxItemBinder.Sample.Core.ViewModels;

namespace MvxItemBinder.Sample.Core
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MainViewModel>());
		}
	}
}