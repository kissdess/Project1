using UnityEngine;
using MyProject.Items;

namespace MyProject.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Item Event", menuName = "Game Events/Item Event")]
    public class ItemEvent : BaseGameEvent<Item>
    {

    }
}