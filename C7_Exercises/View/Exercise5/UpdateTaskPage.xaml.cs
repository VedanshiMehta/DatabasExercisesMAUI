using C7_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C7_Exercises.View.Exercise5;

public partial class UpdateTaskPage : ContentPage
{
	private UpdateTaskViewModel _viewModel;
	public UpdateTaskPage(TaskTabel taskTabel)
	{
		InitializeComponent();
		_viewModel = (UpdateTaskViewModel)BindingContext;
		_viewModel.Id = taskTabel.Id;
		_viewModel.TaskName = taskTabel.Title;
		_viewModel.TaskDescription = taskTabel.Description;
		_viewModel.CompletionDate = taskTabel.CompletionDate;
		_viewModel.StartTime = taskTabel.StartTime;
		_viewModel.EndTime = taskTabel.EndTime;
        _viewModel.UpdateTaskResult += ViewModel_UpdateTaskResult;
	}

    private async void ViewModel_UpdateTaskResult(object sender, ResultEventArgs e)
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