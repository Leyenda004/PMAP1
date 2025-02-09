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
            GameManager.Instance.OnEnemyHarmed();

            if (other.gameObject.GetComponent<Enemy>() != null)
                other.gameObject.GetComponent<Enemy>().Harm(bulletDamage);
            if (other.gameObject.GetComponent<Enemygosht>() != null)
                other.gameObject.GetComponent<Enemygosht>().Harm(bulletDamage);
            if (other.gameObject.GetComponent<Enemy2>() != null)
                other.gameObject.GetComponent<Enemy2>().Harm(bulletDamage);
            //Debug.Log("Enemy Health: " + other.gameObject.GetComponent<Enemy>().getHealth());
        }
        if (other.gameObject.GetComponent<spawnerHealth>() != null){
            Debug.Log("Auch");
            other.gameObject.GetComponent<spawnerHealth>().SpawnerHarm();
        }
        GameManager.Instance.canShoot = true;
        Destroy(gameObject);
    }
}
