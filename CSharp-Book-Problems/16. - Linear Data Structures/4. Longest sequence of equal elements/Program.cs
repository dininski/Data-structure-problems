using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Longest_sequence_of_equal_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> enteredNumbers = new List<int>();

            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                int inputNumber = int.Parse(input);
                enteredNumbers.Add(inputNumber);
                input = Console.ReadLine();
            }

            enteredNumbers.Sort();

            List<int> mostOccurences = new List<int>();
            int currentOccurences = 1;

            for (int i = 0; i < enteredNumbers.Count - 1; i++)
            {
                if (enteredNumbers[i] == enteredNumbers[i + 1])
                {
                    currentOccurences++;
                }
                else
                {
                    currentOccurences = 1;
                }

                if (currentOccurences > mostOccurences.Count)
                {
                    mostOccurences = new List<int>();
                    for (int j = 0; j < currentOccurences; j++)
                    {
                        mostOccurences.Add(enteredNumbers[j]);
                    }
                }
            }

            Console.WriteLine("Max occurences: {0}", mostOccurences.Count);
        }
    }
}
