using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player; 
    [SerializeField] private GameObject exit;   // Referencia al exit
    private float second = 0f; // Para contar el tiempo y quitar 1 vida por segundo

    private bool isLevelComplete = false; // Verificar si el nivel fue completado

    // Start is called before the first frame update
    void Start()
    {
      
    }

    void StartGame()
    {
        second = 0f;
    }

    // Quita 7 de vida si el player colisiona con el enemigo o avanza sin haber matado a un enemigo
    void EnemyDamage()
    {
        player.GetComponent<Health>().Harm(7);
    }

    // Método para cuando el jugador alcance el Exit
    public void Exit()
    {
        if (!isLevelComplete)
        {
            isLevelComplete = true; 
            Debug.Log("Nivel completado"); 
            Invoke("LoadNextLevel", 2f); // Espera 2 segundos antes de cargar el siguiente nivel
        }
    }

    
    void LoadNextLevel()
    {
        Debug.Log("Cargando el siguiente nivel...");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLevelComplete) // Solo quitar vida si el nivel no ha terminado
        {
            second += Time.deltaTime;

            if (second >= 1) // Si pasa un segundo, resta uno de vida
            {
                player.GetComponent<Health>().Harm(1);
                second = 0f;
            }
        }
    }
}