using C7_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C7_Exercises.View.Exercise5;

public partial class Exercise5 : ContentPage
{
    private GetTasksViewModel _viewModel;
	public Exercise5()
	{
		InitializeComponent();
        _viewModel = (GetTasksViewModel)BindingContext;
        _viewModel.DeleteResult += ViewModel_DeleteResult;
        _viewModel.UpdateTaskTabelSelected += ViewModel_UpdateTaskTabelSelected;
	}

    private async void ViewModel_UpdateTaskTabelSelected(object sender, TaskTabel taskTabel)
    {
        await Navigation.PushAsync(new UpdateTaskPage(taskTabel));
    }

    private void ViewModel_DeleteResult(object sender, ResultEventArgs e)
    {
       Toast.Make(e.Message,CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetTaskLists();
    }
    private async void ImageButtonCreateTask_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddTaskPage());
    }
}