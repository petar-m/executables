using System.Threading.Tasks;

namespace M.Executables
{
    public interface IExecutableAsync<TResult>
    {
        Task<TResult> ExecuteAsync();
    }

    public interface IExecutableAsync<TInput, TResult>
    {
        Task<TResult> ExecuteAsync(TInput input);
    }
}