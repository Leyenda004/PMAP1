using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float playerSpeed = 7; // Variar desde la interfaz de Unity
    private Rigidbody2D rb;
    private bool canMove = true;
    private Vector2 dir { get; set; }
    private Vector2 lastDir { get; set; }

    public bool isGamepad { get; private set; }
    public PlayerControls playerControls;
    private PlayerInput playerInput;

    public Vector2 getLastDir()
    {
        return lastDir;
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        InputSystem.onDeviceChange += OnDeviceChange;
        UpdateControlScheme(); // Detectar el dispositivo actual al inicio
    }

    private void OnDisable()
    {
        playerControls.Disable();
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    void Start()
    {
        playerInput.neverAutoSwitchControlSchemes = false;
        rb = GetComponent<Rigidbody2D>();
        dir = lastDir = Vector2.zero;
        animator = GetComponentInChildren<Animator>();
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        UpdateControlScheme();
    }

    private void UpdateControlScheme()
    {
        isGamepad = playerInput.currentControlScheme == "Gamepad";
        Debug.Log($"Cambio de control detectado: {(isGamepad ? "Gamepad" : "Teclado/Ratón")}");
    }

void Update()
    {
        if (canMove)
        {
            //isGamepad = playerInput.currentControlScheme.Equals("Gamepad");
            dir = playerControls.Controles.Movimiento.ReadValue<Vector2>();
            //dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            

            if (Mathf.Abs(dir.x) < 0.25) { dir = new Vector2(0, dir.y); }
            if (Mathf.Abs(dir.y) < 0.25) { dir = new Vector2(dir.x, 0); }
            Debug.Log(dir);

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