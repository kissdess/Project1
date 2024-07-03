using MyProject.Events.CustomEvents;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyProject.Items
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
    {
        [SerializeField] protected ItemSlotUI itemSlotUI = null;
        [SerializeField] protected ItemEvent OnMouseStartHoverItem = null;
        [SerializeField] protected VoidEvent OnMouseEndHoverItem = null;

        private CanvasGroup canvasGroup = null;
        private Transform originalParent = null;
        private bool isHovering = false;

        public ItemSlotUI ItemSlotUI => itemSlotUI;

        private void Start() => canvasGroup = GetComponent<CanvasGroup>();

        private void OnDisable()
        {
            if (isHovering)
            {
                OnMouseEndHoverItem.Raise();
                isHovering = false;
            }
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                OnMouseEndHoverItem.Raise();

                originalParent = transform.parent;

                transform.SetParent(transform.parent.parent);

                canvasGroup.blocksRaycasts = false;
            }
        }
        public virtual void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                transform.position = Input.mousePosition;
            }
        }
        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                transform.SetParent(originalParent);
                transform.localPosition = Vector3.zero;
                canvasGroup.blocksRaycasts = true;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnMouseStartHoverItem.Raise(ItemSlotUI.SlotItem);
            isHovering = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnMouseEndHoverItem.Raise();
            isHovering = false;
        }
    }


}
