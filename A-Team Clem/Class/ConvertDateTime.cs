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

        public string convertToThaiYear(DateTime dt)
        {
            string newYearString = "";
            DateTime d2 = DateTime.Parse(dt.ToString("yyyy/MM/dd hh:mm:ss", new CultureInfo("th-TH")));
            newYearString = d2.Year.ToString(); 
            return newYearString;
        }

        public DateTime convertToDateTimeThai(DateTime dt)
        {
            dt = DateTime.Parse(dt.ToString("dddd dd MMMM yyyy", new CultureInfo("th-TH")));
            return dt;
        }
    }
}
