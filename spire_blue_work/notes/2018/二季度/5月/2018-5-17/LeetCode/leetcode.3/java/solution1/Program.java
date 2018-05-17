import java.util.*;
import java.lang.*;


class Program
{


	public static int LengthOfLongestSubstring(String s) {
		if (s.length() < 2) { return s.length(); }

		int res = 0;


		Map<Character,Integer> arr = new HashMap<Character,Integer>();
		int j=0;
		char c=0;
		for (int i = 0; i < s.length(); i++)
		{
			if (arr.containsKey(s.charAt(i)))
			{
				c=s.charAt(i);
				arr.put(c,arr.get(c)+1);
				//arr.get((char)c)++;
				//arr.get(new Character(s.charAt(i))) = arr.get(s.charAt(i)) + 1;
			}
			else {
				arr.put(s.charAt(i),1);
			
			}


			

				while (arr.get(s.charAt(i)) > 1) {
					if (arr.get(s.charAt(i)) > 1)
					{
						c=s.charAt(j);
						//--arr.get(s.charAt(j));
						arr.put(c,arr.get(c)-1);
						j++;
					}
				}

			res = Math.max(res,i-j+1);

			
		}
		arr.clear();

		return res;

	
	}


   public static void main(String[] args)
	{
	   System.out.println(LengthOfLongestSubstring("aabbbb"));
		System.out.println(LengthOfLongestSubstring("bbbbbb"));

		System.out.println(LengthOfLongestSubstring("pwwkew"));
		System.out.println();


	}
}

