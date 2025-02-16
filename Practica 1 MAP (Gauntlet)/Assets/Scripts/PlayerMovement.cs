using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float playerSpeed = 7f; // Variar desde la interfaz de Unity
    private Rigidbody2D rb;
    private bool canMove = true;
    private Vector2 dir { get; set; }
    private Vector2 lastDir { get; set; }

    public bool isGamepad;

    public Vector2 getLastDir()
    {
        return lastDir;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = lastDir = Vector2.zero;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (canMove)
        {
            if (isGamepad)
            {
                dir = new Vector2(Gamepad.current?.leftStick.x.ReadValue() ?? 0,
                                  Gamepad.current?.leftStick.y.ReadValue() ?? 0);
            }
            else
            {
                dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            }

            if (Mathf.Abs(dir.x) < 0.25f) { dir = new Vector2(0, dir.y); }
            if (Mathf.Abs(dir.y) < 0.25f) { dir = new Vector2(dir.x, 0); }

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