namespace C7_Exercises.View.Exerecise3;

public partial class DashboardScreen : ContentPage
{
	public DashboardScreen()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}