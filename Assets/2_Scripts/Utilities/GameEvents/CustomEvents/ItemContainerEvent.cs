using MyProject.Items;
using UnityEngine;

namespace MyProject.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Item Container Event", menuName = "Game Events/Item Container Event")]
    public class ItemContainerEvent : BaseGameEvent<IItemContainer> { }
}