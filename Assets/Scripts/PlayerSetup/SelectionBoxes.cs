using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBoxes : MonoBehaviour
{
    [SerializeField]
    private PlayerConfigurationManager playerManager;
    [SerializeField]
    private bool thisIsPilot = false;
    [SerializeField]
    private bool thisIsGunner = false;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Allcontrols>().isInsideBox = true;
        if (thisIsPilot)
        {
            playerManager.pilot = other.GetComponent<Allcontrols>().playerIndex;
            other.GetComponent<Allcontrols>().Pilot = true;
        }

        if (thisIsGunner)
        {
            playerManager.gunner = other.GetComponent<Allcontrols>().playerIndex;
            other.GetComponent<Allcontrols>().Turret = true;
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Allcontrols>().isInsideBox = false;
        if (thisIsPilot)
        {
            playerManager.pilot = 0;
        }

        if (thisIsGunner)
        {
            playerManager.gunner = 0;
        }

    }
}
