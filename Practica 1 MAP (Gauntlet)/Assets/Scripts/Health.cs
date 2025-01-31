using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health; //pierde 7 de vida cuando le pega un enemigo y cuando evita un enemigo que ha aparecido en pantalla, as� que si no se pega con los enemigos tambi�n pierde vid

    public int getHealth() { return health; }

    // Start is called before the first frame update
    void Start()
    {
        health = 750;
    }

    public void Harm(int damage)
    {
        health -= damage;
        Debug.Log("Da�o producido: " + damage);
        // Debug.Log("Vidas restantes: " +  health);
    }

    public void Heal(int healthadded)
    {
        health += healthadded;
        Debug.Log("Vida curada: " + healthadded);
        Debug.Log("Vidas restantes: " + health);
    }

}
