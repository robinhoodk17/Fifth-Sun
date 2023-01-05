using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlAssign : MonoBehaviour
{
    [HideInInspector]
    public int playerIndex;
    [HideInInspector]
    public bool Turret = false;
    [HideInInspector]
    public bool Pilot = false;
    private PlayerInput playerInput;
    private bool clicking;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed = 3.0f;
    private Vector2 movementInput = Vector2.zero;
    [HideInInspector]
    public bool isInsideBox = false;
    private PlayerConfigurationManager playerManager;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerIndex = playerInput.playerIndex;
        DontDestroyOnLoad(this);
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerConfigurationManager>();
        controller = gameObject.GetComponent<CharacterController>();
    }


    void Update()
    {
        if (clicking)
        {
            if(isInsideBox)
            {
                playerManager.playerReady[playerIndex] = true;
                playerManager.TryToLoadGame();
            }
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void PlayerSelection(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            clicking = true;
        }

        if (context.performed)
        {
            clicking = true;
        }

        if (context.canceled)
        {
            clicking = false;
        }
    }

    public void onMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
