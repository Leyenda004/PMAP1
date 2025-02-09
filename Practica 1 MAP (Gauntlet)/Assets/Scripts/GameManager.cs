using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private float second = 0f; //para contar el tiempo y quitar 1 vida por segundo
    public int score;
    public int havingKey = 0;
    private bool firstEnemy;
    private static GameManager instance;
    private UIManager ui;
    public bool IsValkchosen;
    [SerializeField] public GameObject player;
    [SerializeField] AudioClip tutorial;
    [SerializeField] AudioClip key;
    [SerializeField] AudioClip potion;
    [SerializeField] AudioClip food;


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
        ui = FindObjectOfType<UIManager>();
        score = 0;

    }

    public void StartGame(UIManager uiscript, GameObject jugador)
    {
        ui = uiscript;
        player = jugador;
        firstEnemy = true;
        GameObject GOSelector = GameObject.FindGameObjectWithTag("CharSelection");
        IsValkchosen = GOSelector.name == "valkyrie";
        Debug.Log(IsValkchosen);
        player.GetComponentInChildren<Animator>().SetBool("IsValkChosen", IsValkchosen);
        player.GetComponentInChildren<Gun>().bulletSkin(IsValkchosen);
        //Destroy(GOSelector);

    }
    
    public void CharSelection(string selection)
    {
        if (selection == "valkyrie")
        {
            score = 0;
            player.GetComponent<Health>().IniHealth();
        }
        else
        {
            score = 0;
            player.GetComponent<Health>().IniHealth();
        }
    }

    //Quita 7 de vida si el player colisiona con el enemigo
    public void EnemyDamage() 
    {
        player.GetComponent<Health>().Harm(7);

        if (firstEnemy)
        {
            CallTutorial("Shoot or avoid ghosts player loses 7 health");
            firstEnemy = false;
        }
    }

    public void TreasureCollected()
    {
        score += 50;
        Debug.Log("score +100");
    }

    //suma 100 de vida si player colisiona con la comida
    public void FoodCollected()
    {
        ControladorSonido.Instance.ReproducirSonido(food);
        player.GetComponent<Health>().Heal(100);

    }

    public void PotionCollected()
    {
        ControladorSonido.Instance.ReproducirSonido(potion);
        player.GetComponent<Health>().Heal(50);

    }
    public void SetKeyValue(int value) // Activa o desactiva la boleana que indica si el jugador porta una llave
    {

        score += 50;
        havingKey += value;
        if (value > 0) ControladorSonido.Instance.ReproducirSonido(key);
    }


    public void CallTutorial(string message) //tutorial
    {
        ControladorSonido.Instance.ReproducirSonido(tutorial);
        ui.ShowTutorial(message);
    }

    
    private void Update()
    {

    }
}
