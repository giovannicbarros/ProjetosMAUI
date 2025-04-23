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
            Button button = (Button)sender;
            button.IsEnabled = false;
            string letter = button.Text;

            var positions = _word.Text.GetPositions(letter);

            if (positions.Count == 0)
            {
                ErrorHandler(button);
                await IsGameOver();

                return;
            }

            ReplaceLetter(letter, positions);
            button.Style = (Style)App.Current.Resources.MergedDictionaries.ElementAt(1)["Success"];

            HasWinner();
        }

        private void ReplaceLetter(string letter, List<int> positions)
        {
            foreach (var position in positions)
            {
                lblText.Text = lblText.Text.Remove(position, 1).Insert(position, letter);
            }
        }

        private void ErrorHandler(Button button)
        {
            _errors++;
            ImgForca.Source = ImageSource.FromFile($"forca{_errors + 1}.png");
            button.Style = (Style)App.Current.Resources.MergedDictionaries.ElementAt(1)["Fail"];
        }

        #region Verify if game finish
        private async Task HasWinner()
        {
            if (!lblText.Text.Contains("_"))
            {
                await DisplayAlert("Parabéns!", "Você ganhou o jogo!", "Novo Jogo");
                ResetScreen();
            }
        }

        private async Task IsGameOver()
        {
            if (_errors == 6)
            {
                await DisplayAlert("Perdeu!", "Você foi enforcado.", "Novo Jogo");
                ResetScreen();
            }
        }
        #endregion

        #region Reset Screen
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
                button.Style = null;
            }
        }

        #endregion

        private void OnButtonClickedResetGame(System.Object sender, System.EventArgs e)
        {
            ResetScreen();
        }
    }

}
