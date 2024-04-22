using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    CharacterController characterController;

    public float moveSpeed = 5f;
    private Vector3 moveDirection;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckFloor();
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            moveDirection.y += 2.5f * Time.deltaTime;
            Debug.Log("Space pressed");
        }
        if(moveDirection.y > 100.0f && !onGround)
        {
            moveDirection.y -= 1.0f * Time.deltaTime;
            Debug.Log("Height reached");
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

    public void CheckFloor()
    {
        if (Physics.Raycast(characterController.transform.position, Vector3.down, 1.08f))
        {
            onGround = true;
        } else {
            onGround = false;
        }
    }
}
