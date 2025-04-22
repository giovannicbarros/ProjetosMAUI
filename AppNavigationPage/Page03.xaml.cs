namespace AppNavigationPage;

public partial class Page03 : ContentPage
{
	public Page03()
	{
		InitializeComponent();
	}

    private void OnButtonPreviousClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}