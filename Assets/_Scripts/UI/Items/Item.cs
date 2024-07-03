using UnityEngine;

namespace MyProject.Items
{
    public abstract class Item : ScriptableObject
    {
        [Header("Basic Info")]
        [SerializeField] private string itemName = "New Item name";
        [SerializeField] private string description = "New Item Description";
        [SerializeField] private Sprite icon;

        public string Name => itemName;

        public string Description => description;

        public abstract string ColouredName { get; }

        public Sprite Icon => icon;

        public abstract string GetInfoDisplayText();
    }
}
