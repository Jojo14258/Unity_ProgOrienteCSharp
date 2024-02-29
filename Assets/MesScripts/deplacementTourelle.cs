using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementTourelle : MonoBehaviour
{
    public Transform transform;
    public Vector3 direction = new Vector3(0, 0, 0);
    public float vitesse = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 1*Time.deltaTime*vitesse);
    }
   
}
