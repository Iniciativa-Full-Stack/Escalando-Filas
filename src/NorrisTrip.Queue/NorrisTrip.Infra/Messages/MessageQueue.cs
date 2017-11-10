using System;
using System.Text;
using Newtonsoft.Json;
using NorrisTrip.Domain.Domain.Entity;
using NorrisTrip.Domain.Infra.Messages;
using RabbitMQ.Client;

namespace NorrisTrip.Infra.Messages
{
    public class MessageQueue : IMessageQueue, IDisposable
    {
        private readonly string _nameExchange;
        private readonly string _route;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly object _locker;

        public MessageQueue(string connectionString, string nameExchange, string route)
        {
            _nameExchange = nameExchange;
            _route = route;
            var factory = new ConnectionFactory
            {
                Uri = connectionString,
                AutomaticRecoveryEnabled = true
            };
            _locker = new object();
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Publish(BehaviorData data)
        {
            lock (_locker)
            {
                var bodyData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

                var basicProperties = _channel.CreateBasicProperties();

                basicProperties.DeliveryMode = 1;
                basicProperties.ContentType = "application/json";

                _channel.BasicPublish(exchange: _nameExchange,
                                      routingKey: _route,
                                      basicProperties: basicProperties,
                                      body: bodyData);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._channel.Dispose();
                this._connection.Dispose();
            }

        }
    }
}
