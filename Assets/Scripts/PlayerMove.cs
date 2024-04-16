using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    CharacterController characterController;

    public float moveSpeed = 5f;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            moveDirection.y += 0.5f * Time.deltaTime;
        }
        if(moveDirection.y > 1 && !characterController.isGrounded)
        {
            moveDirection.Normalize();
            moveDirection.y = -1f;
        }
        

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void AddMoveInput(float forwardInput, float rightInput)
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        moveDirection = (forwardInput * forward) + (rightInput * right);
    }
}
