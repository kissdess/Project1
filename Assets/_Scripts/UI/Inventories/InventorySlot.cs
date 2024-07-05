using MyProject.Items.Equipment;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyProject.Items.Inventories
{
    public class InventorySlot : ItemSlotUI, IDropHandler
    {
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private TextMeshProUGUI itemQuantityText = null;
        [SerializeField] private PlayerController player;
        [SerializeField] private Color equippedColor = Color.yellow;
        [SerializeField] private Color defaultColor = Color.black;

        public override Item SlotItem
        {
            get { return ItemSlot.item; }
            set { }
        }

        public ItemSlot ItemSlot => inventory.GetSlotByIndex(SlotIndex);

        public override void OnDrop(PointerEventData eventData)
        {
            ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();
            if (itemDragHandler == null) return;

            if ((itemDragHandler.ItemSlotUI as InventorySlot) != null)
            {
                inventory.Swap(itemDragHandler.ItemSlotUI.SlotIndex, SlotIndex);
            }
        }

        public override void UpdateSlotUI()
        {
            if (ItemSlot.item == null)
            {
                gameObject.GetComponent<Image>().color = defaultColor;
                EnableSlotUI(false);
                return;
            }

            EnableSlotUI(true);

            ItemIconImage.sprite = ItemSlot.item.Icon;
            itemQuantityText.text = ItemSlot.quantity > 1 ? ItemSlot.quantity.ToString() : "";
        }

        protected override void EnableSlotUI(bool enable)
        {
            base.EnableSlotUI(enable);
            itemQuantityText.enabled = enable;
        }

        // public void OnItemUse()
        // {
        //     if (inventory.UseItem(SlotIndex, player))
        //     {
        //         UpdateSlotUI();
        //     }
        // }



    }
}

