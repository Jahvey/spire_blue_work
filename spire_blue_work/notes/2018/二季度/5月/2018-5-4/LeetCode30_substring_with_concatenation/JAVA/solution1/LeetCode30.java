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
        //NΪ�ַ�������
        Integer N = s.length();
        //�����,���ȱض��������ַ�������
        List<Integer> indexes = new ArrayList<Integer>(s.length());
        if (words.length == 0) {
            return indexes;
        }
        //MΪ�������ʵĳ���
        Integer M = words[0].length();
        //������е�������֮��ĳ��ȳ����ַ������ȣ��򷵻ؿս����
        if (N < M * words.length) {
            return indexes;
        }
        //last �ַ��������һ��������Ϊ������ʼ����±�
        Integer last = N - M + 1;
        
        //map�洢word������table[0]�ж�Ӧ���±�
        Map<String, Integer> mapping = new HashMap<String, Integer>(words.length);
        //table[0]�洢ÿ��word���ֵ���ʵ������table[1]�洢ÿ��wordĿǰΪֹ���ֵ�ͳ�ƴ���
        Integer [][] table = new Integer[2][words.length];
        //failures�洢words�в��ظ�ֵ������������["good","bad","good","bad"]��failures=2
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
        
        //�����ַ���s���ж��ַ�����ǰ�±���Ƿ����words�еĵ��ʣ�������ڣ�������table�е��±꣬��������Ϊ-1
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
            //��֤�ҽڵ㲻�����߽�
            while (right < last) {
                //��֤���ҽڵ�֮������ַ����ܹ��������е�wordֵ
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