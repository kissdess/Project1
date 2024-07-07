// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UIElements;
// using Systems.Inventory;

// public class InventoryManager : MonoBehaviour
// {
//     [SerializeField] UIDocument uiDoc;
//     [SerializeField] List<Item> items;


//     private VisualElement rootEl;
//     private VisualElement slotContainer;
//     private Button addSlotButton;

//     private void OnEnable()
//     {
//         rootEl = uiDoc.rootVisualElement;
//         slotContainer = rootEl.Q<VisualElement>("slot-container");
//         addSlotButton = rootEl.Q<Button>("add-slot-button");

//         //addSlotButton.clicked += AddSlot;

//         //Initialize();

//     }

//     private void AddSlot()
//     {
//         int slotCount = slotContainer.childCount + 1;
//         string slotName = $"slot{slotCount}";

//         VisualElement newSlot = new VisualElement();
//         newSlot.AddToClassList("slot");
//         newSlot.name = slotName;

//         Button slotButton = new Button();
//         slotButton.AddToClassList($"{slotName}.button");
//         slotButton.text = slotName;

//         newSlot.Add(slotButton);
//         slotContainer.Add(newSlot);

//         UpdateSlot(slotName, null);
//     }

//     private void UpdateSlot(string slotName, Item item)
//     {
//         VisualElement slot = rootEl.Q<VisualElement>(slotName);
//         if (slot == null) return;

//         Button slotButton = slot.Q<Button>($"{slotName}.button");
//         if (slotButton == null) return;

//         if (item != null)
//         {
//             slotButton.style.backgroundImage = new StyleBackground(item.Icon);
//             slotButton.text = ""; // 아이콘이 있으면 텍스트 제거
//         }
//         else
//         {
//             slotButton.style.backgroundImage = new StyleBackground(StyleKeyword.None);
//             slotButton.text = slotName;
//         }
//     }

//     private void Initialize()
//     {
//         UpdateSlot("slot1", items.Count > 0 ? items[0] : null);
//         UpdateSlot("slot2", items.Count > 1 ? items[1] : null);
//     }

//     public void AddItem(Item item)
//     {
//         items.Add(item);
//         for (int i = 0; i < slotContainer.childCount; i++)
//         {
//             string slotName = $"slot{i + 1}";
//             if (rootEl.Q<VisualElement>(slotName).Q<Button>($"{slotName}.button").text != "")
//             {
//                 UpdateSlot(slotName, item);
//                 break;
//             }
//         }
//     }



// }