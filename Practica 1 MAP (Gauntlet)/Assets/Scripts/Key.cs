using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) // Trigger evita que el jugador se choque con el interactuable
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            GameManager.Instance.SetKeyBool(true); 
            Destroy(gameObject);

        }
    }
}
