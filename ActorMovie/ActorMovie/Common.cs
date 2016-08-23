using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActorMovie
{
    public class Common
    {
        //获取总毫秒数
        public static long Time()
        {
            DateTime dt1 = new DateTime(1970, 1, 1);
            TimeSpan span = DateTime.Now - dt1;
            return (long)span.TotalMilliseconds;
        }
    }
}
