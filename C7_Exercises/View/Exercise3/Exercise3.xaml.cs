using C7_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C7_Exercises.View.Exerecise3;

public partial class Exercise3 : ContentPage
{
 
	private RegistrationViewModel _registrationViewModel;
    
	public Exercise3()
	{
        
		InitializeComponent();
		_registrationViewModel = (RegistrationViewModel)BindingContext;
        _registrationViewModel.Result += RegistrationViewModel_Result;
        
	}

    //protected override void OnAppearing()
    //{
    //    NavigateToLogin();
    //    base.OnAppearing();
    //}
    //private async void NavigateToLogin()
    //{
    //    if (CurrentAppData.IsUserLoggedIn)
    //    {
    //        await Navigation.PushAsync(new DashboardScreen());
    //    }
    //}
    private async void RegistrationViewModel_Result(object sender, ResultEventArgs e)
    {
        try
        {
            if (e.IsValid)
            {

                await Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                await Navigation.PushAsync(new LoginScreen());

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

    private async void ButtonLogin_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new LoginScreen());
    }
}