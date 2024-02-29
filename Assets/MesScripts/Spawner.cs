using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ballePrefab;
    public float timer = 1;
    public float resetTimer = 1;
    public KeyCode touchTir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TirAutomatique();
    }
    //if (Input.GetKeyDown(touchTir)) 
     // { 
    //    }

    void TirAutomatique()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(ballePrefab, gameObject.transform.position, gameObject.transform.rotation);
            timer = resetTimer;
        }
    }

}
