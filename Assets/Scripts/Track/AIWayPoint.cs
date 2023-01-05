using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWayPoint : MonoBehaviour
{
    public int number;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AI")
        {
            other.GetComponent<Piloting>().reachedAIWaypoint(number);
        }
    }
}
