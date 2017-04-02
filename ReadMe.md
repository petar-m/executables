## Executables

A few interfaces for implementing a variation of the Command design pattern.  
The Executables serve as entry point for the domain/object model. Tipically they will depend on repositories, services, etc. and will orchestrate the domain logic (use cases).    

### Why IExecutable, IExecutableVoid?  

The initial naming was `IQuery` and `ICommand`, but in practice there are cases when commands **may** need return something.  
(E.g. post-redirect-get scenario, when id generation is not in your control, or batch procesing, when you need some kind of summary.)  
So if you want to separate commands form queries in different namespaces, having a `Commands` namespace containing `IQuery` implementations is confusing.  
`IExecutable` is an attempt to express more general concept, and `IExecutableVoid` is just a lack of creativity.  

### Why IExecutor, IExecutorAsync?  

The intent if `IExecutor` is to provide middleware for execution, where the specific implementation can handle  scoping, transactions, error handling, logging, metrics, etc.  
The executor is responsible for instantiation of executables, usually by delegating it to IoC container. 
How an executable is executed (sync/async) is also a concern of the executor, therefore `IExecutorAsync`.  
   
Depending on the use cases/environment both interfaces can be implemented, or only one, or even you may not need executor at all.  

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



