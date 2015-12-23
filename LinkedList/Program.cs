using GenericLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GenericLinkedList
{
    public class Node<T>
    {
        public Node<T> Next;
        public T data;
    }

    public class LinkedList<T> 
    {
        private Node<T> head { get; set; }
        private int _count { get; set; }
        public int Count
        {
            get
            {
               return _count;
            }
        }

        //Initalize LinkedList with a collection of nodes.
        public LinkedList(IEnumerable<T> initalize)
        {
            foreach (T item in initalize)
            {
                AddLast(item);
            }
        }

        //Constructor for initializing empty linked list
        public LinkedList()
        {

        }
 
        //To be able to print pretty much all types of T i used a serializer that serializes any object to string
        public string PrintAll()
        {
            List<string> temp = new List<string>();
            Node<T> current = head;
            while (current != null)
            {
                temp.Add(new JavaScriptSerializer().Serialize(current.data));
                current = current.Next;

            }
            return string.Join(Environment.NewLine, temp);

        }
        /// <summary>
        /// Find first occurance of Node and return the node, else return null
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node<T> Find(T data)
        {
            Node<T> current = head;
            //Loop all Nodes untill we get to the last Node
            while (current.Next != null)
            {
                if(current.data.Equals(data))
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        }

        public void Reverse()
        {
            Node<T> current = head;
            Node<T> newLinkedList = null;
            //Current is always the current head, when while loops the new head is set to current
            while (current != null)
            {
                //Set temp node as the next node from head
                Node<T> temp = current.Next;
                //Set next node from head to the previous head
                current.Next = newLinkedList;
                //Set the current head as the new linked list
                newLinkedList = current;
                //Set the next Node from current head as the new head
                current = temp;
            }
            head = newLinkedList;
        }

        public T GetLastData()
        {
            //This trick can be used instead of using an else 
            //The method returns the default value for the type T 
            T temp = default(T);

            Node<T> current = head;
            //Loop untill we get to the last Node and then reuturn the last node 
            while (current != null)
            {
                temp = current.data;
                current = current.Next;
            }
            
            return temp;
        }

        public T GetHeadData()
        {
            //This trick can be used instead of using an else 
            //The method returns the default value for the type T 
            T temp = default(T);
            if (head != null)
            {
                temp = head.data;
            }
            return temp;
        }

        public void AddFirst(T data)
        {
            Node<T> toAdd = new Node<T>();
            toAdd.data = data;
            //Set the current head as the next for the new head
            toAdd.Next = head;
            head = toAdd;
            _count++;
        }

        public void AddLast(T data)
        {
            //if this is the first item in the list we add it as the first item and set it as head
            if (head == null)
            {
                AddFirst(data); return;
            }

            Node<T> toAdd = new Node<T>();
            toAdd.data = data;

            Node<T> current = head;
            //Loop all Nodes untill we get to the last Node
            while (current.Next != null)
            {
                current = current.Next;
            }
            //Set the next Node to the new Node
            current.Next = toAdd;
            _count++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Tests
            LinkedList<int> linkedList = new LinkedList<int>(new List<int> { 1, 2, 3, 4 });
            linkedList.AddFirst(5);
            linkedList.AddLast(6);
            Console.WriteLine("--Print All--");
            Console.WriteLine(linkedList.PrintAll());
            Console.WriteLine("--Get last data--");
            Console.WriteLine(linkedList.GetLastData());
            Console.WriteLine("--Get first data--");
            Console.WriteLine(linkedList.GetHeadData());
            Console.WriteLine("--Reverse then print All--");
            linkedList.Reverse();
            Console.WriteLine(linkedList.PrintAll());
            Console.WriteLine("--Get Length--");
            Console.WriteLine(linkedList.Count);
            Console.WriteLine(linkedList.Find(3));
            Console.ReadLine();
        }
    }
}
