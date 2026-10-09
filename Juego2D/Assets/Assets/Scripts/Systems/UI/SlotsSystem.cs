using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static PlayerInventorySystem;
public class SlotsSystem : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text itemQuantityText;

    
    public void SetSlot(InventoryItem item)
    {
        if (item != null)
        {
            itemIcon.sprite = item.Icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            itemQuantityText.text = item.Quantity.ToString();
            itemQuantityText.color = Color.black;
        }
    }
    public void ClearSlot()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0); 
        itemQuantityText.text = "";
    }
}