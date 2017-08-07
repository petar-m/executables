using System;

namespace M.Executables
{
    /// <summary>
    /// Represents creating an instance of type.
    /// </summary>
    public interface IInstanceProvider
    {
        /// <summary>
        /// Gets an instance of the given type.
        /// </summary>
        /// <param name="type">The type to create instance of.</param>
        /// <returns>An instance of the given type.</returns>
        object GetInstance(Type type);
    }
}