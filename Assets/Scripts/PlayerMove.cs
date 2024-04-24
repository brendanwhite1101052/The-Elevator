using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    CharacterController characterController;

    public float moveSpeed = 5f;
    public float jumpHeight = 5.0f;
    public float maxHeight = 4.0f;
    private Vector3 moveDirection;
    private bool onGround;
    private bool isJumping;
    private bool isFalling;

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
            isJumping = true;
            isFalling = false;
        }
        if(isJumping)
        {
            
            if(!isFalling)
            {
                moveDirection.y = 1;
                characterController.Move(moveDirection * 2.0f * Time.deltaTime);
                Debug.Log("Jumping");
                if(characterController.transform.position.y > maxHeight)
                {
                    isFalling = true;
                }
            }
            if(isFalling)
            {
                moveDirection.y = -1;
                characterController.Move(moveDirection * Time.deltaTime);
                Debug.Log("Should be falling");
                if(onGround)
                {
                    isFalling = false;
                    isJumping = false;
                }
            }
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
