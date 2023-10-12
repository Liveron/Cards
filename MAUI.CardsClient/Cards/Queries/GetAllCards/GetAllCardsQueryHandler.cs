using Mapster;
using MAUI.CardsClient.Models;
using MAUI.CardsClient.Models.DTOs;
using MAUI.CardsClient.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CardsClient.Cards.Queries.GetAllCards
{
    public class GetAllCardsQueryHandler :
        IRequestHandler<GetAllCardsQuery, ObservableCollection<CardDTO>>
    {
        AFileSystemRepository<Card> _fileSystemRepository;

        public GetAllCardsQueryHandler(AFileSystemRepository<Card> fileSystemRepository) =>
            _fileSystemRepository = fileSystemRepository;

        public  Task<ObservableCollection<CardDTO>> Handle(
            GetAllCardsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Card> cards = _fileSystemRepository.GetAll();

            ObservableCollection<CardDTO> cardDtos = 
                cards.Adapt<ObservableCollection<CardDTO>>();

            return Task.FromResult(cardDtos);
        }
    }
}
