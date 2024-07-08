using System.Text;
using MyProject.Items.Hotbars;
using UnityEngine;
using MyProject.Items.Inventories;


namespace MyProject.Items
{
    [CreateAssetMenu(fileName = "New Consumable Item", menuName = "Items/Consumable Item")]
    public class ConsumableItem : InventoryItem, IHotbarItem
    {
        [Header("Consumable Data")]
        [SerializeField] private string useText = "Does something, maybe?";
        public override string GetInfoDisplayText()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(Rarity.Name).AppendLine();
            builder.Append("<color=green>").Append(useText).Append("</color>").AppendLine();
            builder.Append("Max Stack : ").Append(MaxStack).AppendLine();
            builder.Append("Sell Price : ").Append(SellPrice).AppendLine(" Gold");

            return builder.ToString();
        }

        public bool Use(PlayerController playerController)
        {
            Debug.Log($"Drinking {Name}");
            return true;
        }
    }

}
