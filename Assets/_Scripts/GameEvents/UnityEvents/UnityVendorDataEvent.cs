using UnityEngine.Events;
using System;
using MyProject.Npcs.Occupations.Vendors;

namespace MyProject.Events.UnityEvents
{
    [Serializable] public class UnityVendorDataEvent : UnityEvent<VendorData> { }
}