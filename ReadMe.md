## Executables  

[![NuGet](https://img.shields.io/nuget/v/M.Executables.svg)](https://www.nuget.org/packages/M.Executables)

A few interfaces for implementing a variation of the Command design pattern.  
The Executables serve as entry point for the domain/object model. Tipically they will depend on repositories, services, etc. and will orchestrate the domain logic (use cases).    
Interceptors allow actions to be executed before and after Executable.  
Interceptors may be common for all Executables or targeting specific ones. 

### Why IExecutable, IExecutableVoid?  

The initial naming was `IQuery` and `ICommand`, but in practice there are cases when commands **may** need return something.  
(E.g. post-redirect-get scenario, when id generation is not in your control, or batch procesing, when you need some kind of summary.)  
So if you want to separate commands form queries in different namespaces, having a `Commands` namespace containing `IQuery` implementations is confusing.  
`IExecutable` is an attempt to express more general concept, and `IExecutableVoid` is just a lack of creativity.  

### Why IExecutor, IExecutorAsync?  

The intent if `IExecutor` is to provide middleware for execution, where the specific implementation can handle  scoping, transactions, error handling, logging, metrics, etc.  
The executor is responsible for instantiation of executables, usually by delegating it to IoC container. 
   
Depending on the use cases/environment both interfaces can be implemented, or only one, or even you may not need executor at all.  
  
### Changes  

#### 2.0

- New `IExecutableAsync` and `IExecutableVoidAsync` interfaces - the choice of interface now allows the implementer to convey intent of how the executable should be executed.  

- **(Breaking)** Now `IExecutorAsync` accepts the `*Async` versions of `IExecutable`, allowing the implementation to take advantage of async/await. It is easier now to avoid exposing asynchronous wrapper over synchronous API, which is considered bad practice.  

- **(Breaking)** Now `IExecutor*` interfaces have additional generic constraint `class` on their methods for `IExecutable*` - there is no point for `struct` to implement interface and also plays nice with some IoC containers.
  
#### 2.1  

- `IExecutors` - a single interface for convenience when an executor implements both  `IExecutor` and `IExecutorAsync`  
- `IExecutionInterceptor` - interface for implementing interception of execution.

#### 2.2  

New interface introduced in order to allow separation async and sync implementations.  
New interfaces introduced to allow interceptors to target specific executables.  
New interfaces introduced to allow implementation of interceptors to hint the executors of how to handle them. 


- `IExecutionInterceptorAsync` - new interface for implementing async interception of execution. It complements `IExecutionInterceptor` for async execution.
- `IExecutionInterceptorAsync<TExecutable, TInput, TResult>` and `IExecutionInterceptorAsync<TExecutable, TInput, TResult>` - new interfaces to allow implementation of interceptors targeting specific executables.
- `IDiscardOtherInterceptors` - new interface to hint the executor that the inteceptor should be the only one executed.
- `IDiscardNonGenericInterceptors` - new interface to hint the executor that non-generic interceptors should not be executed. 

The idea behind non-generic interceptors is that they will be runned for all executables.  
There may be cases when common logic will not work or should be different - the generic interceptors are intended to target concrete executable. The new marker interfaces should allow executors to handle scenarios like replacing non-generic interceptors with specific ones or having exclusive ones per executable.  
  

### IInstancePovider?  

`IInstancePovider` and it's implementation `DelegateInstanceProvider` are added for convenience, when executables may have some dependencies, but it is not worth it to add IoC container.  

Example:  
Very simple command:

    public class MyCommand : IExecutableVoid
    {
        private ILogger logger;

        public MyCommand(ILogger logger)
        {
            this.logger = logger;
        }

        public void Execute()
        {
            // log something
        }
    }  

Very simple executor:

    public class MyExecutor : IExecutor
    {
        private readonly IInstanceProvider instanceProvider;

        public MyExecutor(IInstanceProvider instanceProvider)
        {
            this.instanceProvider = instanceProvider;
        }

        public void Execute<TExecutableVoid>() where TExecutableVoid : IExecutableVoid
        {
            var executable = (TExecutableVoid)instanceProvider.GetInstance(typeof(TExecutableVoid));
            executable.Execute();
        }
		...
       
 
Setup:  

	// initialize at startup
	
	// "singleton"
	var logger = new Logger();
	
	// "transient" MyCommand
	var provider = new DelegateInstanceProvider(
	    type => type == typeof(MyCommand) ? new MyCommand(logger) : throw new InvalidOperationException());
			
	var executor = new MyExecutor(provider);
	...
	
	// usage
	executor.Execute<MyCommand>();



