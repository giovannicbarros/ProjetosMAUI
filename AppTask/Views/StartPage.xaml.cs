namespace AppTask.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private void OnClicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new AddEditTaskPage());
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Entry_Search.Focus();
    }
}