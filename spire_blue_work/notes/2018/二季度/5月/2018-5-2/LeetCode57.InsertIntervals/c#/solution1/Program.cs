using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode57_InsertIntervals
{


    /// <summary>
    /// interval class
    /// </summary>
    public class Interval
    {
        public int start;
        public int end;
        public Interval()
        {
            start = 0;
            end = 0;
        }
        public Interval(int s, int e)
        {
            start = s;
            end = e;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IList<Interval> num = new List<Interval>();

            Interval add = testMethod1(num);
            IList<Interval> list = insert(num, add);

            foreach (var i in list)
            {
                Console.Write("{0}  {1}  \n", i.start, i.end);

            }
            Console.WriteLine();

            Console.ReadKey();


        }

        private static Interval testMethod1(IList<Interval> num)
        {
            Interval in1 = new Interval();
         //   Console.WriteLine(num);
           // Console.WriteLine(in1);
            num.Add(in1);

            Interval add = new Interval(5, 7);
            return add;
        }



        public static IList<Interval> insert(IList<Interval> intervals,
            Interval newInterval)
        {
            IList<Interval> res = new List<Interval>();
            int id=0;
            while(id<intervals.Count&&intervals[id].start<newInterval.start){
                id++;
            
            }

            intervals.Add(newInterval);
            Interval last = null;
            foreach (var item in intervals)
            {
                if (last == null || last.end < item.start)
                {

                    last = item;
                    res.Add(last);
                }
                else {
                    last.end = Math.Max(last.end,item.end);
                
                }
            }

            return res;
        }



    }
}
