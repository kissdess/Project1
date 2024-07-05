using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject.Items.Equipment
{
    public class EquipmentController : MonoBehaviour
    {
        [SerializeField] private PlayerStat playerStat;

        private Dictionary<Define.EquipmentType, EquippableItem> equippedItems = new Dictionary<Define.EquipmentType, EquippableItem>();

        public event Action<EquippableItem, bool> OnEquipmentChanged;

        public void EquipItem(EquippableItem item)
        {
            if (equippedItems.TryGetValue(item.equipmentType, out var currentItem))
            {
                UnequipItem(currentItem);
            }

            equippedItems[item.equipmentType] = item;
            playerStat.AddStats(item.AttackBonus, item.DefenseBonus);
            OnEquipmentChanged?.Invoke(item, true);
            Debug.Log($"Equipped: {item.Name}");
        }

        public void UnequipItem(EquippableItem item)
        {
            if (equippedItems.Remove(item.equipmentType))
            {
                playerStat.RemoveStats(item.AttackBonus, item.DefenseBonus);
                OnEquipmentChanged?.Invoke(item, false);
                Debug.Log($"Unequipped: {item.Name}");
            }
        }

        public bool IsItemEquipped(EquippableItem item)
        {
            return equippedItems.TryGetValue(item.equipmentType, out var equippedItem) && equippedItem == item;
        }

        public EquippableItem GetEquippedItem(Define.EquipmentType equipmentType)
        {
            equippedItems.TryGetValue(equipmentType, out var item);
            return item;
        }
    }
}