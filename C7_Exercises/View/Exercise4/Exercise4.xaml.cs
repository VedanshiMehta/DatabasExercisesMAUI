using C7_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C7_Exercises.View.Exercise4;

public partial class Exercise4 : ContentPage
{
	private GetActivitiesViewModel _viewModel;
	public Exercise4()
	{
		InitializeComponent();
		_viewModel = (GetActivitiesViewModel)BindingContext;
        _viewModel.Result += ViewModel_Result;
        _viewModel.UpdateActivityTabel += ViewModel_UpdateActivityTabel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetActivityList();
    }

    private async void ViewModel_UpdateActivityTabel(object sender, ActivityTabel activity)
    {
        await Navigation.PushAsync(new UpdateActivity(activity));
    }

    private void ViewModel_Result(object sender, ResultEventArgs e)
    {
        Toast.Make(e.Message,CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddActivity());
    }
}