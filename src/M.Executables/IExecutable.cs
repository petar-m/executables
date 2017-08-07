namespace M.Executables
{
    /// <summary>
    /// Represents an executable that is executed without parameters and returns result.
    /// </summary>
    /// <typeparam name="TResult">The type of the execution result.</typeparam>
    public interface IExecutable<TResult>
    {
        /// <summary>
        /// Executes the executable and returns result.
        /// </summary>
        /// <returns>The execution result.</returns>
        TResult Execute();
    }

    /// <summary>
    /// Represents an executable that is executed with parameter and returns result.
    /// </summary>
    /// <typeparam name="TInput">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the execution result.</typeparam>
    public interface IExecutable<TInput, TResult>
    {
        /// <summary>
        /// Executes the executable with parameter and returns result.
        /// </summary>
        /// <param name="input">A parameter to use for execution.</param>
        /// <returns>The execution result.</returns>
        TResult Execute(TInput input);
    }
}