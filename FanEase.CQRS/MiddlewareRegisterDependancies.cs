
using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCampaign;
using FanEase.Middleware.Data.Commands.ForCampaignAdvertisement;
using FanEase.Middleware.Data.Commands.ForPlayer;
using FanEase.Middleware.Data.Commands.ForTemplate;
using FanEase.Middleware.Data.Commands.ForTemplateDetails;
using FanEase.Middleware.Data.Commands.ForUser;
using FanEase.Middleware.Data.Commands.ForVideo;
using FanEase.Middleware.Data.Handler.ForAdvertisement;
using FanEase.Middleware.Data.Handler.ForCampaign;
using FanEase.Middleware.Data.Handler.ForCampaignAdvertisement;
using FanEase.Middleware.Data.Handler.ForPlayer;
using FanEase.Middleware.Data.Handler.ForTemplate;
using FanEase.Middleware.Data.Handler.ForTemplateDetails;
using FanEase.Middleware.Data.Handler.ForUser;
using FanEase.Middleware.Data.Handler.ForVideo;
using FanEase.Middleware.Data.Queries.ForCampaign;
using FanEase.Middleware.Data.Queries.ForCampaignAdvertisement;
using FanEase.Middleware.Data.Queries.ForPlayer;
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
            
            services.AddScoped<IRequestHandler<GetAllVideosQuery, ResponseModel<List<Video>>>, GetAllVideosHandler>();
            services.AddScoped<IRequestHandler<GetVideoByIdQuery, ResponseModel<Video>>, GetVideoByIdHandler>();
            services.AddScoped<IRequestHandler<AddVideoCommand, ResponseModel<bool>>, AddVideoHandler>();
            services.AddScoped<IRequestHandler<EditVideoCommand, ResponseModel<bool>>, EditVideoHandler>();
            services.AddScoped<IRequestHandler<DeleteVideoCommand, ResponseModel<bool>>, DeleteVideoHandler>();
            services.AddScoped<IRequestHandler<GetVideosByUserIdQuery,ResponseModel<List<Video>>>,GetVideosByUserIdQueryHandler> ();
            services.AddScoped<IRequestHandler<GetAllTemplateDetailsQuery, ResponseModel<List<TemplateDetail>>>, GetAllTemplateDetailsHandler>();
            services.AddScoped<IRequestHandler<GetTemplateDetailsByIdQuery, ResponseModel<TemplateDetail>>, GetTemplateDetailsByIdHandler>();
            services.AddScoped<IRequestHandler<AddTemplateDetailsCommand, ResponseModel<bool>>, AddTemplateDetailsHandler>();
            services.AddScoped<IRequestHandler<EditTemplateDetailsCommand, ResponseModel<bool>>, EditTemplateDetailsHandler>();
            services.AddScoped<IRequestHandler<DeleteTemplateDetailsCommand, ResponseModel<bool>>, DeleteTemplateDetailsHandler>();
            services.AddScoped<IRequestHandler<GetAllAdvertisementsQuery, ResponseModel<List<Advertisement>>>, GetAllAdvertisementHandler>();
            services.AddScoped<IRequestHandler<GetAdvertisementByIdQuery, ResponseModel<Advertisement>>, GetAdvertisementByIdHandler>();
            services.AddScoped<IRequestHandler<AddAdvertisementCommand, ResponseModel<bool>>, AddAdvertisementHandler>();
            services.AddScoped<IRequestHandler<GetAdvertisementsByUserQuery, ResponseModel<List<Advertisement>>>, GetAdvertisementsByUserHandler>();
            services.AddScoped<IRequestHandler<EditAdvertisementCommand, ResponseModel<bool>>, EditAdvertisementHandler>();
            services.AddScoped<IRequestHandler<DeleteAdvertisementCommand, ResponseModel<bool>>, DeleteAdvertisementHandler>();
            services.AddScoped<IRequestHandler<CampaignCreateCommand, ResponseModel<bool>>, CampaignCreateCommandHandler>();
            services.AddScoped<IRequestHandler<CampaignDeleteCommand, ResponseModel<bool>>, CampaignDeleteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCampaignCommand, ResponseModel<bool>>, UpdateCampaignCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCampaignsQuery, ResponseModel<List<Campaigns>>>, GetAllCampaignsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllCampaignIdQuery, ResponseModel<Campaigns>>, GetAllCampaignIdQueryHandler>();
            services.AddScoped<IRequestHandler<CampaignAdvertisementCreateCommand, ResponseModel<bool>>, CampaignAdvertisementCreateCommandHandler>();
            services.AddScoped<IRequestHandler<CampaignAdvertisementDeleteCommand, ResponseModel<bool>>, CampaignAdvertisementDeleteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCampaignAdvertisementCommand, ResponseModel<bool>>, UpdateCampaignAdvertisementCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCampaignAdvertisementsQuery, ResponseModel<List<Campaign_Advertisement>>>, GetAllCampaignAdvertisementsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllCampaignAdvertisementIdQuery, ResponseModel<Campaign_Advertisement>>, GetAllCampaignAdvertisementIdQueryHandler>();
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
            //For Account
            services.AddScoped<IRequestHandler<ResetPasswordCommand, ResponseModel<bool>>, ResetPasswordHandler>();
            services.AddScoped<IRequestHandler<SetCreatorPasswordCommand,ResponseModel<bool>>,SetCreatorPasswordCommandHandler>();

            return services;
        }
    }
}
