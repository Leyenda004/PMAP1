using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject walls;
    [SerializeField] private GameObject walls_replacement;
    private bool firstTrap;

    private void Start() 
    { 
        walls_replacement.SetActive(false); // No se por que no se activan si antes no las desactivo manualmente :/
        firstTrap = true;
    } 
    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.GetComponent<PlayerMovement>() != null) //comprueba si ha colisionado con el jugador
        {
            Destroy(walls);
            walls_replacement.SetActive(true);
            Destroy(gameObject);
            if (firstTrap) 
            {
                GameManager.Instance.CallTutorial("Traps make walls dissapear");
                firstTrap = false;
            }
        }
    }
}
