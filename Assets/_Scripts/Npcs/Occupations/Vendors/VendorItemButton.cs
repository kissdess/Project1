using UnityEngine;
using TMPro;
using MyProject.Items.Inventories;
using UnityEngine.UI;


namespace MyProject.Npcs.Occupations.Vendors
{

    public class VendorItemButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemNameText = null;
        [SerializeField] private Image itemIconImage = null;

        private VendorSystem vendorSystem = null;
        private InventoryItem item = null;

        public void Initialize(VendorSystem vendorSystem, InventoryItem item, int quantity)
        {
            this.vendorSystem = vendorSystem;
            this.item = item;
            itemNameText.text = $"{item.Name} x{quantity}";
            itemIconImage.sprite = item.Icon;
        }

        public void SelectItem()
        {
            vendorSystem.SetItem(item);
        }



    }
}
