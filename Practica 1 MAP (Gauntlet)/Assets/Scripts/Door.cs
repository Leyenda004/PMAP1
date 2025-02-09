using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [SerializeField] AudioClip doorOpened;

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.GetComponent<PlayerMovement>() != null && GameManager.Instance.havingKey > 0) //comprueba si ha colisionado con el jugador y si este tiene una llave
        {
            GameManager.Instance.SetKeyValue(-1);
            ControladorSonido.Instance.ReproducirSonido(doorOpened);
            Destroy(gameObject);
        }
    }
}
