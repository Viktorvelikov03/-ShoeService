using Microsoft.Extensions.DependencyInjection;
using ShoeService.BL.Interfaces;
using ShoeService.BL.Services;

namespace ShoeService.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterBL(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerCrudService, ShoeCrudService>();
            services.AddSingleton<IBuyShoesService, BuyShoesService>();

            return services;
        }
    }
}
