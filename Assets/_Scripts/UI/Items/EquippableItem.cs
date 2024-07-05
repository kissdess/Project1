using System.Text;
using UnityEngine;
using MyProject.Items.Inventories;

namespace MyProject.Items
{
    [CreateAssetMenu(fileName = "New Equippable Item", menuName = "Items/Equippable Item")]
    public class EquippableItem : InventoryItem, IEquippableItem
    {
        [Header("Equippable Data")]
        [SerializeField] private string useText = "Does something, maybe?";
        [SerializeField] public Define.EquipmentType equipmentType;
        [SerializeField] private int attackBonus;
        [SerializeField] private int defenseBonus;

        public int AttackBonus => attackBonus;
        public int DefenseBonus => defenseBonus;

        public override string GetInfoDisplayText()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(Rarity.Name).AppendLine();
            builder.Append("<color=green>").Append(useText).Append("</color>").AppendLine();
            builder.Append("Equipment Slot: ").Append(equipmentType.ToString()).AppendLine();
            builder.Append("Max Stack : ").Append(MaxStack).AppendLine();
            builder.Append("Sell Price : ").Append(SellPrice).AppendLine(" Gold");

            return builder.ToString();
        }
    }
}
