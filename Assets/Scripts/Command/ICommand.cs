using System.Threading;
using System.Threading.Tasks;

namespace Base.Command
{
    public interface ICommand
    {
        public Task ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
