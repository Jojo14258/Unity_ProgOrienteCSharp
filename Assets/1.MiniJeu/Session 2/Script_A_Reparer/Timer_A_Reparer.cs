using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer_A_Reparer : MonoBehaviour
{
    #region NE PAS TOUCHER
    
    public TMP_Text textTimer;

    private float seconds = 0;
    private int minutes = 0;

    #endregion

    // Update is called once per frame
    void Start()
    {
        CalculTemps();
        AffichageTimer();
    }
    void Update()
    {
        CalculTemps();
        AffichageTimer();
    }
    #region NE PAS TOUCHER

    void CalculTemps()
    {
        seconds = seconds + Time.deltaTime;
        if (seconds >= 60)
        {
            minutes = minutes + 1;
            seconds = seconds - 60;
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
