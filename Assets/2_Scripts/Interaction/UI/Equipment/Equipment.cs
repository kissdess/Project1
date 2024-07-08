using UnityEngine;

namespace MyProject.Items.Equipment
{
    public class Equipment : MonoBehaviour
    {
        [SerializeField] private EquipmentSlot[] equipmentSlots = new EquipmentSlot[5];
        [SerializeField] private EquipmentController equipmentController;

        private void Start()
        {
            equipmentController.OnEquipmentChanged += UpdateEquipmentUI;
        }

        private void OnDestroy()
        {
            equipmentController.OnEquipmentChanged -= UpdateEquipmentUI;
        }

        public void Add(EquippableItem itemToAdd)
        {
            foreach (EquipmentSlot equipmentSlot in equipmentSlots)
            {
                if (equipmentSlot.SlotType == itemToAdd.equipmentType && equipmentSlot.AddItem(itemToAdd))
                {
                    equipmentController.EquipItem(itemToAdd);
                    return;
                }
            }
        }

        private void UpdateEquipmentUI(EquippableItem item, bool isEquipped)
        {
            foreach (EquipmentSlot slot in equipmentSlots)
            {
                if (slot.SlotType == item.equipmentType)
                {
                    slot.SlotItem = isEquipped ? item : null;
                    slot.UpdateSlotUI();
                    break;
                }
            }
        }
    }
}