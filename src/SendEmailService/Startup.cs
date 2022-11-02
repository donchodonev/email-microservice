using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using SendEmailService;

[assembly: FunctionsStartup(typeof(Startup))]
namespace SendEmailService
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
        }
    }
}
