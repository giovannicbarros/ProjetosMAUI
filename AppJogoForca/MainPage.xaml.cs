using AppJogoForca.Models;
using AppJogoForca.Repositories;

namespace AppJogoForca
{
    public partial class MainPage : ContentPage
    {

        private Word _word;

        public MainPage()
        {
            InitializeComponent();

            var repository = new WordRepositories();
            _word = repository.GetRandleWord();

            lblTips.Text = _word.Tips;
            lblText.Text = new string('_', _word.Text.Length);
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {

        }
       
    }

}
