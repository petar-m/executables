namespace M.Executables
{
    public interface IExecutableVoid
    {
        void Execute();
    }

    public interface IExecutableVoid<TInput>
    {
        void Execute(TInput input);
    }
}