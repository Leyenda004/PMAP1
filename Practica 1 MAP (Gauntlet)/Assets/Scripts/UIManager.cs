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

    // Start is called before the first frame update
    void Start()
    {
      playerhealth = FindObjectOfType<Health>();   
    }

    public void ShowTutorial(string message)
    {
        Tutorial.text = message;
    }

    // Update is called once per frame
    void Update()
    {
        Healthb.text = playerhealth.getHealth().ToString();
        Scoreb.text = GameManager.Instance.score.ToString();
    }
}
