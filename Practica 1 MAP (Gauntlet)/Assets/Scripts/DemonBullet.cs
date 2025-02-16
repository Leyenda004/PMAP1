using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DemonBullet : MonoBehaviour
{
    float bulletSpeed;
    Vector2 moveDirection;
    int bulletDamage = 5;
    // Start is called before the first frame update

    public void Init(Vector2 direction, float bulletSpeed_)
    {
        moveDirection = direction.normalized; // Asegurar normalización
        bulletSpeed = bulletSpeed_;
    }

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = moveDirection * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            other.gameObject.GetComponent<Health>().Harm(bulletDamage);
            Debug.Log("DemonBullet destroyed");
        }
        Destroy(gameObject);
    }
}