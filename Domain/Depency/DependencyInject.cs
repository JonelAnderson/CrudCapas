using DataAccess.DBContetx;
using DataAccess.Repositories;
using Domain.Logic;
using Domain.Services;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Depency
{
    public static class DependencyInject
    {
        public static void DependencyInjector(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionBD"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITratamientoService, TratamientoService>();

        }
    }
}
