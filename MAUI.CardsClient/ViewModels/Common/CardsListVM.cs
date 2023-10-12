using CommunityToolkit.Mvvm.ComponentModel;
using Mapster;
using MAUI.CardsClient.Cards.Commands.CreateCard;
using MAUI.CardsClient.Cards.Queries.GetAllCards;
using MAUI.CardsClient.Models.DTOs;
using MediatR;
using System.Collections.ObjectModel;

namespace MAUI.CardsClient.ViewModels.Common
{
    public partial class CardsListVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<CardDTO> _cards = new();

        IMediator _mediator;

        public CardsListVM(IMediator mediator) 
        {
            _mediator = mediator;

            RefreshCards();
        }

        public void RefreshCards()
        {
            Cards = _mediator.Send(new GetAllCardsQuery()).Result;
        }

        public async Task RefreshCardsAsync()
        {
            Cards = await _mediator.Send(new GetAllCardsQueryAsync());
        }

        public async Task AddCardAsync(CardDTO card)
        {
            Cards.Add(card);

            CreateCardCommandAsync command = await card.BuildAdapter()
                .AdaptToTypeAsync<CreateCardCommandAsync>();  

            await _mediator.Send(command);
        }
    }
}
