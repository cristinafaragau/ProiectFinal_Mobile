using ProiectFinal_Mobile.Models;

namespace ProiectFinal_Mobile;

public partial class BreedPage : ContentPage
{
    AnimalList sl;
	public BreedPage(AnimalList alist)
	{
		InitializeComponent();
        sl = alist;
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var breed = (Breed)BindingContext;
        await App.Database.SaveBreedAsync(breed);
        listView.ItemsSource = await App.Database.GetBreedsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var breed = (Breed)BindingContext;
        await App.Database.DeleteBreedAsync(breed);
        listView.ItemsSource = await App.Database.GetBreedsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Breed p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Breed;
            var lp = new ListBreed()
            {
                AnimalListID = sl.ID,
                BreedID = p.ID
            };
            await App.Database.SaveListBreedAsync(lp);
            p.ListBreeds = new List<ListBreed> { lp };
            await Navigation.PopAsync();
        }

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetBreedsAsync();
    }
}