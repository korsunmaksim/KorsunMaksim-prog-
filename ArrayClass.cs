using System;
using System.Text;
using System.Diagnostics;

namespace ASD_lab_1_
{
    partial class ArrayClass
    {
        static public int[] arr = new int[1000000];
        static public int[] arr1 = new int[1000000];
        static public int n;
        static public int lim1, lim2;
        static public LinkedList list1 = new LinkedList();
        static void Main(string[] args)
        {
            Console.WriteLine("Korsun Maksim,IPZ-11/1,lab 1,variant 9");
            Menu();

        }

        static void Menu()
        {
            Console.WriteLine("Choose an Array(1) or a Linked List(2): ");
            char choose = Convert.ToChar(Console.ReadLine());
            char key;
            char command;
            if (choose == '1')
            {
                do
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1.Enter 1 to create a new array");
                    Console.WriteLine("2.Enter 2 to Brute-force search");
                    Console.WriteLine("3.Enter 3 to Barrier search");
                    Console.WriteLine("4.Enter 4 to Binary search");
                    Console.WriteLine("5.Enter 5 to Binary search with Golden ratio \n ");
                    Console.WriteLine("Enter command:");
                    command = Convert.ToChar(Console.ReadLine());
                    switch (command)
                    {
                        case '1': Array(); break;
                        case '2': BruteForceSearch(); break;
                        case '3': BarrierSearch(); break;
                        case '4': BinarySearch(); break;
                        case '5': BinarySearchGolden(); break;
                        default: Console.WriteLine("Wrong command"); break;
                    }
                    Console.WriteLine("Enter 0 to stop");
                    key = Convert.ToChar(Console.ReadLine());
                } while (key != '0');
                Console.WriteLine("======================================");
            }
            else if (choose == '2')
            {
                do
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1.Enter 1 to create a new linked list");
                    Console.WriteLine("2.Enter 2 to Brute-force search");
                    Console.WriteLine("3.Enter 3 to Barrier search");
                    Console.WriteLine("4.Enter 4 to Binary search");
                    Console.WriteLine("5.Enter 5 to Binary search with Golden ratio \n ");
                    Console.WriteLine("Enter command:");
                    command = Convert.ToChar(Console.ReadLine());
                    switch (command)
                    {
                        case '1': ListCreation(list1); break;
                        case '2': BruteForceSearchForList(list1.GetHead(), list1.GetSize()); break;
                        case '3': BarrierSearchForList(list1.GetHead(), list1); break;
                        case '4': BinarySearchForList(list1); break;
                        case '5': BinarySearchForListWithGoldenRatio(list1); break;
                        default: Console.WriteLine("Wrong command"); break;
                    }
                    Console.WriteLine("Enter 0 to stop");
                    key = Convert.ToChar(Console.ReadLine());
                } while (key != '0');
                Console.WriteLine("======================================");
            }
            else Console.WriteLine("Wrong input");
        }
    

       
        static void ArrayCreation(int [] array,int k)
        {
           Console.WriteLine("Enter limits of array:");
           lim1 = Convert.ToInt32(Console.ReadLine());
           lim2 = Convert.ToInt32(Console.ReadLine());
           Random rand = new Random();
            if (lim1 > lim2)
            {
                Console.WriteLine("Wrong limits");
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    array[i] = lim1 + rand.Next(lim2 - lim1+1);
                }
                Console.WriteLine("Array:");
                ArrayOutput(array, k);
            }
            Console.WriteLine(" ");
        }

        static void BruteForceSearch()
        {
            Stopwatch sWatch1 = new Stopwatch();
            int x1;
            Console.WriteLine("Enter x:");
            x1 =Convert.ToInt32(Console.ReadLine());
            int i = 0;
            bool flag = false;
            sWatch1.Start();
            while (i<n && flag!=true)
            {
                if (arr[i] == x1)
                {
                    Console.WriteLine($"a[{i}]={arr[i]}");
                    flag = true;
                }
                i++;
            }
            sWatch1.Stop();
            if (i == n)
            {
                Console.WriteLine("X wasn't found in the array");
            }
            Console.WriteLine($"Duration  {sWatch1.ElapsedMilliseconds} ms");
        }
        static void BarrierSearch()
        {
            Stopwatch sWatch1 = new Stopwatch();
            int x2;
            Console.WriteLine("Enter x:");
            x2 = Convert.ToInt32(Console.ReadLine());
            arr[n] = x2;
            int i = 0;
            sWatch1.Start();
            while (arr[i]!=x2)
            {
                i++;
            }
            sWatch1.Stop();
            if (i < n) Console.WriteLine($"a[{i}]={arr[i]}");
            else Console.WriteLine("X wasn't found in the array");
            Console.WriteLine($"Duration  {sWatch1.ElapsedMilliseconds} ms");
        }
        static void SwapForSort(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
        static void SortArray(int []arr,int size)
        {
            int min;
            for (int i = 0; i < size; i++)
            {
                min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (arr[j] < arr[min]) min = j;
                }
                if(min!=i)
                {
                    int tmp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = tmp;
                }
            }
        }
        static void BinarySearch()
        {
            Stopwatch sWatch1 = new Stopwatch();
            for(int i = 0; i < n; i++)
            {
                arr1[i] = arr[i];
            }
            sWatch1.Start();
            SortArray(arr1,n);
            Console.WriteLine();
            Console.WriteLine("Sorted array:");
            ArrayOutput(arr1, n);
            int x3;
            Console.WriteLine("Enter x");
            x3 = Convert.ToInt32(Console.ReadLine());
            int l = 0;
            int r = n - 1;
            int m;
            do
            {
                m = r - ((r - l) / 2);
                if (arr1[m] < x3) l = m+1;
                else r = m - 1;
            } while ((l <=r) && (arr1[m] != x3));
            sWatch1.Stop();
            if (arr1[m] == x3) Console.WriteLine($"a[{m}]={arr1[m]}");
            else Console.WriteLine("X wasn't found in the array");
            Console.WriteLine($"Duration  {sWatch1.ElapsedMilliseconds} ms");
        }
        static void BinarySearchGolden()
        {
            Stopwatch sWatch1 = new Stopwatch();
            for (int i = 0; i < n; i++)
            {
                arr1[i] = arr[i];
            }
            sWatch1.Start();
            SortArray(arr1,n);
            Console.WriteLine("Sorted array:");
            ArrayOutput(arr1, n);
            int x3;
            Console.WriteLine("Enter x");
            x3 = Convert.ToInt32(Console.ReadLine());
            int l = 0;
            int r = n - 1;
            int m;
            do
            {
                m = Convert.ToInt32( r - ((r - l) / 1.618));
                if (arr1[m] < x3) l = m+1;
                else r = m - 1;
            } while ((l <= r) && (arr1[m] != x3));
            sWatch1.Stop();
            if (arr1[m] == x3) Console.WriteLine($"a[{m}]={arr1[m]}");
            else Console.WriteLine("X wasn't found in the array");
            Console.WriteLine($"Duration  {sWatch1.ElapsedMilliseconds} ms");
        }


        static void Array()
        {
            Console.WriteLine("Enter amount of elements:");
            n = Convert.ToInt32(Console.ReadLine());
            ArrayCreation(arr, n);
            Console.WriteLine("======================================");
        }
        static void ArrayOutput(int []array,int k)
        {
            for(int i = 0; i < k; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
    }
}
