using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenMaxValue
{
    class Program
    {
        /// <summary>
        /// 获得最大窗口的方法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public int[] getMaxWindow(int []arr,int w) { 
        if(w<1||arr==null||arr.Length<w){return null;}

        LinkedList<int> qmax = new LinkedList<int>();
            int []res=new int[arr.Length-w+1];

            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                while (qmax.Count>0&&arr[qmax.First()]<=arr[i])
                {
                    qmax.RemoveLast();
                    
                }
                qmax.AddLast(i);
                if (qmax.First() == i - w) {

                    qmax.RemoveFirst();
                }
                if (i >= w - 1) { 
                
                    res[index++]=arr[qmax.First()];
                }



            }


            return res;

        
        
        
        }

        static void Main(string[] args)
        {
            int[] arr = {4,3,5,4,3,3,6,7 };
            arr = new Program().getMaxWindow(arr,3);
            foreach (var item in arr)
            {
                Console.Write("{0}  ",item);
                
            }
            Console.WriteLine();
            Console.ReadKey();



        }
    }
}
