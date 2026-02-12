using Mapster;
using ShoeService.Models.Dto;
using ShoeService.Models.Entities;

namespace ShoeService.Host.Mappings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Shoe, ShoeDto>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Brand, src => src.Brand)
                .Map(dest => dest.Model, src => src.Model)
                .Map(dest => dest.Size, src => src.Size)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Category, src => src.Category);
        }
    }
}
