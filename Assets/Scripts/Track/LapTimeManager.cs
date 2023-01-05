using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapTimeManager : MonoBehaviour
{

    public float miliseconds, seconds, minutes, totalmiliseconds;
    public static string Display;
    public GameObject LapBox;


    public string milisecondstring, secondsString, minutesString;
    void FixedUpdate()
    {
        miliseconds += Time.deltaTime * 10;
        totalmiliseconds += Time.deltaTime * 10;
        if(miliseconds >= 10f)
        {
            
            miliseconds = 0;
            seconds++;
        }
        if(seconds >= 60f)
        {
            seconds = 0;
            minutes++;
        }
        #region  milisecondstring
        if(miliseconds < 1f)
        {
            milisecondstring = "0" + (miliseconds*10).ToString("F0");
        }
        else
        {
            milisecondstring = (miliseconds*10).ToString("F0");
        }
#endregion
        #region secondString
        if(seconds < 10f)
        {
            secondsString = "0" + seconds.ToString("F0");
        }
        else
        {
            secondsString = seconds.ToString("F0");
        }
        #endregion
        minutesString = minutes.ToString("F0");
        LapBox.GetComponent<TextMeshProUGUI>().text = minutesString + ":" + secondsString + "." + milisecondstring;
        
    }
}
