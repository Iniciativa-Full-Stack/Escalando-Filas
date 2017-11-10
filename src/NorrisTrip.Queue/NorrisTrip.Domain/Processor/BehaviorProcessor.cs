using System.Threading.Tasks;
using Newtonsoft.Json;
using NorrisTrip.Domain.Domain.Entity;
using NorrisTrip.Domain.Infra.Repository;

namespace NorrisTrip.Domain.Processor
{
    public class BehaviorProcessor : IProcessorMessage
    {
        private readonly IBehaviorRepository _repository;

        public BehaviorProcessor(IBehaviorRepository repository)
        {
            _repository = repository;
        }

        public void Invoke(string bodyMessage)
        {
            var behaviorData = JsonConvert.DeserializeObject<BehaviorData>(bodyMessage);

            Task.Run(() => _repository.Create(behaviorData));
        }
    }
}
