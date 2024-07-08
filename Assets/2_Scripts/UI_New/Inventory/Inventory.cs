using System.Collections.Generic;
using UnityEngine;

namespace Systems.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] InventoryView view;
        [SerializeField] int capacity = 20;
        [SerializeField] List<ItemDetails> startingItems = new List<ItemDetails>();
        [field: SerializeField] public SerializableGuid Id { get; set; } = SerializableGuid.NewGuid();

        InventoryController controller;

        void Awake()
        {
            controller = new InventoryController.Builder(view)
            .WithStartingItems(startingItems)
            .WithCapacity(capacity)
            .Build();
        }
    }
}