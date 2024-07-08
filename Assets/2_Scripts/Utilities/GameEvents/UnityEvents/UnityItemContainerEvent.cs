using UnityEngine.Events;
using System;
using MyProject.Items;

namespace MyProject.Events.UnityEvents
{
    [Serializable] public class UnityItemContainerEvent : UnityEvent<IItemContainer> { }
}