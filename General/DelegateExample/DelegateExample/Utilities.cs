namespace DelegateExample
{
    // Define a delegate type for custom comparison
    public delegate int Comparison<T>(T x, T y);

    public class Utilities
    {
        // Generic sort method that accepts a comparison delegate
        public static void Sort<T>(T[] array, Comparison<T> comparison)
        {
            // Implementation of a sorting algorithm
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparison(array[j], array[j + 1]) > 0)
                    {
                        // Swap elements
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                }
            }
        }
    }
}
