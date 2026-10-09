using UnityEngine;
using System.Collections.Generic;

public class InventoryShowSystem : MonoBehaviour
{
    // public GameObject inventoryUI;
    // public PlayerController player;
    // public List<SlotsSystem> slots = new List<SlotsSystem>();

    // private void LateUpdate()
    // {
    //     SetUp();
    // }
    
    // void SetUp()
    // {
    //     int itemCount = player.GetPlayerInventory().GetAllItems().Count;
    //     int slotCount = slots.Count;
    //     int minCount = Mathf.Min(itemCount, slotCount);

    //     for (int i = 0; i < minCount; i++)
    //     {
    //         if (player.GetPlayerInventory().GetAllItems()[i] != null)
    //         {
    //             slots[i].SetSlot(player.GetPlayerInventory().GetAllItems()[i]);
    //         }
    //         else
    //         {
    //             slots[i].ClearSlot();
    //         }
    //     }

    //     // Clear remaining slots if there are more slots than items
    //     for (int i = minCount; i < slotCount; i++)
    //     {
    //         slots[i].ClearSlot();
    //     }
    // }
}
