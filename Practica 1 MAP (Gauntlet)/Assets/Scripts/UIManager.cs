using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    Text Health;
    [SerializeField]
    Text Score;
    [SerializeField]
    Text Character; 
    // Start is called before the first frame update

    public void Persona (string character)
    {
        Character.text = character;
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = GameManager.Instance.score.ToString();
        
    }
}
