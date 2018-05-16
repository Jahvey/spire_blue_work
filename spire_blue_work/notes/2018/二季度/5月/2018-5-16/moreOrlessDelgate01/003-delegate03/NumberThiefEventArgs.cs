using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _003_delegate03
{
    /// <summary>
    /// 自定义一个事件参数类
    /// </summary>
    class NumberThiefEventArgs:EventArgs
    {
        public int numberOfThief;
        public NumberThiefEventArgs(int number) {

            numberOfThief = number;
        }
    }
}
