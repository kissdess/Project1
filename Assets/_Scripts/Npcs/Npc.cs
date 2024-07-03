using MyProject.Interactables;
using MyProject.Npcs.Occupations;
using UnityEngine;
using MyProject.Events.CustomEvents;

namespace MyProject.Npcs
{

    public class Npc : MonoBehaviour, IInteractable
    {
        [SerializeField] private NpcEvent onStartInteraction = null;
        [SerializeField] private new string name = "New Npc Name";
        [SerializeField] private string greetingText = "Hello Adventurer!";

        private GameObject otherInteractor = null;

        public IOccupation[] Occupations { get; private set; } = new IOccupation[0];

        public string Name => name;
        public string GreetingText => greetingText;
        public GameObject OtherInteractor => otherInteractor;

        private void Start() => Occupations = GetComponents<IOccupation>();

        public void Interact(GameObject other)
        {
            otherInteractor = other;
            onStartInteraction.Raise(this);
        }
    }
}
