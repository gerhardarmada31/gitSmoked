using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{

    //CONST
    private PlayerKeys inputs;
    private Vector2 moveInput;


    private void Awake()
    {
        inputs = new PlayerKeys();
    }

    private void OnEnable()
    {
        inputs.PlayerCharacter.Move.performed += HandleMove => moveInput = HandleMove.ReadValue<Vector2>();
        inputs.PlayerCharacter.Move.canceled += HandleMove => moveInput = Vector2.zero;
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.PlayerCharacter.Move.performed -= HandleMove => moveInput = HandleMove.ReadValue<Vector2>();
        inputs.PlayerCharacter.Move.canceled -= HandleMove => moveInput = Vector2.zero;
        inputs.Disable();
    }


    //Movement Happens here
    private void Update()
    {

    }
}
