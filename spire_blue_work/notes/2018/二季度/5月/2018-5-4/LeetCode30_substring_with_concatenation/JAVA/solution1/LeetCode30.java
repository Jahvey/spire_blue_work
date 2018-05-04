import java.util.*;
import java.lang.*;

public class LeetCode30 {
	
	public static void main(String []args){
		
		String s = "wordgoodstudentgoodword";
            String[] words = new String[] { "word", "student" };


            List<Integer> list =(List<Integer>) new LeetCode30().findSubstring(s, words) ;
            showData(list);
            s = "barfoothefoobarman";
            words = new String[] { "foo", "bar" };//[0,9]
            list = (List<Integer>)new LeetCode30().findSubstring(s, words);
            showData(list);
		
		
	}
	
	private static void showData(List<Integer> list)
        {
            for (Integer x:list)
            {
                System.out.printf("%d  ", x);

            }
            System.out.println();
        }
	
  
       public List<Integer> findSubstring(String s, String[] words) {
        //N为字符串长度
        Integer N = s.length();
        //结果集,长度必定不超过字符串长度
        List<Integer> indexes = new ArrayList<Integer>(s.length());
        if (words.length == 0) {
            return indexes;
        }
        //M为单个单词的长度
        Integer M = words[0].length();
        //如果所有单词连接之后的长度超过字符串长度，则返回空结果集
        if (N < M * words.length) {
            return indexes;
        }
        //last 字符串中最后一个可以作为单词起始点的下标
        Integer last = N - M + 1;
        
        //map存储word和其在table[0]中对应的下标
        Map<String, Integer> mapping = new HashMap<String, Integer>(words.length);
        //table[0]存储每个word出现的真实次数，table[1]存储每个word目前为止出现的统计次数
        Integer [][] table = new Integer[2][words.length];
        //failures存储words中不重复值的总数，例如["good","bad","good","bad"]，failures=2
        Integer failures = 0, index = 0;
        for (Integer i = 0; i < words.length; ++i) {
            Integer mapped = mapping.get(words[i]);
			System.out.println("mapped1="+mapped);
            if (mapped == null) {
                ++failures;
                mapping.put(words[i], index);
                mapped = index++;
            }
			System.out.println("mapped2="+mapped);
			System.out.println("table[0][mapped]="+table[0][mapped]);
			 if(table[0][mapped]==null)table[0][mapped]=1;
			 else
            ++table[0][mapped];
        }
        
        //遍历字符串s，判断字符串当前下标后是否存在words中的单词，如果存在，则填入table中的下标，不存在则为-1
        Integer [] smapping = new Integer[last];
        for (Integer i = 0; i < last; ++i) {
            String section = s.substring(i, i + M);
            Integer mapped = mapping.get(section);
            if (mapped == null) {
                smapping[i] = -1;
            } else {
                smapping[i] = mapped;
            }
        }
        
        //fix the number of linear scans
        for (Integer i = 0; i < M; ++i) {
            //reset scan variables
            Integer currentFailures = failures; //number of current mismatches
            Integer left = i, right = i;
            Arrays.fill(table[1], 0);
            //here, simple solve the minimum-window-substring problem
            //保证右节点不超出边界
            while (right < last) {
                //保证左右节点之间的子字符串能够包含所有的word值
                while (currentFailures > 0 && right < last) {
                    Integer target = smapping[right];
                    if (target != -1 && ++table[1][target] == table[0][target]) {
                        --currentFailures;
                    }
                    right += M;
                }
                while (currentFailures == 0 && left < right) {
                    Integer target = smapping[left];
                    if (target != -1 && --table[1][target] == table[0][target] - 1) {
                        Integer length = right - left;
                        //instead of checking every window, we know exactly the length we want
                        if ((length / M) ==  words.length) {
                            indexes.add(left);
                        }
                        ++currentFailures;
                    }
                    left += M;
                }
            }
            
        }
        return indexes;
    
	}
}