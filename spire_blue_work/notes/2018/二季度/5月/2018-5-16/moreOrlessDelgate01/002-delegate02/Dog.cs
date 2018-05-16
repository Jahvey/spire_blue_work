using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _002_delegate02
{
    //事件的发送者
    class Dog
    {
        //1.声明关于事件的委托

        public delegate void AlarmEventHandler(object sender,EventArgs e);

        //2.声明事件
        public event AlarmEventHandler Alarm;

        //3.编写触发事件的函数
        public void OnAlarm(){

            if (this.Alarm != null) {

                Console.WriteLine("\n狗报警：有小偷进来了，旺旺~~~~~");
                this.Alarm(this,new EventArgs());//发出警报
            }
        
        }






    }
}
