using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public Transform transform;
    public Vector3 direction = new Vector3(0, 0, 0);
    public float vitesse = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        DeplaceObjet();
    }
    void DeplaceObjet()
    {
        transform.position += direction * Time.deltaTime * vitesse;
    }

}
