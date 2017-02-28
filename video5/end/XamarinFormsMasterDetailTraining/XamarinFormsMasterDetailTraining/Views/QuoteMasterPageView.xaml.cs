using System;
using System.Diagnostics;

using Xamarin.Forms;
using XamarinFormsMasterDetailTraining.Model;
using XamarinFormsMasterDetailTraining.ViewModels;

namespace XamarinFormsMasterDetailTraining.Views
{
	public partial class QuoteMasterPageView : ContentPage
	{
		public QuoteMasterPageViewModel ViewModel
		{
			get { return BindingContext as QuoteMasterPageViewModel; }
		}

		public QuoteMasterPageView()
		{
			try
			{
				InitializeComponent();

				lvQuotes.ItemSelected += (o, e) =>
				{
					if (e.SelectedItem is Quote)
					{
						var quote = e.SelectedItem as Quote;
						ViewModel.ItemClicked.Execute(quote);
					}
						
				};
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"{ex.Message} - {ex.StackTrace}");
			}
		}
	}
}

