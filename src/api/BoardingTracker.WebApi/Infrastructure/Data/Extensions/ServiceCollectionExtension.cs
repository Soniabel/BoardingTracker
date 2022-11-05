using BoardingTracker.Persistence;
using BoardingTracker.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.WebApi.Infrastructure.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static async Task<IServiceCollection> AddDatabase(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["Db:DefaultConnectionString"];
            services.AddDbContext<DBBoardingTrackerContext>(options =>
                options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly(typeof(DBBoardingTrackerContext).Assembly.FullName)));

            var context = services.BuildServiceProvider().GetService<DBBoardingTrackerContext>();
            await context.SeedDatabase();

            return services;
        }
    }
}
