using MyProject.Items;
using UnityEngine;
using MyProject.Events.CustomEvents;
using MyProject.Npcs.Occupations.Vendors;

namespace MyProject.Npcs.Occupations
{


    public class Vendor : MonoBehaviour, IOccupation
    {
        [SerializeField] private VendorDataEvent onStartVendorScenario = null;

        public string Name => "Let's trade!";

        private IItemContainer itemContainer = null;

        private void Start() => itemContainer = GetComponent<IItemContainer>();

        public void Trigger(GameObject other)
        {
            var otherItemContainer = other.GetComponent<IItemContainer>();

            if (otherItemContainer == null) return;

            VendorData vendorData = new VendorData(otherItemContainer, itemContainer);

            onStartVendorScenario.Raise(vendorData);


        }
    }
}


