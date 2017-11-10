using NorrisTrip.Domain.Domain.Entity;

namespace NorrisTrip.Domain.Infra.Repository
{
    public interface IBehaviorRepository
    {
        void Create(BehaviorData behavior);
    }
}