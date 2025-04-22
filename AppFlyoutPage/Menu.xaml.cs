namespace AppFlyoutPage;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

    private void OnClickedPage01(object sender, EventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new Page01());
    }

    private void OnClickedPage02(object sender, EventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new Page02();
    }

    private void onClickedPage03(object sender, EventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new Page03();
    }
}