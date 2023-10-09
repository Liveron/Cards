using MAUI.CardsClient.Models;
using MAUI.CardsClient.Services.Interfaces;
using MAUI.CardsClient.Utils;
using System.Text.Json;

namespace MAUI.CardsClient.Services
{
    public class CardsFileSystemService : AFileSystemRepository<Card>
    {
        const string CARDS_INFO_FILE = "infoFile.json";

        string _path = Path.Combine(FileSystem.AppDataDirectory, CARDS_INFO_FILE);

        FileStream _fileStream;
        FileStream fileStream 
        {   
            get => _fileStream ??= 
                new FileStream(_path, FileMode.OpenOrCreate, FileAccess.ReadWrite); 

            set => _fileStream = value; 
        }

        public CardsFileSystemService()
        {

        }

        public override void Create(Card entity)
        {
            throw new NotImplementedException();
        }

        public override async Task CreateAsync(Card card)
        {
            IEnumerable<Card> cards = await GetAllAsync();

            cards.ToList().Add(card);

            await JsonSerializerHelper.
                TrySerializeAsync(fileStream, cards);
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Card Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Card> GetAll()
        {
            return JsonSerializerHelper.
                TryDeserialize<IEnumerable<Card>>(fileStream);
        }

        public override async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await JsonSerializerHelper.
                TryDeserializeAsync<IEnumerable<Card>>(fileStream);
        }

        public override void Update(Card entity)
        {
            throw new NotImplementedException();
        }

        protected override void Disposing()
        {
            fileStream.Dispose();
        }

        protected override async ValueTask DisposingAsync()
        {
            await fileStream.DisposeAsync();
        }
    }
}
