namespace M.Executables
{
    /// <summary>
    /// Represents an executor for synchronous execution.
    /// </summary>
    public interface IExecutor
    {
        /// <summary>
        /// Executes an executable synchronously.
        /// </summary>
        /// <typeparam name="TExecutableVoid">The type of executable to create and execute synchronously.</typeparam>
        void Execute<TExecutableVoid>() where TExecutableVoid : class, IExecutableVoid;

        /// <summary>
        /// Executes an executable synchronously with parameter.
        /// </summary>
        /// <typeparam name="TExecutableVoid">The type of executable to create and execute synchronously.</typeparam>
        /// <typeparam name="TInput">The type of the parameter.</typeparam>
        /// <param name="input">A parameter to use for execution.</param>
        void Execute<TExecutableVoid, TInput>(TInput input) where TExecutableVoid : class, IExecutableVoid<TInput>;

        /// <summary>
        /// Executes an executable synchronously and returns result.
        /// </summary>
        /// <typeparam name="TExecutable">The type of executable to create and execute synchronously.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <returns>The execution result.</returns>
        TResult Execute<TExecutable, TResult>() where TExecutable : class, IExecutable<TResult>;

        /// <summary>
        /// Executes an executable synchronously with parameter and returns result.
        /// </summary>
        /// <typeparam name="TExecutable">The type of executable to create and execute synchronously.</typeparam>
        /// <typeparam name="TInput">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="input">A parameter to use for execution.</param>
        /// <returns>The execution result.</returns>
        TResult Execute<TExecutable, TInput, TResult>(TInput input) where TExecutable : class, IExecutable<TInput, TResult>;
    }
}
