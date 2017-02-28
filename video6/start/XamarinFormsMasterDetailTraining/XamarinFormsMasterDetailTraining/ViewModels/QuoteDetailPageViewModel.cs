using System.Diagnostics;

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

		public override void OnNavigatingTo(NavigationParameters parameters)
		{
			if (parameters != null && parameters.ContainsKey("id"))
			{
				int id = -1;
				var didParse = int.TryParse(parameters["id"].ToString(), out id);
				if (didParse && id > -1)
				{
					Debug.WriteLine($"AuthorId that came in is {id}");
				}
			}
		}
	}
}
