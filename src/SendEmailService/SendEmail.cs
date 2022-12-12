using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using SendEmailService.Services;
using SendEmailService.Settings;

namespace SendEmailService
{
    public class SendEmail
    {
        private readonly IEmailSenderService _emailService;

        public SendEmail(IEmailSenderService emailService)
        {
            _emailService = emailService;
        }

        [FunctionName(nameof(SendEmail))]
        public async Task Run(
            [ServiceBusTrigger(
            ServiceBusSettings.Topic,
            ServiceBusSettings.Subscription,
            Connection = "ASBSettings:ConnectionString")] string serviceBusMessage)
        {
            var message = JsonSerializer.Deserialize<ServiceBusMessage>(serviceBusMessage);
            await _emailService.SendEmailAsync(message.FromAlias, message.FromName, message.RecipientEmailAddress, message.RecipientName, message.Message);
        }
    }
}
