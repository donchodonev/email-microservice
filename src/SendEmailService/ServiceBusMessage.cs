namespace SendEmailService
{
    public class ServiceBusMessage
    {
        public string FromAlias { get; set; }

        public string FromName { get; set; }

        public string RecipientEmailAddress { get; set; }

        public string RecipientName { get; set; }

        public string Message { get; set; }
    }
}
