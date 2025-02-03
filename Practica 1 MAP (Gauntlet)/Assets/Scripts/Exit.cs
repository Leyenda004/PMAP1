using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) // Trigger evita que el jugador se choque con el interactuable
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            SceneManager.LoadScene("Menu");

        }
    }

}
