using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RocketInitializer : MonoBehaviour
{
    public bool pilotOrTurret = true;
    public GameObject rocketbody;
    public GameObject turretbody;
    private Allcontrols rocketStats;
    public CinemachineInputProvider inputProvider;
    // Start is called before the first frame update
    void Start()
    {

        foreach(GameObject player in GameObject.FindGameObjectsWithTag("PlayerAssign"))
        {
            rocketStats = player.GetComponent<Allcontrols>();
            player.GetComponent<Allcontrols>().InitializeTrackControls(rocketbody, pilotOrTurret, inputProvider);
            player.GetComponent<Allcontrols>().InitializeTrackControls(turretbody, !pilotOrTurret, inputProvider);
        }
        GetComponent<MoveRocketWithVelocity>().CustomStart(rocketStats.acceleration, rocketStats.brakeSpeed, rocketStats.RightLeftTurnSpeed, rocketStats.UpDownTurnSpeed, rocketStats.TopForwardSpeed);
        GetComponent<Piloting>().CustomStart();
    }
}
