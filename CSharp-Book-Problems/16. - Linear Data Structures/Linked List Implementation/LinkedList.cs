namespace Linked_List_Implementation
{
    public class LinkedList<T>
    {
        private Node head;
        private Node tail;
        public int Count { get; set; }

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
                if ((currentNode.Element.Equals(obj) && currentNode.Element != null)
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