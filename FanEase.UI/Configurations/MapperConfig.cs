using AutoMapper;
using FanEase.UI.Models.Creator;

namespace FanEase.UI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreatorVM,CreatorListVM>().ReverseMap();
        }
    }
}
