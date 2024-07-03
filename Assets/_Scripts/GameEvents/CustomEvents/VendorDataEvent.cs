using MyProject.Npcs.Occupations.Vendors;
using UnityEngine;

namespace MyProject.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New VendorData Event", menuName = "Game Events/VendorData Event")]
    public class VendorDataEvent : BaseGameEvent<VendorData> { }
}