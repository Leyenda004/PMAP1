using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed;
    [SerializeField] int bulletDamage = 7;
    // Start is called before the first frame update
    
    public void Init(float bulletSpeed_){
        bulletSpeed = bulletSpeed_;
    }
    
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().Harm(bulletDamage);
            Debug.Log("Enemy Health: " + other.gameObject.GetComponent<Enemy>().getHealth());
        }
        Destroy(gameObject);
    }
}
