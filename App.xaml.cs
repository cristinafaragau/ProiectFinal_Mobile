using System;
using ProiectFinal_Mobile.Data;
using System.IO;

namespace ProiectFinal_Mobile;

public partial class App : Application
{
    static AnimalListDatabase database;
    public static AnimalListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new AnimalListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder. LocalApplicationData), "AnimalList.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
