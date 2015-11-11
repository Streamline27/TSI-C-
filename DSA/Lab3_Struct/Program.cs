using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Struct
{
    public class CircularList
    {
        // Private class container for data
        private class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int data)
            {
                Data = data;
            }
        }

        private Node Last { get; set; }

        public int Capacity { get; private set; }
        public bool IsEmpty { get { return Capacity == 0; } }

        public void Add(int data, int shift = 0)
        {
            if (IsEmpty)
            {
                Last = new Node(data);
                Last.Next = Last;
            }
            else
            {
                Node nodeBeforeInsertion = Last;
                for (int i = 0; i < shift; i++) nodeBeforeInsertion = nodeBeforeInsertion.Next;

                Node nodeNew = new Node(data);
                nodeNew.Next = nodeBeforeInsertion.Next;
                nodeBeforeInsertion.Next = nodeNew;
            }
            Capacity++;
        }

        public int Get(int shift = 0)
        {
            Node nodeCurrent = Last.Next;
            for (int i = 0; i < shift; i++) nodeCurrent = nodeCurrent.Next;
            return nodeCurrent.Data;
        }

        public void Delete(int shift = 0)
        {
            Node nodeBeforeCurrent = Last;
            for (int i = 0; i < shift; i++) nodeBeforeCurrent = nodeBeforeCurrent.Next;
            nodeBeforeCurrent.Next = nodeBeforeCurrent.Next.Next;
        }
    }


    class Program
    {
        //Task 1
        private static void Show(CircularList list)
        {
            for (int i = 0; i < list.Capacity; i++)
            {
                Console.WriteLine(i+". "+list.Get(i));
            }
            Console.WriteLine();
        }

        //Task 6
        private static void AddThree(int[] a, CircularList list){
            for (int i = a.Length-1; i >= 0; i--)
            {
                list.Add(a[i], 3);
            }
        }

        //Task 3
        private static int Search(CircularList list, int key)
        {
            int index = -1;
            for (int i = 0; i < list.Capacity; i++)
            {
                if (list.Get(i) == key) return i;
            }


            return index;
        }

        //Task 5
        private static void SantaBarbara(CircularList list, int SearchKey, int ElementToAdd)
        {
            int index = Search(list, SearchKey);
            if (index == -1) list.Add(ElementToAdd);
            else list.Add(ElementToAdd, index + 1);
        }

        // Helper function
        private static void FillWithRandom(CircularList list, int numberOfElements)
        {
            Random rand = new Random();
            for (int i = 0; i < numberOfElements; i++)
            {
                list.Add(rand.Next(), i);
            }
        }

        static void Main(string[] args)
        {
            //Creating list
            CircularList list = new CircularList();
            FillWithRandom(list, 6);

            //Running task functions
            Show(list);
            AddThree(new int[] { 1, 1, 1 }, list);
            Show(list);
            Console.WriteLine("Search result: " + Search(list, 3));
            Console.WriteLine();

            SantaBarbara(list, 1, 9);
            Show(list);

            Console.ReadLine();
        }

    }
}
