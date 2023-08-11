
using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCampaign;
using FanEase.Middleware.Data.Commands.ForCampaignAdvertisement;
using FanEase.Middleware.Data.Commands.ForCity;
using FanEase.Middleware.Data.Commands.ForCountry;
using FanEase.Middleware.Data.Commands.ForPlayer;
using FanEase.Middleware.Data.Commands.ForState;
using FanEase.Middleware.Data.Commands.ForTemplate;
using FanEase.Middleware.Data.Commands.ForTemplateDetails;
using FanEase.Middleware.Data.Commands.ForUser;
using FanEase.Middleware.Data.Commands.ForVideo;
using FanEase.Middleware.Data.Handler.ForAdvertisement;
using FanEase.Middleware.Data.Handler.ForCampaign;
using FanEase.Middleware.Data.Handler.ForCampaignAdvertisement;
using FanEase.Middleware.Data.Handler.ForCity;
using FanEase.Middleware.Data.Handler.ForCountry;
using FanEase.Middleware.Data.Handler.ForDashboard;
using FanEase.Middleware.Data.Handler.ForCountry;
using FanEase.Middleware.Data.Handler.ForPlayer;
using FanEase.Middleware.Data.Handler.ForState;
using FanEase.Middleware.Data.Handler.ForTemplate;
using FanEase.Middleware.Data.Handler.ForTemplateDetails;
using FanEase.Middleware.Data.Handler.ForUser;
using FanEase.Middleware.Data.Handler.ForVideo;
using FanEase.Middleware.Data.Queries.ForAdvertisement;
using FanEase.Middleware.Data.Queries.ForCampaign;
using FanEase.Middleware.Data.Queries.ForCampaignAdvertisement;
using FanEase.Middleware.Data.Queries.ForCity;
using FanEase.Middleware.Data.Queries.ForCountry;
using FanEase.Middleware.Data.Queries.ForDashboard;
using FanEase.Middleware.Data.Queries.ForPlayer;
using FanEase.Middleware.Data.Queries.ForState;
using FanEase.Middleware.Data.Queries.ForTemplate;
using FanEase.Middleware.Data.Queries.ForTemplateDetails;
using FanEase.Middleware.Data.Queries.ForUser;
using FanEase.Middleware.Data.Queries.ForVideo;
using FanEase.Repository.Interfaces;
using FanEase.Repository.Repositories;
using FanEase_CQRS.Controllers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware
{
    public static class MiddlewareRegisterDependancies
    {
        public static IServiceCollection RegisterMiddlewareLayer(this IServiceCollection services)
        {
         //For User   
            services.AddScoped<IRequestHandler<GetAllVideosQuery, ResponseModel<List<Video>>>, GetAllVideosHandler>();
            services.AddScoped<IRequestHandler<GetVideoByIdQuery, ResponseModel<Video>>, GetVideoByIdHandler>();
            services.AddScoped<IRequestHandler<AddVideoCommand, ResponseModel<bool>>, AddVideoHandler>();
            services.AddScoped<IRequestHandler<EditVideoCommand, ResponseModel<bool>>, EditVideoHandler>();
            services.AddScoped<IRequestHandler<DeleteVideoCommand, ResponseModel<bool>>, DeleteVideoHandler>();
            services.AddScoped<IRequestHandler<GetVideosByUserIdQuery,ResponseModel<List<Video>>>,GetVideosByUserIdQueryHandler> ();
            services.AddScoped<IRequestHandler<GetAllVideosListQuery, ResponseModel<List<VideoListVm>>>, GetAllVideosListHandler>();
            services.AddScoped<IRequestHandler<GetVideosListScreenByUserIdQuery, ResponseModel<List<VideoListVm>>>, GetVideosListScreenByUserIdHandler>();


            services.AddScoped<IRequestHandler<GetAllTemplateDetailsQuery, ResponseModel<List<TemplateDetail>>>, GetAllTemplateDetailsHandler>();
            services.AddScoped<IRequestHandler<GetTemplateDetailsByIdQuery, ResponseModel<TemplateDetail>>, GetTemplateDetailsByIdHandler>();
            services.AddScoped<IRequestHandler<AddTemplateDetailsCommand, ResponseModel<bool>>, AddTemplateDetailsHandler>();
            services.AddScoped<IRequestHandler<EditTemplateDetailsCommand, ResponseModel<bool>>, EditTemplateDetailsHandler>();
            services.AddScoped<IRequestHandler<DeleteTemplateDetailsCommand, ResponseModel<bool>>, DeleteTemplateDetailsHandler>();
           
            //For Advertisement
            services.AddScoped<IRequestHandler<GetAllAdvertisementsQuery, ResponseModel<List<Advertisement>>>, GetAllAdvertisementHandler>();
            services.AddScoped<IRequestHandler<GetAdvertisementByIdQuery, ResponseModel<Advertisement>>, GetAdvertisementByIdHandler>();
            services.AddScoped<IRequestHandler<AddAdvertisementCommand, ResponseModel<bool>>, AddAdvertisementHandler>();
            services.AddScoped<IRequestHandler<GetAdvertisementsByUserQuery, ResponseModel<List<Advertisement>>>, GetAdvertisementsByUserHandler>();
            services.AddScoped<IRequestHandler<EditAdvertisementCommand, ResponseModel<bool>>, EditAdvertisementHandler>();
            services.AddScoped<IRequestHandler<DeleteAdvertisementCommand, ResponseModel<bool>>, DeleteAdvertisementHandler>();
            services.AddScoped<IRequestHandler<AdvertisementListScreenQuery, ResponseModel<List<AdvertisementListVM>>>, AdvertisementListScreenHandler>();
            services.AddScoped<IRequestHandler<AdvertisementListScreenByUserIdQuery, ResponseModel<List<AdvertisementListVM>>>, AdvertisementListScreenByUserIdHandler>();

            //For Campaign
            services.AddScoped<IRequestHandler<CampaignCreateCommand, ResponseModel<bool>>, CampaignCreateCommandHandler>();
            services.AddScoped<IRequestHandler<CampaignDeleteCommand, ResponseModel<bool>>, CampaignDeleteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCampaignCommand, ResponseModel<bool>>, UpdateCampaignCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCampaignsQuery, ResponseModel<List<Campaigns>>>, GetAllCampaignsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllCampaignIdQuery, ResponseModel<MainCampaign>>, GetAllCampaignIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllCampaignListScreenByUserIdQuery, ResponseModel<List<CampaignListScreenVm>>>, GetAllCampaignListScreenByUserIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetCampaignByDetailsIdQuery, ResponseModel<Campaigns>>, GetCampaignByDetailsIdQueryHandler>();
            //services.AddScoped<IRequestHandler<GetAllCampaignAdvIdQuery,ResponseModel<List<EditCampaignVm>>>,GetAllCampaignAdvIdQueryHandler();
            //services.AddScoped<IRequestHandler<GetAllCampaignAdvIdQuery, ResponseModel<EditCampaignVm>>, GetAllCampaignAdvIdQueryHandler>();

            //For Campaign Advertisement
            services.AddScoped<IRequestHandler<CampaignAdvertisementCreateCommand, ResponseModel<bool>>, CampaignAdvertisementCreateCommandHandler>();
            services.AddScoped<IRequestHandler<CampaignAdvertisementDeleteCommand, ResponseModel<bool>>, CampaignAdvertisementDeleteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCampaignAdvertisementCommand, ResponseModel<bool>>, UpdateCampaignAdvertisementCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCampaignAdvertisementsQuery, ResponseModel<List<Campaign_Advertisement>>>, GetAllCampaignAdvertisementsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllCampaignAdvertisementIdQuery, ResponseModel<Campaign_Advertisement>>, GetCampaignAdvertisementByCampaignIdQueryHandler>();
           
            //
            //For Player
            services.AddScoped<IRequestHandler<PlayerCreateCommand, ResponseModel<bool>>, PlayerCreateCommandHandler>();
            services.AddScoped<IRequestHandler<PlayerDeleteCommand, ResponseModel<bool>>, PlayerDeleteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePlayerCommand, ResponseModel<bool>>, UpdatePlayerCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllPlayersQuery, ResponseModel<List<players>>>, GetAllPlayersQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllPlayerIdQuery, ResponseModel<players>>, GetAllPlayerIdQueryHandler>();

            //For User
            services.AddScoped<IRequestHandler<GetAllUsersQuery, ResponseModel<List<User>>>, GetAllUsersHandler>();
            services.AddScoped<IRequestHandler<GetUserByIdQuery, ResponseModel<User>>, GetUserByIdHandler>();
            services.AddScoped<IRequestHandler<AddUserCommand, ResponseModel<bool>>, AddUserHandler>();
            services.AddScoped<IRequestHandler<EditUserCommand, ResponseModel<bool>>, EditUserHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, ResponseModel<bool>>, DeleteUserHandler>();
            services.AddScoped<IRequestHandler<LoginCommand, ResponseModel<AuthResponse>>, LoginHandler>();
            services.AddScoped<IRequestHandler<GetUserByUserNameQuery, ResponseModel<User>>, GetUserByUserNameQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllCreatorsQuery, ResponseModel<List<User>>>, GetAllCreatorsQueryHandler>();
            services.AddScoped<IRequestHandler<AddCreatorCommand, ResponseModel<bool>>, AddCreatorCommandHandler>();
            services.AddScoped<IRequestHandler<AddViewerCommand, ResponseModel<bool>>, AddViewerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCreatorCommand,bool>, RemoveCreatorCommandHandler>(); 
            
            //For Account
            services.AddScoped<IRequestHandler<ResetPasswordCommand, ResponseModel<bool>>, ResetPasswordHandler>();
            services.AddScoped<IRequestHandler<SetCreatorPasswordCommand,ResponseModel<bool>>,SetCreatorPasswordCommandHandler>();
            services.AddScoped<IRequestHandler<SetPasswordCommand, ResponseModel<bool>>, SetPasswordCommandHandler>();
            services.AddScoped<IRequestHandler<AdvertisementListScreenQuery, ResponseModel<List<AdvertisementListVM>>>, AdvertisementListScreenHandler>();
            //For Template
            services.AddScoped<IRequestHandler<GetTemplateListQuery, ResponseModel<List<TemplateListDTO>>>, GetTemplateListHandler>();
            services.AddScoped<IRequestHandler<GetTemplateListByIdQuery, ResponseModel<Templates>>, GetAllTemplateHandler>();
            services.AddScoped<IRequestHandler<CreateTemplateCommand, ResponseModel<bool>>, CreateTemplateHandler>();
            services.AddScoped<IRequestHandler<UpdateTemplateCommand, ResponseModel<bool>>, UpdateTemplateHandler>();
            services.AddScoped<IRequestHandler<DeleteTemplateCommand, ResponseModel<bool>>, DeleteTemplateHandler>();
            services.AddScoped<IRequestHandler<GetAllTemplatesByUserQuery, ResponseModel<List<TemplateListDTO>>>, GetAllTemplatesByUserQueryHandler>();

            //For Country
            services.AddScoped<IRequestHandler<GetAllCountrysQuery, ResponseModel<List<Country>>>, GetAllCountrysQueryHandler>();
            services.AddScoped<IRequestHandler<CountryCreateCommand, ResponseModel<bool>>, CountryCreateCommandHandler>();
            services.AddScoped<IRequestHandler<CountryDeleteCommand, ResponseModel<bool>>, CountryDeleteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCountryCommand, ResponseModel<bool>>, UpdateCountryCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCountryIdQuery, ResponseModel<Country>>, GetAllCountryIdQueryHandler>();
            services.AddScoped<IRequestHandler<CheckCountryNameExistsQuery, ResponseModel<Country>>, CheckCountryNameExistsQueryHandler>();

       

            //For State
            services.AddScoped<IRequestHandler<StateCreateCommand, ResponseModel<bool>>, CreateStateHandler>();
            services.AddScoped<IRequestHandler<StateDeleteCommand, ResponseModel<bool>>, DeleteStateHandler>();
            services.AddScoped<IRequestHandler<GetStateListByIdQuery, ResponseModel<State>>, GetAllStateHandler>();
            services.AddScoped<IRequestHandler<GetStateListQuery, ResponseModel<List<StateListVM>>>, GetStateListHandler>();
            services.AddScoped<IRequestHandler<StateUpdateCommand, ResponseModel<bool>>, UpdateStateHandler>();

            //For City
            services.AddScoped<IRequestHandler<CityCreateCommand, ResponseModel<bool>>, CreateCityHandler>();
            services.AddScoped<IRequestHandler<GetCityListByIdQuery, ResponseModel<City>>, GetAllCityHandler>();
            services.AddScoped<IRequestHandler<GetCityListQuery, ResponseModel<List<CityListVM>>>, GetCityListHandler>();
            services.AddScoped<IRequestHandler<CityUpdateCommand, ResponseModel<bool>>, UpdateCityHandler>();
            services.AddScoped<IRequestHandler<CityeDeleteCommand, ResponseModel<bool>>, DeleteCityHandler>();

            //For Country
            services.AddScoped<IRequestHandler<GetAllCountrysQuery, ResponseModel<List<Country>>>, GetAllCountrysQueryHandler>();
            services.AddScoped<IRequestHandler<CountryCreateCommand, ResponseModel<bool>>, CountryCreateCommandHandler>();
            services.AddScoped<IRequestHandler<CountryDeleteCommand, ResponseModel<bool>>, CountryDeleteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCountryCommand, ResponseModel<bool>>, UpdateCountryCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCountryIdQuery, ResponseModel<Country>>, GetAllCountryIdQueryHandler>();
            services.AddScoped<IRequestHandler<CheckCountryNameExistsQuery, ResponseModel<Country>>, CheckCountryNameExistsQueryHandler>();

            services.AddScoped<IRequestHandler<AdminDashBoardQuery, ResponseModel<AdminDashboardDTO>>, AdminDashBoardQueryHandler>();
            services.AddScoped<IRequestHandler<LatestAddedVideoQuery, ResponseModel<int>>, LatestAddedVideoQueryHandler>();
            services.AddScoped<IRequestHandler<AssignCampaignCommand, ResponseModel<bool>>, AssignCampaignCommandHandler>();
            services.AddScoped<IRequestHandler<LatestAddedCampaignQuery, ResponseModel<int>>, LatestAddedCampaignQueryHandler>();
            return services;
        }
    }
}
