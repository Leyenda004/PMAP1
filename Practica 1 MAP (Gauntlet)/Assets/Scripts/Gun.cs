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

    [SerializeField] Bullet ValkbulletPrefab;
    [SerializeField] Bullet ElfbulletPrefab;
    Bullet FinalbulletPrefab;
    [SerializeField] float fireRate = 0.15f;
    [SerializeField] float bulletSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;

       
    }
    public void bulletSkin(bool isValkChosen)
    {
        if (isValkChosen) FinalbulletPrefab = ValkbulletPrefab;
        else FinalbulletPrefab = ElfbulletPrefab;
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
            Quaternion angulito = Quaternion.LookRotation(Vector3.forward, lastDir);
            firePoint = (Vector2)parent.transform.position + lastDir/lastDir.magnitude;


            Bullet newBullet = Instantiate(FinalbulletPrefab, firePoint, Quaternion.LookRotation(Vector3.forward, lastDir));
            newBullet.Init(bulletSpeed);
            
            nextFireTime = Time.time + fireRate;
        }
    }
}
