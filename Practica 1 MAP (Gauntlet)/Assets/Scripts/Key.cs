using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private bool firstKey; //para el tutorial
    [SerializeField] private AudioClip gettingkey;
    [SerializeField] private AudioClip tutorialPlaceHolder; //placeHolder

    private void Start()
    {
        firstKey = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Trigger evita que el jugador se choque con el interactuable
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            ControladorSonido.Instance.ReproducirSonido(gettingkey);
            GameManager.Instance.SetKeyBool(true); 
            Destroy(gameObject);

            if (firstKey) //tutorial llave
            {
                ControladorSonido.Instance.ReproducirSonido(tutorialPlaceHolder);
                GameManager.Instance.CallTutorial("Save keys to open doors or treasures");
                firstKey = false;
            }
        }
    }
}
