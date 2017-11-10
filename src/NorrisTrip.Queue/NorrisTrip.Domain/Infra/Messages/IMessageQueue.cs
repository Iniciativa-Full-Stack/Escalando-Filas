using NorrisTrip.Domain.Domain.Entity;

namespace NorrisTrip.Domain.Infra.Messages
{
    public interface IMessageQueue
    {
        void Publish(BehaviorData behaviorData);
    }
}
