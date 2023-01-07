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


    
    private Rigidbody rb;
    private bool accelerating = false;
    private bool braking = false;
    private Vector2 steeringValue;
    private float currentSpeed;
    //we are calling this from the rocketInitializer
    public void CustomStart(float accel, float brake, float rightLeftTurn, float upDownTurn, float topSpeed)
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = 0;
        
        acceleration = accel;
        brakeSpeed = brake;
        RightLeftTurnSpeed = rightLeftTurn;
        UpDownTurnSpeed = upDownTurn;
        TopForwardSpeed = topSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(-steeringValue.y * UpDownTurnSpeed * Time.deltaTime, steeringValue.x * RightLeftTurnSpeed * Time.deltaTime, 0f, Space.Self);
        currentSpeed = rb.velocity.magnitude;
        if(braking){currentSpeed -= brakeSpeed*Time.deltaTime;}
        if(accelerating && !braking && currentSpeed < TopForwardSpeed){currentSpeed += acceleration*Time.deltaTime;}

        rb.velocity = transform.forward * currentSpeed;
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
