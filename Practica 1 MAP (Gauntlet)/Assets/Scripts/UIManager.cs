using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Health playerhealth; 
    [SerializeField] private Text Healthb;
    [SerializeField] private Text Scoreb;
    [SerializeField] private Text Tutorial;
    [SerializeField] private GameObject screenTuto;

    private int score;
    PlayerMovement playerscript;
    Gun gunscript;

    // Start is called before the first frame update
    void Start()
    {
        playerhealth = FindObjectOfType<Health>();
        score = GameManager.Instance.score;
        screenTuto.SetActive(false);
        GameManager.Instance.StartGame(this);

        //ESTO ES PARA EVITAR QUE EL JUGDOR PUEDA ALTERAR LOS SPRITES DE ORIENTACION MIENTRAS SE ENSEÑA EN TUTO
        playerscript = FindAnyObjectByType<PlayerMovement>();
        gunscript = playerscript.gameObject.GetComponentInChildren<Gun>();
    }

    public void ShowTutorial(string message)
    {
        screenTuto.SetActive(true);
        Tutorial.text = message;
        playerscript.enabled = false;
        gunscript.enabled = false;
        Time.timeScale = 0;
        
        StartCoroutine(HideTutorial());
    }

    private IEnumerator HideTutorial()
    {
        yield return new WaitForSecondsRealtime(2f);
        screenTuto.SetActive(false);
        Time.timeScale = 1;
        playerscript.enabled = true;
        gunscript.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Healthb.text = playerhealth.getHealth().ToString();
        Scoreb.text = GameManager.Instance.score.ToString();
    }
}
