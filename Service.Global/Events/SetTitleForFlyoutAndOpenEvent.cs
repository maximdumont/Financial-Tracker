using Prism.Events;

namespace Service.Global.Events
{
    public class SetTitleForFlyoutAndOpenEvent : PubSubEvent<string>
    {
        public SetTitleForFlyoutAndOpenEvent()
        {
        }
    }
}