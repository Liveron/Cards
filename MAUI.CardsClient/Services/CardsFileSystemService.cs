using MAUI.CardsClient.Models;
using MAUI.CardsClient.Services.Interfaces;
using System.Text.Json;

namespace MAUI.CardsClient.Services
{
    public class CardsFileSystemService : ICardsFileSystemService
    {
        const string CARDS_INFO_FILE = "cardsInfo.json";
        
        public IEnumerable<Card> GetAll()
        {
            string pathToRead = Path.Combine(FileSystem.Current.AppDataDirectory, CARDS_INFO_FILE);

            IEnumerable<Card> cards;

            string jsonCards = File.ReadAllText(pathToRead);

            cards = JsonSerializer.Deserialize<IEnumerable<Card>>(jsonCards);

            return cards;
        }

        public Card Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Card card)
        {
            await Task.Run(() => Create(card));
        }

        public void Create(Card card)
        {
            string jsonCard = JsonSerializer.Serialize(card);

            using (var sw = new StreamWriter(File.OpenWrite(Path.Combine(FileSystem.Current.AppDataDirectory, CARDS_INFO_FILE))))
            {
                sw.Write(jsonCard);
            }
        }

        public void Update(Card entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await Task.Run(GetAll);
        }
    }
}
