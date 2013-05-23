namespace Linked_List_Implementation
{
    using System;

    public class LinkedListTests
    {
        public static void Main()
        {
            LinkedList<double> aList = new LinkedList<double>();
            aList.AddElement(10);
            aList.AddElement(100);
            aList.AddElement(50);
            Console.WriteLine(aList.Count);
            //int a;
            //a = aList.Remove(1);
            //Console.WriteLine(a);
            Console.WriteLine(aList.RemoveByIndex(100));
            Console.WriteLine(aList.Count);
        }
    }
}