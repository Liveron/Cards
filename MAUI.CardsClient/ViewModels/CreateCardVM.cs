using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI.CardsClient.Models;
using System.Text.Json;

namespace MAUI.CardsClient.ViewModels
{
    public partial class CreateCardVM : AViewModel
    {
        [ObservableProperty]
        string _description;

        [ObservableProperty]
        string _title;

        [RelayCommand]
        async Task SaveCard()
        {
            Description = FileSystem.AppDataDirectory;

                using (FileStream fs = new(Path.Combine(FileSystem.AppDataDirectory, "Test.json"), FileMode.OpenOrCreate))
                {
                    await JsonSerializer.SerializeAsync(fs, new Card
                    {
                        Title = "Hi",
                        Details = "Test",
                    });
                };    

        }

        void CreateDirectory()
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(FileSystem.Current.AppDataDirectory, "cardsInfo"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
