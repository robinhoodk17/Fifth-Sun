using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Allcontrols : MonoBehaviour
{
    [Header("PlayerAssign stats")]
    public float playerSpeed = 3.0f;

    [Header("Rocket stats")]
    public float acceleration;
    public float brakeSpeed;
    public float RightLeftTurnSpeed;
    public float UpDownTurnSpeed;
    public float TopForwardSpeed;

    [Header ("Turret Stats")]
    public float AimSesitivity;

    
    [HideInInspector] public int playerIndex;
    private CharacterController controller;
    private Vector3 playerVelocity;
    [HideInInspector] public bool Turret = false;
    [HideInInspector] public bool Pilot = false;
    private PlayerInput playerInput;
    private bool clicking;
    private Vector2 movementInput = Vector2.zero;
    [HideInInspector] public bool isInsideBox = false;
    [HideInInspector] public bool SelectionPhase = true;
    [HideInInspector] public bool LoadedTrack = false;

    private PlayerConfigurationManager playerManager;
    private bool isPilotingRocket = false;
    private bool isShootingTurret = false;
    private GameObject controlledObject;

#region MoveRocketWithVelocityVariables    
    private bool accelerating = false;
    private Rigidbody rb;
    private bool braking = false;
    private Vector2 steeringValue;
    private float currentSpeed;
#endregion
#region ShootingTurretVariables
    private bool shooting = false;
    private Vector2 Aiming;
    private GameObject turretbody;
    private Transform turretCameraTransform;
    [SerializeField] private float rotationSpeed = 8f;
#endregion

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerIndex = playerInput.playerIndex;
        DontDestroyOnLoad(this);
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerConfigurationManager>();
        controller = gameObject.GetComponent<CharacterController>();
        SelectionPhase = true;
    }


    void FixedUpdate()
    {
        if(SelectionPhase)
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

        if(isPilotingRocket)
        {
            rb.transform.Rotate(-steeringValue.y * UpDownTurnSpeed * Time.deltaTime, steeringValue.x * RightLeftTurnSpeed * Time.deltaTime, 0f, Space.Self);
            currentSpeed = rb.velocity.magnitude;
            if(braking){currentSpeed -= brakeSpeed*Time.deltaTime;}
            if(accelerating && !braking && currentSpeed < TopForwardSpeed){currentSpeed += acceleration*Time.deltaTime;}
            rb.velocity = rb.transform.forward * currentSpeed;
            
        }
    }

    void LateUpdate()
    {
        if(isShootingTurret)
        {

            if(shooting)
            {
                Debug.Log("shooting");
            }
            /*
            Vector3 currentrotation = turretbody.transform.localRotation.ToEulerAngles();
            turretbody.transform.localRotation = Quaternion.Euler(currentrotation + new Vector3(-Aiming.y * AimSesitivity * Time.deltaTime, -Aiming.x * AimSesitivity * Time.deltaTime, 0f));
            */
            Quaternion targetRotation = Quaternion.Euler(turretCameraTransform.eulerAngles.x, turretCameraTransform.eulerAngles.y, 0);
            turretbody.transform.rotation = Quaternion.Lerp(turretbody.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }

    }
    //we call this method from the rocketInitializer script
    public void InitializeTrackControls(GameObject controlledObject, bool pilotOrTurret, CinemachineInputProvider inputProvider)
    {
            if(Pilot && pilotOrTurret)
            {
                rb = controlledObject.GetComponent<Rigidbody>();
                //rb = controlledRigidBody;
                currentSpeed = 0;
                playerInput.actions.FindActionMap("PilotingLeft").Enable();
                isPilotingRocket = true;
                GameObject.FindGameObjectWithTag("AI").GetComponent<Piloting>().HasPilot = true;
                return;
            }

            if(Turret && !pilotOrTurret)
            {
                Debug.Log("we initialized turret");
                playerInput.actions.FindActionMap("TurretRight").Enable();
                isShootingTurret = true;
                turretbody = controlledObject;
                inputProvider.PlayerIndex = playerIndex;
                turretCameraTransform = inputProvider.transform;
                return;
            }

    }
    #region PlayerSelection
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
    #endregion
    #region MoveRocketWithVelocity
    public void onAcceleration(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            accelerating = true;
        }

        if(context.performed)
        {
            accelerating = true;
        }

        if(context.canceled)
        {
            accelerating = false;
        }
    }
    public void onAcceleration(bool yesorno)
    {
        accelerating = yesorno;
    }
    public void onBraking(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            braking = true;
        }

        if(context.performed)
        {
            braking = true;
        }

        if(context.canceled)
        {
            braking = false;
        }
    }
    public void onBraking(bool yesorno)
    {
        braking = yesorno;
    }
    public void Steering(InputAction.CallbackContext context)
    {
        steeringValue = context.ReadValue<Vector2>();
    }
    public void Steering(Vector2 where)
    {
        steeringValue = where;
    }
    #endregion    
    #region AimTurret
    public void onShoot(InputAction.CallbackContext context)
    {
        
        if(context.started)
        {
            shooting = true;
        }

        if(context.performed)
        {
            shooting = true;
        }

        if(context.canceled)
        {
            shooting = false;
        }

    }
    /*
    public void onAim(InputAction.CallbackContext context)
    {
        Aiming = context.ReadValue<Vector2>();
    }
    */
    #endregion
}
