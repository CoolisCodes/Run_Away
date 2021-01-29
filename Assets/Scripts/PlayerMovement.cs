using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public InputAction movementAction;
    public CharacterController controller;

    private void OnEnable()
    {
        movementAction.Enable();
    }

    private void OnDisable()
    {
        movementAction.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = movementAction.ReadValue<Vector2>();

        Vector3 finalVector = new Vector3(inputVector.x, 0, inputVector.y);

        Debug.Log(movementAction.ReadValue<Vector2>().ToString());

        controller.Move(finalVector * Time.deltaTime * 3);
    }
}
