using System.Threading.Tasks;

namespace M.Executables
{
    public interface IExecutableVoidAsync
    {
        Task ExecuteAsync();
    }

    public interface IExecutableVoidAsync<TInput>
    {
        Task ExecuteAsync(TInput input);
    }
}