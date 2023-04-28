using C7_Exercises.Model;
using System.Linq;

namespace C7_Exercises.View.Exercise1;

public partial class Exercise1 : FlyoutPage
{
	public Exercise1()
	{
		InitializeComponent();
        flyoutPageExercise1.collectionView.SelectionChanged += CollectionView_SelectionChanged;
        flyoutPageExercise1.collectionView.SelectedItem = flyoutPageExercise1.collectionView.ItemsSource.Cast<FlyoutPageItem>().FirstOrDefault();
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