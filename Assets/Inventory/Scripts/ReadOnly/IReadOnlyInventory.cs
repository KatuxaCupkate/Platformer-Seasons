using System;
using System.Collections.Generic;
using UnityEngine;

public interface IReadOnlyInventory 
{
   event Action <string,int> ItemsAdded;
   event Action <string,int> ItemsRemoved; 

   string OwnerId { get; }

   int GetAmount(string itemId);
   bool HasItem(string itemId);
   
}
