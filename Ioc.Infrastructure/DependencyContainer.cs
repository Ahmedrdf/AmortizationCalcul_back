using Application.interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Application.services;
using Infrastructure.Data.Interface;
using Infrastructure.Data.Repository;

namespace Ioc.Infrastructure
{
 public   class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //testTck.Application
            services.AddScoped<IFirstResultsService, FirstResultsService>();

            //testTck.Domain.Interfaces | testTck.Infra.Data.Repositories
            services.AddScoped<IFirstResultsRepository, FirstResultRepository>();
      


        }
    }
}
