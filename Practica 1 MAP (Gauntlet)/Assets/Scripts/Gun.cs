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
    Bullet newBullet;
    [SerializeField] float fireRate = 0.05f;
    [SerializeField] float bulletSpeed = 15f;
    [SerializeField] AudioClip throwvfx;
    bool canShoot = true;
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
        Debug.DrawLine(firePoint, firePoint + Vector2.up * 10f, Color.red, 0.1f);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    float nextFireTime;
    public void Shoot(){
        if (GameManager.Instance.canShoot)
        {
            ControladorSonido.Instance.ReproducirSonido(throwvfx);
            Vector2 lastDir = parent.GetComponent<PlayerMovement>().getLastDir();
            Quaternion angulito = Quaternion.LookRotation(Vector3.forward, lastDir);
            firePoint = (Vector2)parent.transform.position + lastDir/lastDir.magnitude;

            newBullet = Instantiate(FinalbulletPrefab, firePoint, Quaternion.LookRotation(Vector3.forward, lastDir));
            GameManager.Instance.canShoot = false;
            newBullet.Init(bulletSpeed);
        }
        
    }
}
