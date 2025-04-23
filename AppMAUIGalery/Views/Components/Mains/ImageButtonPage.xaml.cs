namespace AppMAUIGallery.Views.Components.Mains;

public partial class ImageButtonPage : ContentPage
{
	bool buttonState = false;
	public ImageButtonPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		buttonState = !buttonState;
		var poweroff = "poweroff.png";
        var poweron = "poweron.png";

		lblTitulo.Text = (buttonState == false) ? "Ligado" : "Desligado";
        btnClick.Source = (buttonState == false) ? ImageSource.FromFile(poweron) : ImageSource.FromFile(poweroff);
    }
}