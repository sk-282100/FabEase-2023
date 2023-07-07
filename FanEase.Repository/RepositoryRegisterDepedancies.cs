﻿

using FanEase.Repository.Interfaces;
using FanEase.Repository.Repositories;
using FanEase.Repository.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository
{
    public static class RepositoryRegisterDepedancies 
    {
        public static IServiceCollection RegisterRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<ITemplateDetailsRepository, TemplateDetailsRepository>();
            services.AddScoped<ITemplateDetailsService, TemplateDetailsService>();
            return services;
        }
    }
}
