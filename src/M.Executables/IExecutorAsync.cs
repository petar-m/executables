using System.Threading.Tasks;

namespace M.Executables
{
    public interface IExecutorAsync
    {
        Task ExecuteAsync<TExecutableVoid>() where TExecutableVoid : IExecutableVoid;

        Task ExecuteAsync<TExecutableVoid, TInput>(TInput input) where TExecutableVoid : IExecutableVoid<TInput>;

        Task<TResult> ExecuteAsync<TExecutable, TResult>() where TExecutable : IExecutable<TResult>;

        Task<TResult> ExecuteAsync<TExecutable, TInput, TResult>(TInput input) where TExecutable : IExecutable<TInput, TResult>;
    }
}
