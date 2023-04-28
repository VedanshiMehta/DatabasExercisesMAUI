using C7_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C7_Exercises.View.Exerecise3;

public partial class LoginScreen : ContentPage
{
	private LoginViewModel viewModel;
	public LoginScreen()
	{
		InitializeComponent();
		viewModel = (LoginViewModel)BindingContext;
        viewModel.LoginResult += ViewModel_LoginResult;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        entryLoginUserName.Text=string.Empty;
        entryLoginPassword.Text = string.Empty;
    }
    private async void ViewModel_LoginResult(object sender, ResultEventArgs e)
    {
        try
        {
            if (e.IsValid)
            {

                await Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                await Navigation.PushAsync(new DashboardScreen());

            }
            else if (!e.IsValid)
            {
                await Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
    }

    private async void Register_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}