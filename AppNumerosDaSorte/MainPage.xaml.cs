namespace AppNumerosDaSorte;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnGenerateLuckNumbers(object sender, EventArgs e)
	{
		NameApp.IsVisible = false;
		ContainerLuckNumbers.IsVisible = true;

		var set = GenerateNumbers();
		NumberLuck01.Text = set.ElementAt(0).ToString("D2");
        NumberLuck02.Text = set.ElementAt(1).ToString("D2");
        NumberLuck03.Text = set.ElementAt(2).ToString("D2");
        NumberLuck04.Text = set.ElementAt(3).ToString("D2");
        NumberLuck05.Text = set.ElementAt(4).ToString("D2");
        NumberLuck06.Text = set.ElementAt(5).ToString("D2");
    }

    private SortedSet<int> GenerateNumbers()
	{
		var set = new SortedSet<int>();
		while (set.Count < 6)
		{
            var random = new Random();
            var luckNumber = random.Next(1, 60);

			set.Add(luckNumber);
        }

		return set;
    }

}