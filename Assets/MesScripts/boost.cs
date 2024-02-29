using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class boost : MonoBehaviour
{
    public GameObject joueur;
    public float time = 5;
    public float resetTime = 5;
    public prof_ControllerCube2 mouvement;
    public PointScore PointBoost;
 
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindWithTag("Player");
        mouvement  = joueur.GetComponent<prof_ControllerCube2>();
        PointBoost = joueur.GetComponent<PointScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {
            
            if (mouvement.vitesse <= 10) { 
            
            mouvement.vitesse += 25;
            StartCoroutine("DureeVitesse");
                }

        }
    }

    IEnumerator DureeVitesse()
    {
        yield return new WaitForSeconds(resetTime);
        mouvement.vitesse -= 25;
    }


    // Update is called once per frame
    void Update()
    {
       
    }
    
}
