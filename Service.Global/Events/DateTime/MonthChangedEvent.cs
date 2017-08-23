using Prism.Events;

namespace Service.Global.Events.DateTime
{
    public class MonthChangedEvent : PubSubEvent<int>
    {
        public const int PreviousMonth = -1;
        public const int NextMonth = 1;
    }
}