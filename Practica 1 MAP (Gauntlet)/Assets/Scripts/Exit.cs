using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Animator animator;
    private Sprite valkyrieSprite;
    private Sprite elfSprite;
    [SerializeField] AudioClip exit;

    void Start()
    {
        animator = player.GetComponentInChildren<Animator>();
        valkyrieSprite = Resources.Load<Sprite>("Sprites/Valkyrie_sprites_12");
        elfSprite = Resources.Load<Sprite>("Sprites/Elf_sprites_12");
    }
    private void OnTriggerEnter2D(Collider2D collision) // Trigger evita que el jugador se choque con el interactuable
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            ControladorSonido.Instance.ReproducirSonido(exit);
            animator.SetTrigger("Exit");

            playerMovement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            playerMovement.DisableMovement();
            // Verificar y actualizar el sprite del jugador según el personaje seleccionado
            SpriteRenderer spriteRenderer = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                if (GameManager.Instance.IsValkchosen)
                {
                    spriteRenderer.sprite = valkyrieSprite;
                }
                else
                {
                    spriteRenderer.sprite = elfSprite;
                }
            }
            else
            {
                Debug.LogError("SpriteRenderer no encontrado en el GameObject del jugador.");
            }

            StartCoroutine(ExitDelay());
        }
        else
        {
            Debug.LogError("PlayerMovement no encontrado en el objeto colisionado.");
        }

    }

    private IEnumerator ExitDelay()
    {

        // Hecho con IA y modificado para que el jugador se mueva hacia la salida
        Vector3 startPosition = player.transform.position;
        Vector3 endPosition = new Vector3 (transform.position.x + GetComponent<BoxCollider2D>().offset.x, transform.position.y + GetComponent<BoxCollider2D>().offset.y, 0);
        float elapsedTime = 0f;
        float duration = 0.35f; // Duration of the movement

        while (elapsedTime < duration)
        {
            player.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        player.transform.position = endPosition;
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}