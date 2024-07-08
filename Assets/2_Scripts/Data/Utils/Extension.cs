using System;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
    {
        return Util.GetOrAddComponent<T>(go);
    }

    public static T GetChildComponent<T>(this GameObject parent, string childName) where T : Component
    {
        Transform childTransform = parent.transform.Find(childName);
        if (childTransform != null)
        {
            return childTransform.GetComponent<T>();
        }
        Debug.LogWarning($"Child with name {childName} not found in {parent.name}");
        return null;
    }

    public static void BindEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.BindEvent(go, action, type);
    }

    public static bool IsValid(this GameObject go)
    {
        return go != null && go.activeSelf;
    }





}