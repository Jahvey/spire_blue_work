using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _003_delegate03
{
    /// <summary>
    /// 事件的接受者
    /// </summary>
    class Host
    {
        //4.编写事件的处理程序，参数中包含了numberofThief信息
        void HostHandlerAlarm(object sender,NumberThiefEventArgs e) 
        {

            if (e.numberOfThief<= 1)
            {
                Console.WriteLine("主  人: 抓住了小偷！");
            }
            else
            {
                Console.WriteLine("主 人:打110报警，我家来了{0}个小偷！", e.numberOfThief);
            }
        
        
        }

        //5.注册事件处理函数

        public Host(Dog dog) {
            dog.Alarm += new Dog.AlarmEventHandler(HostHandlerAlarm);
        
        
        }




    }
}
