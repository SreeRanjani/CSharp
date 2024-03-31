namespace MultiThreadWithMonitor
{
    public class MultiThreadWithMonitorClass
    {
        static object lockObject = new object(); // Object used for synchronization

        public static void Producer()
        {
            lock (lockObject)
            {
                for(int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Producer is producing an item {i}.");

                    // Signal the consumer thread that an item is ready
                    Monitor.Pulse(lockObject);

                    // Producer waits until the consumer has consumed the item
                    Monitor.Wait(lockObject);

                    Console.WriteLine($"Producer resumes production {i}.");
                }
            }
        }

        public static void Consumer()
        {
            lock (lockObject)
            {
                for(int i = 0;i < 10;i++)
                {
                    Console.WriteLine($"Consumer is waiting for an item {i}.");

                    // Consumer waits until the producer produces an item
                    Monitor.Pulse(lockObject);

                    // Signal the producer thread that the item has been consumed
                    Monitor.Wait(lockObject);

                    Console.WriteLine($"Consumer is consuming the item {i}.");
                }
            }
        }
    }
}
