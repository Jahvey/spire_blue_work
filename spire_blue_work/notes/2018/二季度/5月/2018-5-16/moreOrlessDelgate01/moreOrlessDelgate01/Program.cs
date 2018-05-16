using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace moreOrlessDelgate01
{
    class Program
    {
        //define delegate,传入相对应的(int item)的值
        delegate Boolean moreOrlessDelgate(int item);
        static void Main(string[] args)
        {

            var arr = new List<int>() { 1,2,3,4,5,6,67,9};
            var d1 = new moreOrlessDelgate(More);
            Print(arr,d1);
            Console.WriteLine("ok");
            Console.WriteLine("==================");
            var d2 = new moreOrlessDelgate(Less);
            Print(arr, d2);


            Console.WriteLine("ok");


            Console.WriteLine();
            Console.ReadKey();
        }

        static bool More(int item) {

            if (item > 3) return true;
            return false;
        }

        static bool Less(int item) {
            if (item < 3) return true;
            return false;
        
        }

        static void Print(List<int>arr,moreOrlessDelgate dl) {
            foreach (var item in arr) { 
            
                if(dl(item))
                    Console.WriteLine(item);
            }
        
        }






    }
}
