using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode302_substring_with_concatenation
{
    class Program
    {

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
