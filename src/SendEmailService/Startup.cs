using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SendEmailService;
using SendEmailService.Clients;
using SendEmailService.Services;
using SendEmailService.Settings;

[assembly: FunctionsStartup(typeof(Startup))]
namespace SendEmailService
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var configuration = builder.GetContext().Configuration;

            builder.Services.Configure<KeyVaultSettings>(configuration.GetSection("KeyVaultSettings"));
            builder.Services.AddSingleton<AzureKeyVaultClient>();
            builder.Services.AddTransient<IEmailSenderService, EmailSenderService>();
        }
    }
}
