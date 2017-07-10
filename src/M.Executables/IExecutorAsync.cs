using System.Threading.Tasks;

namespace M.Executables
{
    public interface IExecutorAsync
    {
        Task ExecuteAsync<TExecutableVoid>() where TExecutableVoid : class, IExecutableVoid;

        Task ExecuteAsync<TExecutableVoid, TInput>(TInput input) where TExecutableVoid : class, IExecutableVoid<TInput>;

        Task<TResult> ExecuteAsync<TExecutable, TResult>() where TExecutable : class, IExecutable<TResult>;

        Task<TResult> ExecuteAsync<TExecutable, TInput, TResult>(TInput input) where TExecutable : class, IExecutable<TInput, TResult>;
    }
}
