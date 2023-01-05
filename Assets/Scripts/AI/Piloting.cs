using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piloting : MonoBehaviour
{
    MoveRocketWithVelocity controlScript;
    Vector3 targetPosition;
    [SerializeField] private Transform targetPositionTransform;

    [HideInInspector] public bool HasPilot = false;
    bool Accelerate = false;
    bool Breaking = false;
    float HorizontalTurn, VerticalTurn = 0f;
    GameObject[] AIWaypoints;
    Dictionary<int, Vector3> AIWaypointLocations = new Dictionary<int, Vector3>();
    int AIWaypointNumber = 0;
    bool Active = false;
    //We initialize from the rocketInitializer
    public void CustomStart()
    {
        controlScript = GetComponent<MoveRocketWithVelocity>();
        AIWaypoints = GameObject.FindGameObjectsWithTag("AI Waypoint");
        Active = true;
        foreach (GameObject waypoint in AIWaypoints)
        {
            AIWaypointLocations[waypoint.GetComponent<AIWayPoint>().number] = waypoint.transform.position;
        }
        Debug.Log("we custom started");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Active && !HasPilot)
        {
            SetTargetPosition(AIWaypointLocations[AIWaypointNumber]);
            Vector2 turn = new Vector2(0,0);

            Vector3 dirToMovePosition = (targetPosition - transform.position).normalized;
            float dot = Vector3.Dot(dirToMovePosition, transform.forward);
            float HorizontalAngle = Vector3.Dot(dirToMovePosition, transform.right);
            float VerticalAngle = Vector3.Dot(dirToMovePosition, transform.up);
            if (dot < 0.75)
            {
                Accelerate = false;
                Breaking = true;
            }
            else
            {
                Accelerate = true;
                Breaking = false;
            }
            HorizontalTurn = 0f;
            VerticalTurn = 0f;
            if (HorizontalAngle > .02f )
            {
                HorizontalTurn = 1f;
            }
            if(HorizontalAngle < .02f)
            {
                HorizontalTurn = -1f;
            }
            if(VerticalAngle > .02f)
            {
                VerticalTurn = 1f;
            }
            if (VerticalAngle < .02f)
            {
                VerticalTurn = -1f;
            }

            turn = new Vector2(HorizontalTurn, VerticalTurn);

            controlScript.onAcceleration(Accelerate);
            controlScript.onBraking(Breaking);
            controlScript.Steering(turn);
        }
    }

    public void SetTargetPosition(Vector3 Target)
    {
        this.targetPosition = Target;
    }

    private Vector2 xy(Vector3 thisVector)
    {
        return (new Vector2(thisVector.x, thisVector.y));
    }

    private Vector2 xz(Vector3 thisVector)
    {
        return (new Vector2(thisVector.x, thisVector.z));
    }

    public void reachedAIWaypoint (int number)
    {
        //Debug.Log(AIWaypointNumber);
        AIWaypointNumber = number;
        foreach(int Currentkey in AIWaypointLocations.Keys)
        {
            if(Currentkey > AIWaypointNumber)
            {
                AIWaypointNumber++;
                return;
            }
        }
        AIWaypointNumber = 0;
    }

}
