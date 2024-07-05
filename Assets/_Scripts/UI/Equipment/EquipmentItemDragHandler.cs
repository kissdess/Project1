using MyProject.Items.Inventories;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MyProject.Items.Equipment
{
    public class EquipmentItemDragHandler : ItemDragHandler
    {
        [SerializeField] private EquipmentController equipmentController = null;
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private UnityEvent onEquipmentUpdated = null;

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                base.OnPointerUp(eventData);

                if (eventData.hovered.Count == 0)
                {
                    EquipmentSlot equipmentSlot = ItemSlotUI as EquipmentSlot;
                    if (equipmentSlot != null && equipmentSlot.SlotItem is EquippableItem equippableItem)
                    {
                        UnequipItem(equipmentSlot, equippableItem);
                    }
                }
            }
        }

        private void UnequipItem(EquipmentSlot equipmentSlot, EquippableItem equippableItem)
        {
            equipmentController.UnequipItem(equippableItem);
            equipmentSlot.SlotItem = null;
            equipmentSlot.UpdateSlotUI();

            // 인벤토리에 아이템 추가
            if (inventory != null)
            {
                inventory.AddItem(new ItemSlot(equippableItem, 1));
            }
            else
            {
                Debug.LogWarning("Inventory is not assigned. Unable to add unequipped item back to inventory.");
            }

            onEquipmentUpdated.Invoke();
        }
    }
}