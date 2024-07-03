using UnityEngine;
using MyProject.Items.Inventories;
using MyProject.Interactables;

namespace MyProject.Items
{
    public class Gold : MonoBehaviour, IInteractable
    {
        private Inventory inventory;
        private DropItem dropItem;

        public void SetDropItem(DropItem item)
        {
            dropItem = item;
        }

        public void AddGold(int amount)
        {
            inventory.Money += amount;
        }

        public void Interact(GameObject other)
        {
            inventory = other.GetComponent<Inventory>();
            if (dropItem != null)
            {
                AddGold(dropItem.GoldAmount);
            }
            else
            {
                Debug.LogError("DropItem is null.");
            }

            Destroy(gameObject);
            var interactor = other.GetComponentInChildren<Interactor>();
            if (interactor != null)
            {
                interactor.ClearInteractable();
            }
        }
    }
}
