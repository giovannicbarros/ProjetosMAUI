using AppJogoForca.Libraries.Text;
using AppJogoForca.Models;
using AppJogoForca.Repositories;

namespace AppJogoForca
{
    public partial class MainPage : ContentPage
    {

        private Word _word;
        private int _errors;

        public MainPage()
        {
            InitializeComponent();
            ResetScreen();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            string letter = ((Button)sender).Text;

            var positions = _word.Text.GetPositions(letter);

            if (positions.Count == 0)
            {
                _errors++;
                ImgForca.Source = ImageSource.FromFile($"forca{_errors + 1}.png");

                if (_errors == 6)
                {
                    await DisplayAlert("Perdeu!", "Você foi enforcado, quer começar um novo jogo?", "Novo Jogo");
                    ResetScreen();
                }

                return;
            }

            foreach (var position in positions) { 
                lblText.Text = lblText.Text.Remove(position, 1).Insert(position, letter);
            }
        }

        private void ResetScreen()
        {
            ResetVirtualKeyBoard();
            ResetErrors();
            GenerateNewWord();
        }

        private void GenerateNewWord()
        {
            var repository = new WordRepositories();
            _word = repository.GetRandleWord();

            lblTips.Text = _word.Tips;
            lblText.Text = new string('_', _word.Text.Length);
        }

        private void ResetErrors()
        {
            _errors = 0;
            ImgForca.Source = ImageSource.FromFile("forca1.png");
        }

        private void ResetVirtualKeyBoard()
        {
            ResetVirtualLines((HorizontalStackLayout)KeyboardContainer.Children[0]);
            ResetVirtualLines((HorizontalStackLayout)KeyboardContainer.Children[1]);
            ResetVirtualLines((HorizontalStackLayout)KeyboardContainer.Children[2]);
        }

        private void ResetVirtualLines(HorizontalStackLayout horizontal)
        {
            foreach (Button button in horizontal.Children) { 
                button.IsEnabled = true;
            }
        }
    }

}
