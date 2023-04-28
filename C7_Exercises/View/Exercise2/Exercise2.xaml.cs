using C7_Exercises.Model;

namespace C7_Exercises.View.Exercise2;

public partial class Exercise2 : FlyoutPage
{
	public Exercise2()
	{
		InitializeComponent();
        flyoutPageE2.collectionViewE2.SelectionChanged += CollectionViewE2_SelectionChanged;
        flyoutPageE2.collectionViewE2.SelectedItem = flyoutPageE2.collectionViewE2.ItemsSource.Cast<FlyoutPageItem>().FirstOrDefault();
        flyoutPageE2.subCollectionViewE2.SelectionChanged += SubCollectionViewE2_SelectionChanged;

    }
    private void CollectionViewE2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
        }
    }
    private void SubCollectionViewE2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
        }
    }

   
}