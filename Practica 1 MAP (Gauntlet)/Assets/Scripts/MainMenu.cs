using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) CargarNivel("Level 1");
    }

    
    public void CargarNivel(string nombredelnivel)
    {
        SceneManager.LoadScene(nombredelnivel);

    }

}
