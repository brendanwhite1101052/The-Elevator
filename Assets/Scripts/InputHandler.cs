using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    PlayerMove playerMove;
    FPCam fpCam;
    PlayerInteraction playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        fpCam = GetComponent<FPCam>();
        playerInteraction = GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMoveInput();
        HandleCameraInput();
        HandleInteractionInput();
    }

    void HandleMoveInput()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float rightInput = Input.GetAxisRaw("Horizontal");

        playerMove.AddMoveInput(forwardInput,rightInput);
    }

    void HandleCameraInput()
    {
        fpCam.AddXAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        fpCam.AddYAxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);
    }

    void HandleInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerInteraction.TryInteract();
        }
    }
}
