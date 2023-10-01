using _003_AsyncAwait;

Console.WriteLine("General ThreadId {0}", Environment.CurrentManagedThreadId);

MyClass myClass = new();

myClass.OperationAsync();
Thread.Sleep(5000);
Console.WriteLine("General ThreadId {0}",Environment.CurrentManagedThreadId);