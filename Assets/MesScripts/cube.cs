using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public GameObject joueur;
    public PointScore visibilité;
    public bool visible = true;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindWithTag("Player");
        visibilité = joueur.GetComponent<PointScore>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            
        }
    }
}
