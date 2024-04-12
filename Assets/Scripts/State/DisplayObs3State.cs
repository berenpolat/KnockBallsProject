using System.Threading;
using System.Threading.Tasks;
using Base.State;
using UnityEngine;

namespace State
{
    public class DisplayObs3State : GameState
    {
        private bool isShot3 = true;
        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            Debug.Log("Obs3");
            if (isShot3)
            {
                Context.TransitionTo(new DisplayObs4State());
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
