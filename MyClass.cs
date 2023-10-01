

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
            Task task = new (Operation);
            task.Start();

            Console.WriteLine("First/Second part of OperationAsync Thread Id = {0}", Environment.CurrentManagedThreadId);
            await task;

            Console.WriteLine("Second part of OperationAsync Thread Id = {0}", Environment.CurrentManagedThreadId);
        }
    }
}
