using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public abstract class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    protected List<GameObject> _itemData = new List<GameObject>();

    public abstract void Init();

    void Start()
    {
        Init();
    }

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);                                       // Enum의 이름을 배열로 반환

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];

        _objects.Add(typeof(T), objects);               // 딕셔너리에 추가

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;
        return objects[idx] as T;
    }

    protected GameObject GetObject(int Idx) { return Get<GameObject>(Idx); }
    protected Text GetText(int Idx) { return Get<Text>(Idx); }
    protected Button GetButton(int Idx) { return Get<Button>(Idx); }
    protected Image GetImage(int Idx) { return Get<Image>(Idx); }

    protected GameObject GetItemObject(int idx)
    {
        GameObject items = _itemData[idx];
        return items;
    }


    public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;

            case Define.UIEvent.Dragging:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;

            case Define.UIEvent.RightClick:
                evt.OnRightClickHandler -= action;
                evt.OnRightClickHandler += action;
                break;

            case Define.UIEvent.BeginDrag:
                evt.OnBeginDragHandler -= action;
                evt.OnBeginDragHandler += action;
                break;

            case Define.UIEvent.EndDrag:
                evt.OnEndDragHandler -= action;
                evt.OnEndDragHandler += action;
                break;
            case Define.UIEvent.Enter:
                evt.OnPointerEnterHandler -= action;
                evt.OnPointerEnterHandler += action;
                break;
            case Define.UIEvent.Exit:
                evt.OnPointerExitHandler -= action;
                evt.OnPointerExitHandler += action;
                break;

        }

    }


}