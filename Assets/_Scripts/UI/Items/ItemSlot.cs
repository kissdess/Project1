using System; // System 네임스페이스를 사용하여 기본 시스템 기능을 가져옵니다.
using MyProject.Items.Inventories;

namespace MyProject.Items
{
    [Serializable]
    public struct ItemSlot
    {
        public InventoryItem item;
        public int quantity;

        public ItemSlot(InventoryItem item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }

    }
}
