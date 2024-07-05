using MyProject.Items.Hotbars;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyProject.Items
{

    public abstract class ItemSlotUI : MonoBehaviour, IDropHandler
    {
        [Header("UI Components")]
        [SerializeField] private Image itemIconImage = null;

        public int SlotIndex { get; private set; }

        public abstract Item SlotItem { get; set; }

        private void OnEnable() => UpdateSlotUI();

        protected virtual void Start()
        {
            SlotIndex = transform.GetSiblingIndex();
            UpdateSlotUI();
        }

        public abstract void OnDrop(PointerEventData eventData);

        public abstract void UpdateSlotUI();

        protected virtual void EnableSlotUI(bool enable)
        {
            if (itemIconImage != null)
            {
                itemIconImage.enabled = enable;
            }
            else
            {
                Debug.LogWarning("Item icon image is not set.", this);
            }
        }

        public Image ItemIconImage
        {
            get => itemIconImage;
            set => itemIconImage = value;
        }
    }
}
