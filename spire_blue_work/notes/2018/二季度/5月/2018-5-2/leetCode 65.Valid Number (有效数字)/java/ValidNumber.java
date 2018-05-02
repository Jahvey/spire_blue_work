public class ValidNumber{
	
	public static void main(String []args){
		
		//System.out.println("aaa");
		String []tmp={"0 ","0.1 ","abc ","1 2 ","+-2e10 "};
		for(int i=0;i<tmp.length;i+=1){
			System.out.println(tmp[i]+isNumber(tmp[i]));
			
		}

	}
	
	

    public static  boolean isNumber(String s) {
         // Start typing your Java solution below  
        // DO NOT write main() function  
       /*  
        
       "0" => true 
        "     0.1     " => true 
        "abc" => false 
        "1 a" => false 
        "+-2e10" => true 
        //*/  
        //check input.  
        if(s==null || s.length()==0) return false;  
        int sz = s.length();  
        int i=0;  
          
        while(i<sz && s.charAt(i)==' ') ++i;  
          
        boolean space = false;  
        boolean exp = false;  
        boolean dot = false;  
        boolean number = false;  
        boolean neg = false;  
          
        for(; i<sz; i++) {  
            char c = s.charAt(i);  
            if(c==' ') {  
                space = true;  
            } else if(space==true) {  
                return false;  
            } else if( (c=='e' || c=='E') && exp==false && number==true) {  
                exp = true;  
                number = false;  
                dot = true;  
                neg = false;  
            } else if( c=='.' && dot==false) {  
                dot = true;  
                neg = true;  
               // number = false;  
            } else if( c>='0' && c<='9') {  
                number = true;  
            } else if((c=='+' || c=='-') && neg==false && number==false ) {  
                neg = true;  
            } else {  
                return false;  
            }  
        }  
        return number;  
     
    }

	
}