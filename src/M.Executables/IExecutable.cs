namespace M.Executables
{
    public interface IExecutable<TResult>
    {
        TResult Execute();
    }

    public interface IExecutable<TInput, TResult>
    {
        TResult Execute(TInput input);
    }
}