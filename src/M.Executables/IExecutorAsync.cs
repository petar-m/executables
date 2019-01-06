using System.Threading.Tasks;

namespace M.Executables
{
    /// <summary>
    /// Represents an executor for asynchronous execution.
    /// </summary>
    public interface IExecutorAsync
    {
        /// <summary>
        /// Executes an executable asynchronously.
        /// </summary>
        /// <typeparam name="TExecutableVoidAsync">The type of executable to create and execute asynchronously.</typeparam>
        /// <returns>A task representing the asynchronous execution result.</returns>
        Task ExecuteAsync<TExecutableVoidAsync>() where TExecutableVoidAsync : class, IExecutableVoidAsync;

        /// <summary>
        /// Executes an executable asynchronously with parameter.
        /// </summary>
        /// <typeparam name="TExecutableVoidAsync">The type of executable to create and execute asynchronously.</typeparam>
        /// <typeparam name="TInput">The type of the parameter.</typeparam>
        /// <param name="input">A parameter to use for execution.</param>
        /// <returns>A task representing the asynchronous execution result.</returns>
        Task ExecuteAsync<TExecutableVoidAsync, TInput>(TInput input) where TExecutableVoidAsync : class, IExecutableVoidAsync<TInput>;

        /// <summary>
        /// Executes an executable asynchronously and returns result.
        /// </summary>
        /// <typeparam name="TExecutableAsync">The type of executable to create and execute asynchronously.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <returns>A task representing the asynchronous execution result.</returns>
        Task<TResult> ExecuteAsync<TExecutableAsync, TResult>() where TExecutableAsync : class, IExecutableAsync<TResult>;

        /// <summary>
        /// Executes an executable asynchronously with parameter and returns result.
        /// </summary>
        /// <typeparam name="TExecutableAsync">The type of executable to create and execute asynchronously.</typeparam>
        /// <typeparam name="TInput">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="input">A parameter to use for execution.</param>
        /// <returns>A task representing the asynchronous execution result.</returns>
        Task<TResult> ExecuteAsync<TExecutableAsync, TInput, TResult>(TInput input) where TExecutableAsync : class, IExecutableAsync<TInput, TResult>;
    }
}
