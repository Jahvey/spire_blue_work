using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _002_delegate02
{
    /// <summary>
    /// 事件的接受者
    /// </summary>
    class Host
    {
        //4.编写事件处理程序
        void HostHandlerAlarm(object sender, EventArgs e) {

            Console.WriteLine("主人：抓住了小偷。");
        }

        //5.注册事件处理程序


        public Host(Dog dog) {

            dog.Alarm += new Dog.AlarmEventHandler(HostHandlerAlarm);
        }

    }
}
