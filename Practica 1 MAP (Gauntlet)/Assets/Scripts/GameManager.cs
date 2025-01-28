using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float second = 0f; //para contar el tiempo y quitar 1 vida por segundo
    
    //aquí iría el singleton

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StartGame()
    {
        second = 0f;
    }

    //Quita 7 de vida si el player colisiona con el enemigo o avanza sin haber matado a un enemigo. Para comprobar esto necesitamos los enemigos
    void EnemyDamage() 
    {
        player.GetComponent<Health>().Harm(7);
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;

        if (second >= 1) //si pasa un segundo, resta uno de vida. Pone >= por si se exceden los decimales al sumar por frame
        {
            player.GetComponent<Health>().Harm(1);
            second = 0f;
        }
    }
}
