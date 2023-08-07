using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    private GameInputActions gameInputActions;

    private InputAction movement;

    public Vector2 ReadMovement()
    {
        return (movement.ReadValue<Vector2>());
    }

    private void Awake()
    {
        gameInputActions = new GameInputActions();
    }

    private void OnEnable()
    {
        movement = gameInputActions.Player.Movement;
        movement.Enable();

        gameInputActions.Player.Fire.performed += DoFire;

        gameInputActions.Player.Fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();

        gameInputActions.Player.Fire.Disable();

        gameInputActions.Player.Fire.performed -= DoFire;
    }

    private void DoFire(InputAction.CallbackContext obj)
    {
        Debug.Log("Fire ...");
    }
}
