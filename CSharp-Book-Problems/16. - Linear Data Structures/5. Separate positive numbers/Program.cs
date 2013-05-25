using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Separate_positive_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] allNumbers = {19, -10, 12, -6, -3, 34, -2, 5};
            List<int> positiveNumbers = new List<int>();

            for (int i = 0; i < allNumbers.Length; i++)
            {
                if (allNumbers[i] >= 0)
                {
                    positiveNumbers.Add(allNumbers[i]);
                }
            }

            for (int i = 0; i < positiveNumbers.Count; i++)
            {
                Console.Write("{0} ", positiveNumbers[i]);
            }

            Console.WriteLine();
        }
    }
}
