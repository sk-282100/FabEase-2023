
using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models.Advertisements;
using FanEase.UI.Models.City;
using FanEase.UI.Models.Creator;
using FanEase.UI.Models.State;
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
            CreateMap<EditVideoVM, Video>().ReverseMap();
            CreateMap<AddAdvertisementVm,Advertisement>().ReverseMap();
            CreateMap<EditAdvertisementVm, Advertisement>().ReverseMap();
            CreateMap<StateVm, State>().ReverseMap();
            CreateMap<CityVm, City>().ReverseMap();
            CreateMap<AdvertisementListVM, SelectAdvertisement>().ReverseMap();
        }
    }
}
