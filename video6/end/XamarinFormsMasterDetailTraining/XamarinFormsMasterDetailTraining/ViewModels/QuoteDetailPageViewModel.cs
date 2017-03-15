using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

using Prism.Navigation;

using XamarinFormsMasterDetailTraining.Repository;
using XamarinFormsMasterDetailTraining.Model;
using Xamarin.Forms;

namespace XamarinFormsMasterDetailTraining.ViewModels
{
	public class QuoteDetailPageViewModel : BaseViewModel
	{
		private readonly QuotesRepository _quotesRepository;

		private Author _selectedAuthor;
		public Author SelectedAuthor
		{
			get { return _selectedAuthor; }
			set { SetProperty(ref _selectedAuthor, value); }
		}

		private ObservableCollection<Quote> _authorQuotes;
		public ObservableCollection<Quote> AuthorQuotes
		{
			get { return _authorQuotes; }
			set { SetProperty(ref _authorQuotes, value); }
		}


		public QuoteDetailPageViewModel(INavigationService navigationService,
		                                QuotesRepository quotesRepository
		                               )
			: base(navigationService)
		{
			_quotesRepository = quotesRepository;

			Title = "Author Quotes";
		}

		public override void OnNavigatingTo(NavigationParameters parameters)
		{
			if (parameters != null && parameters.ContainsKey("id"))
			{
				int id = -1;
				var didParse = int.TryParse(parameters["id"].ToString(), out id);
				if (didParse && id > -1)
				{
					LoadAuthorQuotes(id);
				}
			}
		}

		private void LoadAuthorQuotes(int authorId)
		{
			SelectedAuthor = _quotesRepository.GetAuthorById(authorId);
			if (SelectedAuthor != null)
			{
				if (Device.Idiom == TargetIdiom.Tablet ||
					Device.Idiom == TargetIdiom.Desktop)
				{
					Title = $"{SelectedAuthor.FullName} Quotes";
				}

				AuthorQuotes = new ObservableCollection<Quote>(_quotesRepository.GetQuotesByAuthor(authorId));
			}
		}
	}
}
