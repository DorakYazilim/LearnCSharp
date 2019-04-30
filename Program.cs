using System;
using System.Collections.Generic;

// GenericLists
// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/introduction-to-generics
namespace LearnCSharp
{
    class Program
    {
        private class MyClass
        {
            public string MyProperty { get; set; }
            public MyClass()
            {
                    
            }
        }
        static void Main(string[] args)
        {
            GenericList<int> list1 = new GenericList<int>();
            list1.AddHead(10);

            GenericList<string> list2 = new GenericList<string>();
            list2.AddHead("Metallica");

            GenericList<MyClass> list3 = new GenericList<MyClass>();
            list3.AddHead(new MyClass() { MyProperty = "Anthrax"});

            foreach (int i in list1)
            {
                Console.Write(i + " ");
                Console.WriteLine("\nDone");
            }

            foreach (string i in list2)
            {
                Console.Write(i + " ");
                Console.WriteLine("\nDone");
            }
            foreach (MyClass i in list3)
            {
                Console.Write(i.MyProperty + " ");
                Console.WriteLine("\nDone");
            }
            Console.ReadLine();
        }
    }
    // Declare 
    public class GenericList<T>
    {
        // The nested class is also generic on T.
        private class Node
        {
            // T used in non-generic constructor.            
            public Node(T t)
            {
                next = null;
                data = t;
            }
            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            // T as private member data type.
            private T data;

            // T as return type of property.
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }
        private Node head;
        public GenericList()
        {
            head = null;
        }

        // T as method parameter type
        public void Add(T input) { }
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
