using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject playerAnim;
    private Animator animator;

    void Start()
    {
        animator = playerAnim.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision) // Trigger evita que el jugador se choque con el interactuable
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            animator.SetTrigger("Exit");
            StartCoroutine(ExitDelay());

        }

    }

    private IEnumerator ExitDelay()
    {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");

    }

}
