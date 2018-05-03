using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode301_substring_with_concatenation
{
    class Program
    {

      public   IList<int> FindSubstring(string s, string[] words)
        {
	IList<int>re=new List<int>();
	//if (s.empty() || words.empty()) return re;
            if(s==string.Empty||(words.Length==1&&words[0]==string.Empty))return re;
	int n = words[0].Length, length1 = s.Length, length2 = words.Length;
	Dictionary<string, int> aa=new Dictionary<string,int>();
	//for (auto x : words) ++aa[x];
    foreach (var x in words)
    {
        if (!aa.ContainsKey(x)) aa.Add(x,1);
        else
        ++aa[x];
        
    }
	for (int i = 0; i < n; ++i){
		int Left = i, Right = i;//  l指向滑动窗口最左边的单词的起始点， r指向滑动窗口最右边的单词的起始点
		Dictionary<string, int> bb=new Dictionary<string,int>();
        while (Right + n <= s.Length)
        {
            //s.Substring(Right,n)
           // if (aa.count(s.substr(Right, n)))

            Console.WriteLine ("right:=" + Right + ",n=" + n + ",s=" + s);
            if(aa.ContainsKey(s.Substring(Right,n)))
            {//有效单词
               // string wd = s.substr(Right, n);
                string wd = s.Substring(Right,n);
                if (!bb.ContainsKey(wd)) bb.Add(wd, 1);
                else
				++bb[wd];
                Right += n;
				if (bb[wd] < aa[wd]) continue; // 当前单词个数小于目标单词个数，r右移，添加最右端单词(continue,跳到下一次循环自动执行)

				while (bb[wd] > aa[wd]){   //当前单词个数大于目标单词个数，删除最左端单词，l右移
				//	if (--bb[s.substr(Left, n)] == 0)
				//		bb.erase(s.substr(Left, n));
                    if (--bb[s.Substring(Left, n)] == 0)
                        bb.Remove(s.Substring(Left,n));
					Left += n;
				}//这里一定要注意用while循环（而不是if），直到当前单词个数等于目标单词个数，具体原因可以自己跑样例写下体会下


				if (bb[wd] == aa[wd] && Right - Left == length2 * n){  //当前单词个数等于目标单词个数，比较目前单词总数与目标单词总数是否相等，
					//如果不相等：r右移，添加最右端单词(跳到下一次循环自动执行)。如果相等：删除最左端单词，l右移；r右移，添加最右端单词(跳到下一次循环自动执行)。
					//re.push_back(l);
                    re.Add(Left);
				//	if (--bb[s.substr(Left, n)] == 0)
				//		bb.erase(s.substr(Left, n));
                    if (--bb[s.Substring(Left, n)] == 0)
                        bb.Remove(s.Substring(Left, n));
					Left += n;
				}
			}
			else {  //如果单词无效，则l,r跳到下一个单词处重新开始计数
				//bb.clear();
                bb.Clear();
				Right += n;
				Left = Right;
			}
		}
	}
	return re;
}


        static void Main(string[] args)
        {

            Console.WriteLine("aabbccddee".Substring(0,5));
            // Console.WriteLine("aa");
           string s = "wordgoodstudentgoodword";
            string []words = new []{"word","student"};

             
            List<int> list = new Program().FindSubstring(s, words) as List<int>;
            showData(list);
            s = "barfoothefoobarman";
            words = new[] { "foo", "bar" };//[0,9]
             list=new Program().FindSubstring(s,words) as List<int>;
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
