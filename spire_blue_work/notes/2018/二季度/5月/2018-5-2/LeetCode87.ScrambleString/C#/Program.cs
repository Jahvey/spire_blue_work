using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode87_ScrambleTheString
{
    class Program
    {

        public static bool isScramble(string s1, string s2)
        {
            //using the recursive
            int L1 = s1.Length;
            int L2 = s2.Length;
            if (L1 != L2) return false;
            if (L1 == 0) return true;

            char[] c1 = s1.ToCharArray();
            char[] c2 = s2.ToCharArray();
            if(L1==1)return c1[0]==c2[0];

            Array.Sort(c1);
            Array.Sort(c2);
           // Console.WriteLine(c1);
          //  Console.WriteLine(c2);
            for (int i = 0; i < L1; i++)
            {
                if (c1[i] != c2[i]) return false;
                //return true;
                
            }
            bool result = false;
            for (int i = 1; i <L1 && !result; ++i)
            {
                String s11 = s1.Substring(0, i);
                String s12 = s1.Substring(i);
                String s21 = s2.Substring(0, i);
                String s22 = s2.Substring(i);
                result = isScramble(s11, s21) && isScramble(s12, s22);
                if (!result)
                {
                    String s31 = s2.Substring(0, L1 - i);
                    String s32 = s2.Substring(L1 - i);
                    result = isScramble(s11, s32) && isScramble(s12, s31);
                }
            }
            return result;

        }

        static void Main(string[] args)
        {
            Console.WriteLine(isScramble("great","eatrg"));
            Console.WriteLine(isScramble("abcde", "caebd"));
            Console.ReadKey();


        }
    }
}
