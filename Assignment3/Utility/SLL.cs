using Assignment3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    [Serializable]
    public class SLL : ILinkedListADT
    {
        // Define refernce/pointer to the first node
        private Node head;
        private int listSize;

        // SLL class constructor 
        // Create empty list
        public SLL()
        {
            head = null;
        }

        // Implementation of AddFirst() or Prepend method for SLL
        // Add node at the beginning of SLL
        // data ==> data to be added
        public void AddFirst(User data)
        {
            listSize++;
            // Create new node for data
            Node newNode = new Node(data);
            // Set the new node reference to the current head
            newNode.Next = head;
            // Update head to point to the new node
            head = newNode;
        }

        // Implementation of AddLast() or Append method for SLL
        // Add node at the end of SLL
        // data => data to be added
        public void AddLast(User data)
        {
            listSize++;
            // Create new node for data 
            Node newNode = new Node(data);

            if (head == null)  // Empty SLL
            {
                // Update head to point to the new node
                head = newNode;
                return;
            }

            // Iterate through the SLL
            Node currentNode = head;
            while (currentNode.Next != null) // Loop until reaching null
            {
                // Go to the next node in the SLL
                currentNode = currentNode.Next;
            }

            // Update the reference of the last node to point to the new node
            // New node by default point to null (See Node class)
            currentNode.Next = newNode;
        }

        // Implementation of Remove() method for SLL
        // Remove the node at a specified index from SLL
        public void Remove(int index)
        {
            if (index < 0 || index >= listSize)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                listSize--;
                RemoveFirst();
                return;
            }

            Node currentNode = head;
            Node previousNode = null;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            previousNode.Next = currentNode.Next;
            listSize--;
        }

        // Implementation of RemoveFirst() method for SLL
        // Remove the first node from SLL
        public void RemoveFirst()
        {
            listSize--;
            if (head == null)       // Empty SLL
            {
                return;             // Nothing to do
            }

            // Update head to skip the first node and point ot next node
            // This will update the second node to be the first node
            head = head.Next;
        }

        // Implementation of RemoveLast() method for SLL
        // Remove the last node from SLL
        public void RemoveLast()
        {
            listSize--;
            if (head == null)       // Empty SLL
            {
                return;             // Nothing to do
            }

            if (head.Next == null)  // Only one node in the SLL
            {
                head = null;        // Set head to null
                return;
            }

            // Navigate the SLL using two references
            // One for current node and the other for previous node
            Node previousNode = null;    // Keep track for the node before the current node
            Node currentNode = head;     // Representing the current node being evaluated.
            while (currentNode.Next != null)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            // After loop finishs, update the previous to point to null
            // like that, you skipped the last node
            previousNode.Next = null;
        }

        // Implementation of Add() method for SLL
        // Add node at certain index in SLL
        // data => data to be added
        public void Add(User data, int index)
        {
            if (index < 0 || index > listSize)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                listSize++;
                AddFirst(data);
                return;
            }

            Node newNode = new Node(data);
            Node currentNode = head;
            Node previousNode = null;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            newNode.Next = currentNode;
            previousNode.Next = newNode;
            listSize++;
        }

        // Implementation of Replace() method for SLL
        // Replaces the node at a specified index with the value in the SLL
        public void Replace(User value, int index)
        {
            if (index < 0 || index > listSize - 1)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                head.Data = value;
                return;
            }

            Node newNode = new Node(value);
            Node currentNode = head;
            Node previousNode = null;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            newNode.Next = currentNode.Next;
            previousNode.Next = newNode;
        }

        // Implementation of GetValue() method for SLL
        // Gets the value of a node at a specified index in the SLL
        public User GetValue(int index)
        {
            if (index < 0 || index > listSize - 1)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                return head.Data;
            }
            Node currentNode = head;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }
            return currentNode.Data;
        }

        // Implementation of IndexOf() method for SLL
        //parameter data Data object to find the first index of.
        //return First of index of element with matching data or -1 if not found.
        public int IndexOf(User target)
        {
            if (head == null)
            {
                return -1;
            }

            int index = 0;
            for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
            {
                if (Equals(tempNode.Data, target))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        // Implementation of Contains() method for SLL
        // Check if SLL contains certain data
        // data => data to be checked for
        // Return true if SLL contins the data, otherwise, return false
        public bool Contains(User data)
        {
            // Navigate the SLL to find the required data
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        // Implementation of Clear() method for SLL
        // Remove all node from SLL
        public void Clear()
        {
            listSize = 0;
            head = null;
        }

        // Implementation of Count() method for SLL
        // Return the size of the SLL
        public int Count()
        {
            if (head is null)
            {
                return 0;
            }
            return listSize;
        }

        // Implementation of Invert() method for SLL
        // Reverses the order of all the nodes in the SLL
        public void Invert()
        {
            // Empty list or only one node
            if (head == null || head.Next == null)
            {
                return;     // Nothing to do
            }

            // Iterate through the SLL using three references
            Node previousNode = null;    // Keep track for the node before the current node
            Node currentNode = head;     // Representing the current node being evaluated.
            Node nextNode = null;        // Keep track for the node after the current node
            while (currentNode != null)
            {
                // Reverse the nodes order by updating the next as current and current as previous
                nextNode = currentNode.Next;
                currentNode.Next = previousNode;
                // Update the previous and current to progress through the SLL
                previousNode = currentNode;
                currentNode = nextNode;
            }

            head = previousNode;
        }

        // Implementation of Sort() method for SLL
        // Sort the nodes in SLL is ascending order of names
        public void Sort()
        {
            // Empty list or only one node, no need to sort
            if (head == null || head.Next == null)
            {
                return;     // Nothing to do
            }

            bool swapped;
            do
            {
                swapped = false;
                Node currentNode = head;
                Node nextNode = head.Next;

                while (nextNode != null)
                {
                    // use the conditional operator
                    if (Comparer<object>.Default.Compare(currentNode.Data.Name, nextNode.Data.Name) > 0)
                    {
                        // Swap nodes' Data
                        User temp = currentNode.Data;
                        currentNode.Data = nextNode.Data;
                        nextNode.Data = temp;

                        swapped = true;
                    }

                    currentNode = nextNode;
                    nextNode = nextNode.Next;
                }
            } while (swapped);
        }

        // Implementation of ToArray() method for SLL
        // Form one array for nodes' data in SLL
        // Return array for the nodes' data in SLL
        public User[] ToArray()
        {
            User[] users = new User[listSize]; // Create an empty array

            // Iterate through the SLL
            Node currentNode = head;
            int i = 0;

            while (currentNode != null)
            {
                users[i] = currentNode.Data;
                currentNode = currentNode.Next;
                i++;
            }

            return users;
        }

        // Implementation of Join() method for SLL
        // Combines two SLLs into one SLL
        public void Join(SLL list1, SLL list2)
        {
            if (list1.head == null)  // Empty SLL
            {
                head = list2.head;
            }

            if (list2.head == null)  // Empty SLL
            {
                head = list1.head;
            }


            // Iterate through the SLL
            head = list1.head;
            Node currentNode = head;
            while (currentNode.Next != null) // Loop until reaching null
            {
                // Go to the next node in the SLL
                currentNode = currentNode.Next;
            }

            currentNode.Next = list2.head;
            listSize = list1.Count() + list2.Count();
        }

        // Implementation of Seperate() method for SLL
        // Seperates a SLLs into two SLL on a specified index
        // Returns a tuple of the SSLs
        public (SLL, SLL) Seperate(int index)
        {
            SLL list1 = new SLL();
            SLL list2 = new SLL();
            list1.head = head;
            Node previousNode = null;
            Node currentNode = list1.head;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            list2.head = currentNode;
            previousNode.Next = null;
            list1.listSize = currentIndex;
            list2.listSize = listSize - currentIndex;
            return (list1, list2);
        }
    }
}