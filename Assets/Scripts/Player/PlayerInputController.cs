using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private NewControls _controls;
   private IControllable _controllable;

   private void Awake() {
       _controllable = GetComponent<IControllable>();
       _controls = new NewControls();
       _controls.Enable();
   }


   private void Update()
    {
    ReadMove();
   
   }
private void OnEnable() 
{
    _controls.GamePlay.Jump.performed += OnJumpPerformed; 
    _controls.GamePlay.ThrowItem.performed += OnItemThrown;
}
private void OnDisable() 
{
    _controls.GamePlay.Jump.performed -= OnJumpPerformed; 
    
}
private void OnJumpPerformed(InputAction.CallbackContext context)
{
     _controllable.Jump();
}
   public void ReadMove() 
   {
       var horizontalInput = _controls.GamePlay.Movement.ReadValue<Vector2>().x;
       _controllable.Move(horizontalInput);
   }

   private void OnItemThrown(InputAction.CallbackContext context)
   {
       _controllable.ThrowItem();
   }
   
}
