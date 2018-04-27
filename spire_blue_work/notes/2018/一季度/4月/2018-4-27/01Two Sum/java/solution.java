import java.util.*;
import java.lang.*;


public class solution {
    public static int[] twoSum(int[] nums, int target) {
        int[] result = new int[2];
        HashMap<Integer, Integer> map = new HashMap<Integer, Integer>();

        for(int i = 0; i < nums.length; i++){
            if(map.containsKey(target - nums[i])){
                result[0] = map.get(target - nums[i]);
                result[1] = i ;
                return result;
            }else{
                map.put(nums[i], i);
            }
        }

        return result;
    }
	
	
	public static void main(String []args){
		
		int []arr=new int[]{2, 7, 11, 15};
		int target=9;
		arr=twoSum(arr,target);
		System.out.println(arr[0]+"  "+arr[1]);
		
		arr=new int[]{230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 };
		 target=542;
		arr=twoSum(arr,target);
		System.out.println(arr[0]+"  "+arr[1]);
		
		
	}
	
}