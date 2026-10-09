using UnityEngine;
using System.Collections.Generic;

public class PlayerInventorySystem : MonoBehaviour
{
    //Este sistema maneja el inventario del jugador
    [System.Serializable]
    public class InventoryItem
    {
        public string ItemType;
        public int Quantity;
        public Sprite Icon;

        public InventoryItem(string itemType, int quantity, Sprite icon = null)
        {
            ItemType = itemType;
            Quantity = quantity;
            Icon = icon;
        }
    }

    private Dictionary<string, InventoryItem> items = new Dictionary<string, InventoryItem>();

    public void AddItem(string itemType, int amount = 1, Sprite icon = null)
    {
        if (items.ContainsKey(itemType))
        {
            items[itemType].Quantity += amount;
        }
        else
        {
            items[itemType] = new InventoryItem(itemType, amount, icon);
        }
        SortAlphabetically();
    }

    public bool RemoveItem(string itemType, int amount)
    {
        if (items.ContainsKey(itemType) && items[itemType].Quantity >= amount)
        {
            items[itemType].Quantity -= amount;
            if (items[itemType].Quantity <= 0)
            {
                items.Remove(itemType);
            }
            return true;
        }
        return false;
    }

    public int GetItemCount(string itemType)
    {
        if (items.ContainsKey(itemType))
        {
            return items[itemType].Quantity;
        }
        return 0;
    }

    public bool HasItem(string itemType)
    {
        return items.ContainsKey(itemType) && items[itemType].Quantity > 0;
    }

    public List<InventoryItem> GetAllItems()
    {
        return new List<InventoryItem>(items.Values);
    }

    private void SortAlphabetically()
    {
        var sortedItems = new SortedDictionary<string, InventoryItem>(items);
        items = new Dictionary<string, InventoryItem>(sortedItems);
    }
}
