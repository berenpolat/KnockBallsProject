using System.Threading;
using System.Threading.Tasks;
using Base.State;
using UnityEngine;

namespace State
{
    public class DisplayObs7State : GameState
    {
        private bool isShot7 = true;
        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            Debug.Log("Obs 7");
            return Task.CompletedTask;
        }
    }
}
