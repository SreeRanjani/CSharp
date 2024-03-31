using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadDemo
{
    public class Method4Helper
    {
        private int numOfIterations;

        public Method4Helper(int numOfIteration)
        {
            this.numOfIterations = numOfIteration;
        }

        public void Method4()
        {
            for (int i = 0; i < numOfIterations; i++)
            {
                Console.WriteLine($"Method 4 iteration {i}");
                Thread.Sleep(10);
            }
        }
    }
}
