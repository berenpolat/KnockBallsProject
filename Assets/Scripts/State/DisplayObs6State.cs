using System.Threading;
using System.Threading.Tasks;
using Base.State;
using UnityEngine;

namespace State
{
    public class DisplayObs6State : GameState
    {
        private bool isShot6 = true;
        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            Debug.Log("Obs 6");
            if (isShot6)
            {
                Context.TransitionTo(new DisplayObs7State());
                _ = Context.CurrentState.RunStateAsync(cancellationToken);
                return Task.CompletedTask;
            }
            else
            {
                Context.TransitionTo(new FailLevelState());
                _ = Context.CurrentState.RunStateAsync(cancellationToken);
                return Task.CompletedTask;
            }
        }
    }
}
