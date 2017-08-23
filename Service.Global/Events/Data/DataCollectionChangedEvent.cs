using System.Collections.Generic;
using Prism.Events;
using Service.Data.Models.Models;

namespace Service.Global.Events.Data
{
    public class DataCollectionChangedEvent : PubSubEvent<IEnumerable<DateCollection>>
    {
    }
}