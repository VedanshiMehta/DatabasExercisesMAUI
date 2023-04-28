using C7_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C7_Exercises.View.Exercise4;

public partial class UpdateActivity : ContentPage
{
	private UpdateActivityViewModel _viewModel;
	public UpdateActivity(ActivityTabel activity)
	{
		InitializeComponent();
		_viewModel = (UpdateActivityViewModel)BindingContext;
        _viewModel.Id = activity.Id;
        _viewModel.Title = activity.Title;
        _viewModel.DueDate = activity.DueDate;
        _viewModel.IsCompleted = activity.IsCompleted;
        _viewModel.UpdateAcivityResult += ViewModel_UpdateAcivityResult;
	}

    private async void ViewModel_UpdateAcivityResult(object sender, ResultEventArgs e)
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
}