using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private Health playerhealth; 
    [SerializeField]
    Text Healthb;
    [SerializeField]
    Text Scoreb;
    // Start is called before the first frame update
    void Start()
    {
      playerhealth = FindObjectOfType<Health>();   
    }


    // Update is called once per frame
    void Update()
    {
        Healthb.text = playerhealth.getHealth().ToString();
        Scoreb.text = GameManager.Instance.score.ToString();
    }
}
