using Prism.Events;

namespace Service.Global.Events.Shell
{
    public class GenericPayloadEvent<T> : PubSubEvent<T>
    {
    }
}