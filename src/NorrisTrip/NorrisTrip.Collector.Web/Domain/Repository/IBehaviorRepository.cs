using NorrisTrip.Collector.Web.Domain.Entity;

namespace NorrisTrip.Collector.Web.Domain.Repository
{
    public interface IBehaviorRepository
    {
        void Create(BehaviorData behavior);
    }
}