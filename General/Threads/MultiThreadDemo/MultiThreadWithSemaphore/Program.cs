// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Semaphore gate = new Semaphore(1,2); // Object used for synchronization
Thread thread1 = new Thread(Producer);
Thread thread2 = new Thread(Consumer);

thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();

void Producer()
{
    {
        for (int i = 0; i < 10; i++)
        {
            gate.WaitOne();
            Console.WriteLine($"Thread 1 starting {i}.");
            Console.WriteLine($"Thread 1 closing {i}.");
            gate.Release();
        }
    }
}

void Consumer()
{
    for (int i = 0; i < 10; i++)
    {
        gate.WaitOne();
        Console.WriteLine($"Thread 2 starting {i}.");
        Console.WriteLine($"Thread 2 closing {i}.");
        gate.Release();
    }
}
