using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    Text Healthb;
    [SerializeField]
    Text Scoreb;
    // Start is called before the first frame update

   

    // Update is called once per frame
    void Update()
    {
        Score.text = GameManager.Instance.score.ToString();
        
    }
}
