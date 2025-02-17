using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private float second = 0f; //para contar el tiempo y quitar 1 vida por segundo
    public int score;
    public int keyAmmount = 0;
    public bool firstKey;
    public bool firstHarm;
    public bool firstTrap;
    public bool canShoot = true;
    private static GameManager instance;
    private UIManager ui;
    public bool IsValkchosen;
    [SerializeField] public GameObject player;
    [SerializeField] AudioClip tutorial;
    [SerializeField] AudioClip key;
    [SerializeField] AudioClip potion;
    [SerializeField] AudioClip food;
    [SerializeField] AudioClip defeat;
    [SerializeField] UIkeyBehaviour UIkeyScript;


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
        score = 0;
        keyAmmount = 0;
        firstKey = true;
        firstHarm = true;
        firstTrap = true;
        canShoot = true;
        ui = uiscript;
        player = jugador;
        GameObject GOSelector = GameObject.FindGameObjectWithTag("CharSelection");
        GameObject InputSelector = GameObject.FindGameObjectWithTag("InputSelector");
        IsValkchosen = GOSelector.name == "valkyrie";
        player.GetComponent<PlayerMovement>().isGamepad = InputSelector.name == "Gamepad";
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

    public void DebugFoodCollected()
    {
        ControladorSonido.Instance.ReproducirSonido(food);
        player.GetComponent<Health>().Heal(7000);

    }

    public void OnEnemyHarmed()
    {
        score += 20;
    }

    public void PotionCollected()
    {
        ControladorSonido.Instance.ReproducirSonido(potion);
        player.GetComponent<Health>().Heal(50);

    }
    public void SetKeyValue(int value) // Activa o desactiva la boleana que indica si el jugador porta una llave
    {

        score += 50;
        keyAmmount += value;
        ui.EvaluateKeys(keyAmmount);
        if (value > 0) ControladorSonido.Instance.ReproducirSonido(key);
    }


    public void CallTutorial(string message) //tutorial
    {
        ControladorSonido.Instance.ReproducirSonido(tutorial);
        ui.ShowTutorial(message);
    }

    public void Death() //llamo al IEnumerator desde aquí porque desde otro script no me deja
    {
        StartCoroutine(PlayerDefeat());
    }
    public IEnumerator PlayerDefeat() //Derrota jugador
    {
        Destroy(player);
        ControladorSonido.Instance.ReproducirSonido(defeat);
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(0);
    }



    private void Update()
    {

    }
}
