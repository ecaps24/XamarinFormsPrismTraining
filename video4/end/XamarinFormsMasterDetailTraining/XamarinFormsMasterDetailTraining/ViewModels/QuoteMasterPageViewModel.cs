using System;
using Prism.Navigation;

namespace XamarinFormsMasterDetailTraining.ViewModels
{
	public class QuoteMasterPageViewModel : BaseViewModel
	{
		public QuoteMasterPageViewModel(INavigationService navigationService)
			:base(navigationService)
		{
			Title = "Quotes";
		}
	}
}
