using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _003_delegate03
{
    /// <summary>
    /// 事件的发送者
    /// </summary>
    class Dog
    {
        //sender ：表示事件的发送方，EventArgs 表明事件的信息
        //1.声明关于事件的委托
        public delegate void AlarmEventHandler(object sender,NumberThiefEventArgs e);
        //2.声明事件
        public event AlarmEventHandler Alarm;
        //3.编写引发事件的函数，注意，现在的结果是多出来了一个参数

        public void OnAlarm(NumberThiefEventArgs e){

            if (this.Alarm != null) {

                Console.WriteLine("/n狗报警: 有小偷进来了,汪汪~~~~~~~/n");
                this.Alarm(this,e);
            }
        
        }





    }
}
