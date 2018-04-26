import java.util.*;
import java.lang.*;

public class FindMedianSortedArrays{
	public static void main(String args[]){
		
		int[] a = new int[] { 1, 2 };
            int[] b = new int[] { 3, 4 ,6};
            System.out.println(FindMedianSortedArray(a, b));
             a = new int[] { 2,1 };
            b = new int[] { 6,4,3 };

            System.out.println(FindMedianSortedArray(a,b));


            a = new int[] { 2, 3 };
            b = new int[] { 1, 4 };

            System.out.println(FindMedianSortedArray(a, b));
            a = new int[] { 3, 2 };
            b = new int[] { 4, 1 };

            System.out.println(FindMedianSortedArray(a, b));
		
		
	}
	
	
	public static double FindMedianSortedArray(int[] nums1, int[] nums2) {
            int n = nums1.length;
            int m = nums2.length;
            if (n > m)   //保证数组1一定最短
                return FindMedianSortedArray(nums2, nums1);
            int L1=0, L2=0, R1=0, R2=0, c1, c2, lo = 0, hi = 2 * n;  //我们目前是虚拟加了'#'所以数组1是2*n长度
            while (lo <= hi)   //二分
            {
                c1 = (lo + hi) / 2;  //c1是二分的结果
                c2 = m + n - c1;
                L1 = (c1 == 0) ? Integer.MIN_VALUE : nums1[(c1 - 1) / 2];   //map to original element
                R1 = (c1 == 2 * n) ?  Integer.MAX_VALUE: nums1[c1 / 2];
                L2 = (c2 == 0) ? Integer.MIN_VALUE : nums2[(c2 - 1) / 2];
                R2 = (c2 == 2 * m) ? Integer.MAX_VALUE : nums2[c2 / 2];

                if (L1 > R2)
                    hi = c1 - 1;
                else if (L2 > R1)
                    lo = c1 + 1;
                else
                    break;
            }
            return (Math.max(L1, L2) + Math.min(R1, R2)) / 2.0;

        }
	
	
}

