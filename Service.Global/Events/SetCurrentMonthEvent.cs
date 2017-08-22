using System;
using Prism.Events;

namespace Service.Global.Events
{
    public class SetCurrentMonthEvent : PubSubEvent<DateTime>
    {
    }
}