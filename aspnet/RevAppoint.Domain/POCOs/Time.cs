using System;

namespace RevAppoint.Domain.POCOs
{
    public class Time : AEntityID
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Time(){}
        public Time(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}