using System;
using Prism.Events;
using Prism.Navigation;
using XamarinFormsMasterDetailTraining.Events;
using XamarinFormsMasterDetailTraining.Messages;

namespace XamarinFormsMasterDetailTraining.ViewModels
{
	public class QuoteMasterDetailPageViewModel : BaseViewModel
	{
		private readonly IEventAggregator _eventAggregator;

		public QuoteMasterDetailPageViewModel(
			INavigationService navigationService,
			IEventAggregator eventAggregator

		)
			: base(navigationService)
		{
			_eventAggregator = eventAggregator;

			SubscribeEvents();
		}

		private void SubscribeEvents()
		{
			_eventAggregator.GetEvent<AuthorQuoteNavigationEvent>().Subscribe(DoAuthorQuoteNavigation);
		}

		private async void DoAuthorQuoteNavigation(AuthorQuoteNavigationMessage message)
		{
			var parameter = new NavigationParameters($"id={message.AuthorId}");
			await _navigationService.NavigateAsync("BaseNavigationPageView/QuoteDetailPageView", parameter);	
		}
	}
}
