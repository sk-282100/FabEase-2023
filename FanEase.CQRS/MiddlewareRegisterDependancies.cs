
using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForTemplateDetails;
using FanEase.Middleware.Data.Commands.ForVideo;
using FanEase.Middleware.Data.Handler.ForAdvertisement;
using FanEase.Middleware.Data.Handler.ForTemplateDetails;
using FanEase.Middleware.Data.Handler.ForVideo;
using FanEase.Middleware.Data.Queries.ForTemplateDetails;
using FanEase.Middleware.Data.Queries.ForVideo;
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
            return services;
        }
    }
}
