using System;

namespace M.Executables
{
    public interface IInstanceProvider
    {
        object GetInstance(Type type);
    }
}