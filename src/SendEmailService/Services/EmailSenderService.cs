using System.Threading.Tasks;
using SendEmailService.Clients;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendEmailService.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly AzureKeyVaultClient _kvClient;

        public EmailSenderService(AzureKeyVaultClient kvClient)
        {
            _kvClient = kvClient;
        }

        public Task<Response> SendEmailAsync(
            string fromEmailAlias,
            string fromName,
            string recipientEmail,
            string recipientName,
            string emailContent,
            string subject = "No Subject")
        {
            var apiKey = _kvClient.GetSecret(Secrets.SendGridApiKey).Value.Value;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress($"{fromEmailAlias}@em5405.sendgrid.ml", fromName),
                Subject = subject,
                PlainTextContent = emailContent
            };

            msg.AddTo(new EmailAddress(recipientEmail, recipientName));

            return client.SendEmailAsync(msg);
        }
    }
}
