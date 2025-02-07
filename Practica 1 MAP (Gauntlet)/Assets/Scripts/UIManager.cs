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

    // Start is called before the first frame update
    void Start()
    {
        playerhealth = FindObjectOfType<Health>();
        score = GameManager.Instance.score;
        screenTuto.SetActive(false);
    }

    public void ShowTutorial(string message)
    {
        screenTuto.SetActive(true);
        Tutorial.text = message;
        Debug.Log("COÑO, FUNCIONA");
    }

    // Update is called once per frame
    void Update()
    {
        Healthb.text = playerhealth.getHealth().ToString();
        Scoreb.text = GameManager.Instance.score.ToString();
    }
}
