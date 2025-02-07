using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float second = 0f; //para contar el tiempo y quitar 1 vida por segundo
    public int score;
    public bool havingKey; 
    private static GameManager instance;
    private UIManager ui;
    [SerializeField] public GameObject player;

    public static GameManager Instance { get { return instance; } }


    //singleton
    private void Awake()
    {
        if (Instance != null && Instance != this) //patr�n singleton
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
    public void StartGame(UIManager ui)
    {
        this.ui = ui;
        second = 0f;
    }
    
    public void CharSelection(string selection)
    {
        if (selection == "valkyrie")
        {

        }
        else
        {

        }
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

    //suma 100 de vida si player colisiona con la comida
    public void FoodCollected()
    {
       
        player.GetComponent<Health>().Heal(100);

    }

    public void PotionCollected()
    {
       
        player.GetComponent<Health>().Heal(50);

    }
    public void SetKeyBool(bool value) // Activa o desactiva la boleana que indica si el jugador porta una llave
    {
        havingKey = value;
    }


    public void CallTutorial(string message) //tutorial
    {
        ui.ShowTutorial(message);
        Debug.Log("WENAAAAAAAS");
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
