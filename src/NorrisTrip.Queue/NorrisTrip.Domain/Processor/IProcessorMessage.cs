namespace NorrisTrip.Domain.Processor
{
    public interface IProcessorMessage
    {
        void Invoke(string bodyMessage);
    }
}
