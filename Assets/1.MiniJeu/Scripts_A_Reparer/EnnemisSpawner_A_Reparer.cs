using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisSpawner_A_Reparer : MonoBehaviour
{
    // Prefab de projectile qui va servir à en créer des nouveaux
    public GameObject projectilePrefab;

    // Le temps avant de faire apparaitre un nouveau projectile
    public float timer;

    void Start()
    {
        // --------------------------------------------------------------------------------------------------------
        // On défini un temps aléatoire en seconde avant l'apparition du prochain projectile
        // --------------------------------------------------------------------------------------------------------
        timer = Random.Range(0.5f, 2f);
    }

    void Update()
    {
        // --------------------------------------------------------------------------------------------------------
        // Le temps d'attente du prochain projectile baisse avec le temps
        // --------------------------------------------------------------------------------------------------------
        timer = timer - Time.deltaTime;
        
        // --------------------------------------------------------------------------------------------------------
        // Si le temps d'attente du prochain projectile est en dessous de 0
        // --------------------------------------------------------------------------------------------------------
        if (timer <= 0)
        {
            // ---> On crée un nouveau projectile
            ApparitionEnnemi();
            timer = Random.Range(0.1f, 0.8f) + timer;
        }

    }

    // ------------------------------------------------------------------------------------------------------------
    // Lance un nouveau projectile 
    // ------------------------------------------------------------------------------------------------------------
    void ApparitionEnnemi()
    {
        // --------------------------------------------------------------------------------------------------------
        // Défini la position d'apparition du nouveau projectile
        // --------------------------------------------------------------------------------------------------------
        Vector2 unitCircle = Random.insideUnitCircle;
        Vector3 positionApparition = Vector3.Normalize(new Vector3(unitCircle.x, 0, unitCircle.y)) * 20;

        // Crée     Un projectile     La position         La rotation
        Instantiate(projectilePrefab, positionApparition, projectilePrefab.transform.rotation);
    }
}