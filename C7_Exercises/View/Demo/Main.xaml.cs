using C7_Exercises.Model;
using C7_Exercises.View;

namespace C7_Exercises;

public partial class Main : FlyoutPage
{


	public Main()
	{
		InitializeComponent();
		
        flyoutPage.CollectionView.SelectionChanged += CollectionView_SelectionChanged;
        flyoutPage.CollectionView.SelectedItem = flyoutPage.CollectionView.ItemsSource.Cast<FlyoutPageItem>().FirstOrDefault();

    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
        }

    }
}

