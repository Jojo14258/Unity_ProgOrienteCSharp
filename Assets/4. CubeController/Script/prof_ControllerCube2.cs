#region credit
//Fait par Florent&Valentin TumoLyon
#endregion
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prof_ControllerCube2: MonoBehaviour
{
    public Transform transform;
    public float vitesse = 10;
    public float rotationVitesse = 10;
    public PointScore vie;
    public GameObject joueur;
    public Vector3 Reapparition;
    public Transform respawn;
    public KeyCode toucheAvant;
    public KeyCode toucheArriere;
    public KeyCode toucheGauche;
    public KeyCode toucheDroite;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        joueur = GameObject.FindWithTag("Player");
        vie = joueur.GetComponent<PointScore>();
    }

    // Update is called once per frame
    void Update()
    {
        DeplaceObjet();
        if (vie.vie <= 0)
        {
            transform.position = respawn.position;
            vie.vie = 100;
            //transform.position = Reapparition ;


        }
    }

    void DeplaceObjet()
    {
        if (Input.GetKey(toucheDroite)==true)
        {
            transform.position = transform.position + Vector3.right * vitesse * Time.deltaTime;
            // Vector3.right �quivalent � new Vector3(1,0,0)
        }
        if (Input.GetKey(toucheGauche) == true)
        {
            transform.position = transform.position + Vector3.right * -vitesse * Time.deltaTime;
        }
        if (Input.GetKey(toucheAvant) == true)
        {
            transform.position = transform.position + Vector3.forward * vitesse * Time.deltaTime;
            // Vector3.right �quivalent � new Vector3(0,0,1)
        }
        if (Input.GetKey(toucheArriere) == true)
        {
            transform.position = transform.position + Vector3.forward * -vitesse * Time.deltaTime;
        }

    }
}
