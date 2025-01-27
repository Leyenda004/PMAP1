using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity; // Variar desde la interfaz de Unity
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position += Vector3.left * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.position += Vector3.right * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.position += Vector3.up * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.position += Vector3.down * velocity * Time.deltaTime;
        }
    }
}
