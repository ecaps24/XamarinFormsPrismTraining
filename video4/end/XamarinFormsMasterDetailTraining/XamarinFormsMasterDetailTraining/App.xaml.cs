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
				await NavigationService.NavigateAsync("QuoteMasterDetailPageView/BaseNavigationPageView/QuoteDetailPageView");
			}
			else 
			{
				//assume it's phone and navigate clean
				await NavigationService.NavigateAsync("BaseNavigationPageView/QuoteMasterPageView"); 
			}
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<QuoteMasterDetailPageView, QuoteMasterDetailPageViewModel>();
			Container.RegisterTypeForNavigation<QuoteMasterPageView, QuoteMasterPageViewModel>();
			Container.RegisterTypeForNavigation<QuoteDetailPageView, QuoteDetailPageViewModel>();
			Container.RegisterTypeForNavigation<BaseNavigationPageView, BaseNavigationPageViewModel>();
		}
	}
}

