using System.Threading.Tasks;

namespace M.Executables
{
    /// <summary>
    /// Represents an executable that is executed asynchronously without parameters and returns result.
    /// </summary>
    /// <typeparam name="TResult">The type of the execution result.</typeparam>
    public interface IExecutableAsync<TResult>
    {
        /// <summary>
        /// Executes the executable asynchronously and returns result.
        /// </summary>
        /// <returns>The execution result.</returns>
        Task<TResult> ExecuteAsync();
    }

    /// <summary>
    /// Represents an executable that is executed asynchronously with parameter and returns result.
    /// </summary>
    /// <typeparam name="TInput">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the execution result.</typeparam>
    public interface IExecutableAsync<TInput, TResult>
    {
        /// <summary>
        /// Executes the executable asynchronously with parameter and returns result.
        /// </summary>
        /// <param name="input">A parameter to use for execution.</param>
        /// <returns>The execution result.</returns>
        Task<TResult> ExecuteAsync(TInput input);
    }
}