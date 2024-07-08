using MyProject.Npcs;
using UnityEngine;

namespace MyProject.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Npc Event", menuName = "Game Events/Npc Event")]
    public class NpcEvent : BaseGameEvent<Npc> { }
}