using Mapster;
using MAUI.CardsClient.ViewModels.CreateCardPage;

namespace MAUI.CardsClient.Models.DTOs
{
    public class CardDTO : IMapFrom<Card>, IMapFrom<CreateCardData>
    {
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public void ConfigureMapping(TypeAdapterConfig config)
        {
            config.NewConfig<Card, CardDTO>()
                .Map(dest => dest.Title, source => source.Title)
                .Map(dest => dest.Details, source => source.Details)
                .Map(dest => dest.ImageUrl, source => source.ImageUrl);

            config.NewConfig<CreateCardData, CardDTO>()
                .Map(dest => dest.Title, source => source.Title)
                .Map(dest => dest.Details, source => source.Details)
                .Map(dest => dest.ImageUrl, source => source.ImageUrl);
        }
    }
}
