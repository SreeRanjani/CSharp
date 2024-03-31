using MultiThreadDemo;

Console.WriteLine("Thread demo, starting main thread");
// Getting current thread
Thread ctTh = Thread.CurrentThread;
// Setting current thread name
// ctTh.Name = "Thread Demo: Main Thread";
Console.WriteLine($"Current thread name is {ctTh.Name}");

int method3Arg = 5;
Method4Helper method4Helper = new Method4Helper(3);

// Invoking methods in worker threads

Thread method1Th = new(PrintTenNumbers)
{ Name = "PrintTenNumbers" };

Thread method2Th = new(Method2)
{ Name = "Method 2 Thread" };

// Passing parameters
// using lambda
Thread method3Th = new(() => Method3(method3Arg))
{ Name = "Method 3 Thread" };

// using helper class
Thread method4Th = new(method4Helper.Method4)
{ Name = "Method 4 Thread" };

// Using parameterized thread object
Thread method5Th = new(Method5)
{ Name = "Method 5 Thread" };

//Returning values
MethodCallback callback = (result) => { Console.WriteLine($"Method 6 callback result: {result}"); };
Thread method6Th = new(() => Method6(callback))
{ Name = "Method 6 Thread" };

method1Th.Start();
method2Th.Start();
method3Th.Start();
method4Th.Start();
method5Th.Start(5);
method6Th.Start();
method2Th.Join();
Console.WriteLine("Main Thread Ended");

void PrintTenNumbers()
{
    for (int i = 0; i<10; i++)
    {
        Console.WriteLine($"Method 1 iteration {i}");
        Thread.Sleep(100);
    }
}

/*void Method1Helper()
{
    Method1(method1Arg);
}*/

void Method2()
{
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine($"Method 2 iteration {i} start.");
        Thread.Sleep(1000);
        Console.WriteLine($"Method 2 iteration {i} end.");
    }
}

void Method3(int max)
{
    for (int i = 0; i < max; i++)
    {
        Console.WriteLine($"Method 3 iteration {i}.");
        Thread.Sleep(500);
    }
}

void Method5(object numOfIterations)
{
    for (int i = 0; i < (int)numOfIterations; i++)
    {
        Console.WriteLine($"Method 5 iteration {i}.");
        Thread.Sleep(500);
    }
}

void Method6(MethodCallback returnCallback)
{
    returnCallback(5);
}

delegate void MethodCallback(int result);