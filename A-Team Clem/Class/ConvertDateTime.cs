using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace A_Team_Clem
{
    class ConvertDateTime
    {
        public ConvertDateTime()
        {            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        public DateTime convert(DateTime dt)
        {
            DateTime newDateTime = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            return newDateTime;
        }
    }
}
