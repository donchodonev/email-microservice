using Microsoft.Azure.WebJobs;
using SendEmailService.Clients;
using SendEmailService.Settings;

namespace SendEmailService
{
    public class SendEmail
    {
        private readonly AzureKeyVaultClient _keyVaultClient;

        public SendEmail(AzureKeyVaultClient keyVaultClient)
        {
            _keyVaultClient = keyVaultClient;
        }

        [FunctionName(nameof(SendEmail))]
        public void Run(
            [ServiceBusTrigger(
            ServiceBusSettings.Topic,
            ServiceBusSettings.Subscription,
            Connection = "ASBSettings:ConnectionString")] string message)
        {
            var sendgrindApikey = _keyVaultClient.GetSecret(Secrets.SendGridApiKey);
        }
    }
}
