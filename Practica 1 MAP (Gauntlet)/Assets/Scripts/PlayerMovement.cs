using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] GameObject animatedPlayer;
    private Animator animator;
    [SerializeField] private float playerSpeed = 7; // Variar desde la interfaz de Unity
    Rigidbody2D rb;
    bool shooting = false;
    bool canMove = true;
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
    }
    void Update()
    {
        if (canMove && !shooting)
        { 
        dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = dir * playerSpeed;
        }
        float magnitud = dir.magnitude;
        //establece la última dirección en la que se movió el jugador (distinta de 0)
        if (dir != Vector2.zero) lastDir = dir;
        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
        animator.SetFloat("LastHori", lastDir.x);
        animator.SetFloat("LastVerti", lastDir.y);
        animator.SetFloat("magnitude", magnitud);
        animator.speed = magnitud;

        //if (dir.x > 0 && dir.y > 0)
        //{
        //    animator.SetBool("Walk_Up", true);
        //    animator.SetBool("Walk_Down", false);
        //    animator.SetBool("Walk_Left", false);
        //    animator.SetBool("Walk_Right", false);
        //}
        //else if (dir.x < 0 && dir.y > 0)
        //{
        //    animator.SetBool("Walk_Up", true);
        //    animator.SetBool("Walk_Down", false);
        //    animator.SetBool("Walk_Left", false);
        //    animator.SetBool("Walk_Right", false);
        //}
        //else if (dir.x > 0 && dir.y < 0)
        //{
        //    animator.SetBool("Walk_Down", true);
        //    animator.SetBool("Walk_Up", false);
        //    animator.SetBool("Walk_Left", false);
        //    animator.SetBool("Walk_Right", false);
        //}
        //else if (dir.x < 0 && dir.y < 0)
        //{
        //    animator.SetBool("Walk_Down", true);
        //    animator.SetBool("Walk_Up", false);
        //    animator.SetBool("Walk_Left", false);
        //    animator.SetBool("Walk_Right", false);
        //}
        //else if (dir.x > 0)
        //{
        //    animator.SetBool("Walk_Right", true);
        //    animator.SetBool("Walk_Up", false);
        //    animator.SetBool("Walk_Down", false);
        //    animator.SetBool("Walk_Left", false);
        //}
        //else if (dir.x < 0)
        //{
        //    animator.SetBool("Walk_Left", true);
        //    animator.SetBool("Walk_Up", false);
        //    animator.SetBool("Walk_Down", false);
        //    animator.SetBool("Walk_Right", false);
        //}
        //else if (dir.y > 0)
        //{
        //    animator.SetBool("Walk_Up", true);
        //    animator.SetBool("Walk_Down", false);
        //    animator.SetBool("Walk_Left", false);
        //    animator.SetBool("Walk_Right", false);
        //}
        //else if (dir.y < 0)
        //{
        //    animator.SetBool("Walk_Down", true);
        //    animator.SetBool("Walk_Up", false);
        //    animator.SetBool("Walk_Left", false);
        //    animator.SetBool("Walk_Right", false);
        //}
        //else
        //{
        //    animator.SetBool("Walk_Up", false);
        //    animator.SetBool("Walk_Down", false);
        //    animator.SetBool("Walk_Left", false);
        //    animator.SetBool("Walk_Right", false);
        //}
    }
    public void DisableMovement()
    {
        canMove = false;
    }

    // Método para activar el movimiento (por si lo necesitas en otro momento)
    public void EnableMovement()
    {
        canMove = true;
    }

}