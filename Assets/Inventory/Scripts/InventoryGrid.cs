using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : IReadOnlyInventoryGrid
{
    public event Action<string, int> ItemsAdded;
    public event Action<string, int> ItemsRemoved;
    public event Action<Vector2Int> SizeChanged;

    public string OwnerId => _data.OwnerId;
    public Vector2Int Size  
    {
        get => _data.Size;
        set
        {
            if(_data.Size!=value)
            {
                _data.Size = value;
                SizeChanged?.Invoke(value);
                
            }

        }
    }


     private readonly InventoryGridData _data;
     private readonly Dictionary<Vector2Int, InventorySlot> _slotsMap = new Dictionary<Vector2Int, InventorySlot>();

    public InventoryGrid(InventoryGridData data)
    {
        _data = data;
        var size = data.Size;

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                var index = x * size.y + y; 
                var slotData = data.Slots[index];
                var slot = new InventorySlot(slotData);
                var pos = new Vector2Int(x, y);
                _slotsMap[pos] = slot;
            }
        }
    }
    public int GetAmount(string itemId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyInventorySlot[,] GetSlots()
    {
        var slots = new IReadOnlyInventorySlot[Size.x, Size.y];

       for(int x = 0; x < Size.x; x++)
       {
           for(int y = 0; y < Size.y; y++)
           {
               var pos = new Vector2Int(x, y);
               slots[x, y] = _slotsMap[pos];
           }
       }
        return slots;
    }

    public bool HasItem(string itemId)
    {
        throw new NotImplementedException();
    }

    public void AddItems(string itemId, int amount=1)
    {
        throw new NotImplementedException();
    }
    public void AddItems(Vector2Int slotCoordinates, string itemId, int amount = 1)
    {

    }

    public void RemoveItems(string itemId, int amount=1)
    {
        throw new NotImplementedException();
    }

    public void RemoveItems(Vector2Int slotCoordinates, string itemId, int amount = 1)
    {
        throw new NotImplementedException();
    }

}
