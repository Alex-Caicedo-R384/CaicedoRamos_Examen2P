namespace CaicedoRamos_Examen2P;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.NotePage), typeof(Views.NotePage));
    }
}
