using MyProject.Events.CustomEvents;
using MyProject.Events.UnityEvents;

namespace MyProject.Events.Listener
{
    public class IntListener : BaseGameEventListener<int, IntEvent, UnityIntEvent> { }
}