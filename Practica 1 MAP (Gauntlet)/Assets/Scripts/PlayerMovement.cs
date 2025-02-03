using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] GameObject animatedPlayer;
    private Animator animator;
    [SerializeField] private float playerSpeed = 7; // Variar desde la interfaz de Unity
    Rigidbody2D rb;
    Vector2 dir { get; set; }
    Vector2 lastDir { get; set; }

    public Vector2 getLastDir()
    {
        return lastDir;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = lastDir = Vector2.zero;
        //animator = animatedPlayer.GetComponent<Animator>();
        animator = GetComponentInChildren<Animator>();
        GameManager.Instance.StartGame(gameObject);
    }
    void Update()
    {
        dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = dir * playerSpeed;

        //establece la última dirección en la que se movió el jugador (distinta de 0)
        if (dir != Vector2.zero) lastDir = dir;

        if (dir.x > 0 && dir.y > 0)
        {
            animator.SetBool("Walk_Up", true);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (dir.x < 0 && dir.y > 0)
        {
            animator.SetBool("Walk_Up", true);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (dir.x > 0 && dir.y < 0)
        {
            animator.SetBool("Walk_Down", true);
            animator.SetBool("Walk_Up", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (dir.x < 0 && dir.y < 0)
        {
            animator.SetBool("Walk_Down", true);
            animator.SetBool("Walk_Up", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (dir.x > 0)
        {
            animator.SetBool("Walk_Right", true);
            animator.SetBool("Walk_Up", false);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Left", false);
        }
        else if (dir.x < 0)
        {
            animator.SetBool("Walk_Left", true);
            animator.SetBool("Walk_Up", false);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (dir.y > 0)
        {
            animator.SetBool("Walk_Up", true);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (dir.y < 0)
        {
            animator.SetBool("Walk_Down", true);
            animator.SetBool("Walk_Up", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else
        {
            animator.SetBool("Walk_Up", false);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
    }

}
