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

    /** 
     * Mouse Commands
     */

    public Vector2 ReadMousePosition() => Mouse.current.position.ReadValue();

    public bool IsLeftMouseButtonPressed() => Mouse.current.leftButton.wasPressedThisFrame;

    public bool IsRightMouseButtonPressed() => Mouse.current.rightButton.wasPressedThisFrame;

    public InputDirective ReadMovement()
    {
        Vector2 mouse = movement.ReadValue<Vector2>();

        InputDirective command = InputDirective.INPUT_STILL;

        if (mouse.x == 1)
        {
            command = InputDirective.INPUT_RIGHT;
        } 
        else if (mouse.x == -1)
        {
            command = InputDirective.INPUT_LEFT;
        } 
        
        return (command);
    }

    private void DoFire(InputAction.CallbackContext obj)
    {
        OnFire.Invoke();
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
}
