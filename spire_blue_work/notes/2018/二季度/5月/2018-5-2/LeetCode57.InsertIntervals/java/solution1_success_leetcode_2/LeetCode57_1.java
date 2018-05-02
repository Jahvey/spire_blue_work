

import java.util.*;

class Interval2 { 
	int start; 
	int end; 
	Interval2(){
		start = 0;
		end = 0;
	} 
	Interval2(int s, int e){
		start = s;
		end = e;
	}
}

public class LeetCode57_1{
	
	public static void main(String args[]){
		LinkedList<Interval2> num = new LinkedList<Interval2>();
/**		
		Interval2 in1 = new Interval2(1, 3);
		Interval2 in2 = new Interval2(4, 6);
		Interval2 in3 = new Interval2(8, 10);
		Interval2 in4 = new Interval2(13, 20);
		num.add(in1);
		num.add(in2);
		num.add(in3);
		num.add(in4);
*/


		Interval2 in1 = new Interval2();
		num.add(in1);
		Interval2 add = new Interval2(5, 9);
		
		LinkedList<Interval2> list = insertRegion(num, add);
		
		Iterator<Interval2> it = list.iterator();
		while(it.hasNext()){
			Interval2 iter = it.next();
			System.out.print(iter.start+" ");
			System.out.print(iter.end+" ");
		}
	}


	public static LinkedList<Interval2> insertRegion(LinkedList<Interval2> intervals, 
			Interval2 newInterval) {
		//保存结果集
		LinkedList<Interval2> res = new LinkedList<Interval2>();
		
		//输入集如果是非空的
		if(intervals != null){
			for(Interval2 item : intervals){
				if(newInterval == null || item.end < newInterval.start){
					res.add(item);
				}
				
				//将比插入区间大的区间插入到结果集中
				else if(item.start > newInterval.end){
					res.add(newInterval);
					res.add(item);
					newInterval = null;
				}
				
				//插入区间有重叠，更新插入区间
				else{
					newInterval.start = Math.min(newInterval.start, item.start);
					newInterval.end = Math.max(newInterval.end, item.end);		
				}

			}
		}
		if(res.size()==1&&(res.getFirst().start==res.getFirst().end)&&res.getFirst().end==0){
			res.clear();
			res.add(newInterval);
			
		}
			
		
		return res;
	}
	
	
}
	