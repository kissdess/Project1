using UnityEngine.Events;
using System;
using MyProject.Npcs;

namespace MyProject.Events.UnityEvents
{
    [Serializable] public class UnityNpcEvent : UnityEvent<Npc> { }
}