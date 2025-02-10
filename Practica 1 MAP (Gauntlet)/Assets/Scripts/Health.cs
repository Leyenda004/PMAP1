using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Health : MonoBehaviour
{
    private float second = 0f;
    [SerializeField] private int health; //pierde 7 de vida cuando le pega un enemigo y cuando evita un enemigo que ha aparecido en pantalla, as� que si no se pega con los enemigos tambi�n pierde vid
    GameManager gameManager;
    public int getHealth() { return health; }
    


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        IniHealth();
    }
    void Update()
    {
        second += Time.deltaTime;

        if (second >= 1) //si pasa un segundo, resta uno de vida. Pone >= por si se exceden los decimales al sumar por frame
        {
            Harm(1);
            second = 0f;
        }

        if (health <= 0)
        {
            health = 0;
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
            
        }
    }

    public void Harm(int damage)
    {
        health -= damage;
        //Debug.Log("Da�o producido: " + damage);
        // Debug.Log("Vidas restantes: " +  health);
    }

    public void IniHealth()
    {
        health = 750;
    }

    public void Heal(int healthadded)
    {
        health += healthadded;
        Debug.Log("Vida curada: " + healthadded);
        Debug.Log("Vidas restantes: " + health);
    }

}
