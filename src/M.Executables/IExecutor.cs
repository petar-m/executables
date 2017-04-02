namespace M.Executables
{
    public interface IExecutor
    {
        void Execute<TExecutableVoid>() where TExecutableVoid : IExecutableVoid;

        void Execute<TExecutableVoid, TInput>(TInput input) where TExecutableVoid : IExecutableVoid<TInput>;

        TResult Execute<TExecutable, TResult>() where TExecutable : IExecutable<TResult>;

        TResult Execute<TExecutable, TInput, TResult>(TInput input) where TExecutable : IExecutable<TInput, TResult>;
    }
}
