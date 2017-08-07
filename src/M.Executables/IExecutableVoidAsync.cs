using System.Threading.Tasks;

namespace M.Executables
{
    /// <summary>
    /// Represents an executable that is executed asynchonously without parameters and doesn't return result.
    /// </summary>
    public interface IExecutableVoidAsync
    {
        /// <summary>
        /// Executes the executable asynchronously.
        /// </summary>
        /// <returns>A task representing the execution result.</returns>
        Task ExecuteAsync();
    }

    /// <summary>
    /// Represents an executable that is executed asynchonously with parameter and doesn't return result.
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface IExecutableVoidAsync<TInput>
    {
        /// <summary>
        /// Executes the executable asynchonously with parameter.
        /// </summary>
        /// <param name="input">A parameter to use for execution.</param>
        /// <returns>A task representing the execution result.</returns>
        Task ExecuteAsync(TInput input);
    }
}