using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float vitesse;

    #region NE PAS TOUCHER

    // Référence au joueur
    static GameObject player;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        // --------------------------------------------------------------------------------------------------------
        // Oriente le projectile en direction du joueur
        // --------------------------------------------------------------------------------------------------------
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y, 0);
    }

    #endregion

    void Update()
    {
       Mouvement();
    }

    // ------------------------------------------------------------------------------------------------------------
    // Déplace le projectile
    // ------------------------------------------------------------------------------------------------------------
    void Mouvement()
    {
        transform.position += (transform.forward * vitesse) * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        HorsEcran();
    }

    #region NE PAS TOUCHER
    // ------------------------------------------------------------------------------------------------------------
    // Vérifie si le projectile est en dehors de l'écran et le détruit si c'est le cas 
    // ------------------------------------------------------------------------------------------------------------
    bool estApparu = false;
    
    void HorsEcran()
    {
        Vector2 cameraPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (cameraPosition.x >= 0 && cameraPosition.x <= 1 && cameraPosition.y >= 0 && cameraPosition.y <= 1 && estApparu == false)
        {
            estApparu = true;
        }

        if (cameraPosition.x <= -0.2f || cameraPosition.x >= 1.2f && estApparu)
        {
            Destroy(this.gameObject);
        }
        if (cameraPosition.y <= -0.2f || cameraPosition.y >= 1.2f && estApparu)
        {
            Destroy(this.gameObject);
        }
    }

    #endregion
}