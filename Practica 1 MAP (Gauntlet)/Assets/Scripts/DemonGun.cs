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
    [SerializeField] AudioClip throwvfx;

    public void Shoot(Vector2 dir, Vector2 origin){
        ControladorSonido.Instance.ReproducirSonido(throwvfx);
        newBullet = Instantiate(bullet, origin, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
        newBullet.Init(bulletSpeed);
        Debug.Log("DemonGun Shoot");
    }
}