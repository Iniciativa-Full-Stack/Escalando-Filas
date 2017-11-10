using System;

namespace NorrisTrip.Domain.Infra.Messages
{
    public interface IMessageReceiver
    {
        event Action<string> Received;

        void AttachQueue();

        void ReleaseQueue();

    }
}
