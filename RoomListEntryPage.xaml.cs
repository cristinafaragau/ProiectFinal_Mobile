using ProiectFinal_Mobile.Models;

namespace ProiectFinal_Mobile;

public partial class RoomListEntryPage : ContentPage
{
	public RoomListEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRoomListsAsync();
    }
    async void OnRoomListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoomListPage
        {
            BindingContext = new RoomList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new RoomListPage
            {
                BindingContext = e.SelectedItem as RoomList
            });
        }
    }
}