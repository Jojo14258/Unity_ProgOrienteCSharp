using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScore : MonoBehaviour
{
    public int score = 0;
    public float vieMax = 100;
    public float vie = 100;
    


    public Image barreDeVie;
    public Text Score;
    private void Start()
    {
        vie = vieMax;
    }
    public void MiseAJourPV(int pv)
    {
        vie += pv;
        barreDeVie.fillAmount = vie / vieMax;
        //Debug.Log("La vie du joueur est" + vie);
        if(vie>= vieMax)
        {
            vie = vieMax;
        }

        if(vie <= 0)
        {
            //GameOver
            vie = 0;
        }
    }
    public void MiseAJourScore(int point)
    {
        score += point;
        Score.text = ("Score : " + score);
        //Debug.Log("Le score du joueur est de" + score);
    }

}

