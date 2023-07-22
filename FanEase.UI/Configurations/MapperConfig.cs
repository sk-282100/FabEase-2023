using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models.Creator;
using FanEase.UI.Models.Videos;

namespace FanEase.UI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreatorVM,CreatorListVM>().ReverseMap();
            CreateMap<CreatorVM, EditCreatorVM>().ReverseMap();
            CreateMap<User, EditCreatorVM>().ReverseMap();
            CreateMap<AddVideoVm,Video>().ReverseMap();
        }
    }
}
