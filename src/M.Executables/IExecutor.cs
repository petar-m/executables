namespace M.Executables
{
    public interface IExecutor
    {
        void Execute<TExecutableVoid>() where TExecutableVoid : class, IExecutableVoid;

        void Execute<TExecutableVoid, TInput>(TInput input) where TExecutableVoid : class, IExecutableVoid<TInput>;

        TResult Execute<TExecutable, TResult>() where TExecutable : class, IExecutable<TResult>;

        TResult Execute<TExecutable, TInput, TResult>(TInput input) where TExecutable : class, IExecutable<TInput, TResult>;
    }
}
