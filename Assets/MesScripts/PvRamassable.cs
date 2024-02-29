using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvRamassable : MonoBehaviour
{
    public int pvGagner = 10;
    public GameObject joueur; 
    public PointScore scriptJoueur; //script du joueur 

 
    void Start()
    {
        joueur = GameObject.FindWithTag("Player");
        scriptJoueur = joueur.GetComponent<PointScore>();
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            scriptJoueur.MiseAJourPV(pvGagner);
            Destroy(gameObject);
        }
    }
}
