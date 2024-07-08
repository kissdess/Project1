using UnityEngine;
using UnityEngine.UI;


public class UI_Inven_Description : UI_Scene
{
    enum GameObjects
    {
        ItemNameText,
        ItemDescriptionText
    }



    string _itemNameText;
    string _itemDescriptionText;

    public override void Init()
    {

        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _itemNameText;
        Get<GameObject>((int)GameObjects.ItemDescriptionText).GetComponent<Text>().text = _itemDescriptionText;


    }

    public void SetDescription(string itemNameText, string itemDescriptionText)
    {
        _itemNameText = itemNameText;
        _itemDescriptionText = itemDescriptionText;
    }

    public void ResetDescription()
    {
        SetDescription(" ", " ");
    }

}
