using System;
using Microsoft.Azure.WebJobs;

namespace SendEmailService
{
    public class SendEmail
    {
        [FunctionName(nameof(SendEmail))]
        public void Run(
            [ServiceBusTrigger(
            ServiceBusSettings.Topic,
            ServiceBusSettings.Subscription,
            Connection = "ASBSettings:ConnectionString")] string message)
        {
            Console.WriteLine(message);
        }
    }
}
