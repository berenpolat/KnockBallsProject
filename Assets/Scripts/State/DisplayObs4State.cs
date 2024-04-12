using System.Threading;
using System.Threading.Tasks;
using Base.State;
using UnityEngine;

namespace State
{
    public class DisplayObs4State : GameState
    {
        private bool isShot4 = true;
        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            Debug.Log("Obs 4");
            if (isShot4)
            {
                Context.TransitionTo(new DisplayObs5State());
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
