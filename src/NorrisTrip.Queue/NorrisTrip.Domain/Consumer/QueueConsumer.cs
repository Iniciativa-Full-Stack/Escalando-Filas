using NorrisTrip.Domain.Infra.Messages;
using NorrisTrip.Domain.Processor;

namespace NorrisTrip.Domain.Consumer
{
    public class QueueConsumer
    {

        private readonly string _queueName;
        private readonly IMessageReceiver _messageReceiver;
        private readonly IProcessorMessage _processorMessage;

        public QueueConsumer(string queueName, IMessageReceiver messageReceiver, IProcessorMessage processorMessage)
        {
            _queueName = queueName;
            _messageReceiver = messageReceiver;
            _processorMessage = processorMessage;
        }

        public void Start()
        {
            _messageReceiver.Received += _processorMessage.Invoke;
            _messageReceiver.AttachQueue();
        }

        public void Stop()
        {
            _messageReceiver.ReleaseQueue();
        }

        public string Name { get { return _queueName; } }
    }
}
