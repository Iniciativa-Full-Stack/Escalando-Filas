using System;
using System.Text;
using NorrisTrip.Domain.Infra.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;

namespace NorrisTrip.Infra.Messages
{
    public class MessageReceiver : IMessageReceiver, IDisposable
    {
        private readonly string _queueName;
        private readonly TimeSpan _timeOut;
        private readonly object _locker;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly Subscription _subscription;
        private bool _cancelationToken;
        public event Action<string> Received;

        public MessageReceiver(string connectionString, string queueName, TimeSpan timeOut)
        {
            _queueName = queueName;
            _timeOut = timeOut;
            var factory = new ConnectionFactory
            {
                Uri = connectionString,
                AutomaticRecoveryEnabled = true
            };
            _locker = new object();
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _subscription = new Subscription(_channel, queueName, false);
        }


        public void AttachQueue()
        {
            while (!_cancelationToken)
            {
                BasicDeliverEventArgs message;
                while (_subscription.Next((int)_timeOut.TotalMilliseconds, out message))
                {
                    lock (_locker)
                    {
                        if (!_cancelationToken)
                        {
                            try
                            {
                                if (Received != null)
                                {
                                    var content = Encoding.UTF8.GetString(message.Body);
                                    Received(content);
                                    _subscription.Ack(message);
                                }
                            }
                            catch
                            {
                                _subscription.Model.BasicNack(message.DeliveryTag, false, true);
                            }
                        }
                    }

                }
            }
        }

        public void ReleaseQueue()
        {
            _cancelationToken = true;
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
