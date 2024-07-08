using System.ComponentModel.Design.Serialization;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    /***********************************************************************
    *                           Enum Fields    
    ***********************************************************************/

    enum GameObjects
    {
        ItemIcon,
        ItemNameText,
        ItemAmount
    }


    /***********************************************************************
    *                           Public Fields    
    ***********************************************************************/


    /***********************************************************************
    *                           Private Fields
    ***********************************************************************/
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private Transform originalParent;

    private RectTransform rect;

    private Sprite _icon;
    private string _name;
    private string _amount;

    private GameObject _uiInven;
    private GameObject _gridPanel;
    private GameObject _uiDesc;

    /***********************************************************************
    *                           Unity Events
    ***********************************************************************/


    void Awake()
    {
        canvasGroup = Util.GetOrAddComponent<CanvasGroup>(gameObject);
    }


    void Start()
    {
        Init();
    }



    /***********************************************************************
    *                           Init Methods
    ***********************************************************************/

    public override void Init()
    {
        InitObjects();
    }

    private void InitObjects()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemIcon).GetComponent<Image>().sprite = _icon;
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;
        Get<GameObject>((int)GameObjects.ItemAmount).GetComponent<Text>().text = _amount;
    }

    /***********************************************************************
    *           Public Methods
    ***********************************************************************/

    public void SetInfo(Sprite icon, string name, string amount)
    {
        _icon = icon;
        _name = name;
        _amount = amount;
    }

}





