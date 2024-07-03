using MyProject.Events.CustomEvents;
using MyProject.Events.UnityEvents;
using MyProject.Npcs;

namespace MyProject.Events.Listener
{
    public class NpcListener : BaseGameEventListener<Npc, NpcEvent, UnityNpcEvent> { }
}