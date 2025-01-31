using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject animatedPlayer;
    private Animator animator;
    [SerializeField]
    private float velocity = 15; // Variar desde la interfaz de Unity
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = animatedPlayer.GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 newPos = new Vector3 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        rb.velocity = newPos * velocity;

        // Input.GetAxisRaw("Horizontal") Devuelve -1 cuando se presiona A o LeftArrow y 1 cuando se presiona D o RightArrow
        // Más de lo mismo para Input.GetAxisRaw("Vertical") pero con W y S o UpArrow y DownArrow respectivamente

        if (newPos.x > 0 && newPos.y > 0)
        {

            animator.SetBool("Walk_Up", true);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (newPos.x < 0 && newPos.y > 0)
        {

            animator.SetBool("Walk_Up", true);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (newPos.x > 0 && newPos.y < 0)
        {

            animator.SetBool("Walk_Down", true);
            animator.SetBool("Walk_Up", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (newPos.x < 0 && newPos.y < 0)
        {

            animator.SetBool("Walk_Down", true);
            animator.SetBool("Walk_Up", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (newPos.x > 0)
        {

            animator.SetBool("Walk_Right", true);
            animator.SetBool("Walk_Up", false);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Left", false);
        }
        else if (newPos.x < 0)
        {

            animator.SetBool("Walk_Left", true);
            animator.SetBool("Walk_Up", false);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (newPos.y > 0)
        {
            animator.SetBool("Walk_Up", true);
            animator.SetBool("Walk_Down", false);
            animator.SetBool("Walk_Left", false);
            animator.SetBool("Walk_Right", false);
        }
        else if (newPos.y < 0)
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
