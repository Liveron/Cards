using Mapster;
using MAUI.CardsClient.Models;
using MAUI.CardsClient.Models.DTOs;
using MAUI.CardsClient.Services.Interfaces;
using MediatR;
using System.Collections.ObjectModel;

namespace MAUI.CardsClient.Cards.Queries.GetAllCards
{
    public class GetAllCardsQueryAsyncHandler :
        IRequestHandler<GetAllCardsQueryAsync, ObservableCollection<CardDTO>>
    {
        AFileSystemRepository<Card> _fileSystemRepository;

        public GetAllCardsQueryAsyncHandler(AFileSystemRepository<Card> fileSystemRepository) =>
            _fileSystemRepository = fileSystemRepository;

        public async Task<ObservableCollection<CardDTO>> Handle(
            GetAllCardsQueryAsync request, CancellationToken cancellationToken)
        {
            IEnumerable<Card> cards = await _fileSystemRepository.GetAllAsync();

            return await cards.BuildAdapter()
                .AdaptToTypeAsync<ObservableCollection<CardDTO>>();
        }
    }
}
