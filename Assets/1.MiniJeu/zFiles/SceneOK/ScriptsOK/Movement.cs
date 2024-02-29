using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vitesse = 1;

    // Vérifie si le joueur est toujours en vie
    public bool estMort = false;

    public KeyCode Droite;
    public KeyCode Gauche;
    public KeyCode Haut;
    public KeyCode Bas;

    void Update()
    {
        // --------------------------------------------------------------------------------------------------------
        // Si le joueur n'est pas mort
        // --------------------------------------------------------------------------------------------------------
        if (estMort == false)
        {
            // ---> Alors il peut se déplacer
            Deplacement();
        }
    }

    void Deplacement()
    {
        Vector3 direction = new Vector3(0,0,0);

        // --------------------------------------------------------------------------------------------------------
        // Vérifie quel touche est pressée et modifie la direction du personnage en fonction
        // --------------------------------------------------------------------------------------------------------
        if (Input.GetKey(Droite))
        {
            direction = direction + new Vector3(vitesse, 0, 0); 
        }
        if (Input.GetKey(Gauche))
        {
            direction = direction + new Vector3(-vitesse, 0, 0); 
        }

        if (Input.GetKey(Haut))
        {
            direction = direction + new Vector3(0, 0, vitesse); 
        }
        if (Input.GetKey(Bas))
        {
            direction = direction + new Vector3(0, 0, -vitesse); 
        }

        #region NE PAS TOUCHER

        float distance = Vector3.Distance(direction, Vector3.zero);
        if (distance != 0)
            direction = direction / distance;


        // --------------------------------------------------------------------------------------------------------
        // Lance les animations de course
        // --------------------------------------------------------------------------------------------------------
        if (distance != 0)
            animator.SetBool("Running", true);
        else
            animator.SetBool("Running", false);


        // --------------------------------------------------------------------------------------------------------
        // Bloque le joueur s'il va sortir de l'écran
        // --------------------------------------------------------------------------------------------------------
        Vector3 mask = HorsEcran((direction * vitesse) * Time.deltaTime);
        direction = new Vector3(direction.x * mask.x, 0, direction.z * mask.z);

        // --------------------------------------------------------------------------------------------------------
        // Oriente le joueur
        // --------------------------------------------------------------------------------------------------------
        transform.LookAt(transform.position + direction);

        #endregion

        // --------------------------------------------------------------------------------------------------------
        // Bouge le joueur
        // --------------------------------------------------------------------------------------------------------
        transform.position = transform.position + (direction * vitesse) * Time.deltaTime;
    }

    #region NE PAS TOUCHER

    // Est utilisé pour animer le personnage
    Animator animator;

    
    void Start()
    {
        if (GetComponent<Animator>())
        {
            animator = GetComponent<Animator>();
        }
    }


    // ------------------------------------------------------------------------------------------------------------
    // Vérifie si le joueur se dirige hors de l'écran
    // ------------------------------------------------------------------------------------------------------------
    Vector3 HorsEcran(Vector3 direction)
    {
        Vector3 mask = new Vector3(1,0,1);
        Vector2 cameraPosition = Camera.main.WorldToViewportPoint(transform.position + direction);

        if (cameraPosition.x <= 0 || cameraPosition.x >= 1)
        {
            mask = new Vector3(0,0,1);
        }
        if (cameraPosition.y <= 0 || cameraPosition.y >= 1)
        {
            mask = new Vector3(mask.x,0,0);
        }

        return mask;
    }
    #endregion
}