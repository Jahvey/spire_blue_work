import java.util.*;

public class LeetCode301{
	
	public List<Integer> findSubstring(String s,String[]words){
		
		List<Integer> result = new ArrayList<Integer>();
        if(words.length == 0){
            return result;
        }
        int wordLength = words[0].length();
        int allWordsLength = words.length;
        Map<String, Integer> wordMap = new HashMap<String, Integer>();
        
        for(int j = 0 ; j<words.length ; j++){
            wordMap.put(words[j], -1);
        }
        
        int start = 0;
        for(int i = 0 ; i<s.length()-wordLength ;){
            String current = s.substring(i, i+wordLength);
            if(wordMap.containsKey(current)){
                int key = wordMap.get(current);
                //出现重复情况
                if(key>=start){
                    start = key + wordLength;
                //长度等于所有长度
                }else if(i-start == wordLength*(allWordsLength-1)){
                    result.add(start);
                    start+=wordLength;
                }    
                wordMap.replace(current, i);
                i+=wordLength;
                continue;
            }
            i++;
            start = i;
        }
        return result;
		
	}
	
	public static void main(String []args){
		
		System.out.println("aa");
		
		String s = "wordgoodstudentgoodword";
		String[] words = new String[] { "word", "student" };


		List<Integer> list =(List<Integer>) new LeetCode301().findSubstring(s, words) ;
		showData(list);
		s = "barfoothefoobarman";
		words = new String[] { "foo", "bar" };//[0,9]
		list = (List<Integer>)new LeetCode301().findSubstring(s, words);
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
	
	
}