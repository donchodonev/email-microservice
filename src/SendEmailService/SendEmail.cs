using Microsoft.Azure.WebJobs;

namespace SendEmailService
{
    public class SendEmail
    {
        //DO NOT COMMIT
        [FunctionName(nameof(SendEmail))]
        public void Run(
            [ServiceBusTrigger(
            "ASBSettings:TopicName",
            "ASBSettings:SubscriptionName",
            Connection = "ASBSettings:ConnectionString")] EmailMessage message)
        {
            //TODO
        }
    }
}
