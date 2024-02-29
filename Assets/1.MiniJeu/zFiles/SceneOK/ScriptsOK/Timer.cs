using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    #region NE PAS TOUCHER
    public TMP_Text textTimer;

    float seconds = 0;
    int minutes = 0;

    #endregion

    // Update is called once per frame
    void Update()
    {
        CalculTemps();
        AffichageTimer();
    }

    #region NE PAS TOUCHER

    void CalculTemps()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60)
        {
            minutes++;
            seconds -= 60;
        }
    }

    void AffichageTimer()
    {
        string sec;
        string min;
        if (seconds < 10)
        {
            sec = "0" + Mathf.Floor(seconds).ToString();
            
        }
        else
        {
            sec = Mathf.Floor(seconds).ToString();
        }

        if (minutes < 10)
        {
            min = "0" + minutes.ToString();
        }
        else
        {
            min = minutes.ToString();
        }

        textTimer.text = min + ":" + sec;
    }

    #endregion
}
