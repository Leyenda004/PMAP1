using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Health playerhealth; 
    [SerializeField] Text Healthb;
    [SerializeField] Text Scoreb;
    [SerializeField] Text ELFHealthb;
    [SerializeField] Text ELFScoreb;
    [SerializeField] GameObject VALKinsertCoin;
    [SerializeField] GameObject ELFinsertCoin;

    [SerializeField] private Text Tutorial;
    [SerializeField] private GameObject screenTuto;
    [SerializeField] GameObject[] keysUi;

    PlayerMovement playerscript;
    Gun gunscript;

    // Start is called before the first frame update
    void Start()
    {
        playerhealth = FindObjectOfType<Health>();
        screenTuto.SetActive(false);
        //ESTO ES PARA EVITAR QUE EL JUGDOR PUEDA ALTERAR LOS SPRITES DE ORIENTACION MIENTRAS SE ENSE�A EN TUTO
        playerscript = playerhealth.gameObject.GetComponent<PlayerMovement>();
        gunscript = playerscript.gameObject.GetComponentInChildren<Gun>();
        EvaluateKeys(0);
        GameManager.Instance.StartGame(this, playerscript.gameObject);

        if (!GameManager.Instance.IsValkchosen)
        {
            Healthb = ELFHealthb;
            Scoreb = ELFScoreb;
            VALKinsertCoin.SetActive(true);
            ELFinsertCoin.SetActive(false);
            keysUi[0].gameObject.transform.position += new Vector3(0, -355f, 0);
            keysUi[1].gameObject.transform.position += new Vector3(0, -355f, 0);
        }
        else
        {
            ELFinsertCoin.SetActive(true);
            VALKinsertCoin.SetActive(false);
        }

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
    public void EvaluateKeys(int keyAmmount)
    {
        if (keyAmmount == 0)
        {
            keysUi[0].SetActive(false);
            keysUi[1].SetActive(false);
        }
        else if (keyAmmount == 1)
        {
            keysUi[0].SetActive(true);
            keysUi[1].SetActive(false);
        }
        else if (keyAmmount == 2)
        {
            keysUi[0].SetActive(true);
            keysUi[1].SetActive(true);
        }
    }
}
