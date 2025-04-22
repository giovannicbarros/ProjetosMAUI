namespace AppNavigationPage;

public partial class Page02 : ContentPage
{
	public Page02()
	{
		InitializeComponent();
	}

    private void OnButtonNextClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Page03());
    }

    private void OnButtonPreviousClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}