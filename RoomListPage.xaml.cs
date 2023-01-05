using ProiectFinal_Mobile.Models;
namespace ProiectFinal_Mobile;

public partial class RoomListPage : ContentPage
{
	public RoomListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (RoomList)BindingContext;
        
        await App.Database.SaveRoomListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (RoomList)BindingContext;
        await App.Database.DeleteRoomListAsync(slist);
        await Navigation.PopAsync();
    }
}