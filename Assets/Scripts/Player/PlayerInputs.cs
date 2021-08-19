using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{

    //CONST
    private PlayerKeys inputs;
    private Vector2 moveInput;
    private PlayerMovement playerMovement;


    private void Awake()
    {
        inputs = new PlayerKeys();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        inputs.PlayerCharacter.Move.performed += HandleMove => moveInput = HandleMove.ReadValue<Vector2>();
        inputs.PlayerCharacter.Move.canceled += HandleMove => moveInput = Vector2.zero;
        inputs.PlayerCharacter.Jump.performed += HandleJump;
        inputs.Enable();
    }



    private void OnDisable()
    {
        inputs.PlayerCharacter.Move.performed -= HandleMove => moveInput = HandleMove.ReadValue<Vector2>();
        inputs.PlayerCharacter.Move.canceled -= HandleMove => moveInput = Vector2.zero;
        inputs.PlayerCharacter.Jump.performed -= HandleJump;
        inputs.Disable();
    }

    private void HandleJump(InputAction.CallbackContext context)
    {
        playerMovement.Jump();
    }
    //Movement Happens here
    private void Update()
    {
        Debug.Log("Movements" + moveInput);
        playerMovement.Move(moveInput);
    }
}
