using System;

namespace TimingComponent
{
    public class TimingComponentConfiguration
    {
        public string ServiceName { get; set; }
        public Action Perform { get; set; }
        public int IntervalInMillseconds { get; set; } = 2000;
    }
}