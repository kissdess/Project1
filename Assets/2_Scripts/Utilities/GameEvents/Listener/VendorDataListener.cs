using MyProject.Events.CustomEvents;
using MyProject.Events.UnityEvents;
using MyProject.Npcs.Occupations.Vendors;

namespace MyProject.Events.Listener
{
    public class VendorDataListener : BaseGameEventListener<VendorData, VendorDataEvent, UnityVendorDataEvent> { }
}