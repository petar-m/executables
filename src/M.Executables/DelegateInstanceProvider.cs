using System;

namespace M.Executables
{
    /// <summary>
    /// Creates instance of given type using a delegate for creation.
    /// </summary>
    public class DelegateInstanceProvider : IInstanceProvider
    {
        private readonly Func<Type, object> instanceProvider;

        /// <summary>
        /// Creates a new instance of DelegateInstanceProvider.
        /// </summary>
        /// <param name="instanceProvider">A delegate used to create instance of given type.</param>
        public DelegateInstanceProvider(Func<Type, object> instanceProvider)
        {
            this.instanceProvider = instanceProvider;
        }

        /// <summary>
        /// Creates instance of the given type.
        /// </summary>
        /// <param name="type">The type to create instance of.</param>
        /// <returns>An instance of the given type.</returns>
        public object GetInstance(Type type)
        {
            return instanceProvider(type);
        }
    }
}
