using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using FFCG.ServiceFabric.MyActor.Interfaces;

namespace FFCG.ServiceFabric.MyActor
{
    [StatePersistence(StatePersistence.Persisted)]
    internal class MyActor : Actor, IMyActor
    {
        public MyActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
        }

        protected override Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");

            return this.StateManager.TryAddStateAsync("count", 0);
        }

        Task<int> IMyActor.GetCountAsync(CancellationToken cancellationToken)
        {
            return this.StateManager.GetStateAsync<int>("count", cancellationToken);
        }

        Task IMyActor.SetCountAsync(int count, CancellationToken cancellationToken)
        {
            return this.StateManager.AddOrUpdateStateAsync("count", count, (key, value) => count > value ? count : value, cancellationToken);
        }
    }
}
