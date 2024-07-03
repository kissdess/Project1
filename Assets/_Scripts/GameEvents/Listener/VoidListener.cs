using MyProject.Events.CustomEvents;
using MyProject.Events.UnityEvents;

namespace MyProject.Events.Listener
{
    public class VoidListener : BaseGameEventListener<Void, VoidEvent, UnityVoidEvent> { }
}