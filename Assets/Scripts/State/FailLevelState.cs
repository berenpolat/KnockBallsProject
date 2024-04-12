using System.Threading;
using System.Threading.Tasks;
using Base.State;
using UnityEngine;

namespace State
{
    public class FailLevelState :GameState
    {
        
        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            Debug.Log("Failed Level");
            return null;
        }
    }
}
