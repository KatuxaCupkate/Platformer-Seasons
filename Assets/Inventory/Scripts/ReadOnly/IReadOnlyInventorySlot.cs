using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public interface IReadOnlyInventorySlot
   {
      event Action <string> ItemIdChanged;
      event Action <int> ItemAmountChanged;
      string ItemId { get; }

      int Amount { get; }
      bool IsEmpty { get; }

   }

