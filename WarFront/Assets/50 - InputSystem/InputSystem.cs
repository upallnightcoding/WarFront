using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public static event Action OnFire = delegate { };

    private GameInputActions gameInputActions;

    private InputAction movement;

    public InputSystemCmd ReadMovement()
    {
        Vector2 mouse = movement.ReadValue<Vector2>();

        InputSystemCmd command = InputSystemCmd.INPUT_STILL;

        if (mouse.x == 1)
        {
            command = InputSystemCmd.INPUT_RIGHT;
        } 
        else if (mouse.x == -1)
        {
            command = InputSystemCmd.INPUT_LEFT;
        } 
        
        return (command);
    }

    public Vector2 ReadMousePosition()
    {
        return(Mouse.current.position.ReadValue());
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
        OnFire.Invoke();
    }
}
