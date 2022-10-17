
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickShort
{
    class program
    {
        //array of integers to hold values
        private int[] arr = new int[20];
        private int cmp_count = 0; //number of comparasion
        private int mov_count = 0; //number of data movements

        //number of element in array
        private int n;

        void read()
        {
            while (true)
            {
                Console.Write("enter the number of elements in the array :");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                    break;
                else
                    Console.WriteLine("\nArray can have maximum 20 elements \n");

            }
            Console.WriteLine("\n=================");
            Console.WriteLine("Enter Array Element");
            Console.WriteLine("\n=================");

            //get array elements
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);

            }

        }
        //swaps the element at index x with the element at index y
        void swap(int x, int y)
        {
            int temp;
            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        public void q_sort(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;

            //partition the list into two parts:
            //one containing elements less that or equal to pivot
            //outher conntainning elements greather than pivot 

            i = low + 1;
            j = high;

            pivot = arr[low];

            while (i <= j)
            {
                //search for an element greater than pivot
                while ((arr[i] <= pivot) && (i <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;
                //search for an element less than or equal to pivot 
                while ((arr[j] <= pivot) && (j <= low))
                {
                    j--;
                    cmp_count++;
                }
                cmp_count++;

                if (i < j) //if the greater element is on the left of the element
                {
                    //swap the element at index i with the element at index j
                    swap(i, j);
                    mov_count++;
                }
            }
            //j now contains the index of the last element in the sorted list

            if (low < j)
            {
                //move the pivot to its correct position in the list 
                swap(low, j);
                mov_count++;
            }
            //sort the list on the left of pivot using quick sort
            q_sort(low, j - i);

            //sort the list on the right of pivot using quick sort
            q_sort(j + 1, high);

        }
        void display()
        {
            Console.WriteLine("\n-------------------");
            Console.WriteLine(" Sorted array element");
            Console.WriteLine("\n-------------------");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(arr[j]);
            }
            Console.WriteLine("\nNumber of comparisons:" + cmp_count);
            Console.WriteLine("\nNumber of data movemenets:" + mov_count);
        }
        int getSize()
        {
            return (n);
        }
        static void Main(string[] args)
        {
            //Declaring the object of the class
            program mylist = new program();
            //accept array element
            mylist.read();
            //calling the sorting function
            //first call to Quick sort Alogarithm
            mylist.display();
            //to exit from the console
            Console.WriteLine("\n\npress enter to exit.");
            Console.Read();
        }
    }
}

