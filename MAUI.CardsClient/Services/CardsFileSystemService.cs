using MAUI.CardsClient.Models;
using MAUI.CardsClient.Services.Interfaces;
using MAUI.CardsClient.Utils;
using MAUI.CardsClient.Utils.Extensions;

namespace MAUI.CardsClient.Services
{
    public class CardsFileSystemService : AFileSystemRepository<Card>
    {
        const string CARDS_INFO_FILE = "infoFile.json";

        string _path = Path.Combine(FileSystem.AppDataDirectory, CARDS_INFO_FILE);

        FileStream? _fileStream = default;
        FileStream fileStream 
        {   
            get => _fileStream ??= 
                new FileStream(_path, FileMode.OpenOrCreate, FileAccess.ReadWrite); 

            set => _fileStream = value; 
        }

        public override void Create(Card entity)
        {
            throw new NotImplementedException();
        }

        public override async Task CreateAsync(Card card)
        {
            IEnumerable<Card> cards = await GetAllAsync();

            List<Card> cardsToWrite = cards.ToList();

            cardsToWrite.Add(card);

            await JsonSerializerHelper.
                TrySerializeAsync(fileStream, cardsToWrite);

            await fileStream.NormalizeAsync();
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
            IEnumerable<Card> cards = JsonSerializerHelper.
                TryDeserialize<IEnumerable<Card>>(fileStream) ?? 
                Enumerable.Empty<Card>();

            fileStream.Normalize();

            return cards;
        }

        public override async Task<IEnumerable<Card>> GetAllAsync()
        {
            bool isdf = File.Exists(_path);

            IEnumerable<Card> cards = await JsonSerializerHelper.
                TryDeserializeAsync<IEnumerable<Card>>(fileStream) ??
                Enumerable.Empty<Card>();

            await fileStream.NormalizeAsync();

            return cards;
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
