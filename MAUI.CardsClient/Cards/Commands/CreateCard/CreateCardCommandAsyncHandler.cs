using MAUI.CardsClient.Models;
using MAUI.CardsClient.Services.Interfaces;
using MAUI.CardsClient.ViewModels.Common;
using MAUI.CardsClient.ViewModels.MainPage;
using MediatR;

namespace MAUI.CardsClient.Cards.Commands.CreateCard
{
    public class CreateCardCommandAsyncHandler :
        IRequestHandler<CreateCardCommandAsync, Guid>
    {
        AFileSystemRepository<Card> _fileSystemRepository;
        public CreateCardCommandAsyncHandler(
            AFileSystemRepository<Card> fileSystemRepository) =>
            _fileSystemRepository = fileSystemRepository;

        public async Task<Guid> Handle(
            CreateCardCommandAsync request, CancellationToken cancellationToken)
        {
            var card = new Card
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Details = request.Details,
            };

            await _fileSystemRepository.CreateAsync(card);

            return card.Id;
        }
    }
}
