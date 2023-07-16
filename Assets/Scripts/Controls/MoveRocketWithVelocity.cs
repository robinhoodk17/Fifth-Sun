using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MoveRocketWithVelocity : MonoBehaviour
{
    public float acceleration;
    public float brakeSpeed;
    public float RightLeftTurnSpeed;
    public float UpDownTurnSpeed;
    public float TopForwardSpeed;
    private PlayerInput playerinput;
    private Vector2 lookInput, screenCenter, mouseDistance;


    #region CameraVariables
    [SerializeField] private GameObject rocketCamera;
    public Vector3 cameraOffset = new Vector3(0, .0283f, -.24f);
    public float cameraResponsiveness = 1;
    #endregion

    #region Turret
    [SerializeField] private GameObject turret;
    #endregion

    #region PrivateRocketVariables
    [SerializeField] private GameObject rocket;
    private Rigidbody rb;
    private bool accelerating = false;
    private bool braking = false;
    private Vector2 steeringValue;
    private float currentSpeed;
    #endregion
    //we are calling this from the rocketInitializer
    public void CustomStart(float accel, float brake, float rightLeftTurn, float upDownTurn, float topSpeed)
    {
        rb = rocket.GetComponent<Rigidbody>();
        currentSpeed = 0;
        Cursor.visible = false;
        acceleration = accel;
        brakeSpeed = brake;
        RightLeftTurnSpeed = rightLeftTurn;
        UpDownTurnSpeed = upDownTurn;
        TopForwardSpeed = topSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rocket.transform.position;
        turret.transform.position = rocket.transform.position + rocket.transform.TransformDirection(new Vector3(0,0,-.21f));
        //turret.position = rocket.transform.position;
    }
    void FixedUpdate()
    {

        rocket.transform.RotateAround(rocket.transform.position, rocketCamera.transform.up, steeringValue.x * RightLeftTurnSpeed * Time.deltaTime);
        rocket.transform.RotateAround(rocket.transform.position, rocketCamera.transform.right, steeringValue.y * UpDownTurnSpeed * Time.deltaTime);
        currentSpeed = rb.velocity.magnitude;
        if(braking){currentSpeed -= brakeSpeed*Time.deltaTime;}
        if(accelerating && !braking && currentSpeed < TopForwardSpeed){currentSpeed += acceleration*Time.deltaTime;}
        
        rb.velocity = transform.forward * currentSpeed;

        
        float rocketX = rocket.transform.eulerAngles.x;
        float rocketY = rocket.transform.eulerAngles.y;
        float rocketZ = rocket.transform.eulerAngles.z;
        Quaternion targetQuaternion = Quaternion.Euler(new Vector3(rocketX, rocketY, rocketZ));
        //transform.eulerAngles = new Vector3(rocketX - rocketX, rocketY, rocketZ-rocketZ);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, Time.deltaTime*cameraResponsiveness);
    }

    public void onAcceleration(bool yesorno)
    {
        accelerating = yesorno;
    }

    public void onBraking(bool yesorno)
    {
        braking = yesorno;
    }

    public void Steering(Vector2 where)
    {
        steeringValue = where;
    }

}
