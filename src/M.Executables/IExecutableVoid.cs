namespace M.Executables
{
    /// <summary>
    /// Represents an executable that is executed without parameters and doesn't return result.
    /// </summary>
    public interface IExecutableVoid
    {
        /// <summary>
        /// Executes the executable.
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// Represents an executable that is executed with parameter and doesn't return result.
    /// </summary>
    /// <typeparam name="TInput">The type of the parameter.</typeparam>
    public interface IExecutableVoid<TInput>
    {
        /// <summary>
        /// Executes the executable with parameter.
        /// </summary>
        /// <param name="input">A parameter to use for execution.</param>
        void Execute(TInput input);
    }
}