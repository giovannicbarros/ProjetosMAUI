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
}