using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class MoveInputEvent : UnityEvent<float, float> { }

public class InputController : MonoBehaviour
{
    [SerializeField]
    private Player_Controls controls;

    public MoveInputEvent moveInputEvent;

    private void Awake()
    {
        controls = new Player_Controls();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();

        controls.Gameplay.Move.performed += OnMovePerformed;
        controls.Gameplay.Move.canceled += OnMovePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        moveInputEvent?.Invoke(moveInput.x, moveInput.y);
    }

    private void OnDisable()
    {
        controls.Gameplay.Move.performed -= OnMovePerformed;
        controls.Gameplay.Move.canceled -= OnMovePerformed;

        controls.Gameplay.Disable();
    }
}
