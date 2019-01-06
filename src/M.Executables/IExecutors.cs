namespace M.Executables
{
    /// <summary>
    /// Represents an interface for both synchronous and asynchronous execution.
    /// </summary>
    public interface IExecutors : IExecutor, IExecutorAsync
    {
    }
}
