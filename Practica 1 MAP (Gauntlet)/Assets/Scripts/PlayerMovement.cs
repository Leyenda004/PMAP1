using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity = 15; // Variar desde la interfaz de Unity
    Rigidbody2D rb;
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 newPos = new Vector3 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        rb.velocity = newPos * velocity;

        // Input.GetAxisRaw("Horizontal") Devuelve -1 cuando se presiona A o LeftArrow y 1 cuando se presiona D o RightArrow
        // Más de lo mismo para Input.GetAxisRaw("Vertical") pero con W y S o UpArrow y DownArrow respectivamente
    }

}
