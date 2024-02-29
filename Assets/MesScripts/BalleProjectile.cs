using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleProjectile : MonoBehaviour
{
    public Transform transform;
    public Vector3 direction;
    public float vitesse;
    public float delaiDestruction = 2f;

    public int pvPerdu = -10;
    public GameObject joueur;
    public PointScore scriptJoueur;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindWithTag("Player");
        scriptJoueur = joueur.GetComponent<PointScore>();

        transform = gameObject.GetComponent<Transform>();
        Destroy(gameObject, delaiDestruction);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            scriptJoueur.MiseAJourPV(pvPerdu);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        direction = transform.forward;
        transform.position = transform.position + vitesse * direction * Time.deltaTime;
    }
}