using Prism.Events;

namespace Service.Global.Events.Controls
{
    public class SetTitleForFlyoutAndOpenEvent : PubSubEvent<string>
    {
        public SetTitleForFlyoutAndOpenEvent()
        {
        }
    }
}