using System;
using System.Collections.Generic;

namespace Service.Global.Dates
{
    public class DataTimeShiftPadding
    {
        public static int GetShiftFrom(DayOfWeek dayBegin, DayOfWeek dayEnd)
        {
            var counter = 0;
            while (dayBegin != dayEnd)
            {
                counter++;
                dayBegin++;
            }

            return counter;
        }
    }
}