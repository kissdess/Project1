using System;
using System.Text;
using UnityEngine;
namespace MyProject.TooltipUI
{
    [CreateAssetMenu(fileName = "New Consumable", menuName = "Items/Consuamble")]
    public class Consumable : Item
    {
        [SerializeField] private Rarity rarity;
        [SerializeField] private string useText = "Use: Something";

        public Rarity Rarity { get { return rarity; } }

        public override string ColouredName
        {
            get
            {
                string hexColour = ColorUtility.ToHtmlStringRGB(rarity.Colour);
                return $"<color=#{hexColour}>{Name}</color>";
            }
        }

        public override string GetTooltipInfoText()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Rarity.Name).AppendLine();
            builder.Append("<color=green>Use: ").Append(useText).Append("</color>").AppendLine();
            builder.Append("Sell Price: ").Append(SellPrice).Append(" Gold");

            return builder.ToString();
        }

    }
}
