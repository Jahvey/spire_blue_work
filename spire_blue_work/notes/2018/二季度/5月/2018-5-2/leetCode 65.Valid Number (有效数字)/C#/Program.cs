using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode65_ValidNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            String[] tmp = { "0 ", "0.1 ", "abc ", "1 2 ", "+-2e10 " };
            for (int i = 0; i < tmp.Length; i += 1)
            {
                Console.WriteLine(tmp[i] + isNumber(tmp[i]));

            }
            Console.ReadKey();
        }


        public static bool isNumber(String s)
        {
            // Start typing your Java solution below  
            // DO NOT write main() function  
            /*  
        
            "0" => true 
             "     0.1     " => true 
             "abc" => false 
             "1 a" => false 
             "+-2e10" => true 
             //*/
            //check input.  
            if (s == null || s.Length == 0) return false;
            int sz = s.Length;
            int i = 0;
            
            while (i < sz && s[i] == ' ') ++i;

            bool space = false;
            bool exp = false;
            bool dot = false;
            bool number = false;
            bool neg = false;

            for (; i < sz; i++)
            {
                char c = s[i];
                if (c == ' ')
                {
                    space = true;
                }
                else if (space == true)
                {
                    return false;
                }
                else if ((c == 'e' || c == 'E') && exp == false && number == true)
                {
                    exp = true;
                    number = false;
                    dot = true;
                    neg = false;
                }
                else if (c == '.' && dot == false)
                {
                    dot = true;
                    neg = true;
                    // number = false;  
                }
                else if (c >= '0' && c <= '9')
                {
                    number = true;
                }
                else if ((c == '+' || c == '-') && neg == false && number == false)
                {
                    neg = true;
                }
                else
                {
                    return false;
                }
            }
            return number;

        }
    }
}
