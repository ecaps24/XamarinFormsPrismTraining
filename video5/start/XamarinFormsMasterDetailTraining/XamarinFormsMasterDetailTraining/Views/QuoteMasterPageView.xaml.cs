using System;
using System.Diagnostics;

using Xamarin.Forms;

namespace XamarinFormsMasterDetailTraining.Views
{
	public partial class QuoteMasterPageView : ContentPage
	{
		public QuoteMasterPageView()
		{
			try
			{
				InitializeComponent();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"{ex.Message} - {ex.StackTrace}");
			}
		}
	}
}

