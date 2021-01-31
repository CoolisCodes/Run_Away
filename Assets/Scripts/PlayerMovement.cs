using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 2;

    public CharacterController controller;

    float moveHorizontal;
    float moveVertical;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMoveInput(float horizontal, float vertical) 
    {
        moveHorizontal = horizontal;
        moveVertical = vertical;

        Debug.Log($"Move Input: {moveVertical} {moveHorizontal}");
    }

    // Start is called before the first frame update
    private void Update()
    {
        controller.Move(new Vector3(moveHorizontal, 0, moveVertical) * Time.deltaTime * speed);
    }
}
