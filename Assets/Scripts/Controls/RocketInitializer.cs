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
    public Camera turretCamera;
    public Transform bulletSpawnPoint;
    public Transform bulletParent;
    public Collider rocketCollider;
    public GameObject cinemachineInputProvider;
    // Start is called before the first frame update
    void Start()
    {

        foreach(GameObject player in GameObject.FindGameObjectsWithTag("PlayerAssign"))
        {
            rocketStats = player.GetComponent<Allcontrols>();
            player.GetComponent<Allcontrols>().controlledGameObject = gameObject;
            player.GetComponent<Allcontrols>().InitializeTrackControls(rocketbody, pilotOrTurret, inputProvider, bulletSpawnPoint, bulletParent, turretCamera, rocketCollider, cinemachineInputProvider);
            player.GetComponent<Allcontrols>().InitializeTrackControls(turretbody, !pilotOrTurret, inputProvider, bulletSpawnPoint, bulletParent, turretCamera, rocketCollider, cinemachineInputProvider);
        }
        GetComponentInChildren<MoveRocketWithVelocity>().CustomStart(rocketStats.acceleration, rocketStats.brakeSpeed, rocketStats.RightLeftTurnSpeed, rocketStats.UpDownTurnSpeed, rocketStats.TopForwardSpeed);
        GetComponentInChildren<Piloting>().CustomStart();
    }
}
