using Happy.Weddings.Gateway.Core.Domain.Identity;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Messaging.Sender.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Happy.Weddings.Gateway.Messaging.Sender.Identity
{
    public class UsernameUpdateSender : IUsernameUpdateSender
    {
        /// <summary>
        /// The hostname
        /// </summary>
        private readonly string _hostname;

        /// <summary>
        /// The queue name
        /// </summary>
        private readonly string _queueName;

        /// <summary>
        /// The username
        /// </summary>
        private readonly string _username;

        /// <summary>
        /// The password
        /// </summary>
        private readonly string _password;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsernameUpdateSender"/> class.
        /// </summary>
        /// <param name="rabbitMqOptions">The rabbit mq options.</param>
        public UsernameUpdateSender(IOptions<RabbitMqConfig> rabbitMqOptions)
        {
            _hostname = rabbitMqOptions.Value.Hostname;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            _queueName = rabbitMqOptions.Value.QueueName;
        }

        /// <summary>
        /// Sends the name of the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void SendUserName(User user)
        {
            var messagefactory = new ConnectionFactory() { HostName = _hostname, UserName = _username, Password = _password };

            using (var connection = messagefactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var json = JsonConvert.SerializeObject(user);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
                }
            }
        }
    }
}
