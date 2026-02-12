using Microsoft.Extensions.DependencyInjection;
using ShoeService.DL.Interfaces;
using ShoeService.DL.Repositories;

namespace ShoeService.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDL(this IServiceCollection services)
        {
            services.AddSingleton<IShoeRepository, ShoeRepository>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
