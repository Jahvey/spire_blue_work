using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _001_delegate01
{
    class Program
    {
        internal static void BubbleSort(int []arr) {
            bool swap = true;
            do
            {
                swap = false;
                for (int i = 0; i < arr.Length-1; i++)
                {
                    if (arr[i] > arr[i + 1]) {
                        int temp = arr[i];
                        arr[i] = arr[i+1];
                         arr[i+1]=temp ;
                        swap = true;
                    }
                    
                }


            } while (swap);
        
        }


        internal static void BubbleSort1(int []arr) {

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] > arr[i]) { //从小到大
                    
                        int temp=arr[i];
                        arr[i]=arr[j];
                        arr[j] = temp;
                    }
                    
                }
                
            }
        
        
        }


        static void BubbleSort2(int []arr) {

            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    //if (arr[j] > arr[i]) {//从大到小
                    if(arr[j]<arr[i]){//从小到大
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        
                    
                    }
                    
                }
                
            }
        }


        static void Main(string[] args)
        {

            int[]arr=new int[100];
           // Random r = new Random(1);
            Random r = new Random(1);
            for (int i = 1; i <=100; i++)
            {
                int index = r.Next(100);
                if (arr[index] == 0)
                    arr[index] = i;
                else
                    i--;
                
            }
            foreach (var item in arr)
            {
                Console.Write(item);
                Console.Write(" ");
                
            }
            Console.WriteLine();

           // BubbleSort(arr);
           // BubbleSort1(arr);

            BubbleSort2(arr);
            Console.WriteLine("============");

            foreach (var item in arr)
            {
                Console.Write(item);
                Console.Write(" ");

            }
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
