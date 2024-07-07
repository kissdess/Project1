namespace Systems.Inventory
{
    [System.Serializable]
    public class Item
    {
        public SerializableGuid Id;
        public ItemDetails details;
        public int quantity;

        public Item(ItemDetails details, int quantity = 1)
        {
            Id = SerializableGuid.NewGuid();
            this.details = details;
            this.quantity = quantity;
        }
    }
}