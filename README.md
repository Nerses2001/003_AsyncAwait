# 003_AsyncAwait
## Asynchronous Operations in C#

In this code example, we are exploring asynchronous operations in C# using asynchronous programming and threads.

## Code

```csharp
namespace _003_AsyncAwait
{
    internal class MyClass
    {
        public void Operation()
        {
            Console.WriteLine("Operation ThreadId {0}", Environment.CurrentManagedThreadId);
            Console.WriteLine("Begin");
            Console.WriteLine("End");
        }

        public async void OperationAsync()
        {
            Console.WriteLine("First part of OperationAsync Thread Id = {0}", Environment.CurrentManagedThreadId);
            Task task = new Task(Operation);
            task.Start();

            Console.WriteLine("First/Second part of OperationAsync Thread Id = {0}", Environment.CurrentManagedThreadId);
            await task;

            Console.WriteLine("Second part of OperationAsync Thread Id = {0}", Environment.CurrentManagedThreadId);
        }
    }
}
using _003_AsyncAwait;

Console.WriteLine("General ThreadId {0}", Environment.CurrentManagedThreadId);

MyClass myClass = new();

myClass.OperationAsync();
Thread.Sleep(5000);
Console.WriteLine("General ThreadId {0}", Environment.CurrentManagedThreadId);
```
## Explanation

- The provided code defines the namespace `_003_AsyncAwait`.

- `MyClass` contains two methods: `Operation` and `OperationAsync`.

- `Operation` prints information about the current thread and prints "Begin" and "End".

- `OperationAsync` is an asynchronous method that also prints information about the current thread. It creates a task (`Task`), starts it with the `Operation` method, and awaits the completion of this task.

- When `OperationAsync` is called, it launches `Operation` in a new thread (asynchronously) and waits until this new thread completes before proceeding.

- The results of execution may vary due to asynchrony. For example, "First part of OperationAsync" and "Second part of OperationAsync" may have different thread identifiers (`ThreadId`) since they might be executed in different threads.

- `Thread.Sleep(5000)` pauses the execution of the main thread for 5 seconds.

- Then "General ThreadId" is printed with the current thread identifier after the wait.

- This code illustrates how asynchronous operations allow tasks to run concurrently in different threads, leading to different thread identifiers in various parts of the asynchronous process.
