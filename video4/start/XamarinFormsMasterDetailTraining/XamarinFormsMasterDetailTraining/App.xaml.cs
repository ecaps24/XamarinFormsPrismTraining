using Prism.Unity;
using Xamarin.Forms;
using XamarinFormsMasterDetailTraining.ViewModels;
using XamarinFormsMasterDetailTraining.Views;

namespace XamarinFormsMasterDetailTraining
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected async override void OnInitialized()
		{
			InitializeComponent();

			if (Device.Idiom == TargetIdiom.Desktop
			   || Device.Idiom == TargetIdiom.Tablet)
			{
				await NavigationService.NavigateAsync("MasterDetailPageView/BaseNavigationPageView/DetailPageView");
			}
			else 
			{
				//assume it's phone and navigate clean
				await NavigationService.NavigateAsync("BaseNavigationPageView/MasterPageView"); 
			}
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MasterDetailPageView, MasterDetailPageViewModel>();
			Container.RegisterTypeForNavigation<MasterPageView, MasterPageViewModel>();
			Container.RegisterTypeForNavigation<DetailPageView, DetailPageViewModel>();
			Container.RegisterTypeForNavigation<BaseNavigationPageView, BaseNavigationPageViewModel>();
		}
	}
}

