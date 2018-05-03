import java.util.*;
import java.lang.*;

class Program
{

  public   List<Integer> Findsubstring(String s, String[] words)
	{
	List<Integer>re=new ArrayList<Integer>();

	if(s==""||(words.length==1&&words[0]==""))return re;
	int n = words[0].length();
	int length1 = s.length();
	int length2 = words.length;
	Map<String, Integer> aa=new HashMap<String,Integer>();

	for(String x:words)
	{
		if (!aa.containsKey(x)) aa.put(x,1);
		else{

		int count=aa.get(x);
		aa.remove(x);
		aa.put(x,count++);
			
		}
		
		
	}
for (Integer i = 0; i < n; ++i){
	Integer Left = i, Right = i;//  l指向滑动窗口最左边的单词的起始点， r指向滑动窗口最右边的单词的起始点
	Map<String, Integer> bb=new HashMap<String,Integer>();
	while (Right + n <= s.length())
	{
	System.out.println("right:="+Right+",n="+n+",s="+s);
	
	//notice the C# substring and java substring difference.
		if(aa.containsKey(s.substring(Right,n+Right)))
		{//有效单词
	
			String wd = s.substring(Right,n+Right);
			if (!bb.containsKey(wd)) bb.put(wd, 1);
			else{

				int count=bb.get(wd);
				bb.remove(wd);
				bb.put(wd,count++);
				
			}
			
			Right += n;
			if (bb.get(wd) < aa.get(wd)) continue; // 当前单词个数小于目标单词个数，r右移，添加最右端单词(continue,跳到下一次循环自动执行)

			while (bb.get(wd) > aa.get(wd)){   //当前单词个数大于目标单词个数，删除最左端单词，l右移

				int count=bb.get(s.substring(Left, n+Left));
					if (--count == 0)
						bb.remove(s.substring(Left,n+Left));
					Left += n;
			}//这里一定要注意用while循环（而不是if），直到当前单词个数等于目标单词个数，具体原因可以自己跑样例写下体会下


			if (bb.get(wd) == aa.get(wd) && Right - Left == length2 * n){  //当前单词个数等于目标单词个数，比较目前单词总数与目标单词总数是否相等，
				//如果不相等：r右移，添加最右端单词(跳到下一次循环自动执行)。如果相等：删除最左端单词，l右移；r右移，添加最右端单词(跳到下一次循环自动执行)。
			
				re.add(Left);
				int count=bb.get(s.substring(Left, n+Left));
				if (-- count== 0)
					bb.remove(s.substring(Left, n+Left));
				Left += n;
			}
		}
		else {  //如果单词无效，则l,r跳到下一个单词处重新开始计数
			
			bb.clear();
			Right += n;
			Left = Right;
		}
	}
}
return re;
}
	

	public static void main(String[] args)
	{
	
	   String s = "wordgoodstudentgoodword";
		String []words = new String[]{"word","student"};

		 
		List<Integer> list = new Program().Findsubstring(s, words) ;
		showData(list);
		s = "barfoothefoobarman";
		words = new String[] { "foo", "bar" };//[0,9]
		 list=new Program().Findsubstring(s,words) ;
		 showData(list);

		
	}

	private static void showData(List<Integer>  list)
	{
		for (Integer x:list)
		{
			System.out.printf("%d  ", x);

		}
		System.out.println();
	}



}

