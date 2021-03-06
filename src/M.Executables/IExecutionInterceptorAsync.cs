﻿using System;
using System.Threading.Tasks;

namespace M.Executables
{
    /// <summary>
    /// Represents an interception allowing actions to be performed before and after execution.
    /// </summary>
    public interface IExecutionInterceptorAsync
    {
        /// <summary>
        /// Gets the execution order - lower to higher (lower indexes are executed first)
        /// </summary>
        int OrderingIndex { get; }

        /// <summary>
        /// An action to be performed before execution.
        /// </summary>
        /// <typeparam name="TExecutable">The type of the executable instance to be executed.</typeparam>
        /// <typeparam name="TInput">The type of the executable parameter. IEmpty if the executable does not have parameter.</typeparam>
        /// <param name="executable">The executable instance to be executed - implementation of one of the IExectable* interfaces.</param>
        /// <param name="input">The TInput instance to be passed to the executable. IEmpty with value null if the executable does not have parameter.</param>
        /// <returns>A task representing the asynchronous execution result.</returns>
        Task BeforeAsync<TExecutable, TInput>(TExecutable executable, TInput input);

        /// <summary>
        /// An action to be performed after execution.
        /// </summary>
        /// <typeparam name="TExecutable">The type of the executable instance that was executed.</typeparam>
        /// <typeparam name="TInput">The type of the executable parameter. IEmpty if the executable does not have parameter.</typeparam>
        /// <typeparam name="TResult">The type of the executable return value. IEmpty if the executable is void.</typeparam>
        /// <param name="executable">The executable instance that was executed - implementation of one of the IExectable* interfaces.</param>
        /// <param name="input">The TInput instance that was passed to the executable. IEmpty with value null if the executable does not have parameter.</param>
        /// <param name="result">The executable return value. IEmpty with value null if the executable is void, default(TResult) if exception was thrown during execution.</param>
        /// <param name="exception">The instance of the thrown exception, null if there was no exception.</param>
        /// /// <returns>A task representing the asynchronous execution result.</returns>
        Task AfterAsync<TExecutable, TInput, TResult>(TExecutable executable, TInput input, TResult result, Exception exception);
    }

    /// <summary>
    /// Represents an interception allowing actions to be performed before and after execution.
    /// </summary>
    /// <typeparam name="TExecutable">The type of the executable instance that was executed.</typeparam>
    /// <typeparam name="TInput">The type of the executable parameter. IEmpty if the executable does not have parameter.</typeparam>
    /// <typeparam name="TResult">The type of the executable return value. IEmpty if the executable is void.</typeparam>
    public interface IExecutionInterceptorAsync<TExecutable, TInput, TResult>
    {
        /// <summary>
        /// Gets the execution order - lower to higher (lower indexes are executed first)
        /// </summary>
        int OrderingIndex { get; }

        /// <summary>
        /// An action to be performed before execution.
        /// </summary>
        /// <param name="executable">The executable instance to be executed - implementation of one of the IExectable* interfaces.</param>
        /// <param name="input">The TInput instance to be passed to the executable. IEmpty with value null if the executable does not have parameter.</param>
        /// <returns>A task representing the asynchronous execution result.</returns>
        Task BeforeAsync(TExecutable executable, TInput input);

        /// <summary>
        /// An action to be performed after execution.
        /// </summary>
        /// <param name="executable">The executable instance that was executed - implementation of one of the IExectable* interfaces.</param>
        /// <param name="input">The TInput instance that was passed to the executable. IEmpty with value null if the executable does not have parameter.</param>
        /// <param name="result">The the executable return value. IEmpty with value null if the executable is void, default(TResult) if exception was thrown during execution.</param>
        /// <param name="exception">The instance of the thrown exception, null if there was no exception.</param>
        /// <returns>A task representing the asynchronous execution result.</returns>
        Task AfterAsync(TExecutable executable, TInput input, TResult result, Exception exception);
    }
}
