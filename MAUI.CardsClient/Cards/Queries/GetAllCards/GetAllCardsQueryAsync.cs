using MAUI.CardsClient.Models.DTOs;
using MediatR;
using System.Collections.ObjectModel;

namespace MAUI.CardsClient.Cards.Queries.GetAllCards
{
    public class GetAllCardsQueryAsync
        : IRequest<ObservableCollection<CardDTO>> { }
}
