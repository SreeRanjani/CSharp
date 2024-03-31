// See https://aka.ms/new-console-template for more information
using MultiThreadWithMonitor;

Console.WriteLine("Main program started.");

object threadLock = new object();

Thread thread1 = new Thread(SharedMethod)
{ Name = "thread1" };

Thread thread2 = new Thread(SharedMethod)
{ Name = "thread2" };

thread1.Start();
thread2.Start();
thread1.Join();
thread2.Join();
Console.WriteLine("Main program ended.");

void SharedMethod()
{
    lock (threadLock)
    {
        Thread ctTh = Thread.CurrentThread;
        Console.WriteLine($"Thread {ctTh.Name} is requesting for resource.");
        Thread.Sleep(1000);
        Console.WriteLine($"Thread {ctTh.Name} used resource");
    }
}

// Create two threads
Thread producerThread = new Thread(MultiThreadWithMonitorClass.Producer);
Thread consumerThread = new Thread(MultiThreadWithMonitorClass.Consumer);

// Start both threads
producerThread.Start();
consumerThread.Start();