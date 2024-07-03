using UnityEngine;

namespace MyProject.Items.Hotbars
{

    public interface IHotbarItem
    {
        string Name { get; }
        Sprite Icon { get; }
        void Use();
    }
}

