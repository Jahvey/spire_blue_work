public class xmain{
	
	public static void main(String []args){
		
		//System.out.println("aa");
		
		System.out.println(substring("aabbccddee",0,5));
	}
	
	
	public static String substring(String s,int startIndex,int length){
		return s.substring(startIndex,startIndex+length);
		
		
	}
}