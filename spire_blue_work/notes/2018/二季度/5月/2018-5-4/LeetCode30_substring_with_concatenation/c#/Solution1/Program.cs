using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode302_substring_with_concatenation
{
    class Program
    {
        # region FindSubstring2_result_no_view
        //public IList<int> FindSubstring2_result_no_view(string s, string[] words) { 
            
        ////N为字符串长度
        //int N = s.Length;
        ////结果集,长度必定不超过字符串长度
        //List<int> indexes = new List<int>(s.Length);
        //if (words.Length == 0) {
        //    return indexes;
        //}
        ////M为单个单词的长度
        //int M = words[0].Length;
        ////如果所有单词连接之后的长度超过字符串长度，则返回空结果集
        //if (N < M * words.Length) {
        //    return indexes;
        //}
        ////last 字符串中最后一个可以作为单词起始点的下标
        //int last = N - M + 1;
        //int wdl=words.Length;
        ////map存储word和其在table[0]中对应的下标
        //Dictionary<String, int> mapping = new Dictionary<String, int>(words.Length);
        ////table[0]存储每个word出现的真实次数，table[1]存储每个word目前为止出现的统计次数
            
        //int [,] table = new int[2,wdl];
        ////failures存储words中不重复值的总数，例如["good","bad","good","bad"]，failures=2
        //int failures = 0, index = 0;
        //for (int i = 0; i < words.Length; ++i) {
        //    int mapped = 0;
        //    if (mapping.ContainsKey(words[i]))
        //    {
        //        mapped = mapping[words[i]];
        //        Console.WriteLine("mapped1=" + mapped);
        //        if (mapped == null)
        //        {
        //            ++failures;
        //            mapping.Add(words[i], index);
        //            mapped = index++;
        //        }
        //        Console.WriteLine("mapped2=" + mapped);

        //        if (table[0, mapped] == null) table[0, mapped] = 1;
        //        else
        //            ++table[0, mapped];
        //        Console.WriteLine("table[0,mapped]=" + table[0, mapped]);

        //    }
        //    else {
        //        mapping.Add(words[i],1);
                
        //    } 
        //}
        
        ////遍历字符串s，判断字符串当前下标后是否存在words中的单词，如果存在，则填入table中的下标，不存在则为-1
        //int [] smapping = new int[last];
        //for (int i = 0; i < last; ++i) {
        //  //  String section = s.substring(i, i + M);
        //    String section = s.Substring(i, M);//注意C# 和java substring的区别
        //    if (mapping.ContainsKey(section))
        //    {
        //        int mapped = mapping[section];
        //        if (mapped == null)
        //        {
        //            smapping[i] = -1;
        //        }
        //        else
        //        {
        //            smapping[i] = mapped;
        //        }

        //    }
        //    else {
        //        mapping.Add(section,1);
            
        //    }
           
        //}
        
        ////fix the number of linear scans
        //for (int i = 0; i < M; ++i) {
        //    //reset scan variables
        //    int currentFailures = failures; //number of current mismatches
        //    int left = i, right = i;
        //    //Arrays.fill(table[1], 0);
        //    for (int j = 1; j < 2; j++)
        //    {
        //        for (int k = 0; k < wdl; k++)
        //        {
        //            table[j,k] = 0;
                    
        //        }
                
        //    }
        
        //    //here, simple solve the minimum-window-substring problem
        //    //保证右节点不超出边界
        //    while (right < last) {
        //        //保证左右节点之间的子字符串能够包含所有的word值
        //        while (currentFailures > 0 && right < last) {
        //            int target = smapping[right];
        //            if (target != -1 && ++table[1,target] == table[0,target]) {
        //                --currentFailures;
        //            }
        //            right += M;
        //        }
        //        while (currentFailures == 0 && left < right) {
        //            int target = smapping[left];
        //            if (target != -1 && --table[1,target] == table[0,target] - 1) {
        //                int Length = right - left;
        //                //instead of checking every window, we know exactly the Length we want
        //                if ((Length / M) ==  words.Length) {
        //                    indexes.Add(left);
        //                }
        //                ++currentFailures;
        //            }
        //            left += M;
        //        }
        //    }
            
        //}
        //return indexes;



        //}
#endregion

        #region FindSubstring1_someerror
        //public IList<int> FindSubstring1_someerror(string s, string[] words) {

       //     IList<int> res = new List<int>();

       //     if (s==string.Empty|| (words.Length==1&&words[0]==string.Empty))
       // {
       //     return res;
       // }
       //     int sLen = s.Length;//母串的总长度
       //     int wordLen = words[0].Length;//单个单词的长度
       //     int wordCount = words.Count();//单词的个数
       //     int subLen = wordLen * wordCount;//每次需要从母串中拿来进行匹配的子串的长度
       //     Dictionary<string, int> myWords=new Dictionary<string,int>();
       //     int i=0;
       //     int j=0;
       //     int k=0;
       //     for (i = 0; i < wordCount; i++)
       //     {
       //         if (!myWords.ContainsKey(words[i])) myWords.Add(words[i],1);
       //         myWords[words[i]] = myWords[words[i]] + 1;
       //     }//用来记录words中所有word出现的次数用于后面的计算
       //     i = 0;
       //     int count;
       //     while(i<sLen-subLen+1){
       //         Dictionary<string, int> tempMap = myWords;
       //         count = 0;
       //         int subCount = i + subLen;//临时保存母串中需要拿出来匹配的长度
       //         //不能直接while(k<subLen + i)因为满足当i自增后会循环条件变化，内循环会多循环一次

       //         k = i;
       //         //while (count<wordCount) { 
                
    
       //         while (count<wordCount||k < subCount) {
       //             string temp = s.Substring(k, wordLen);//取出一个与word长度一样的子串
       //             if (!tempMap.ContainsKey(temp))//没有找到说明从i开头的子串中没有需要的单词，这个直接时候i++，并跳出循环 
       //             {
       //                 i++;
       //                 break;
       //             }
       //             else
       //             {
             

       //                 if (tempMap[temp] > 0)
       //                 {
       //                     tempMap[temp]--;//”用过“的单词从临时Map中剔除
       //                     k += wordLen;//k跳到下一个单词
       //                     count++;
       //                 }
       //                 //虽然找到，但多余了，也要剔除
       //                 else
       //                 {
       //                     i++;
       //                     break;
       //                 }
       //             }

       //             //关于何时往结果集中添加。我目前的办法是，在子串中每找到一个
       //             //单词count++，直到找到所有单词，即count==wordCount
       //             //希望有更好的办法
       //             // if (count == wordCount)
       //             if (count==wordCount|| k == subCount)
       //             {
       //                 // res.push_back(i);
       //                 //tempMap.clear();
       //                 res.Add(i);
       //                 tempMap.Clear();
       //                 i++;
       //             }

                
                
       //         }

             
               
                
            
            
       //     }



       //     return res;
       // }
#endregion

        public IList<int> FindSubstring1(string s, string[] words) {
            List<int> result = new List<int>();
            if (words.Length == 0)
            {
                return result;
            }
            int wordLength = words[0].Length;
            int allWordsLength = words.Length;
            Dictionary<String, int> wordMap = new Dictionary<String, int>();

            for (int j = 0; j < words.Length; j++)
            {
                //wordMap.put(words[j], -1);
                wordMap.Add(words[j],-1);
            }

            int start = 0;
            for (int i = 0; i < s.Length - wordLength; )
            {
               // String current = s.substring(i, i + wordLength);
                String current = s.Substring(i, wordLength);
                if (wordMap.ContainsKey(current))
                {
                    int key = wordMap[current];
                    //出现重复情况
                    if (key >= start)
                    {
                        start = key + wordLength;
                        //长度等于所有长度
                    }
                    else if (i - start == wordLength * (allWordsLength - 1))
                    {
                        result.Add(start);
                        start += wordLength;
                    }
                    wordMap.Remove(current);
                    wordMap.Add(current,i);
                    //wordMap.replace(current, i);
                    i += wordLength;
                    continue;
                }
                i++;
                start = i;
            }
            return result;
		
        
        
        }


        public IList<int> FindSubstring2(string s, string[] words)
        {
            List<int> result = new List<int>();
            if (words.Length == 0)
            {
                return result;
            }
            int wordLength = words[0].Length;
            int allWordsLength = words.Length;
           Dictionary<String, int> wordMap = new Dictionary<String, int>();

            for (int j = 0; j < words.Length; j++)
            {
                //wordMap.put(words[j], -1);
                if (!wordMap.ContainsKey(words[j]))
                    wordMap.Add(words[j], -1);
                else {
                    wordMap.Remove(words[j]);
                    wordMap.Add(words[j],-1);
                }
                    

            }

            int start = 0;
            for (int i = 0; i < s.Length - wordLength; )
            {
                // String current = s.substring(i, i + wordLength);
                String current = s.Substring(i, wordLength);
               if (wordMap.ContainsKey(current))

                {
                    int key = wordMap[current];
                    //出现重复情况
                    if (key >= start)
                    {
                        start = key + wordLength;
                        //长度等于所有长度
                    }
                    else if (i - start == wordLength * (allWordsLength - 1))
                    {
                        result.Add(start);
                        start += wordLength;
                    }
                    wordMap.Remove(current);
                    wordMap.Add(current, i);
                    //wordMap.replace(current, i);
                    i += wordLength;
                    continue;
                }
                i++;
                start = i;
            }
            return result;



        }



        /// <summary>
        /// final success the problem .
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> FindSubstring(string s, string[] words) {
            List<int> result = new List<int>();
            if (words.Length == 0)
            {
                return result;
            }
            int wordLength = words[0].Length;
            int allWordsLength = words.Length;


            Dictionary<String, int> wordMap = new Dictionary<String, int>();
            for (int j = 0; j < words.Length; j++)
            {
                if (wordMap.ContainsKey(words[j]))
                {
                    wordMap[words[j]] = wordMap[words[j]] + 1;
                }
                else {

                    wordMap.Add(words[j],1);
                }
                //wordMap.Add(words[j], wordMap.ContainsKey(words[j]) ? wordMap[words[j]] + 1 : 1);
            }

            for (int start = 0; start <= s.Length - wordLength * allWordsLength; start++)
            {
                //副本
                Dictionary<String, int> copy = new Dictionary<String, int>(wordMap);
                for (int i = start; i < start + wordLength * allWordsLength; i += wordLength)
                {
                    String current = s.Substring(i,  wordLength);
                    if (copy.ContainsKey(current))
                    {
                        int key = copy[current];
                        if (key == 1)
                        {
                            copy.Remove(current);
                        }
                        else
                        {
                            copy[current] = copy[current] - 1;

                           // copy.Add(current, key - 1);
                        }
                        if (copy.Count==0)
                        {
                            result.Add(start);
                            //及时跳出循环，否则可能造成超时问题
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        
        }


        static void Main(string[] args)
        {
          //  Console.WriteLine("aabbccddee".Substring(0, 5));
            // Console.WriteLine("aa");
            string s = "wordgoodstudentgoodword";
            string[] words = new[] { "word", "student" };


            List<int> list =new Program().FindSubstring(s, words) as List<int> ;
            showData(list);
            s = "barfoothefoobarman";
            words = new[] { "foo", "bar" };//[0,9]
            list = new Program().FindSubstring(s, words) as List<int>;
            showData(list);

            s="wordgoodgoodgoodbestword";
            words = new[] { "word", "good", "best", "good" };
            list = new Program().FindSubstring(s, words) as List<int>;
            showData(list);


            Console.ReadKey();

        }


        private static void showData(List<int> list)
        {
            foreach (var x in list)
            {
                Console.Write("{0}  ", x);

            }
            Console.WriteLine();
        }
    }
}
