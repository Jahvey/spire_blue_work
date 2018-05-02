

import java.util.*;

class Interval { 
	int start; 
	int end; 
	Interval(){
		start = 0;
		end = 0;
	} 
	Interval(int s, int e){
		start = s;
		end = e;
	}
}

public class LeetCode57_3{
	
	public static void main(String args[]){
		List<Interval> num = new LinkedList<Interval>();
/**		
		Interval in1 = new Interval(1, 3);
		Interval in2 = new Interval(4, 6);
		Interval in3 = new Interval(8, 10);
		Interval in4 = new Interval(13, 20);
		num.add(in1);
		num.add(in2);
		num.add(in3);
		num.add(in4);
*/


		Interval in1 = new Interval();
		num.add(in1);
		Interval add = new Interval(5, 9);
		
		//List<Interval> list = (List)insert(num, add);
		List<Interval> list = insert(num, add);
		Iterator<Interval> it = list.iterator();
		while(it.hasNext()){
			Interval iter = it.next();
			System.out.print(iter.start+" ");
			System.out.print(iter.end+" ");
		}
	}

	
	
		public static List<Interval> insert(List<Interval> intervals, 
			Interval newInterval) {
		//保存结果集
		List<Interval> res = new LinkedList<Interval>();
		
		//输入集如果是非空的
		if(intervals != null){
			for(Interval item : intervals){
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
		if(res.size()==1&&(res.get(0).end==0)){
			//res.clear();
			res.add(newInterval);
			
		}
		
		return res;
	}
	
	

	
}
	