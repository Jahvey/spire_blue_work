using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution4_getMidNum
{
    class Program
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            int n = nums1.Length;
            int m = nums2.Length;
            if (n > m)   //保证数组1一定最短
                return FindMedianSortedArrays(nums2, nums1);
            int L1=0, L2=0, R1=0, R2=0, c1, c2, lo = 0, hi = 2 * n;  //我们目前是虚拟加了'#'所以数组1是2*n长度
            while (lo <= hi)   //二分
            {
                c1 = (lo + hi) / 2;  //c1是二分的结果
                c2 = m + n - c1;
                L1 = (c1 == 0) ? int.MinValue: nums1[(c1 - 1) / 2];   //map to original element
                R1 = (c1 == 2 * n) ?  int.MaxValue: nums1[c1 / 2];
                L2 = (c2 == 0) ? int.MinValue: nums2[(c2 - 1) / 2];
                R2 = (c2 == 2 * m) ? int.MaxValue : nums2[c2 / 2];

                if (L1 > R2)
                    hi = c1 - 1;
                else if (L2 > R1)
                    lo = c1 + 1;
                else
                    break;
            }
            return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2.0;

        }
        public static double FindMedianSortedArrays_BUG(int[] a, int[] b)
        {
            int aLen = a.Length-1;
            int bLen = b.Length-1;
            //1.一个数组完全包含另外一个数组
            if (a[0] <= b[0] & b[bLen] <= a[aLen]&b[0]<=b[bLen])
            { //a完全包含b,并且从小到大排序
                if ((b.Length)%2.0 != 0.0)//说明b数组个数为奇数个
                    return b[b.Length / 2 ];
                else //说明是偶数
                    return (b[b.Length / 2] + b[b.Length / 2 - 1]) / 2.0;

            }
            else if (b[0] <= a[0] & a[aLen] <= b[bLen] & b[0] <= b[bLen])//b完全包含a,并且从小到大排序
            {
                if ((a.Length) % 2.0 != 0.0)//说明b数组个数为奇数个
                    return a[a.Length / 2 ];
                else //说明是偶数
                    return (a[a.Length / 2] + a[a.Length / 2 - 1]) / 2.0;

            }
            else if (a[aLen] <= b[bLen] & b[0] <= a[0])
            {//a完全包含b,并且从大到小排序
                if ((b.Length) % 2.0 != 0.0)//说明b数组个数为奇数个
                    return b[b.Length / 2];
                else //说明是偶数
                    return (b[b.Length / 2] + b[b.Length / 2 - 1]) / 2.0;

            }
            else if (b[bLen] <= a[aLen] & a[0] <= b[0])//b完全包含a,并且从大到小排序
            {
                double index = (a.Length)% 2.0;
                if ((a.Length) % 2.0 != 0.0)//说明b数组个数为奇数个
                    return a[a.Length / 2 ];
                else //说明是偶数
                    return (a[a.Length / 2] + a[a.Length / 2 - 1]) / 2.0;

            }


            //1.完全不考虑两个数组有交集
            //考虑从小到大排序
            if ((a[0] <= b[0]) & (a[aLen] <= b[0]) & b[0] <= b[bLen]) return (a[aLen] + b[0]) / 2.0;
            else if ((b[0] <= a[0]) & (b[bLen] <= a[0]) & b[0] <= b[bLen]) return (b[bLen] + a[0]) / 2.0;  
                //考虑的是从大到小排序
            else if((a[0]<=b[bLen])&(a[aLen]<=b[bLen])) return (a[0]+b[bLen])/2.0;
            else if ((b[0] <= a[aLen]) & (b[bLen] <= a[aLen])) return (b[0] + a[aLen]) / 2.0;
           
                //2.两个数组有部分交集

            return 0.0;
        }

        static void Main(string[] args)
        {
            int[] a = new[] { 1, 2 };
            int[] b = new[] { 3, 4 ,6};
            Console.WriteLine(FindMedianSortedArrays(a, b));
             a = new[] { 2,1 };
            b = new[] { 6,4,3 };

            Console.WriteLine(FindMedianSortedArrays(a,b));


            a = new[] { 2, 3 };
            b = new[] { 1, 4 };

            Console.WriteLine(FindMedianSortedArrays(a, b));
            a = new[] { 3, 2 };
            b = new[] { 4, 1 };

            Console.WriteLine(FindMedianSortedArrays(a, b));
            Console.ReadKey();
        }
    }
}
