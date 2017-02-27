using Prism.Navigation;
using Xamarin.Forms;

namespace XamarinFormsMasterDetailTraining.Views
{
	public partial class BaseNavigationPageView 
		: NavigationPage, INavigationPageOptions 
	{
		public bool ClearNavigationStackOnNavigation
		{
			get { return true; }
		}

		public BaseNavigationPageView()
		{
			InitializeComponent();
		}
	}
}

