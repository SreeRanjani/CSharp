# Thread in General

Operating system has multiple processes. Each application runs in a process, it can use single or multiple threads in the process.

# Why are multiple threads needed?

# Default Thread

When a C# application runs, it runs in the `Main thread`
![MainThread](image.png)

# Threads Window

This can be opened when a program is running by going to `Debug -> Windows -> Threads`

# Running code in a different thread

Sometimes we might want to run time consuming processes in a separate thread, this can be done using the below steps

1. Create the method

   > Note: Methods called in a different thread can take 0 or 1 object type argument and cannot return any value

2. Create a new thread using `new Thread(methodToBeRun)`. The method to be run in the separate thread should be passed as argument to this constructor.

3. Start the thread using `threadName.Start()`

Example:

```csharp
public void PrintTenNumbers()
{
    for ( i = 0; i < 10; i ++)
    {
        Console.WriteLine($"Current iteration: {i}")
    }
}

// Normal method call
PrintTenNumbers();

// Calling method in a worker thread
Thread printNumbersThread = new Thread(PrintTenNumbers)
{
    Name = "PrintTenNumbers"
};

printNumbersThread.Start();
```

This will create a new thread called `PrintTenNumbers` and run the PrintTenNumbers method in that thread
![PrintTenNumbersThread](image-1.png)

# Passing Arguments to the Method called in a Different thread

Passing argument to a method that runs in a different thread be achieved in 3 ways

1. Using the `ParameterizedThreadStart` constructor</br>
   There are multiple constructors for the Thread class. For executing method with argument, the ParameterizedThreadStart constructor can be used. This supports method with only one argument of type **object**.
   To achieve this similar to the normal constructor, pass the name of method with argument to the Thread constructor and when starting the thread, pass the argument to be used.</br>

   Example:

   ```csharp
   // Method that takes one argument of type object
   public void PrintNumbers(object n)
   {
       for ( i = 0; i < (int) n; i ++) //Converting object type to required type
       {
           Console.WriteLine($"Current iteration: {i}")
       }
   }

   PrintTenNumbers();

   // Calling method in a worker thread
   Thread printNumbersThread = new Thread(PrintNumbers)
   {
       Name = "PrintNumbers"
   };

    // Passing argument
   printNumbersThread.Start(5);
   ```

   Disadvantages:

   - Only one argument can be passed
   - Argument doesn't have type safety

2. Using Helper Class </br>
   Here we can create a helper class
