using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DemonGun : MonoBehaviour
{
    GameObject parent;
    [SerializeField] DemonBullet bullet;
    DemonBullet newBullet;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] float bulletSpeed = 15f;

    public void Shoot(Vector2 dir, Vector2 origin)
    {
        newBullet = Instantiate(bullet, origin, Quaternion.identity);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        newBullet.Init(dir, bulletSpeed); // Ahora pasamos la dirección correcta

        Debug.Log("DemonGun Shoot");
    }


}