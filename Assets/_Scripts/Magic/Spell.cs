using MyProject.Items.Hotbars;
using UnityEngine;

namespace MyProject.Magic
{
    public class Spell : ScriptableObject, IHotbarItem
    {
        [Header("Basic Info")]
        [SerializeField] private string itemName = "New Spell Name";
        [SerializeField] private Sprite icon = null;
        [SerializeField] private Element element = null;

        public string Name => name;

        public Sprite Icon => Icon;

        public Element Element => element;

        public void Use()
        {
            Debug.Log($"Casting {Name}");
        }
    }
}
