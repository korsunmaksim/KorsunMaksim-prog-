using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ASD_lab_1_
{
    class Node
    {
        public int data;
        public Node next;

        public Node(int x)
        {
            data = x;
            next = null;
        }
    }

    class LinkedList
    {
        int size = 0;
        Node head;

        public LinkedList()
        {
            head = null;
        }
        public Node GetHead()
        {
            return head;
        }
        public int GetSize()
        {
            return size;
        }
        public void AddToEnd(int data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new Node(data);
            }
            size++;
        }

        public void OutputLinkedList()
        {
            Node runner = head;
            while (runner != null)
            {
                Console.Write(runner.data + " ");
                runner = runner.next;
            }
            Console.WriteLine();
        }
        public bool Checking(Node element, int x)
        {
            if (element.data == x) return true;
            else return false;
        }
    }

    partial class ArrayClass
    {
        
        static public void ListCreation(LinkedList list)
        {

            Console.WriteLine("Enter amount of elements");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter limits:");
            int limit1, limit2;
            limit1 = Convert.ToInt32(Console.ReadLine());
            limit2 = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                list.AddToEnd(limit1 + rand.Next(limit2 - limit1 + 1));
            }
            list.OutputLinkedList();
            Console.WriteLine("======================================");
        }

        static public void BruteForceSearchForList(Node head, int sizeOfList)
        {
            Stopwatch sWatch2 = new Stopwatch();
            Console.WriteLine("Enter x:");
            int x = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            bool flag1 = false;
            sWatch2.Start();
            while (i < sizeOfList && (!flag1))
            {
                if (head.data == x)
                {
                    flag1 = true;
                    Console.WriteLine($"{head.data}  Element of the Linked List with index [{i}]");
                }
                head = head.next;
                i++;
            }
            sWatch2.Stop();
            if (i == sizeOfList) Console.WriteLine("X isn't included in array");
            Console.WriteLine($"Duration  {sWatch2.ElapsedMilliseconds} ms");
        }

        static public void BarrierSearchForList(Node head, LinkedList list)
        {
            Stopwatch sWatch2 = new Stopwatch();
            Console.WriteLine("Enter x:");
            int x = Convert.ToInt32(Console.ReadLine());
            list.AddToEnd(x);
            int i = 0;
            sWatch2.Start();
            while (head.data != x)
            {
                head = head.next;
                i++;
            }
            sWatch2.Stop();
            if (i == list.GetSize()) Console.WriteLine("X isn't included in array");
            else Console.WriteLine($"{head.data}  Element of the Linked List with index [{i}]");
            Console.WriteLine($"Duration  {sWatch2.ElapsedMilliseconds} ms");
        }
        static public Node GetElement(Node head, int m)
        {
            for (int i = 0; i < m; i++)
            {
                head = head.next;
            }
            return head;
        }
        
        static public void Sort(LinkedList list)//сортування списку для бинарного пошуку
        {
            int size = list.GetSize();
            int min;
            for (int i = 0; i < size; i++)
            {
                min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (GetElement(list.GetHead(), j).data < GetElement(list.GetHead(), min).data) min = j;
                }
                if (min != i)
                {
                    int tmp = GetElement(list.GetHead(), min).data;
                    GetElement(list.GetHead(), min).data = GetElement(list.GetHead(), i).data;
                    GetElement(list.GetHead(), i).data = tmp;
                }
            }
        }

        static public void BinarySearchForList(LinkedList list)
        {
            LinkedList listForBinarySearch = new LinkedList();
            int size = list.GetSize();
            for (int i = 0; i < size; i++)
            {
                listForBinarySearch.AddToEnd(GetElement(list.GetHead(), i).data);
            }
            Sort(listForBinarySearch);
            Console.WriteLine("Sorted list \n");
            listForBinarySearch.OutputLinkedList();
            Console.WriteLine("Enter x:");
            int x = Convert.ToInt32(Console.ReadLine());
            int r = list.GetSize() - 1;
            int l = 0;
            int m;
            do
            {
                m = r - ((r - l) / 2);
                if (GetElement(listForBinarySearch.GetHead(), m).data < x) l = m+1;
                else r = m - 1;
            } while ((l <= r) &&( GetElement(listForBinarySearch.GetHead(), m).data != x));
            if (GetElement(listForBinarySearch.GetHead(), m).data == x) Console.WriteLine($"{GetElement(listForBinarySearch.GetHead(), m).data}  Element of the Linked List with index [{m}]");
            else Console.WriteLine("X isn't included in the list ");
        }

        static public void BinarySearchForListWithGoldenRatio(LinkedList list)
        {

            LinkedList listForBinarySearchGold = new LinkedList();
            int size = list.GetSize();
            for (int i = 0; i < size; i++)
            {
                listForBinarySearchGold.AddToEnd(GetElement(list.GetHead(), i).data);
            }
            Sort(listForBinarySearchGold);
            Console.WriteLine("Sorted list \n");
            listForBinarySearchGold.OutputLinkedList();
            Console.WriteLine("Enter x:");
            int x = Convert.ToInt32(Console.ReadLine());
            int r = list.GetSize() - 1;
            int l = 0;
            int m;
            do
            {
                m = Convert.ToInt32(r - ((r - l) / 1.618));
                if (GetElement(listForBinarySearchGold.GetHead(), m).data < x) l = m + 1;
                else r = m - 1;
            } while ((l <= r) && (GetElement(listForBinarySearchGold.GetHead(), m).data != x));
            if (GetElement(listForBinarySearchGold.GetHead(), m).data == x) Console.WriteLine($"{GetElement(listForBinarySearchGold.GetHead(), m).data}  Element of the Linked List with index [{m}]");
            else Console.WriteLine("X isn't included in the list ");
        }


    }
}
