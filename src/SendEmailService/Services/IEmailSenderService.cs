using System.Threading.Tasks;
using SendGrid;

namespace SendEmailService.Services
{
    public interface IEmailSenderService
    {
        public Task<Response> SendEmailAsync(
            string fromEmailAlias,
            string fromName,
            string recipientEmail,
            string recipientName,
            string emailContent,
            string subject = "No Subject")
    }
}