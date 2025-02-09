using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject playerAnim;
    private Animator animator;
    [SerializeField]  AudioClip exit;

    void Start()
    {
        animator = playerAnim.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision) // Trigger evita que el jugador se choque con el interactuable
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            ControladorSonido.Instance.ReproducirSonido(exit);
            animator.SetTrigger("Exit");
            playerMovement.DisableMovement();
            StartCoroutine(ExitDelay());

        }
        else
        {
            Debug.LogError("PlayerMovement no encontrado en el objeto colisionado.");
        }

    }

    private IEnumerator ExitDelay()
    {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");

    }

}
