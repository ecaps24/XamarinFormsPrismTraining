using System;
using System.Diagnostics;
using System.Collections.ObjectModel;

using Prism.Commands;
using Prism.Navigation;
using Prism.Events;

using Xamarin.Forms;

using XamarinFormsMasterDetailTraining.Model;
using XamarinFormsMasterDetailTraining.Repository;
using XamarinFormsMasterDetailTraining.Messages;
using XamarinFormsMasterDetailTraining.Events;

namespace XamarinFormsMasterDetailTraining.ViewModels
{
	public class QuoteMasterPageViewModel : BaseViewModel
	{
		private readonly QuotesRepository _quotesRepository;
		private readonly IEventAggregator _eventAggregator;

		private ObservableCollection<Quote> _randomQuotes;
		public ObservableCollection<Quote> RandomQuotes
		{
			get { return _randomQuotes; }
			set { SetProperty(ref _randomQuotes, value); }
		}

		public DelegateCommand<Quote> ItemClicked { get; set; }

		public QuoteMasterPageViewModel(
			INavigationService navigationService,
			IEventAggregator eventAggregator,
			QuotesRepository quotesRepository
		)
			:base(navigationService)
		{
			_quotesRepository = quotesRepository;
			_eventAggregator = eventAggregator;

			Title = "Quotes";

			ItemClicked = new DelegateCommand<Quote>(DoQuoteClicked);
			GetRandomQuotes();
		}

		private async void DoQuoteClicked(Quote quote)
		{
			if (Device.Idiom == TargetIdiom.Phone)
			{
				var parameter = new NavigationParameters($"id={quote.AuthorValue.Id}");
				await _navigationService.NavigateAsync("QuoteDetailPageView", parameter);
			}
			else
			{
				var message = new AuthorQuoteNavigationMessage { AuthorId = quote.AuthorValue.Id };
				_eventAggregator.GetEvent<AuthorQuoteNavigationEvent>().Publish(message);
			}
		}

		private void GetRandomQuotes()
		{
			RandomQuotes = new ObservableCollection<Quote>(_quotesRepository.GetRandomQuotes());
		}
	}
}
