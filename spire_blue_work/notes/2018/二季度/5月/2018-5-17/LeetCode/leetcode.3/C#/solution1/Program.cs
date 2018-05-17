using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace playtheCode
{
    class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s) {
            if (s.Length < 2) { return s.Length; }

            int res = 0;

          //  int []arr=new int[s.Length];
            Dictionary<char, int> arr = new Dictionary<char, int>();
            int j=0;
            for (int i = 0; i < s.Length; i++)
            {
                if (arr.ContainsKey(s[i]))
                {
                    arr[s[i]] = arr[s[i]] + 1;
                }
                else {
                    arr.Add(s[i],1);
                
                }


                

                    while (arr[s[i]] > 1) {
                        if (arr[s[i]] > 1)
                        {
                        //arr[s[i]] = arr[s[j++]] - 1;//some error
                            --arr[s[j]];
                            j++;
                        }
                    }

                res = Math.Max(res,i-j+1);

                
            }


            return res;

        
        }


        static void Main(string[] args)
        {
           Console.WriteLine(LengthOfLongestSubstring("aabbbb"));
            Console.WriteLine(LengthOfLongestSubstring("bbbbbb"));

            Console.WriteLine(LengthOfLongestSubstring("pwwkew"));
            Console.ReadKey();


        }
    }
}
