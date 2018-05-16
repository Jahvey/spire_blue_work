using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hannoTaiProblem
{

    public enum move{
        NOW,L2M,M2L,M2R,R2M
    
    }

    /// <summary>
    /// 使用非递归的方式来调用汉诺塔问题
    /// </summary>
    public class hannoProblem2 {
        public int hannoTower(int num,String left,String mid,String right) {
            int step = 0;//立个flag
            Stack<int> ls = new Stack<int>();
            Stack<int> ms = new Stack<int>();
            Stack<int> rs = new Stack<int>();
            ls.Push(int.MaxValue);
            ms.Push(int.MaxValue);
            rs.Push(int.MaxValue);

            //init the stack values
            for (int i = num ; i > 0; i--)
            {
                ls.Push(i);
            }

            move[] record = { move.NOW};
            //循环终止得条件就是讲rs的内容给清空
            //为什么终止条件上必须显示的是rs.size()!=num+1
            //显然，rs.size()始终要比num的个数多一个int.MaxValue
            while(rs.Count()!=num+1){
                step += fStack2tStack(record,move.L2M,move.M2L,ls,ms,left,mid);

                step += fStack2tStack(record, move.M2L, move.L2M,  ms,ls, 
                    mid,left);
                step += fStack2tStack(record,move.M2R,move.R2M,ms,rs,mid,right);
                step += fStack2tStack(record, move.R2M, move.M2R, rs, ms, right,mid );
            
            }

            return step;
        }

        /// <summary>
        /// 两个栈对象之间互相调用
        /// </summary>
        /// <param name="record"></param>
        /// <param name="preMove"></param>
        /// <param name="nowMove"></param>
        /// <param name="fStack"></param>
        /// <param name="tStack"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static int fStack2tStack(move[]record,move preMove,move nowMove,Stack<int> fStack,Stack<int>tStack,string from,string to) {
            if(record[0]!=preMove&&fStack.Peek()<tStack.Peek()){
            //如果完全符合 相邻不可逆 原则 和小压大的原则，则保存相应的运行结果


                tStack.Push(fStack.Pop());
                Console.WriteLine("Move from  "+tStack.Peek()+"  from "+from+"  to  "+to);

                //更新record记录
                record[0] = nowMove;
                return 1;//表明移动记录成功，步数更新加1


            
            }

            return 0;
        
        
        }


    
    }



    class Program
    {
        static void Main(string[] args)
        {

            //noRecursionInvoke();





            Console.ReadKey();
        }

        private static void noRecursionInvoke()
        {
            hannoProblem2 hanno = new hannoProblem2();
            Console.WriteLine("总共运行了: " + hanno.hannoTower(7, "L", "M", "R"));
        }
    }
}
