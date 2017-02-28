using Prism.Navigation;

namespace XamarinFormsMasterDetailTraining.ViewModels
{
	public class QuoteDetailPageViewModel : BaseViewModel
	{
		public QuoteDetailPageViewModel(INavigationService navigationService)
			: base(navigationService)
		{
			Title = "Author Quotes";
		}
	}
}
