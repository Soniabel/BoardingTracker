using BoardingTracker.Infrastructure.SendGrid.Interfaces;
using BoardingTracker.Infrastructure.SendGrid.Models;
using BoardingTracker.Infrastructure.SendGrid.Services;
using SendGrid.Extensions.DependencyInjection;

namespace BoardingTracker.WebApi.Infrastructure.SendGrid.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddCustomSendGrid(this IServiceCollection services, IConfiguration configuration)
        {
            var sendGridModel = new SendGridModel();
            services.AddSendGrid(options =>
            {
                options.ApiKey = configuration.GetSection("SendGridEmailSettings")
                .GetValue<string>("APIKey");
                configuration.Bind("SendGridEmailSettings", sendGridModel);
            });

            services.AddSingleton(sendGridModel);

            services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
