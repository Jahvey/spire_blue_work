using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode._5
{
    /// <summary>
    /// 5.最长回文子串
    /// </summary>
    class Program
    {

        public static string longestPalindrome(string s) {
        int max_len=0;
        string res="";
        int ss=s.Length;
        int i,j,k;
        for(i=0;i<ss;i++){
            
            
            findRes(ref s,i-1,i+1,ref max_len,ref res);
        }
        
        for(i=0;i+1<ss;i++){
            
            findRes(ref s,i,i+1,ref max_len,ref res);
            
        }
        return res;
    }
    
       static void findRes(ref string  s,int j,int k,ref int  max_len,ref string  res){
        
        
        int ss=s.Length;
        while(j>=0&&k<=ss-1&&s[j]==s[k]){
            --j;
            ++k;
            
        }
        
        if(k-j-1 >max_len){
            
            
            max_len=k-j-1;
            res=s.Substring(j+1,max_len);
        }
        
        
    }


        static void Main(string[] args)
        {
            
            Console.WriteLine(~-10);
            Console.WriteLine(longestPalindrome("babad"));//bab
            Console.ReadKey();



        }
    }
}
