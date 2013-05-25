namespace Linked_List_Implementation
{
    using System;

    public class LinkedList<T> where T : IComparable
    {
        private Node head;
        private Node tail;
        public int Count { get; private set; }

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public void AddElement(T element)
        {
            if (this.head == null)
            {
                this.head = new Node(element);
                this.tail = this.head;
            }
            else
            {
                Node newNode = new Node(element, this.tail);
                this.tail = newNode;
            }

            this.Count++;
        }

        public T RemoveByIndex(int index)
        {
            int currentIndex = 0;
            Node currentNode = this.head;
            Node previousNode = null;

            while (currentIndex < index)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            this.Count--;

            if (this.Count == 0)
            {
                this.head = null;
            }
            else if (previousNode == null)
            {
                this.head = currentNode.Next;
            }
            else
            {
                previousNode.Next = currentNode.Next;
            }

            Node lastElement = null;

            if (this.head != null)
            {
                lastElement = this.head;
                while (lastElement.Next != null)
                {
                    lastElement = lastElement.Next;
                }
            }

            this.tail = lastElement;

            return currentNode.Element;
        }

        public int Remove(T obj)
        {
            Node currentNode = this.head;
            Node previousNode = null;
            int elementIndex = 0;

            while (currentNode != null)
            {
                if ((currentNode.Element.CompareTo(obj) == 0 && currentNode.Element != null)
                    || currentNode.Element == null && obj == null)
                {
                    break;
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
                elementIndex++;
            }

            if (currentNode != null)
            {
                RemoveByIndex(elementIndex);
                return elementIndex;
            }
            else
            {
                return -1;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > this.Count - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException("The supplied index must be larger that 0 and less than the size of the list!");
                }

                Node currentNode = this.head;
                int counter = 0;

                while (counter != index)
                {
                    currentNode = currentNode.Next;
                    counter++;
                }

                return currentNode.Element;
            }

            set
            {
                if (index > this.Count - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException("The supplied index must be larger that 0 and less than the size of the list!");
                }

                Node currentNode = this.head;
                int counter = 0;

                while (counter != index)
                {
                    currentNode = currentNode.Next;
                    counter++;
                }

                currentNode.Element = value;
            }
        }

        public int IndexOf(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("The element that you are searching for cannot be null!");
            }

            Node currentItem = this.head;
            int currentIndex = 0;

            if (!this.Contains(obj))
            {
                return -1;
            }

            while (currentItem.Element.CompareTo(obj) != 0 && currentItem != null)
            {
                currentItem = currentItem.Next;
                currentIndex++;
            }

            return currentIndex;
        }

        public bool Contains(T obj)
        {
            Node currentItem = this.head;

            while (currentItem != null)
            {
                if (currentItem.Element.CompareTo(obj) == 0)
                {
                    return true;
                }

                currentItem = currentItem.Next;
            }

            return false;
        }

        private class Node
        {
            public Node(T element)
            {
                this.Element = element;
                this.Next = null;
            }

            public Node(T element, Node previousNode)
            {
                this.Element = element;
                previousNode.Next = this;
            }

            public Node Next { get; set; }

            public T Element { get; set; }
        }
    }
}