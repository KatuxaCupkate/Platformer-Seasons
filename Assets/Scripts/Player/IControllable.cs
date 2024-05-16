using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable 
{
    void Move(float horizontalInput);
    void Jump();
    void ThrowItem();
}
