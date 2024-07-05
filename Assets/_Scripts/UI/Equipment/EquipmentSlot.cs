using UnityEngine;
using UnityEngine.EventSystems;
using MyProject.Items.Inventories;

namespace MyProject.Items.Equipment
{
    public class EquipmentSlot : ItemSlotUI, IDropHandler
    {
        [SerializeField] private EquipmentController equipmentController = null;
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private Define.EquipmentType slotType;

        public Define.EquipmentType SlotType => slotType;

        private Item slotItem = null;

        public override Item SlotItem
        {
            get { return slotItem; }
            set
            {
                slotItem = value;
                UpdateSlotUI();
            }
        }

        public bool AddItem(Item itemToAdd)
        {
            if (!(itemToAdd is EquippableItem equippableItem) || equippableItem.equipmentType != slotType)
            {
                return false;
            }

            if (SlotItem != null) { return false; }
            SlotItem = itemToAdd;
            equipmentController.EquipItem(equippableItem);
            return true;
        }

        public override void OnDrop(PointerEventData eventData)
        {
            ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();
            if (itemDragHandler == null) { return; }

            InventorySlot inventorySlot = itemDragHandler.ItemSlotUI as InventorySlot;
            if (inventorySlot != null && inventorySlot.ItemSlot.item is EquippableItem equippableItem && equippableItem.equipmentType == slotType)
            {
                EquipFromInventory(inventorySlot, equippableItem);
                return;
            }

            EquipmentSlot equipmentSlot = itemDragHandler.ItemSlotUI as EquipmentSlot;
            if (equipmentSlot != null && equipmentSlot.SlotType == slotType)
            {
                SwapEquipment(equipmentSlot);
                return;
            }
        }

        private void EquipFromInventory(InventorySlot inventorySlot, EquippableItem equippableItem)
        {
            if (SlotItem != null)
            {
                equipmentController.UnequipItem(SlotItem as EquippableItem);
                inventory.AddItem(new ItemSlot(SlotItem as InventoryItem, 1));
            }

            SlotItem = equippableItem;
            equipmentController.EquipItem(equippableItem);
            inventory.RemoveItem(inventorySlot.ItemSlot);
            inventorySlot.UpdateSlotUI();
            UpdateSlotUI();
        }

        private void SwapEquipment(EquipmentSlot otherSlot)
        {
            Item oldItem = SlotItem;
            SlotItem = otherSlot.SlotItem;
            otherSlot.SlotItem = oldItem;

            if (SlotItem != null)
                equipmentController.EquipItem(SlotItem as EquippableItem);
            if (oldItem != null)
                equipmentController.EquipItem(oldItem as EquippableItem);

            UpdateSlotUI();
            otherSlot.UpdateSlotUI();
        }

        public override void UpdateSlotUI()
        {
            if (SlotItem == null)
            {
                EnableSlotUI(false);
                return;
            }

            ItemIconImage.sprite = SlotItem.Icon;
            EnableSlotUI(true);
        }

        protected override void EnableSlotUI(bool enable)
        {
            base.EnableSlotUI(enable);
        }
    }
}