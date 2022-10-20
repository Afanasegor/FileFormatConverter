using FileFormatConverter.Data.Context;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileFormatConverter.WebApi.Extensions.AppInit
{
    public static class HangfireExtension
    {
        public static void AddHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("HangfireConnection");

            var optionsBuilder = new DbContextOptionsBuilder<HangfireContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var hangfireDbContext = new HangfireContext(optionsBuilder.Options);

            services.AddHangfire(config => config.UseSqlServerStorage(connectionString));
            services.AddHangfireServer();
        }
    }
}
