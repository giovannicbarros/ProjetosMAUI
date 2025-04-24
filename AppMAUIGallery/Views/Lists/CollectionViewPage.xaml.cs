using AppMAUIGallery.Views.Lists.Models;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Text;

namespace AppMAUIGallery.Views.Lists;

public partial class CollectionViewPage : ContentPage
{
	ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
	int countMovies = 0;
	public CollectionViewPage()
	{
		InitializeComponent();

		AddTenMovies();
		CollectionViewControl.ItemsSource = MovieList.GetGroupList();

        scrollTimer = new System.Timers.Timer(ScrollTimeout);
        scrollTimer.Elapsed += OnScrollTimerElapsed;
        scrollTimer.AutoReset = false;

        // Assumindo que seu CollectionView est� nomeado como "collectionView"
        CollectionViewControl.Scrolled += CollectionView_Scrolled;
    }

    private async void RefreshView_Refreshing(object sender, EventArgs e)
	{
		((RefreshView)sender).IsRefreshing = true;

		await Task.Delay(3000);
		CollectionViewControl.ItemsSource = MovieList.GetList();

        ((RefreshView)sender).IsRefreshing = false;
    }

    private void CollectionViewControl_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
		AddTenMovies();
    }

	private void AddTenMovies()
	{
		for(int i = 0; i < 20; i++)
		{
			Movie movie = new Movie
			{
				Id = countMovies++,
				Name = $"Movie {countMovies}",
				Description = $"Description {countMovies}",
				LaunchYear = 2022,
				Duration = new TimeSpan(2, 0, 0)
			};
			movies.Add(movie);
		}

	}

    private void CollectionViewControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		StringBuilder sb = new StringBuilder();
		foreach(Movie movie in e.CurrentSelection)
		{
			sb.Append(movie.Name + " - ");
        }
		LblSelectedMovies.Text = sb.ToString();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		var group = (List<GroupMovie>)CollectionViewControl.ItemsSource;
		var item = group[2][0];

        CollectionViewControl.ScrollTo(item, position: ScrollToPosition.Start);
        //CollectionViewControl.ScrollTo(4, position: ScrollToPosition.Start);
    }

    private System.Timers.Timer scrollTimer;
    private bool isScrolling = false;
    private const int ScrollTimeout = 500;
    private void CollectionViewControl_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
		//LblScrollStatus.Text = $"Posicionamento: {e.VerticalOffset} - Espa�amento: {e.VerticalDelta}";
    }
    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        if (!isScrolling)
        {
            isScrolling = true;
            OnScrollStarted();
        }

        // Reinicia o temporizador toda vez que o evento `Scrolled` � acionado
        scrollTimer.Stop();
        scrollTimer.Start();
    }
    private void OnScrollTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Device.BeginInvokeOnMainThread(() =>
        {
            isScrolling = false;
            OnScrollEnded();
        });
    }
    private void OnScrollStarted()
    {
        // C�digo a ser executado no in�cio da rolagem
        Console.WriteLine("Scroll iniciado");
        LblScrollStatus.Text = "Scroll iniciado";
    }

    private void OnScrollEnded()
    {
        // C�digo a ser executado no fim da rolagem
        Console.WriteLine("Scroll terminado");
        LblScrollStatus.Text = "Scroll terminado";
    }
}