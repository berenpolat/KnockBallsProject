using System.Threading;
using System.Threading.Tasks;
using Base.State;
using Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace State
{
    public class DisplayObs1State : GameState
    {
        private int shootCount = 3;
        
        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            Debug.Log("Obs 1");
            return null;
        }
        
    
    }
}
