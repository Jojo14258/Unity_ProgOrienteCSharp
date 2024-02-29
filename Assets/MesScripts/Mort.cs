using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mort : MonoBehaviour

{
    public GameObject joueur;
    public PointScore scriptJoueur;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindWithTag("Player");
        scriptJoueur = joueur.GetComponent<PointScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            scriptJoueur.vie = -5;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
