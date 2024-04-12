using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Base.State
{
    public interface IContext 
    {
        public IGameState CurrentState { get; }
        public IContext TransitionTo(IGameState state);
        public Task RunStateAsync(CancellationToken cancellationToken = default);
    }

    public class Context : IContext
    {
        public IGameState CurrentState { get; private set; } = null!;
        

        public Context()
        {
           
        }

        public IContext TransitionTo(IGameState state)
        {
            CurrentState = state;
            CurrentState.SetContext(this);
            return this;
        }

        public async Task RunStateAsync(CancellationToken cancellationToken = default) =>
            await CurrentState.RunStateAsync(cancellationToken);

    }
}