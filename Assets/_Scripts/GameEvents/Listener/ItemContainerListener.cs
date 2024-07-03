using MyProject.Events.CustomEvents;
using MyProject.Events.UnityEvents;
using MyProject.Items;

namespace MyProject.Events.Listener
{
    public class ItemContainerListener : BaseGameEventListener<IItemContainer, ItemContainerEvent, UnityItemContainerEvent> { }
}