using System;

namespace M.Executables
{
    public class DelegateInstanceProvider : IInstanceProvider
    {
        private readonly Func<Type, object> instanceProvider;

        public DelegateInstanceProvider(Func<Type, object> instanceProvider)
        {
            this.instanceProvider = instanceProvider;
        }

        public object GetInstance(Type type)
        {
            return instanceProvider(type);
        }
    }
}
