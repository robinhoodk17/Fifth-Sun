using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketInitializer : MonoBehaviour
{
    public bool pilotOrTurret;
    [HideInInspector]
    public Rigidbody rb;
    private Allcontrols rocketStats;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("PlayerAssign"))
        {
            rocketStats = player.GetComponent<Allcontrols>();
            player.GetComponent<Allcontrols>().InitializeTrackControls(rb, pilotOrTurret);
        }
        GetComponent<MoveRocketWithVelocity>().CustomStart(rocketStats.acceleration, rocketStats.brakeSpeed, rocketStats.RightLeftTurnSpeed, rocketStats.UpDownTurnSpeed, rocketStats.TopForwardSpeed);
        GetComponent<Piloting>().CustomStart();
    }
}
