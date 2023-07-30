using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    [Serializable]
    // Node Class
    // Node class is defined as generic class to allow store any data type
    public class Node
    {
        // Data or value stored in the node.
        public User Data { get; set; }
        // Reference to the next node in the linked list.
        public Node Next { get; set; }

        // Node class constructor
        public Node(User data)
        {
            Data = data;
            Next = null;
        }
    }

}

