using C7_Exercises.View.Exercise1;
using C7_Exercises.View.Exercise2;
using C7_Exercises.View.Exerecise3;
using C7_Exercises.View.Exercise4;
using C7_Exercises.View.Exercise5;
using C7_Exercises.View.Exercise6;


namespace C7_Exercises;

public partial class App : Application
{
	
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Exercise5())
		{
            BarBackgroundColor = Color.Parse("#609EA0"),
            BarTextColor = Color.Parse("#ffffff"),
        };


    }

    protected override void OnStart()
    {
       
        CreateTabel();
        base.OnStart();
    }

   

    private async void CreateTabel()
    {
        DatabaseConnection.GetDBConnection();
        await UserDatabase.CreateTabelAsync();
    }
}
