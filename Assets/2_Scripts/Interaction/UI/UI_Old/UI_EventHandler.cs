using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> OnRightClickHandler = null;
    public Action<PointerEventData> OnBeginDragHandler = null;
    public Action<PointerEventData> OnEndDragHandler = null;
    public Action<PointerEventData> OnPointerEnterHandler = null;
    public Action<PointerEventData> OnPointerExitHandler = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragHandler?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragHandler?.Invoke(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnClickHandler?.Invoke(eventData);
        else if (eventData.button == PointerEventData.InputButton.Right)
            OnRightClickHandler?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEnterHandler?.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExitHandler?.Invoke(eventData);
    }
}
