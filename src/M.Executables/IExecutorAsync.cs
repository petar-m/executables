using System.Threading.Tasks;

namespace M.Executables
{
    public interface IExecutorAsync
    {
        Task ExecuteAsync<TExecutable>() where TExecutable : IExecutableVoid;

        Task ExecuteAsync<TExecutable, TInput>(TInput input) where TExecutable : IExecutableVoid<TInput>;

        Task<TResult> ExecuteAsync<TExecutable, TResult>() where TExecutable : IExecutable<TResult>;

        Task<TResult> ExecuteAsync<TExecutable, TInput, TResult>(TInput input) where TExecutable : IExecutable<TInput, TResult>;
    }
}
