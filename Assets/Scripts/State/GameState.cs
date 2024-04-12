using System.Threading;
using System.Threading.Tasks;

namespace Base.State
{
    public interface IGameState
    {
        public void SetContext(IContext context);
        public Task RunStateAsync(CancellationToken cancellationToken = default);
    }
    
    public abstract class GameState : IGameState
    {
        protected IContext Context { get; private set; } = null!;

        protected GameState()
        {
            //$"New state: {GetType().Name}".PrintToConsoleInfo();
        }

        ~GameState()
        {
            //$"{GetType().FullName} destroyed and collected!".PrintToConsole();
        }
        
        public void SetContext(IContext context)
        {
            Context = context;
        }

        public abstract Task RunStateAsync(CancellationToken cancellationToken = default);
    }
}
