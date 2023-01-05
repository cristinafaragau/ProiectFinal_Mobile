using ProiectFinal_Mobile.Models;

namespace ProiectFinal_Mobile;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var alist = (AnimalList)BindingContext;
        alist.Date = DateTime.UtcNow;
        await App.Database.SaveAnimalListAsync(alist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var alist = (AnimalList)BindingContext;
        await App.Database.DeleteAnimalListAsync(alist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BreedPage((AnimalList)
       this.BindingContext)
        {
            BindingContext = new Breed()
        });

    }
    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Breed breed;
        var animalList = (AnimalList)BindingContext;
        if (listView.SelectedItem != null)
        {
            breed = listView.SelectedItem as Breed;
            var listBreedAll = await App.Database.GetListBreeds();
            var listBreed = listBreedAll.FindAll(x => x.BreedID == breed.ID & x.AnimalListID == animalList.ID);
            await App.Database.DeleteListBreedAsync(listBreed.FirstOrDefault());
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (AnimalList)BindingContext;

        listView.ItemsSource = await App.Database.GetListBreedsAsync(shopl.ID);
    }
}