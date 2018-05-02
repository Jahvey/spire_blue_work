using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Leetcode027_InsertIntervals
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
            IList<Interval> num = new List<Interval>() ;

           // Interval add = testNum1(num);
         //   Interval add = testNum2(num);
           // Interval add = testNum3(num);

            Interval in1 = new Interval();
            Console.WriteLine(num);
            Console.WriteLine(in1);
            num.Add(in1);

            Interval add = new Interval(5, 7);
            IList<Interval> list = insert(num, add) ;

            foreach (var i in list)
            {
                Console.Write("{0}  {1}  \n",i.start,i.end);
                
            }
            Console.WriteLine();

            Console.ReadKey();

        }
        #region begin test
        private static Interval testNum3(LinkedList<Interval> num)
        {
            Interval in1 = new Interval();

            num.AddLast(in1);

            Interval add = new Interval(5, 7);
            return add;
        }

        private static Interval testNum2(LinkedList<Interval> num  )
        {
            Interval in1 = new Interval(1, 3);
            Interval in2 = new Interval(6, 9);
   
            num.AddLast(in1);
            num.AddLast(in2);
       


            Interval add = new Interval(2, 5);
            return add;
        }

        private static Interval testNum1(LinkedList<Interval> num)
        {
            Interval in1 = new Interval(1, 3);
            Interval in2 = new Interval(4, 6);
            Interval in3 = new Interval(8, 10);
            Interval in4 = new Interval(13, 20);
            num.AddLast(in1);
            num.AddLast(in2);
            num.AddLast(in3);
            num.AddLast(in4);


            Interval add = new Interval(5, 9);
            return add;
        }
        #endregion


       


        public static IList<Interval> insert(IList<Interval> intervals,
            Interval newInterval) { 
      
                IList<Interval> res = new List<Interval>() ;
                //输入集如果是非空的  
                if (intervals != null)
                {
                    //  for(Interval item : intervals){  
                    foreach (Interval item in intervals)
                    {


                        if (newInterval == null || item.end < newInterval.start)
                        {
                           
                            res.Add(item);
                        }

                        //将比插入区间大的区间插入到结果集中  
                        else if (item.start > newInterval.end)
                        {
                            res.Add(newInterval);
                            res.Add(item);
                            newInterval = null;
                        }

                        //插入区间有重叠，更新插入区间  
                        else
                        {
                            newInterval.start = Math.Min(newInterval.start, item.start);
                            newInterval.end = Math.Max(newInterval.end, item.end);
                        }

                    }
                }

                if (res.Count == 1 && res.First().end == 0)
                {
                    res.Clear();
                    res.Add(newInterval);
                }


                return res;
        }


        public static LinkedList<Interval> insertRegion(LinkedList<Interval> intervals,
            Interval newInterval)
        {
            //保存结果集  
            LinkedList<Interval> res = new LinkedList<Interval>();

            //输入集如果是非空的  
            if (intervals != null)
            {
                //  for(Interval item : intervals){  
                foreach (Interval item in intervals)
                {


                    if (newInterval == null || item.end < newInterval.start)
                    {
                        res.AddLast(item);
                    }

                    //将比插入区间大的区间插入到结果集中  
                    else if (item.start > newInterval.end)
                    {
                        res.AddLast(newInterval);
                        res.AddLast(item);
                        newInterval = null;
                    }

                    //插入区间有重叠，更新插入区间  
                    else
                    {
                        newInterval.start = Math.Min(newInterval.start, item.start);
                        newInterval.end = Math.Max(newInterval.end, item.end);
                    }

                }
            }

            if (res.Count == 1 && res.First().end == 0) {
                res.Clear();
                res.AddLast(newInterval);
            }


            return res;
        }

    }
}
