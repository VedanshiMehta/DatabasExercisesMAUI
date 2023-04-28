using C7_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C7_Exercises.View.Exercise5;

public partial class AddTaskPage : ContentPage
{
	private CreateTaskViewModel _createTaskViewModel;
	public AddTaskPage()
	{
		InitializeComponent();
		_createTaskViewModel = (CreateTaskViewModel)BindingContext;
        _createTaskViewModel.AddTaskResult += CreateTaskViewModel_AddTaskResult;
	}

    private async void CreateTaskViewModel_AddTaskResult(object sender, ResultEventArgs e)
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