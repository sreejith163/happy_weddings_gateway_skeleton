namespace Happy.Weddings.Gateway.Core.Infrastructure
{
    public class RabbitMqConfig
    {
        /// <summary>
        /// Gets or sets the hostname.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets the name of the queue.
        /// </summary>
        public string QueueName { get; set; }

        /// <summary>
        /// Gets or sets the name of the exchange.
        /// </summary>
        public string ExchangeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}
