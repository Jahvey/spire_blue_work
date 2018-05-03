import java.util.*;
import java.lang.*;

class Program1
{


	public static void main(String[] args)
	{
		// Console.WriteLine("aa");
	   String s = "wordgoodstudentgoodword";
		String []words = new String[]{"word","student"};

		 
		//ArrayList<Integer> list = new Program().Findsubstring(s, words) ;
		ArrayList<Integer> list = new ArrayList<>();
		showData(list);
		s = "barfoothefoobarman";
		words = new String[] { "foo", "bar" };//[0,9]
		// list=new Program().Findsubstring(s,words) ;
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

