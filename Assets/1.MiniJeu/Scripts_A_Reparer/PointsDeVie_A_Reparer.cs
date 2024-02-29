using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsDeVie_A_Reparer : MonoBehaviour
{
    // Les points de vie du joueur
    public int PV = 10;
    private int PVActuel;
    public string nomJoueur = "Player";

    // ------------------------------------------------------------------------------------------------------------
    // Lorsque le joueur perd des points de vie
    // ------------------------------------------------------------------------------------------------------------
    void PerdPV(int dommage, GameObject other)
    {
        // --------------------------------------------------------------------------------------------------------
        // Le joueur perd un certain nombre de points de vie
        // --------------------------------------------------------------------------------------------------------
        PVActuel = PVActuel - dommage;

        // --------------------------------------------------------------------------------------------------------
        // Si le joueur n'a plus de point de vie
        // --------------------------------------------------------------------------------------------------------
        VerifieMort(other);

        BarreDeVieAJour();
    }

    #region NE PAS TOUCHER

    // Est utilisé pour animer le personnage
    private Animator animator;

    // Le script du Mouvement du joueur
    private Movement_A_Reparer movementScript;

    private Image barreDeVie;
    private TMP_Text nom;

    void Start()
    {
        barreDeVie = GameObject.Find("BarreDeVie").GetComponent<Image>();
        nom = GameObject.Find("Nom").GetComponent<TMP_Text>();
        PVActuel = PV;
        nom.text = nomJoueur;
        movementScript = GetComponent<Movement_A_Reparer>();
        animator = GetComponent<Animator>();
        
        VerifieMort(gameObject);
    }

    // ------------------------------------------------------------------------------------------------------------
    // Lorsque le joueur perd
    // ------------------------------------------------------------------------------------------------------------
    void Perdre(GameObject other)
    {
        // --------------------------------------------------------------------------------------------------------
        // Oriente le joueur vers le projectile qui a touché
        // --------------------------------------------------------------------------------------------------------
        transform.LookAt(other.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        
        // --------------------------------------------------------------------------------------------------------
        // Bloque le mouvement du joueur
        // --------------------------------------------------------------------------------------------------------
        movementScript.estMort = true;

        // --------------------------------------------------------------------------------------------------------
        // Lance l'animation de mort
        // --------------------------------------------------------------------------------------------------------
        animator.SetBool("Mort", true);
    }

    void VerifieMort(GameObject other)
    {
        if (PVActuel <= 0 && movementScript.estMort == false)
        {
            PVActuel = 0;
            // ---> Il perd
            Perdre(other);

            BarreDeVieAJour();
        }
    }

    // ------------------------------------------------------------------------------------------------------------
    // Lorsqu'un objet touche le joueur
    // ------------------------------------------------------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        // --------------------------------------------------------------------------------------------------------
        // Si l'objet touché a le tag "Ennemi"
        // --------------------------------------------------------------------------------------------------------
        if (other.tag == "Ennemi")
        {
            // ---> Le joueur perd 1 point de vie
            PerdPV(1, other.gameObject);

            // ---> L'ennemi est détruit
            Destroy(other.gameObject);
        }
    }

    void BarreDeVieAJour()
    {
        barreDeVie.fillAmount = (float)PVActuel / PV;
    }
    #endregion
}