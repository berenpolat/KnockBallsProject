using System.Threading;
using System.Threading.Tasks;
using Base.State;
using UnityEngine;

namespace State
{
    public class DisplayObs1State : GameState
    {
        private bool isShot1 = true;
        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            Debug.Log("Obs 1");
            if (isShot1)
            {
                Context.TransitionTo(new DisplayObs2State());
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
