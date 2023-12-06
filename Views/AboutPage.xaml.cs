namespace CaicedoRamos_Examen2P.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://github.com/Alex-Caicedo-R384/CaicedoRamos_Examen2P.git");
    }
}