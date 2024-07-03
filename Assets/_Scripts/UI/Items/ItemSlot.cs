using System; // System 네임스페이스를 사용하여 기본 시스템 기능을 가져옵니다.
using MyProject.Items.Inventories;

namespace MyProject.Items
{
    [Serializable] // 이 구조체가 직렬화 가능함을 나타내는 특성입니다.
    public struct ItemSlot // ItemSlot이라는 구조체를 정의합니다.
    {
        public InventoryItem item; // InventoryItem 타입의 item 필드입니다.
        public int quantity; // int 타입의 quantity 필드입니다.

        // ItemSlot 구조체의 생성자를 정의합니다.
        public ItemSlot(InventoryItem item, int quantity)
        {
            this.item = item; // 전달된 item 매개변수를 item 필드에 할당합니다.
            this.quantity = quantity; // 전달된 quantity 매개변수를 quantity 필드에 할당합니다.       }
        }

    }
}
