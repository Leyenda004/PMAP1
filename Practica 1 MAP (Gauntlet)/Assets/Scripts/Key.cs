using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision) // Trigger evita que el jugador se choque con el interactuable
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            GameManager.Instance.SetKeyValue(1);

            
            Destroy(gameObject);

            if (GameManager.Instance.firstKey) //tutorial llave
            {
                GameManager.Instance.CallTutorial("Save keys to open doors or treasures");
                GameManager.Instance.firstKey = false;
            }
        }
    }
}
