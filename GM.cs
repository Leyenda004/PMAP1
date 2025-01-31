using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float second = 0f; //para contar el tiempo y quitar 1 vida por segundo
    private int score;
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    //singleton
    private void Awake()
    {
        if (Instance != null && Instance != this) //patrón singleton
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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

    public void TreasureCollected()
    {
        score += 100;
        Debug.Log("score +100");
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