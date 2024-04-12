using System.Threading;
using System.Threading.Tasks;
using Base.State;
using UnityEngine;

namespace State
{
    public class DisplayObs5State : GameState
    {
        private bool isShot5 = true;
        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            Debug.Log("Obs 5");
            if (isShot5)
            {
                Context.TransitionTo(new DisplayObs6State());
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
