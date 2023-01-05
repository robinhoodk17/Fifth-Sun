using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WayPoints : MonoBehaviour
{
    public bool IsEndPoint;

    [System.NonSerialized] public bool HasCompletedHalfLap = false;
    [System.NonSerialized] public int currentLap = 0;
    private GameObject LapCompleteTrigger;
    private GameObject HalfLapTrigger;

    private GameObject BestLapBox;
    private LapTimeManager lapTimer;
    private float totalmiliseconds;


    void Start()
    {
        LapCompleteTrigger = GameObject.FindGameObjectWithTag("EndPoint");
        BestLapBox = GameObject.FindGameObjectWithTag("BestLapBox");
        lapTimer = GameObject.FindGameObjectWithTag("LapTimeManager").GetComponent<LapTimeManager>();
    }

    void OnTriggerEnter()
    {
        if(!IsEndPoint)
        {
            LapCompleteTrigger.GetComponent<WayPoints>().HasCompletedHalfLap = true;
            Debug.Log("we entered halfpoint");
        }
        if(HasCompletedHalfLap && IsEndPoint)
        {
            if(currentLap == 0)
            {
                BestLapBox.GetComponent<TextMeshProUGUI>().text = lapTimer.minutesString + ":" + lapTimer.secondsString + "." + lapTimer.milisecondstring;
                totalmiliseconds = lapTimer.totalmiliseconds;
            }
            else
            {
                if(lapTimer.totalmiliseconds < totalmiliseconds)
                {
                    BestLapBox.GetComponent<TextMeshProUGUI>().text = lapTimer.minutesString + ":" + lapTimer.secondsString + "." + lapTimer.milisecondstring;
                    totalmiliseconds = lapTimer.totalmiliseconds;
                }
            }
            
            lapTimer.miliseconds = 0;
            lapTimer.seconds = 0;
            lapTimer.minutes = 0;
            lapTimer.totalmiliseconds = 0;
            currentLap++;
            HasCompletedHalfLap = false;
            Debug.Log("we entered end");
        }
    }
}
