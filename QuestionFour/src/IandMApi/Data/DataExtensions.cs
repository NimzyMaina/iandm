using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IandMApi.Data
{
    public static class DataExtensions
    {

        public static IServiceCollection AddDbConfig(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<IandMDbContext>(options => { options.UseInMemoryDatabase("IandMDb"); });
            
            return services;
        }
        
    }
}