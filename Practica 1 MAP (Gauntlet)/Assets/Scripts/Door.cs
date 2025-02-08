using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.GetComponent<PlayerMovement>() != null && GameManager.Instance.havingKey) //comprueba si ha colisionado con el jugador y si este tiene una llave
        {
            GameManager.Instance.SetKeyBool(false);
            Destroy(gameObject);
        }
    }
}
