using UnityEngine;

namespace MyProject.Npcs.Occupations
{
    public interface IOccupation
    {
        string Name { get; }

        void Trigger(GameObject other);
    }
}