using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DemonBullet : MonoBehaviour
{
    float bulletSpeed;
    int bulletDamage = 100;
    // Start is called before the first frame update
    
    public void Init(float bulletSpeed_){
        bulletSpeed = bulletSpeed_;
    }
    
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            other.gameObject.GetComponent<Health>().Harm(bulletDamage);
            Debug.Log("DemonBullet destroyed");
            Destroy(gameObject);
        }
    }
}