using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGridView : MonoBehaviour
{
   
  public void Setup(IReadOnlyInventoryGrid inventoryGrid)
  {
    var slots = inventoryGrid.GetSlots();
    var size = inventoryGrid.Size;
    for (int x = 0; x < size.x; x++)
    {
      for (int y = 0; y < size.y; y++)
      {
        var slot = slots[x, y];
        Debug.Log($"Slot: ({x},{y}). Item: {slot.ItemId}, Amount: {slot.Amount}");
      }
    }
  }
}
