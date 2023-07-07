
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForTemplateDetails;
using FanEase.Middleware.Data.Commands.ForVideo;
using FanEase.Middleware.Data.Handler.ForTemplateDetails;
using FanEase.Middleware.Data.Handler.ForVideo;
using FanEase.Middleware.Data.Queries.ForTemplateDetails;
using FanEase.Middleware.Data.Queries.ForVideo;
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
            
            services.AddScoped<IRequestHandler<GetAllVideosQuery, List<Video>>, GetAllVideosHandler>();
            services.AddScoped<IRequestHandler<GetVideoByIdQuery, Video>, GetVideoByIdHandler>();
            services.AddScoped<IRequestHandler<AddVideoCommand, bool>, AddVideoHandler>();
            services.AddScoped<IRequestHandler<EditVideoCommand, bool>, EditVideoHandler>();
            services.AddScoped<IRequestHandler<DeleteVideoCommand, bool>, DeleteVideoHandler>();
            services.AddScoped<IRequestHandler<GetAllTemplateDetailsQuery,List<TemplateDetail>>, GetAllTemplateDetailsHandler>();
            services.AddScoped<IRequestHandler<GetTemplateDetailsByIdQuery, TemplateDetail>, GetTemplateDetailsByIdHandler>();
            services.AddScoped<IRequestHandler<AddTemplateDetailsCommand, bool>, AddTemplateDetailsHandler>();
            services.AddScoped<IRequestHandler<EditTemplateDetailsCommand, bool>, EditTemplateDetailsHandler>();
            services.AddScoped<IRequestHandler<DeleteTemplateDetailsCommand, bool>, DeleteTemplateDetailsHandler>();
            return services;
        }
    }
}
