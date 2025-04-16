namespace AppNumerosDaSorte
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Current Page
            return new Window(new MainPage());
        }
    }
}