using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketInitializer : MonoBehaviour
{
    public bool pilotOrTurret = true;
    public Rigidbody rocketbody;
    public Rigidbody turretbody;
    private Allcontrols rocketStats;
    // Start is called before the first frame update
    void Start()
    {

        foreach(GameObject player in GameObject.FindGameObjectsWithTag("PlayerAssign"))
        {
            rocketStats = player.GetComponent<Allcontrols>();
            player.GetComponent<Allcontrols>().InitializeTrackControls(rocketbody, pilotOrTurret);
            player.GetComponent<Allcontrols>().InitializeTrackControls(turretbody, !pilotOrTurret);
        }
        GetComponent<MoveRocketWithVelocity>().CustomStart(rocketStats.acceleration, rocketStats.brakeSpeed, rocketStats.RightLeftTurnSpeed, rocketStats.UpDownTurnSpeed, rocketStats.TopForwardSpeed);
        GetComponent<Piloting>().CustomStart();
    }
}
