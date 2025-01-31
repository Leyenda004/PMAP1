using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    GameObject parent;
    Vector2 firePoint;
    Vector2 dir;

    [SerializeField] Bullet bulletPrefab;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] float bulletSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(firePoint, firePoint + Vector2.up * 0.1f, Color.red, 0.1f);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    float nextFireTime;
    void Shoot(){
        if (Time.time > nextFireTime)
        {
            Vector2 lastDir = parent.GetComponent<PlayerMovement>().getLastDir();
            firePoint = (Vector2)parent.transform.position + lastDir;


            Bullet newBullet = Instantiate(bulletPrefab, firePoint, Quaternion.LookRotation(Vector3.forward, lastDir));
            newBullet.Init(bulletSpeed);
            
            nextFireTime = Time.time + fireRate;
        }
    }
}
