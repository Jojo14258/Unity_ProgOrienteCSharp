using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRamassable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject joueur;
    public PointScore scriptScore;
    public int pointPiece = 10;
    void Start()
    {
        joueur = GameObject.FindWithTag("Player");
        scriptScore = joueur.GetComponent<PointScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            scriptScore.MiseAJourScore(pointPiece);
            Destroy(gameObject);
        }
    }   
   
}
