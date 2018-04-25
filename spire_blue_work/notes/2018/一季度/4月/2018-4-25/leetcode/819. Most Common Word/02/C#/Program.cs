using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using System.Text.RegularExpressions;

namespace pdfExtSVGError1
{
    class Program
    {
        static void Main(string[] args)
        {

            // save2svg();

            InvokeMostCommonWord();



        }

        private static void InvokeMostCommonWord()
        {


            String[] banned = { "m", "q", "e", "l", "c", "i", "z", "j", "g", "t", "w", "v", "h", "p", "d", "b", "a", "r", "x", "n" };
            Console.WriteLine(new Program().MostCommonWord("j. t? T. z! R, v, F' x! L; l! W. M; S. y? r! n; O. q; I? h; w. t; y; X? y, p. k! k, h, J, r? w! U! V; j' u; R! z. s. T' k. P? M' I' j! y. P, T! e; X. w? M! Y, X; G; d, X? S' F, K? V, r' v, v, D, w, K! S? Q! N. n. V. v. t? t' x! u. j; m; n! F, V' Y! h; c! V, v, X' X' t? n; N' r; x. W' P? W; p' q, S' X, J; R. x; z; z! G, U; m. P; o. P! Y; I, I' l' J? h; Q; s? U, q, x. J, T! o. z, N, L; u, w! u, S. Y! V; S? y' E! O; p' X, w. p' M, h! R; t? K? Y' z? T? w; u. q' R, q, T. R? I. R! t, X, s? u; z. u, Y, n' U; m; p? g' P? y' v, o? K? R. Q? I! c, X, x. r' u! m' y. t. W; x! K? B. v; m, k; k' x; Z! U! p. U? Q, t, u' E' n? S' w. y; W, x? r. p! Y? q, Y. t, Z' V, S. q; W. Z, z? x! k, I. n; x? z; V? s! g, U; E' m! Z? y' x? V! t, F. Z? Y' S! z, Y' T? x? v? o! l; d; G' L. L, Z? q. w' r? U! E, H. C, Q! O? w! s? w' D. R, Y? u. w, N. Z? h. M? o, B, g, Z! t! l, W? z, o? z, q! O? u, N; o' o? V; S! z; q! q. o, t! q! w! Z? Z? w, F? O' N' U' p? r' J' L; S. M; g' V. i, P, v, v, f; W? L, y! i' z; L? w. v, s! P?", banned));

            String input = "Bob hit a ball, the hit BALL flew far after it was hit.";
            banned = null;
            banned = new string[] { "hit" };
            Console.WriteLine(new Program().MostCommonWord(input, banned));

            Console.ReadKey();
        }

        public string MostCommonWord(string paragraph, string[] banned)
        {
            string result = "";
            HashSet<String> ban = new HashSet<String>(banned);
            Dictionary<String, int> count = new Dictionary<String, int>();
            // 使用"['?!,; .]+"去除标点符号

            paragraph = paragraph.ToLower();
            String[] words = paragraph.Split(new char[] { ' ' });
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = Regex.Replace(words[i], "['?!,; .]+", "");

            }

            int max = 0;


            foreach (var w in words)
            {

                if (!ban.Contains(w))
                {
                    if (!count.ContainsKey(w)) count.Add(w, 1);
                    else {
                        //count.Add(w, count[w] + 1);
                        count[w] += 1;
                    }
                    
                    if (count[w] > max)
                    {
                        result = w;
                        max = count[w];
                    }
                }

            }




            return result;


        }

        public string MostCommonWord_old(string paragraph, string[] banned)
        {

            //大小写屏蔽,并且去除掉一些奇奇怪怪的标点符号
            paragraph = paragraph.ToLower();
            string[] split = paragraph.Split(new char[] { ' ' });

            for (int i = 0; i < split.Length; i++)
            {
                split[i] = Regex.Replace(split[i], "['?!,; .]+", "");
            }

            // paragraph = Regex.Replace(paragraph, "['?!,; .]+", "");

            string result = "";
            Dictionary<string, int> dics = new Dictionary<string, int>();

            int[] count = new int[split.Length];//用于存放单词出现频率的数组
            int[] index = new int[split.Length];//用于存放count数组中的下标值
            for (int i = 0; i < split.Length; i++)
            {
                if (!dics.ContainsKey(split[i]))
                {
                    dics.Add(split[i], i);
                    count[i]++;
                }
                else
                {
                    int res = dics[split[i]];
                    count[res]++;

                }

            }
            //这一步循环完成之后得到的结果为一个count类型的数组，并且这个count数组的下标代表的是原来split[]数组中所表示的元素的下标（很重要）

            for (int i = 0; i < index.Length; i++)
            {
                index[i] = i;//代表split中每一个元素的下标值，将下标跟数组元素绑定

            }

            for (int i = 0; i < count.Length - 1; i++)
            {
                for (int j = i + 1; j < count.Length; j++)
                {
                    if (count[i] < count[j])
                    {
                        int tem = count[i];
                        count[i] = count[j];
                        count[j] = tem;
                        int met = index[i];//下标也要变化
                        index[i] = index[j];
                        index[j] = met;
                    }
                }
            }
            //做完以上的冒泡排序，可以得到两个已经排好序（从大到小）的两个数组
            //其中，count数组表示的是split数组的众数，而index表示split数组中的索引
            for (int i = 0; i < split.Length; i++)
            {//count从大到小排列，help[i]即是count[i]在原数组split中的下标
                String le = split[index[i]];
                //Console.WriteLine("le is " + le);
                Boolean issame = false;
                for (int j = 0; j < banned.Length; j++)
                {
                    if (String.Equals(le, banned[j]))
                    {
                        issame = true; break;
                    }
                }
                if (issame == false) return le;
            }


            return result;


        }
        private static void save2svg()
        {
            PdfDocument document = new PdfDocument();
            document.LoadFromFile("Tista reviseted.pdf");
            document.SaveToFile("Result.svg", FileFormat.SVG);
            System.Diagnostics.Process.Start("Result.pdf");
        }
    }
}
