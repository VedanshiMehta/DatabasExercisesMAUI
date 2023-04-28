using C7_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C7_Exercises.View.Exercise4;

public partial class AddActivity : ContentPage
{
	private AddActivityViewModel _viewModel;
	public AddActivity()
	{
		InitializeComponent();
		_viewModel = (AddActivityViewModel)BindingContext;
        _viewModel.AddAcivityResult += ViewModel_AddAcivityResult;
	}

    private async void ViewModel_AddAcivityResult(object sender, ResultEventArgs e)
    {
        try
        {
            if (e.IsValid)
            {

                await Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                await Navigation.PopAsync();

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
}