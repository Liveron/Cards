using Mapster;
using MAUI.CardsClient.Models.DTOs;
using MediatR;

namespace MAUI.CardsClient.Cards.Commands.CreateCard
{
    public class CreateCardCommandAsync : IRequest<Guid>, IMapFrom<CardDTO>
    {
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;

        public void ConfigureMapping(TypeAdapterConfig config)
        {
            config.NewConfig<CardDTO, CreateCardCommandAsync>()
                .Map(dest => dest.Title, source => source.Title)
                .Map(dest => dest.Details, source => source.Details);
        }
    }
}
