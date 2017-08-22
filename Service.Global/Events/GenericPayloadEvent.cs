using Prism.Events;

namespace Service.Global.Events
{
    public class GenericPayloadEvent<T> : PubSubEvent<T>
    {
    }
}