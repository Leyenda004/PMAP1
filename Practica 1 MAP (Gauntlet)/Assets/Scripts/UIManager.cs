using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Health playerhealth; 
    [SerializeField] private Text Healthb;
    [SerializeField] private Text Scoreb;
    [SerializeField] private Text Tutorial;
    [SerializeField] private GameObject keyimage;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
      playerhealth = FindObjectOfType<Health>();
      score = GameManager.Instance.score;
        if (keyimage != null)
        {
            keyimage.SetActive(false); //interfaz desactivada
        }
    }

    public void ShowTutorial(string message)
    {
        Tutorial.text = message;
    }

    public void OnKeyObtained()
    {
        keyimage.SetActive(true); //activa la pantalla de fin del juego

    }

    // Update is called once per frame
    void Update()
    {
        Healthb.text = playerhealth.getHealth().ToString();
        Scoreb.text = GameManager.Instance.score.ToString();
    }
}
